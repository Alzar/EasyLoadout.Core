/*
 *	Developed By: Alzar
 *	Name: Loadout+
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */

namespace LoadoutPlus.Utils {
	using System.Windows.Forms;
	using Rage;
	using Rage.Native;
	using RAGENativeUI;
	using RAGENativeUI.Elements;
	using LSPD_First_Response.Mod.API;

	internal static class Core {
		private static string[] loadouts;

		private static MenuPool pMenuPool;
		private static UIMenu pLoadoutMenu;

		private static UIMenuCheckboxItem pLoadout1;
		private static UIMenuCheckboxItem pLoadout2;
		private static UIMenuCheckboxItem pLoadout3;
		private static UIMenuItem pGiveLoadout;

		public static void RunPlugin() {
			loadouts = new string[3];
			//Declaring all loadouts, right now this is statically set to 3. Hopefully will convert this doing being dynamic and be able to have as many as the user would like
			loadouts[0] = "Plugins/LSPDFR/Loadout+/Configs/Loadout1.ini";
			loadouts[1] = "Plugins/LSPDFR/Loadout+/Configs/Loadout2.ini";
			loadouts[2] = "Plugins/LSPDFR/Loadout+/Configs/Loadout3.ini";
		

			//Initial menu setup
			pMenuPool = new MenuPool();
			pLoadoutMenu = new UIMenu("Loadout+", "Choose your active loadout");
			pMenuPool.Add(pLoadoutMenu);


			//Done really badly, but we're setting the items of the menu to have the name that the player sets in the ini file
			LoadoutConfig.SetConfigPath(loadouts[0]);
			LoadoutConfig.LoadConfigTitle();
			pLoadoutMenu.AddItem(pLoadout1 = new UIMenuCheckboxItem(Global.Loadout.LoadoutTitle, true, "Set " + Global.Loadout.LoadoutTitle + " as the active loadout."));

			LoadoutConfig.SetConfigPath(loadouts[1]);
			LoadoutConfig.LoadConfigTitle();
			pLoadoutMenu.AddItem(pLoadout2 = new UIMenuCheckboxItem(Global.Loadout.LoadoutTitle, false, "Set " + Global.Loadout.LoadoutTitle + " as the active loadout."));

			LoadoutConfig.SetConfigPath(loadouts[2]);
			LoadoutConfig.LoadConfigTitle();
			pLoadoutMenu.AddItem(pLoadout3 = new UIMenuCheckboxItem(Global.Loadout.LoadoutTitle, false, "Set " + Global.Loadout.LoadoutTitle + " as the active loadout."));
			pLoadoutMenu.AddItem(pGiveLoadout = new UIMenuItem("Give Loadout"));

			pLoadoutMenu.RefreshIndex();

			pLoadoutMenu.OnItemSelect += OnItemSelect;
			pLoadoutMenu.OnCheckboxChange += OnCheckboxChange;


			//Some very basic logic checking for default loadout that we can use right now
			//Once I add user-defined amounts this will need to be changed
			if (Global.Application.DefaultLoadout > 3) {
				Global.Application.DefaultLoadout = 3;
				Notifier.Notify("~r~[ERROR] ~s~There was an error with your defined default loadout, setting to Loadout 3 as default.");
				Logger.Log("Your default loadout was set higher than 3, this is invalid, setting to default loadout 3");
			}
			else if (Global.Application.DefaultLoadout < 1) {
				Global.Application.DefaultLoadout = 1;
				Notifier.Notify("~r~[ERROR] ~s~There was an error with your defined default loadout, setting to Loadout 1 as default.");
				Logger.Log("Your default loadout was set lower than 1, this is invalid, setting to default loadout 1");
			}

			LoadoutConfig.SetConfigPath(loadouts[Global.Application.DefaultLoadout - 1]);
			LoadoutConfig.LoadConfig();
			UpdateActiveLoadout(Global.Application.DefaultLoadout);


			//Initial loadout giving for when player goes on duty
			GiveLoadout();


			//Game loop
			while (true) {
				GameFiber.Yield();

				//Checking if keybinds for opening menu is pressed. Currently it doesn't check if any other menu is open, so it can overlap with other RageNativeUI menus.
				if (Game.IsKeyDownRightNow(Global.Controls.OpenMenuModifier) && Game.IsKeyDown(Global.Controls.OpenMenu) || Global.Controls.OpenMenuModifier == Keys.None && Game.IsKeyDown(Global.Controls.OpenMenu)) {
					pLoadoutMenu.Visible = !pLoadoutMenu.Visible;
				}

				if (Game.IsKeyDownRightNow(Global.Controls.GiveLoadoutModifier) && Game.IsKeyDown(Global.Controls.GiveLoadout) || Global.Controls.GiveLoadoutModifier == Keys.None && Game.IsKeyDown(Global.Controls.GiveLoadout)) {
					GiveLoadout();
				}

				pMenuPool.ProcessMenus();
			}
		}

