using System;
using System.Collections.Generic;
using System.Linq;


namespace LoadoutPlus.Utils {
	using System.Windows.Forms;
	using Rage;

	public class Config {

		public static InitializationFile initialiseFile() {
			//InitializationFile is a Rage class.
			InitializationFile ini = new InitializationFile("Plugins/LSPDFR/LoadoutPlus.ini");
			ini.Create();
			return ini;
		}

		public static void LoadConfig() {
			InitializationFile settings = initialiseFile();
			KeysConverter kc = new KeysConverter();

			string glTemp, glmTemp;

			glTemp = settings.ReadString("Keybinds", "GiveLoadout", "F8");
			glmTemp = settings.ReadString("Keybinds", "GiveLoadoutModifier", "None");

			Global.Controls.GiveLoadout = (Keys)kc.ConvertFromString(glTemp);
			Global.Controls.GiveLoadoutModifier = (Keys)kc.ConvertFromString(glmTemp);

			//Pistols
			Global.Loadout.Pistol = settings.ReadBoolean("Loadout", "Pistol", false);
			Global.Loadout.CombatPistol = settings.ReadBoolean("Loadout", "CombatPistol", false);
			Global.Loadout.Pistol50 = settings.ReadBoolean("Loadout", "Pistol50", false);
			Global.Loadout.APPistol = settings.ReadBoolean("Loadout", "APPistol", false);
			Global.Loadout.HeavyPistol = settings.ReadBoolean("Loadout", "HeavyPistol", false);
			//SMG
			Global.Loadout.MicroSMG = settings.ReadBoolean("Loadout", "MicroSMG", false);
			Global.Loadout.SMG = settings.ReadBoolean("Loadout", "SMG", false);
			Global.Loadout.AssaultSMG = settings.ReadBoolean("Loadout", "AssaultSMG", false);
			Global.Loadout.TommyGun = settings.ReadBoolean("Loadout", "TommyGun", false);
			//Shotguns
			Global.Loadout.PumpShotgun = settings.ReadBoolean("Loadout", "PumpShotgun", false);
			Global.Loadout.SawedOffShotgun = settings.ReadBoolean("Loadout", "SawedOffShotgun", false);
			Global.Loadout.AssaultShotgun = settings.ReadBoolean("Loadout", "AssaultShotgun", false);
			Global.Loadout.BullpupShotgun = settings.ReadBoolean("Loadout", "BullpupShotgun", false);
			Global.Loadout.HeavyShotgun = settings.ReadBoolean("Loadout", "HeavyShotgun", false);
			//LMG
			Global.Loadout.MG = settings.ReadBoolean("Loadout", "MG", false);
			Global.Loadout.CombatMG = settings.ReadBoolean("Loadout", "CombatMG", false);
			//Rifles
			Global.Loadout.AssaultRifle = settings.ReadBoolean("Loadout", "AssaultRifle", false);
			Global.Loadout.AssaultRifleAttachments = settings.ReadBoolean("Loadout", "AssaultRifleAttachments", false);
			Global.Loadout.CarbineRifle = settings.ReadBoolean("Loadout", "CarbineRifle", false);
			Global.Loadout.CarbineRifleAttachments = settings.ReadBoolean("Loadout", "CarbineRifleAttachments", false);
			Global.Loadout.AdvancedRifle = settings.ReadBoolean("Loadout", "AdvancedRifle", false);
			Global.Loadout.AdvancedRifleAttachments = settings.ReadBoolean("Loadout", "AdvancedRifleAttachments", false);
			Global.Loadout.SpecialCarbine = settings.ReadBoolean("Loadout", "SpecialCarbine");
			Global.Loadout.SpecialCarbineAttachments = settings.ReadBoolean("Loadout", "SpecialCarbineAttachements", false);
			Global.Loadout.BullpupRifle = settings.ReadBoolean("Loadout", "BullpupRifle", false);
			Global.Loadout.BullpupRifleAttachments = settings.ReadBoolean("Loadout", "BullpupRifleAttachments", false);
			//Snipers
			Global.Loadout.SniperRifle = settings.ReadBoolean("Loadout", "SniperRifle", false);
			Global.Loadout.HeavySniper = settings.ReadBoolean("Loadout", "HeavySniper", false);
			Global.Loadout.MarksmanRifle = settings.ReadBoolean("Loadout", "MarksmanRifle", false);
			//Other
			Global.Loadout.Nightstick = settings.ReadBoolean("Loadout", "Nightstick", false);
			Global.Loadout.Taser = settings.ReadBoolean("Loadout", "Taser", false);
			Global.Loadout.Flashlight = settings.ReadBoolean("Loadout", "Flashlight", false);
			Global.Loadout.Flare = settings.ReadBoolean("Loadout", "Flare", false);
			Global.Loadout.FireExtinguisher = settings.ReadBoolean("Loadout", "FireExtinguisher", false);
			//Misc
			Global.Loadout.AttachFlashlightToAll = settings.ReadBoolean("Loadout", "AttachFlashlightToAll", false);
		}
	}
}