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
	using LSPD_First_Response.Mod.API;

	internal static class Core {
		public static void RunPlugin() {
			GiveLoadout();
			while(true) {
				GameFiber.Yield();

				if(Game.IsKeyDownRightNow(Global.Controls.GiveLoadoutModifier) && Game.IsKeyDown(Global.Controls.GiveLoadout) || Global.Controls.GiveLoadoutModifier == Keys.None && Game.IsKeyDown(Global.Controls.GiveLoadout)) {
					GiveLoadout();
				}
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
			if(Global.Loadout.PistolMKII) {
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
			if (Global.Loadout.SMGMKII) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SMG_MK2", Global.LoadoutAmmo.MGAmmo, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SMG_MK2", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.CombatMGMKII) {
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
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_ASSAULTRIFLE_CLIP_02");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_AT_AR_FLSH");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_AT_AR_AFGRIP");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_AT_SCOPE_MACRO");
				}
				else if(Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.CarbineRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_CARBINERIFLE", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.CarbineRifleAttachments) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_CARBINERIFLE_CLIP_02");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_AT_AR_FLSH");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_AT_AR_AFGRIP");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_AT_SCOPE_MEDIUM");
				}
				else if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.AdvancedRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_ADVANCEDRIFLE", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.AdvancedRifleAttachments) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ADVANCEDRIFLE", "COMPONENT_ADVANCEDRIFLE_CLIP_02");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ADVANCEDRIFLE", "COMPONENT_AT_AR_FLSH");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ADVANCEDRIFLE", "COMPONENT_AT_SCOPE_SMALL");
				}
				else if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ADVANCEDRIFLE", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.SpecialCarbine) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SPECIALCARBINE", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.SpecialCarbineAttachments) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_SPECIALCARBINE_CLIP_02");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_AT_AR_FLSH");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_AT_AR_AFGRIP");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_AT_SCOPE_MEDIUM");
				}
				else if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.BullpupRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_BULLPUPRIFLE", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.BullpupRifleAttachments) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_BULLPUPRIFLE_CLIP_02");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_AT_AR_FLSH");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_AT_AR_AFGRIP");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_AT_SCOPE_SMALL");
				}
				else if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.CompactRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_COMPACTRIFLE", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.CompactRifleAttachments) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_COMPACTRIFLE", "COMPONENT_COMPACTRIFLE_CLIP_02");
				}
			}
			if (Global.Loadout.AssaultRifleMKII) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_ASSAULTRIFLE_MK2", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.AssaultRifleMKIIAttachments) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_02");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_AT_AR_FLSH");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_AT_AR_AFGRIP_02");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_AT_SCOPE_MEDIUM_MK2");
				}
				else if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.CarbineRifleMKII) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_CARBINERIFLE_MK2", Global.LoadoutAmmo.RifleAmmo, false);
				if (Global.Loadout.CarbineRifleMKIIAttachments) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CLIP_02");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE_MK2", "COMPONENT_AT_AR_FLSH");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE_MK2", "COMPONENT_AT_AR_AFGRIP_02");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE_MK2", "COMPONENT_AT_SCOPE_MEDIUM_MK2");
				}
				else if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE_MK2", "COMPONENT_AT_AR_FLSH");
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
			if (Global.Loadout.HeavySniperMKII) {
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
			Game.DisplayNotification("~p~[Loadout+]: ~s~Loadout Cleared ~g~Successfully~s~!");
		}
	}
}
