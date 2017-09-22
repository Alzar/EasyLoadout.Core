

namespace LoadoutPlus.Utils {
	using Rage;
	using Rage.Native;
	using LSPD_First_Response.Mod.API;

	class Core {
		public static void RunPlugin() {
			Game.LogTrivial("Running initial loadout give...");
			GiveLoadout();

			while(true) {
				GameFiber.Yield();

				if(Game.IsKeyDownRightNow(Global.Controls.GiveLoadoutModifier) && Game.IsKeyDown(Global.Controls.GiveLoadout)) {
					Game.LogTrivial("Keybind Pressed... Giving loadout to player");
					GiveLoadout();
				}
			}
		}

		private static void GiveLoadout() {
			Ped playerPed = Game.LocalPlayer.Character;

			Game.LogTrivial("Starting process to give loadout...");

			Game.LogTrivial("Removing all weapons from player");
			Rage.Native.NativeFunction.Natives.REMOVE_ALL_PED_WEAPONS(playerPed, true);

			Game.LogTrivial("Giving weapons to player depending on setting in LoadoutPlus.ini");
			if (Global.Loadout.Pistol) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_PISTOL", 10000, false);
				if(Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_PISTOL", "COMPONENT_AT_PI_FLSH");
				}
			}
			if (Global.Loadout.CombatPistol) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_COMBATPISTOL", 10000, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_COMBATPISTOL", "COMPONENT_AT_PI_FLSH");
				}
			}
			if (Global.Loadout.Pistol50) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_PISTOL50", 10000, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_PISTOL50", "COMPONENT_AT_PI_FLSH");
				}
			}
			if (Global.Loadout.APPistol) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_APPISTOL", 10000, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_APPISTOL", "COMPONENT_AT_PI_FLSH");
				}
			}
			if (Global.Loadout.HeavyPistol) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_HEAVYPISTOL", 10000, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_HEAVYPISTOL", "COMPONENT_AT_PI_FLSH");
				}
			}
			if (Global.Loadout.MicroSMG) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MICROSMG", 10000, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_MICROSMG", "COMPONENT_AT_PI_FLSH");
				}
			}
			if (Global.Loadout.SMG) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SMG", 10000, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SMG", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.AssaultSMG) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_ASSAULTSMG", 10000, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTSMG", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.TommyGun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_GUSENBERG", 10000, false);
			}
			if (Global.Loadout.PumpShotgun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_PUMPSHOTGUN", 10000, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_PUMPSHOTGUN", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.SawedOffShotgun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SAWNOFFSHOTGUN", 10000, false);
			}
			if (Global.Loadout.AssaultShotgun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_ASSAULTSHOTGUN", 10000, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTSHOTGUN", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.BullpupShotgun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_BULLPUPSHOTGUN", 10000, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPSHOTGUN", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.HeavyShotgun) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_HEAVYSHOTGUN", 10000, false);
				if (Global.Loadout.AttachFlashlightToAll) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_HEAVYSHOTGUN", "COMPONENT_AT_AR_FLSH");
				}
			}
			if (Global.Loadout.MG) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MG", 10000, false);
			}
			if (Global.Loadout.CombatMG) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_COMBATMG", 10000, false);
			}
			if (Global.Loadout.AssaultRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_ASSAULTRIFLE", 10000, false);
				if (Global.Loadout.AssaultRifleAttachments) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_ASSAULTRIFLE_CLIP_03");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_AT_AR_FLSH");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_AT_AR_AFGRIP");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ASSAULTRIFLE", "COMPONENT_AT_SCOPE_MACRO");
				}
			}
			if (Global.Loadout.CarbineRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_CARBINERIFLE", 10000, false);
				if (Global.Loadout.CarbineRifleAttachments) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_CARBINERIFLE_CLIP_03");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_AT_AR_FLSH");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_AT_AR_AFGRIP");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_CARBINERIFLE", "COMPONENT_AT_SCOPE_MEDIUM");
				}
			}
			if (Global.Loadout.AdvancedRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_ADVANCEDRIFLE", 10000, false);
				if (Global.Loadout.AdvancedRifleAttachments) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ADVANCEDRIFLE", "COMPONENT_ADVANCEDRIFLE_CLIP_02");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ADVANCEDRIFLE", "COMPONENT_AT_AR_FLSH");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_ADVANCEDRIFLE", "COMPONENT_AT_SCOPE_SMALL");
				}
			}
			if (Global.Loadout.SpecialCarbine) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SPECIALCARBINE", 10000, false);
				if (Global.Loadout.SpecialCarbineAttachments) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_SPECIALCARBINE_CLIP_03");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_AT_AR_FLSH");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_AT_AR_AFGRIP");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_SPECIALCARBINE", "COMPONENT_AT_SCOPE_MEDIUM");
				}
			}
			if (Global.Loadout.BullpupRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_BULLPUPRIFLE", 10000, false);
				if (Global.Loadout.BullpupRifleAttachments) {
					playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_BULLPUPRIFLE_CLIP_02");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_AT_AR_FLSH");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_AT_AR_AFGRIP");
					playerPed.Inventory.AddComponentToWeapon("WEAPON_BULLPUPRIFLE", "COMPONENT_AT_SCOPE_SMALL");
				}
			}
			if (Global.Loadout.SniperRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_SNIPERRIFLE", 10000, false);
			}
			if (Global.Loadout.HeavySniper) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_HEAVYSNIPER", 10000, false);
			}
			if (Global.Loadout.MarksmanRifle) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_MARKSMANRIFLE", 10000, false);
			}
			if (Global.Loadout.Nightstick) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_NIGHTSTICK", 1, false);
			}
			if (Global.Loadout.Taser) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_STUNGUN", 1, false);
			}
			if (Global.Loadout.Flashlight) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_FLASHLIGHT", 1, false);
			}
			if (Global.Loadout.Flare) {
				playerPed.Inventory.GiveNewWeapon("WEAPON_FLARE", 50, false);
			}

			Game.LogTrivial("Loadout successfully given to player!");
		}
	}
}
