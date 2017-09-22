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
			Game.LogTrivial("Loading Config...");
			InitializationFile settings = initialiseFile();
			KeysConverter kc = new KeysConverter();

			string glTemp, glmTemp;

			glTemp = settings.ReadString("Keybinds", "GiveLoadout");
			glmTemp = settings.ReadString("Keybinds", "GiveLoadoutModifier");

			Global.Controls.GiveLoadout = (Keys)kc.ConvertFromString(glTemp);
			Global.Controls.GiveLoadoutModifier = (Keys)kc.ConvertFromString(glmTemp);

			//Pistols
			Global.Loadout.Pistol = settings.ReadBoolean("Loadout", "Pistol");
			Global.Loadout.CombatPistol = settings.ReadBoolean("Loadout", "CombatPistol");
			Global.Loadout.Pistol50 = settings.ReadBoolean("Loadout", "Pistol50");
			Global.Loadout.APPistol = settings.ReadBoolean("Loadout", "APPistol");
			Global.Loadout.HeavyPistol = settings.ReadBoolean("Loadout", "HeavyPistol");
			//SMG
			Global.Loadout.MicroSMG = settings.ReadBoolean("Loadout", "MicroSMG");
			Global.Loadout.SMG = settings.ReadBoolean("Loadout", "SMG");
			Global.Loadout.AssaultSMG = settings.ReadBoolean("Loadout", "AssaultSMG");
			Global.Loadout.TommyGun = settings.ReadBoolean("Loadout", "TommyGun");
			//Shotguns
			Global.Loadout.PumpShotgun = settings.ReadBoolean("Loadout", "PumpShotgun");
			Global.Loadout.SawedOffShotgun = settings.ReadBoolean("Loadout", "SawedOffShotgun");
			Global.Loadout.AssaultShotgun = settings.ReadBoolean("Loadout", "AssaultShotgun");
			Global.Loadout.BullpupShotgun = settings.ReadBoolean("Loadout", "BullpupShotgun");
			Global.Loadout.HeavyShotgun = settings.ReadBoolean("Loadout", "HeavyShotgun");
			//LMG
			Global.Loadout.MG = settings.ReadBoolean("Loadout", "MG");
			Global.Loadout.CombatMG = settings.ReadBoolean("Loadout", "CombatMG");
			//Rifles
			Global.Loadout.AssaultRifle = settings.ReadBoolean("Loadout", "AssaultRifle");
			Global.Loadout.AssaultRifleAttachments = settings.ReadBoolean("Loadout", "AssaultRifleAttachments");
			Global.Loadout.CarbineRifle = settings.ReadBoolean("Loadout", "CarbineRifle");
			Global.Loadout.CarbineRifleAttachments = settings.ReadBoolean("Loadout", "CarbineRifleAttachments");
			Global.Loadout.AdvancedRifle = settings.ReadBoolean("Loadout", "AdvancedRifle");
			Global.Loadout.AdvancedRifleAttachments = settings.ReadBoolean("Loadout", "AdvancedRifleAttachments");
			Global.Loadout.SpecialCarbine = settings.ReadBoolean("Loadout", "SpecialCarbine");
			Global.Loadout.SpecialCarbineAttachments = settings.ReadBoolean("Loadout", "SpecialCarbineAttachements");
			Global.Loadout.BullpupRifle = settings.ReadBoolean("Loadout", "BullpupRifle");
			Global.Loadout.BullpupRifleAttachments = settings.ReadBoolean("Loadout", "BullpupRifleAttachments");
			//Snipers
			Global.Loadout.SniperRifle = settings.ReadBoolean("Loadout", "SniperRifle");
			Global.Loadout.HeavySniper = settings.ReadBoolean("Loadout", "HeavySniper");
			Global.Loadout.MarksmanRifle = settings.ReadBoolean("Loadout", "MarksmanRifle");
			//Misc
			Global.Loadout.Nightstick = settings.ReadBoolean("Loadout", "Nightstick");
			Global.Loadout.Taser = settings.ReadBoolean("Loadout", "Taser");
			Global.Loadout.Flashlight = settings.ReadBoolean("Loadout", "Flashlight");
			Global.Loadout.Flare = settings.ReadBoolean("Loadout", "Flare");
			Global.Loadout.AttachFlashlightToAll = settings.ReadBoolean("Loadout", "AttachFlashlightToAll");
			Global.Loadout.SmokeGrenadeLauncher = settings.ReadBoolean("Loadout", "SmokeGrenadeLauncher");

			Game.LogTrivial("... Config successfully loaded!");
		}
	}
}