		public static void OnCheckboxChange(UIMenu sender, UIMenuCheckboxItem checkbox, bool isChecked) {
			//Ensuring UI that had the update is ours..
			if (sender == pLoadoutMenu) {
				//Then we're checking the checkboxes were updated...
				if (checkbox == pLoadout1) {
					UpdateActiveLoadout(1);
				}
				else if (checkbox == pLoadout2) {
					UpdateActiveLoadout(2);
				}
				else if (checkbox == pLoadout3) {
					UpdateActiveLoadout(3);
				}
				else {
					return;
				}
			}
			else
				return;
		}

		private static void UpdateActiveLoadout(int loadout) {
			//Setting and loading config file
			LoadoutConfig.SetConfigPath(loadouts[(loadout - 1)]);
			LoadoutConfig.LoadConfig();

			//This is all pretty much visual stuff. We're just updating UI menu text and description aswell as ensuring correct boxes are checked/unchecked
			switch (loadout) {
				case 1:
					pLoadout1.Checked = true;
					pLoadout2.Checked = false;
					pLoadout3.Checked = false;
					pLoadout1.Text = Global.Loadout.LoadoutTitle;
					pLoadout1.Description = "Set " + Global.Loadout.LoadoutTitle + " as the active loadout.";
					break;
				case 2:
					pLoadout2.Checked = true;
					pLoadout1.Checked = false;
					pLoadout3.Checked = false;
					pLoadout2.Text = Global.Loadout.LoadoutTitle;
					pLoadout2.Description = "Set " + Global.Loadout.LoadoutTitle + " as the active loadout.";
					break;
				case 3:
					pLoadout3.Checked = true;
					pLoadout1.Checked = false;
					pLoadout2.Checked = false;
					pLoadout3.Text = Global.Loadout.LoadoutTitle;
					pLoadout3.Description = "Set " + Global.Loadout.LoadoutTitle + " as the active loadout.";
					break;
			}

			//Sending notification of active loadout change
			Notifier.Notify(Global.Loadout.LoadoutTitle + " set as active loadout ~g~Successfully~s~!");
		}

		public static void OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index) {
			if (sender == pLoadoutMenu) {
				if(selectedItem == pGiveLoadout) {
					GiveLoadout();
				}
			}
			else {
				return;
			}
		}

