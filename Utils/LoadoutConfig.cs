/*
 *	Developed By: Alzar
 *	Name: Loadout+
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */


namespace LoadoutPlus.Utils {
	using System.Windows.Forms;
	using Rage;

	static class LoadoutConfig {
		private static string filePath;

		private static InitializationFile initialiseFile(string filepath) {
			//InitializationFile is a Rage class.
			InitializationFile ini = new InitializationFile(filepath);
			ini.Create();
			return ini;
		}

		public static void SetConfigPath(string path) {
			filePath = path;
		}

		public static string GetConfigPath() {
			return filePath;
		}

		public static void LoadConfig() {
			InitializationFile settings = initialiseFile(filePath);

			//Title
			Global.Loadout.LoadoutTitle = settings.ReadString("Loadout", "LoadoutTitle", "Loadout");

			//Pistols
			Global.Loadout.Pistol = settings.ReadBoolean("Loadout", "Pistol", false);
			Global.Loadout.CombatPistol = settings.ReadBoolean("Loadout", "CombatPistol", true);
			Global.Loadout.Pistol50 = settings.ReadBoolean("Loadout", "Pistol50", false);
			Global.Loadout.APPistol = settings.ReadBoolean("Loadout", "APPistol", false);
			Global.Loadout.HeavyPistol = settings.ReadBoolean("Loadout", "HeavyPistol", false);
			Global.Loadout.SNSPistol = settings.ReadBoolean("Loadout", "SNSPistol", false);
			Global.Loadout.VintagePistol = settings.ReadBoolean("Loadout", "VintagePistol", false);
			Global.Loadout.MarksmanPistol = settings.ReadBoolean("Loadout", "MarksmanPistol", false);
			Global.Loadout.HeavyRevolver = settings.ReadBoolean("Loadout", "HeavyRevolver", false);
			Global.Loadout.PistolMKII = settings.ReadBoolean("Loadout", "PistolMKII", false);

			//Machine Guns
			Global.Loadout.MicroSMG = settings.ReadBoolean("Loadout", "MicroSMG", false);
			Global.Loadout.SMG = settings.ReadBoolean("Loadout", "SMG", false);
			Global.Loadout.AssaultSMG = settings.ReadBoolean("Loadout", "AssaultSMG", false);
			Global.Loadout.TommyGun = settings.ReadBoolean("Loadout", "TommyGun", false);
			Global.Loadout.MG = settings.ReadBoolean("Loadout", "MG", false);
			Global.Loadout.CombatMG = settings.ReadBoolean("Loadout", "CombatMG", false);
			Global.Loadout.CombatPDW = settings.ReadBoolean("Loadout", "CombatPDW", false);
			Global.Loadout.MiniSMG = settings.ReadBoolean("Loadout", "MiniSMG", false);
			Global.Loadout.MachinePistol = settings.ReadBoolean("Loadout", "MachinePistol", false);
			Global.Loadout.SMGMKII = settings.ReadBoolean("Loadout", "SMGMKII", false);
			Global.Loadout.CombatMGMKII = settings.ReadBoolean("Loadout", "CombatMGMKII", false);

			//Shotguns
			Global.Loadout.PumpShotgun = settings.ReadBoolean("Loadout", "PumpShotgun", true);
			Global.Loadout.SawedOffShotgun = settings.ReadBoolean("Loadout", "SawedOffShotgun", false);
			Global.Loadout.AssaultShotgun = settings.ReadBoolean("Loadout", "AssaultShotgun", false);
			Global.Loadout.BullpupShotgun = settings.ReadBoolean("Loadout", "BullpupShotgun", false);
			Global.Loadout.HeavyShotgun = settings.ReadBoolean("Loadout", "HeavyShotgun", false);
			Global.Loadout.Musket = settings.ReadBoolean("Loadout", "Musket", false);
			Global.Loadout.DoubleBarrel = settings.ReadBoolean("Loadout", "DoubleBarrel", false);
			Global.Loadout.AutoShotgun = settings.ReadBoolean("Loadout", "AutoShotgun", false);

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
			Global.Loadout.CompactRifle = settings.ReadBoolean("Loadout", "CompactRifle", false);
			Global.Loadout.CompactRifleAttachments = settings.ReadBoolean("Loadout", "CompactRifleAttachments", false);
			Global.Loadout.AssaultRifleMKII = settings.ReadBoolean("Loadout", "AssaultRifleMKII", false);
			Global.Loadout.AssaultRifleMKIIAttachments = settings.ReadBoolean("Loadout", "AssaultRifleMKIIAttachments", false);
			Global.Loadout.CarbineRifleMKII = settings.ReadBoolean("Loadout", "CarbineRifleMKII", false);
			Global.Loadout.CarbineRifleMKIIAttachments = settings.ReadBoolean("Loadout", "CarbineRifleMKIIAttachments", false);

			//Snipers
			Global.Loadout.SniperRifle = settings.ReadBoolean("Loadout", "SniperRifle", false);
			Global.Loadout.HeavySniper = settings.ReadBoolean("Loadout", "HeavySniper", false);
			Global.Loadout.MarksmanRifle = settings.ReadBoolean("Loadout", "MarksmanRifle", false);
			Global.Loadout.HeavySniperMKII = settings.ReadBoolean("Loadout", "HeavySniperMKII", false);

			//Heavy Weapons
			Global.Loadout.GrenadeLauncher = settings.ReadBoolean("Loadout", "GrenadeLauncher", false);
			Global.Loadout.RPG = settings.ReadBoolean("Loadout", "RPG", false);
			Global.Loadout.Minigun = settings.ReadBoolean("Loadout", "Minigun", false);
			Global.Loadout.FireworkLauncher = settings.ReadBoolean("Loadout", "FireworkLauncher", false);
			Global.Loadout.HomingLauncher = settings.ReadBoolean("Loadout", "HomingLauncher", false);
			Global.Loadout.RailGun = settings.ReadBoolean("Loadout", "RailGun", false);
			Global.Loadout.CompactLauncher = settings.ReadBoolean("Loadout", "CompactLauncher", false);

			//Throwables
			Global.Loadout.Flare = settings.ReadBoolean("Loadout", "Flare", true);
			Global.Loadout.BZGas = settings.ReadBoolean("Loadout", "BZGas", false);
			Global.Loadout.TearGas = settings.ReadBoolean("Loadout", "TearGas", false);
			Global.Loadout.Molotov = settings.ReadBoolean("Loadout", "Molotov", false);
			Global.Loadout.Grenade = settings.ReadBoolean("Loadout", "Grenade", false);
			Global.Loadout.StickyBomb = settings.ReadBoolean("Loadout", "StickyBomb", false);
			Global.Loadout.ProximityMine = settings.ReadBoolean("Loadout", "ProximityMine", false);
			Global.Loadout.PipeBomb = settings.ReadBoolean("Loadout", "PipeBomb", false);
			Global.Loadout.Snowball = settings.ReadBoolean("Loadout", "Snowball", false);
			Global.Loadout.Baseball = settings.ReadBoolean("Loadout", "Baseball", false);

			//Melee Weapons
			Global.Loadout.Nightstick = settings.ReadBoolean("Loadout", "Nightstick", true);
			Global.Loadout.Knife = settings.ReadBoolean("Loadout", "Knife", false);
			Global.Loadout.Hammer = settings.ReadBoolean("Loadout", "Hammer", false);
			Global.Loadout.BaseballBat = settings.ReadBoolean("Loadout", "BaseballBat", false);
			Global.Loadout.Crowbar = settings.ReadBoolean("Loadout", "Crowbar", false);
			Global.Loadout.GolfClub = settings.ReadBoolean("Loadout", "GolfClub", false);
			Global.Loadout.BrokenBottle = settings.ReadBoolean("Loadout", "BrokenBottle", false);
			Global.Loadout.AntiqueDagger = settings.ReadBoolean("Loadout", "AntiqueDagger", false);
			Global.Loadout.Hatchet = settings.ReadBoolean("Loadout", "Hatchet", false);
			Global.Loadout.BrassKnuckles = settings.ReadBoolean("Loadout", "BrassKnuckles", false);
			Global.Loadout.Machete = settings.ReadBoolean("Loadout", "Machete", false);
			Global.Loadout.Switchblade = settings.ReadBoolean("Loadout", "Switchblade", false);
			Global.Loadout.BattleAxe = settings.ReadBoolean("Loadout", "BattleAxe", false);
			Global.Loadout.Wrench = settings.ReadBoolean("Loadout", "Wrench", false);
			Global.Loadout.PoolCue = settings.ReadBoolean("Loadout", "PoolCue", false);

			//Other
			Global.Loadout.Taser = settings.ReadBoolean("Loadout", "Taser", true);
			Global.Loadout.FlareGun = settings.ReadBoolean("Loadout", "FlareGun", false);
			Global.Loadout.Flashlight = settings.ReadBoolean("Loadout", "Flashlight", true);
			Global.Loadout.FireExtinguisher = settings.ReadBoolean("Loadout", "FireExtinguisher", true);
			Global.Loadout.GasCan = settings.ReadBoolean("Loadout", "GasCan", false);

			//Misc
			Global.Loadout.BodyArmor = settings.ReadBoolean("Loadout", "BodyArmor", true);
			Global.Loadout.AttachFlashlightToAll = settings.ReadBoolean("Loadout", "AttachFlashlightToAll", false);
		}
	}
}