		private static void GiveLoadout() {
			Ped playerPed = Game.LocalPlayer.Character;

			Logger.Log("Removing Weapons...");
			Rage.Native.NativeFunction.Natives.REMOVE_ALL_PED_WEAPONS(playerPed, true);

			Logger.Log("Processing Loadout...");

			//Pistols
			if (Global.Loadout.Pistol) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_PISTOL", Global.LoadoutAmmo.PistolAmmo, false);
				if(Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_PISTOL", "COMPONENT_AT_PI_FLSH");
				}
			}
			if (Global.Loadout.CombatPistol) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_COMBATPISTOL", Global.LoadoutAmmo.PistolAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_COMBATPISTOL", "COMPONENT_AT_PI_FLSH");
				}
			}
			if (Global.Loadout.Pistol50) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_PISTOL50", Global.LoadoutAmmo.PistolAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_PISTOL50", "COMPONENT_AT_PI_FLSH");
				}
			}
			if (Global.Loadout.APPistol) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_APPISTOL", Global.LoadoutAmmo.PistolAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_APPISTOL", "COMPONENT_AT_PI_FLSH");
				}
			}
			if (Global.Loadout.HeavyPistol) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_HEAVYPISTOL", Global.LoadoutAmmo.PistolAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_HEAVYPISTOL", "COMPONENT_AT_PI_FLSH");
				}
			}
			if (Global.Loadout.SNSPistol) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SNSPISTOL", Global.LoadoutAmmo.PistolAmmo, false);
			}
			if (Global.Loadout.VintagePistol) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_VINTAGEPISTOL", Global.LoadoutAmmo.PistolAmmo, false);
			}
			if (Global.Loadout.MarksmanPistol) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MARKSMANPISTOL", Global.LoadoutAmmo.PistolAmmo, false);
			}
			if (Global.Loadout.HeavyRevolver) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_REVOLVER", Global.LoadoutAmmo.PistolAmmo, false);
			}
			if(Global.Loadout.PistolMK2) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_PISTOL_MK2", Global.LoadoutAmmo.PistolAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_PISTOL_MK2", "COMPONENT_AT_PI_FLSH_02");
				}
			}

			//Machine Guns
			if (Global.Loadout.MicroSMG) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MICROSMG", Global.LoadoutAmmo.MGAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_MICROSMG", "COMPONENT_AT_PI_FLSH");
				}
			}
			if (Global.Loadout.SMG) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SMG", Global.LoadoutAmmo.MGAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SMG", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.AssaultSMG) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_ASSAULTSMG", Global.LoadoutAmmo.MGAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTSMG", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.TommyGun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_GUSENBERG", Global.LoadoutAmmo.MGAmmo, false);
			}
			if (Global.Loadout.MG) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MG", Global.LoadoutAmmo.MGAmmo, false);
			}
			if (Global.Loadout.CombatMG) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_COMBATMG", Global.LoadoutAmmo.MGAmmo, false);
			}
			if (Global.Loadout.CombatPDW) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_COMBATPDW", Global.LoadoutAmmo.MGAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_COMBATPDW", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.MiniSMG) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MINISMG", Global.LoadoutAmmo.MGAmmo, false);
			}
			if (Global.Loadout.MachinePistol) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MACHINEPISTOL", Global.LoadoutAmmo.MGAmmo, false);
			}
			if (Global.Loadout.SMGMK2) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SMG_MK2", Global.LoadoutAmmo.MGAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SMG_MK2", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.CombatMGMK2) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_COMBATMG_MK2", Global.LoadoutAmmo.MGAmmo, false);
			}

			//Shotguns
			if (Global.Loadout.PumpShotgun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_PUMPSHOTGUN", Global.LoadoutAmmo.ShotgunAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_PUMPSHOTGUN", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.SawedOffShotgun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SAWNOFFSHOTGUN", Global.LoadoutAmmo.ShotgunAmmo, false);
			}
			if (Global.Loadout.AssaultShotgun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_ASSAULTSHOTGUN", Global.LoadoutAmmo.ShotgunAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTSHOTGUN", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.BullpupShotgun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_BULLPUPSHOTGUN", Global.LoadoutAmmo.ShotgunAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPSHOTGUN", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.HeavyShotgun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_HEAVYSHOTGUN", Global.LoadoutAmmo.ShotgunAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_HEAVYSHOTGUN", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.Musket) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MUSKET", Global.LoadoutAmmo.ShotgunAmmo, false);
			}
			if (Global.Loadout.DoubleBarrel) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_DBSHOTGUN", Global.LoadoutAmmo.ShotgunAmmo, false);
			}
			if (Global.Loadout.AutoShotgun) {
				playerPed.Inventory.GiveNewWeapon(317205821, Global.LoadoutAmmo.ShotgunAmmo, false);
			}


			//Rifles
			if (Global.Loadout.AssaultRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_ASSAULTRIFLE", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.AssaultRifleAttachments) {
					if (Global.Loadout.AssaultRifleExtendedMag)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", Global.Loadout.AssaultRifleExtendedMagString);
					if (Global.Loadout.Flashlight)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_AT_AR_FLSH");
					if (Global.Loadout.AssaultRifleGrip)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_AT_AR_AFGRIP");
					if (Global.Loadout.AssaultRifleOptic)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_AT_SCOPE_MACRO");
					if (Global.Loadout.AssaultRifleMuzzle)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_AT_AR_SUPP_02");
				}
			}
			if (Global.Loadout.CarbineRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_CARBINERIFLE", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.CarbineRifleAttachments) {
					if (Global.Loadout.CarbineRifleExtendedMag)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", Global.Loadout.CarbineRifleExtendedMagString);
					if (Global.Loadout.CarbineRifleFlashlight)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_AT_AR_FLSH");
					if (Global.Loadout.CarbineRifleGrip)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_AT_AR_AFGRIP");
					if (Global.Loadout.CarbineRifleOptic)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_AT_SCOPE_MEDIUM");
					if (Global.Loadout.CarbineRifleMuzzle)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_AT_AR_SUPP");
				}
			}
			if (Global.Loadout.AdvancedRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_ADVANCEDRIFLE", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.AdvancedRifleAttachments) {
					if (Global.Loadout.AdvancedRifleExtendedMag)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ADVANCEDRIFLE", Global.Loadout.AdvancedRifleExtendedMagString);
					if (Global.Loadout.AdvancedRifleFlashlight)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ADVANCEDRIFLE", "COMPONENT_AT_AR_FLSH");
					if (Global.Loadout.AdvancedRifleOptic)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ADVANCEDRIFLE", "COMPONENT_AT_SCOPE_SMALL");
					if (Global.Loadout.AdvancedRifleMuzzle)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ADVANCEDRIFLE", "COMPONENT_AT_AR_SUPP");
				}
			}
			if (Global.Loadout.SpecialCarbine) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SPECIALCARBINE", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.SpecialCarbineAttachments) {
					if (Global.Loadout.SpecialCarbineExtendedMag)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", Global.Loadout.SpecialCarbineExtendedMagString);
					if (Global.Loadout.SpecialCarbineFlashlight)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_AT_AR_FLSH");
					if (Global.Loadout.SpecialCarbineGrip)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_AT_AR_AFGRIP");
					if (Global.Loadout.SpecialCarbineOptic)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_AT_SCOPE_MEDIUM");
					if (Global.Loadout.SpecialCarbineMuzzle)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_AT_AR_SUPP_02");
				}
			}
			if (Global.Loadout.BullpupRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_BULLPUPRIFLE", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.BullpupRifleAttachments) {
					if(Global.Loadout.BullpupRifleExtendedMag)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", Global.Loadout.BullpupRifleExtendedMagString);
					if (Global.Loadout.BullpupRifleFlashlight)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_AT_AR_FLSH");
					if (Global.Loadout.BullpupRifleGrip)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_AT_AR_AFGRIP");
					if (Global.Loadout.BullpupRifleOptic)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_AT_SCOPE_SMALL");
					if (Global.Loadout.BullpupRifleMuzzle)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_AT_AR_SUPP");
				}
			}
			if (Global.Loadout.CompactRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_COMPACTRIFLE", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.CompactRifleAttachments) {
					if (Global.Loadout.CompactRifleExtendedMag)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_COMPACTRIFLE", Global.Loadout.CompactRifleExtendedMagString);
				}
			}
			if (Global.Loadout.AssaultRifleMK2) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_ASSAULTRIFLE_MK2", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.AssaultRifleMK2Attachments) {
					if (Global.Loadout.AssaultRifleMK2ExtendedMag)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE_MK2", Global.Loadout.AssaultRifleMK2ExtendedMagString);
					if (Global.Loadout.AssaultRifleMK2Flashlight)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_AT_AR_FLSH");
					if (Global.Loadout.AssaultRifleMK2Grip)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_AT_AR_AFGRIP_02");
					if (Global.Loadout.AssaultRifleMK2Optic)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE_MK2", Global.Loadout.AssaultRifleMK2OpticString);
					if (Global.Loadout.AssaultRifleMK2Muzzle)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE_MK2", Global.Loadout.AssaultRifleMK2MuzzleString);
					if (Global.Loadout.AssaultRifleMK2Barrel)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE_MK2", Global.Loadout.AssaultRifleMK2BarrelString);
				}
			}
			if (Global.Loadout.CarbineRifleMK2) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_CARBINERIFLE_MK2", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.CarbineRifleMK2Attachments) {
					if (Global.Loadout.CarbineRifleMK2ExtendedMag)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE_MK2", Global.Loadout.CarbineRifleMK2ExtendedMagString);
					if (Global.Loadout.CarbineRifleMK2Flashlight)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE_MK2", "COMPONENT_AT_AR_FLSH");
					if (Global.Loadout.CarbineRifleMK2Grip)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE_MK2", "COMPONENT_AT_AR_AFGRIP_02");
					if (Global.Loadout.CarbineRifleMK2Optic)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE_MK2", Global.Loadout.CarbineRifleMK2OpticString);
					if (Global.Loadout.CarbineRifleMK2Muzzle)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE_MK2", Global.Loadout.CarbineRifleMK2MuzzleString);
					if (Global.Loadout.CarbineRifleMK2Barrel)
						playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE_MK2", Global.Loadout.CarbineRifleMK2BarrelString);
				}
			}

			//Snipers
			if (Global.Loadout.SniperRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SNIPERRIFLE", Global.LoadoutAmmo.SniperAmmo, false);
			}
			if (Global.Loadout.HeavySniper) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_HEAVYSNIPER", Global.LoadoutAmmo.SniperAmmo, false);
			}
			if (Global.Loadout.MarksmanRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MARKSMANRIFLE", Global.LoadoutAmmo.SniperAmmo, false);
			}
			if (Global.Loadout.HeavySniperMK2) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_HEAVYSNIPER_MK2", Global.LoadoutAmmo.SniperAmmo, false);
			}

			//Heavy Weapons
			if (Global.Loadout.GrenadeLauncher) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_GRENADELAUNCHER", Global.LoadoutAmmo.HeavyAmmo, false);
			}
			if (Global.Loadout.RPG) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_RPG", Global.LoadoutAmmo.HeavyAmmo, false);
			}
			if (Global.Loadout.Minigun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MINIGUN", 10000, false);
			}
			if (Global.Loadout.FireworkLauncher) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_FIREWORK", Global.LoadoutAmmo.HeavyAmmo, false);
			}
			if (Global.Loadout.HomingLauncher) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_HOMINGLAUNCHER", Global.LoadoutAmmo.HeavyAmmo, false);
			}
			if (Global.Loadout.RailGun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_RAILGUN", Global.LoadoutAmmo.HeavyAmmo, false);
			}
			if (Global.Loadout.CompactLauncher) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_COMPACTLAUNCHER", Global.LoadoutAmmo.HeavyAmmo, false);
			}

			//Throwables
			if (Global.Loadout.Flare) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_FLARE", Global.LoadoutAmmo.ThrowableCount, false);
			}
			if (Global.Loadout.BZGas) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_BZGAS", Global.LoadoutAmmo.ThrowableCount, false);
			}
			if (Global.Loadout.TearGas) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SMOKEGRENADE", Global.LoadoutAmmo.ThrowableCount, false);
			}
			if (Global.Loadout.Molotov) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MOLOTOV", Global.LoadoutAmmo.ThrowableCount, false);
			}
			if (Global.Loadout.Grenade) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_GRENADE", Global.LoadoutAmmo.ThrowableCount, false);
			}
			if (Global.Loadout.StickyBomb) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_STICKYBOMB", Global.LoadoutAmmo.ThrowableCount, false);
			}
			if (Global.Loadout.ProximityMine) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_PROXMINE", Global.LoadoutAmmo.ThrowableCount, false);
			}
			if (Global.Loadout.PipeBomb) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_PIPEBOMB", Global.LoadoutAmmo.ThrowableCount, false);
			}
			if (Global.Loadout.Snowball) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SNOWBALL", Global.LoadoutAmmo.ThrowableCount, false);
			}
			if (Global.Loadout.Baseball) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_BALL", Global.LoadoutAmmo.ThrowableCount, false);
			}

			//Melee Weapons
			if (Global.Loadout.Nightstick) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_NIGHTSTICK", 1, false);
			}
			if (Global.Loadout.Knife) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_KNIFE", 1, false);
			}
			if (Global.Loadout.Hammer) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_HAMMER", 1, false);
			}
			if (Global.Loadout.BaseballBat) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_BAT", 1, false);
			}
			if (Global.Loadout.Crowbar) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_CROWBAR", 1, false);
			}
			if (Global.Loadout.GolfClub) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_GOLFCLUB", 1, false);
			}
			if (Global.Loadout.BrokenBottle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_BOTTLE", 1, false);
			}
			if (Global.Loadout.AntiqueDagger) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_DAGGER", 1, false);
			}
			if (Global.Loadout.Hatchet) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_HATCHET", 1, false);
			}
			if (Global.Loadout.BrassKnuckles) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_KNUCKLE", 1, false);
			}
			if (Global.Loadout.Machete) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MACHETE", 1, false);
			}
			if (Global.Loadout.Switchblade) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SWITCHBLADE", 1, false);
			}
			if (Global.Loadout.BattleAxe) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_BATTLEAXE", 1, false);
			}
			if (Global.Loadout.Wrench) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_WRENCH", 1, false);
			}
			if (Global.Loadout.PoolCue) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_POOLCUE", 1, false);
			}

			//Other
			if (Global.Loadout.Taser) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_STUNGUN", 100, false);
			}
			if (Global.Loadout.FlareGun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_FLAREGUN", Global.LoadoutAmmo.ThrowableCount, false);
			}
			if (Global.Loadout.Flashlight) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_FLASHLIGHT", 1, false);
			}
			if (Global.Loadout.FireExtinguisher) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_FIREEXTINGUISHER", 10000, false);
			}
			if (Global.Loadout.GasCan) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_PETROLCAN", 10000, false);
			}

			//Misc
			if (Global.Loadout.BodyArmor) {
				playerPed.Armor = 100;
			}

			Logger.Log("Loadout Successfully Processed...");
			Notifier.Notify("(Active: ~g~" + Global.Loadout.LoadoutTitle + "~s~) Loadout Cleared ~g~Successfully~s~!");
		}
	}
}
