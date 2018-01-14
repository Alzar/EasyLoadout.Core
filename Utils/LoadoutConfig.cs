/*
 *	Developed By: Alzar
 *	Name: Easy Loadout
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */


namespace EasyLoadout.Utils {
	using System.Windows.Forms;
	using Rage;

	static class LoadoutConfig {
		private static string filePath;
		private static string[] AssaultRifleMagazines = new string[] { "COMPONENT_ASSAULTRIFLE_CLIP_01", "COMPONENT_ASSAULTRIFLE_CLIP_02", "COMPONENT_ASSAULTRIFLE_CLIP_03" };
		private static string[] CarbineRifleMagazines = new string[] { "COMPONENT_CARBINERIFLE_CLIP_01", "COMPONENT_CARBINERIFLE_CLIP_02", "COMPONENT_CARBINERIFLE_CLIP_03" };
		private static string[] AdvancedRifleMagazines = new string[] { "COMPONENT_ADVANCEDRIFLE_CLIP_01", "COMPONENT_ADVANCEDRIFLE_CLIP_02" };
		private static string[] SpecialCarbineMagazines = new string[] { "COMPONENT_SPECIALCARBINE_CLIP_01", "COMPONENT_SPECIALCARBINE_CLIP_02", "COMPONENT_SPECIALCARBINE_CLIP_03" };
		private static string[] BullpupRifleMagazines = new string[] { "COMPONENT_BULLPUPRIFLE_CLIP_01", "COMPONENT_BULLPUPRIFLE_CLIP_02" };
		private static string[] CompactRifleMagazines = new string[] { "COMPONENT_COMPACTRIFLE_CLIP_01", "COMPONENT_COMPACTRIFLE_CLIP_02", "COMPONENT_COMPACTRIFLE_CLIP_03" };

		//MK2 Variants
		private static string[] AssaultRifleMK2Magazines = new string[] { "COMPONENT_ASSAULTRIFLE_MK2_CLIP_01", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_02", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_ARMORPIERCING", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_FMJ", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_INCENDIARY", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_TRACER" };
		private static string[] AssaultRifleMK2Optics = new string[] { "COMPONENT_AT_SIGHTS", "COMPONENT_AT_SCOPE_MACRO_MK2", "COMPONENT_AT_SCOPE_MEDIUM_MK2" };
		private static string[] AssaultRifleMK2Muzzles = new string[] { "COMPONENT_AT_AR_SUPP_02", "COMPONENT_AT_MUZZLE_01", "COMPONENT_AT_MUZZLE_02", "COMPONENT_AT_MUZZLE_03", "COMPONENT_AT_MUZZLE_04", "COMPONENT_AT_MUZZLE_05", "COMPONENT_AT_MUZZLE_06", "COMPONENT_AT_MUZZLE_07" };
		private static string[] AssaultRifleMK2Barrels = new string[] { "COMPONENT_AT_AR_BARREL_01", "COMPONENT_AT_AR_BARREL_02" };

		private static string[] CarbineRifleMK2Magazines = new string[] { "COMPONENT_CARBINERIFLE_MK2_CLIP_01", "COMPONENT_CARBINERIFLE_MK2_CLIP_02", "COMPONENT_CARBINERIFLE_MK2_CLIP_ARMORPIERCING", "COMPONENT_CARBINERIFLE_MK2_CLIP_FMJ", "COMPONENT_CARBINERIFLE_MK2_CLIP_INCENDIARY", "COMPONENT_CARBINERIFLE_MK2_CLIP_TRACER" };
		private static string[] CarbineRifleMK2Optics = new string[] { "COMPONENT_AT_SIGHTS", "COMPONENT_AT_SCOPE_MACRO_MK2", "COMPONENT_AT_SCOPE_MEDIUM_MK2" };
		private static string[] CarbineRifleMK2Muzzles = new string[] { "COMPONENT_AT_AR_SUPP", "COMPONENT_AT_MUZZLE_01", "COMPONENT_AT_MUZZLE_02", "COMPONENT_AT_MUZZLE_03", "COMPONENT_AT_MUZZLE_04", "COMPONENT_AT_MUZZLE_05", "COMPONENT_AT_MUZZLE_06", "COMPONENT_AT_MUZZLE_07" };
		private static string[] CarbineRifleMK2Barrels = new string[] { "COMPONENT_AT_CR_BARREL_01", "COMPONENT_AT_CR_BARREL_02" };

		private static string[] SpecialCarbineMK2Magazines = new string[] { "COMPONENT_SPECIALCARBINE_MK2_CLIP_01", "COMPONENT_SPECIALCARBINE_MK2_CLIP_02", "COMPONENT_SPECIALCARBINE_MK2_CLIP_TRACER", "COMPONENT_SPECIALCARBINE_MK2_CLIP_INCENDIARY", "COMPONENT_SPECIALCARBINE_MK2_CLIP_ARMORPIERCING", "COMPONENT_SPECIALCARBINE_MK2_CLIP_FMJ" };
		private static string[] SpecialCarbineMK2Optics = new string[] { "COMPONENT_AT_SIGHTS", "COMPONENT_AT_SCOPE_MACRO_MK2", "COMPONENT_AT_SCOPE_MEDIUM_MK2" };
		private static string[] SpecialCarbineMK2Muzzles = new string[] { "COMPONENT_AT_AR_SUPP_02", "COMPONENT_AT_MUZZLE_01", "COMPONENT_AT_MUZZLE_02", "COMPONENT_AT_MUZZLE_03", "COMPONENT_AT_MUZZLE_04", "COMPONENT_AT_MUZZLE_05", "COMPONENT_AT_MUZZLE_06", "COMPONENT_AT_MUZZLE_07" };
		private static string[] SpecialCarbineMK2Barrels = new string[] { "COMPONENT_AT_SC_BARREL_01", "COMPONENT_AT_SC_BARREL_02" };

		private static string[] BullpupRifleMK2Magazines = new string[] { "COMPONENT_BULLPUPRIFLE_MK2_CLIP_01", "COMPONENT_BULLPUPRIFLE_MK2_CLIP_02", "COMPONENT_BULLPUPRIFLE_MK2_CLIP_TRACER", "COMPONENT_BULLPUPRIFLE_MK2_CLIP_INCENDIARY", "COMPONENT_BULLPUPRIFLE_MK2_CLIP_ARMORPIERCING", "COMPONENT_BULLPUPRIFLE_MK2_CLIP_FMJ" };
		private static string[] BullpupRifleMK2Optics = new string[] { "COMPONENT_AT_SIGHTS", "COMPONENT_AT_SCOPE_MACRO_02_MK2", "COMPONENT_AT_SCOPE_SMALL_MK2" };
		private static string[] BullpupRifleMK2Muzzles = new string[] { "COMPONENT_AT_AR_SUPP", "COMPONENT_AT_MUZZLE_01", "COMPONENT_AT_MUZZLE_02", "COMPONENT_AT_MUZZLE_03", "COMPONENT_AT_MUZZLE_04", "COMPONENT_AT_MUZZLE_05", "COMPONENT_AT_MUZZLE_06", "COMPONENT_AT_MUZZLE_07" };
		private static string[] BullpupRifleMK2Barrels = new string[] { "COMPONENT_AT_BP_BARREL_01", "COMPONENT_AT_BP_BARREL_02" };

		private static string[] PumpShotgunMK2Magazines = new string[] { "COMPONENT_PUMPSHOTGUN_MK2_CLIP_01", "COMPONENT_PUMPSHOTGUN_MK2_CLIP_TRACER", "COMPONENT_PUMPSHOTGUN_MK2_CLIP_INCENDIARY", "COMPONENT_PUMPSHOTGUN_MK2_CLIP_HOLLOWPOINT", "COMPONENT_PUMPSHOTGUN_MK2_CLIP_FMJ" };
		private static string[] PumpShotgunMK2Optics = new string[] { "COMPONENT_AT_SIGHTS", "COMPONENT_AT_SCOPE_MACRO_MK2", "COMPONENT_AT_SCOPE_SMALL_MK2" };
		private static string[] PumpShotgunMK2Muzzles = new string[] { "COMPONENT_AT_SR_SUPP_03", "COMPONENT_AT_MUZZLE_08" };

		/* COMMENTING THESE LINES OUT AS THESE WEAPONS ARE NOT SUPPORTED AT THIS TIME
		private static string[] HeavyRevolverMK2Magazines = new string[] { "COMPONENT_REVOLVER_MK2_CLIP_01", "COMPONENT_REVOLVER_MK2_CLIP_FMJ", "COMPONENT_REVOLVER_MK2_CLIP_HOLLOWPOINT", "COMPONENT_REVOLVER_MK2_CLIP_INCENDIARY", "COMPONENT_REVOLVER_MK2_CLIP_TRACER" };
		private static string[] HeavyRevolverMK2Optics = new string[] { "COMPONENT_AT_SIGHTS", "COMPONENT_AT_SCOPE_MACRO_MK2" };

		private static string[] SNSPistolMK2Magazines = new string[] { "COMPONENT_SNSPISTOL_MK2_CLIP_01", "COMPONENT_SNSPISTOL_MK2_CLIP_02", "COMPONENT_SNSPISTOL_MK2_CLIP_TRACER", "COMPONENT_SNSPISTOL_MK2_CLIP_INCENDIARY", "COMPONENT_SNSPISTOL_MK2_CLIP_HOLLOWPOINT", "COMPONENT_SNSPISTOL_MK2_CLIP_FMJ" };
		private static string[] SNSPistolMK2Muzzles = new string[] { "COMPONENT_AT_PI_SUPP_02", "COMPONENT_AT_PI_COMP_02" };

		private static string[] MarksmanRifleMK2Magazines = new string[] { "COMPONENT_MARKSMANRIFLE_MK2_CLIP_01", "COMPONENT_MARKSMANRIFLE_MK2_CLIP_02", "COMPONENT_MARKSMANRIFLE_MK2_CLIP_TRACER", "COMPONENT_MARKSMANRIFLE_MK2_CLIP_INCENDIARY", "COMPONENT_MARKSMANRIFLE_MK2_CLIP_ARMORPIERCING", "COMPONENT_MARKSMANRIFLE_MK2_CLIP_FMJ" };
		private static string[] MarksmanRifleMK2Optics = new string[] { "COMPONENT_AT_SIGHTS", "COMPONENT_AT_SCOPE_MEDIUM_MK2", "COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM_MK2" };
		private static string[] MarksmanRifleMK2Muzzles = new string[] { "COMPONENT_AT_AR_SUPP", "COMPONENT_AT_MUZZLE_01", "COMPONENT_AT_MUZZLE_02", "COMPONENT_AT_MUZZLE_03", "COMPONENT_AT_MUZZLE_04", "COMPONENT_AT_MUZZLE_05", "COMPONENT_AT_MUZZLE_06", "COMPONENT_AT_MUZZLE_07" };
		private static string[] MarksmanRifleMK2Barrels = new string[] { "COMPONENT_AT_MRFL_BARREL_01", "COMPONENT_AT_MRFL_BARREL_02" };
		*/


		private static InitializationFile initialiseFile(string filepath) {
			//InitializationFile is a Rage class.
			InitializationFile ini = new InitializationFile(filepath);
			ini.Create();
			return ini;
		}

		public static void SetConfigPath(string path) {
			filePath = path + ".ini";
		}

		public static string GetConfigPath() {
			return filePath;
		}

		//Pretty useless function that we're calling at initialization so we can load config titles for UI reasons
		public static void LoadConfigTitle() {
			InitializationFile settings = initialiseFile(filePath);
			//Title
			Global.Loadout.LoadoutTitle = settings.ReadString("Loadout", "LoadoutTitle", "Loadout");
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
			Global.Loadout.PistolMK2 = settings.ReadBoolean("Loadout", "PistolMK2", false);
			Global.Loadout.SNSPistolMK2 = settings.ReadBoolean("Loadout", "SNSPistolMK2", false);
			Global.Loadout.HeavyRevolverMK2 = settings.ReadBoolean("Loadout", "HeavyRevolverMK2", false);
			Global.Loadout.DoubleActionRevolver = settings.ReadBoolean("Loadout", "DoubleActionRevolver", false);

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
			Global.Loadout.SMGMK2 = settings.ReadBoolean("Loadout", "SMGMK2", false);
			Global.Loadout.CombatMGMK2 = settings.ReadBoolean("Loadout", "CombatMGMK2", false);

			//Shotguns
			Global.Loadout.PumpShotgun = settings.ReadBoolean("Loadout", "PumpShotgun", true);
			Global.Loadout.SawedOffShotgun = settings.ReadBoolean("Loadout", "SawedOffShotgun", false);
			Global.Loadout.AssaultShotgun = settings.ReadBoolean("Loadout", "AssaultShotgun", false);
			Global.Loadout.BullpupShotgun = settings.ReadBoolean("Loadout", "BullpupShotgun", false);
			Global.Loadout.HeavyShotgun = settings.ReadBoolean("Loadout", "HeavyShotgun", false);
			Global.Loadout.Musket = settings.ReadBoolean("Loadout", "Musket", false);
			Global.Loadout.DoubleBarrel = settings.ReadBoolean("Loadout", "DoubleBarrel", false);
			Global.Loadout.AutoShotgun = settings.ReadBoolean("Loadout", "AutoShotgun", false);
			Global.Loadout.PumpShotgunMK2 = settings.ReadBoolean("Loadout", "PumpShotgunMK2", false);

			//Rifles
			Global.Loadout.AssaultRifle = settings.ReadBoolean("Loadout", "AssaultRifle", false);
			Global.Loadout.CarbineRifle = settings.ReadBoolean("Loadout", "CarbineRifle", false);
			Global.Loadout.AdvancedRifle = settings.ReadBoolean("Loadout", "AdvancedRifle", false);
			Global.Loadout.SpecialCarbine = settings.ReadBoolean("Loadout", "SpecialCarbine");
			Global.Loadout.BullpupRifle = settings.ReadBoolean("Loadout", "BullpupRifle", false);
			Global.Loadout.CompactRifle = settings.ReadBoolean("Loadout", "CompactRifle", false);
			Global.Loadout.AssaultRifleMK2 = settings.ReadBoolean("Loadout", "AssaultRifleMK2", false);
			Global.Loadout.CarbineRifleMK2 = settings.ReadBoolean("Loadout", "CarbineRifleMK2", false);
			Global.Loadout.SpecialCarbineMK2 = settings.ReadBoolean("Loadout", "SpecialCarbineMK2", false);
			Global.Loadout.CarbineRifleMK2 = settings.ReadBoolean("Loadout", "CarbineRifleMK2", false);

			//Snipers
			Global.Loadout.SniperRifle = settings.ReadBoolean("Loadout", "SniperRifle", false);
			Global.Loadout.HeavySniper = settings.ReadBoolean("Loadout", "HeavySniper", false);
			Global.Loadout.MarksmanRifle = settings.ReadBoolean("Loadout", "MarksmanRifle", false);
			Global.Loadout.HeavySniperMK2 = settings.ReadBoolean("Loadout", "HeavySniperMK2", false);

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

			//Attachments
			Global.Loadout.AssaultRifleAttachments = settings.ReadBoolean("WeaponAttachments", "AssaultRifleAttachments", false);
			Global.Loadout.CarbineRifleAttachments = settings.ReadBoolean("WeaponAttachments", "CarbineRifleAttachments", false);
			Global.Loadout.AdvancedRifleAttachments = settings.ReadBoolean("WeaponAttachments", "AdvancedRifleAttachments", false);
			Global.Loadout.SpecialCarbineAttachments = settings.ReadBoolean("WeaponAttachments", "SpecialCarbineAttachements", false);
			Global.Loadout.BullpupRifleAttachments = settings.ReadBoolean("WeaponAttachments", "BullpupRifleAttachments", false);
			Global.Loadout.CompactRifleAttachments = settings.ReadBoolean("WeaponAttachments", "CompactRifleAttachments", false);
			Global.Loadout.AssaultRifleMK2Attachments = settings.ReadBoolean("WeaponAttachments", "AssaultRifleMK2Attachments", false);
			Global.Loadout.CarbineRifleMK2Attachments = settings.ReadBoolean("WeaponAttachments", "CarbineRifleMK2Attachments", false);
			Global.Loadout.SpecialCarbineMK2Attachments = settings.ReadBoolean("WeaponAttachments", "SpecialCarbineMK2Attachments", false);
			Global.Loadout.BullpupRifleMK2Attachments = settings.ReadBoolean("WeaponAttachments", "BullpupRifleMK2Attachments", false);
			Global.Loadout.PumpShotgunMK2Attachments = settings.ReadBoolean("WeaponAttachments", "PumpShotgunMK2Attachments", false);



			///All config stuff for attachments and component strings are loaded here aswell as sent to be validated as to if they're valid or not
			if (Global.Loadout.AssaultRifle) {
				if (Global.Loadout.AssaultRifleAttachments) {
					Global.Loadout.AssaultRifleMagazine = settings.ReadBoolean("AssaultRifleAttachments", "Magazine", false);
					Global.Loadout.AssaultRifleGrip = settings.ReadBoolean("AssaultRifleAttachments", "Grip", true);
					Global.Loadout.AssaultRifleOptic = settings.ReadBoolean("AssaultRifleAttachments", "Optic", true);
					Global.Loadout.AssaultRifleFlashlight = settings.ReadBoolean("AssaultRifleAttachments", "Flashlight", true);
					Global.Loadout.AssaultRifleMuzzle = settings.ReadBoolean("AssaultRifleAttachments", "Suppressor", false);
					Global.Loadout.AssaultRifleMagazineString = settings.ReadString("AssaultRifleComponentStrings", "Magazine", "COMPONENT_ASSAULTRIFLE_CLIP_02");
					ValidateComponentStrings(1);
				}
			}

			if (Global.Loadout.CarbineRifle) {
				if (Global.Loadout.CarbineRifleAttachments) {
					Global.Loadout.CarbineRifleMagazine = settings.ReadBoolean("CarbineRifleAttachments", "Magazine", false);
					Global.Loadout.CarbineRifleGrip = settings.ReadBoolean("CarbineRifleAttachments", "Grip", true);
					Global.Loadout.CarbineRifleOptic = settings.ReadBoolean("CarbineRifleAttachments", "Optic", true);
					Global.Loadout.CarbineRifleFlashlight = settings.ReadBoolean("CarbineRifleAttachments", "Flashlight", true);
					Global.Loadout.CarbineRifleMuzzle = settings.ReadBoolean("CarbineRifleAttachments", "Suppressor", false);
					Global.Loadout.CarbineRifleMagazineString = settings.ReadString("CarbineRifleComponentStrings", "Magazine", "COMPONENT_CARBINERIFLE_CLIP_02");
					ValidateComponentStrings(2);
				}
			}

			if (Global.Loadout.AdvancedRifle) {
				if (Global.Loadout.AdvancedRifleAttachments) {
					Global.Loadout.AdvancedRifleMagazine = settings.ReadBoolean("AdvancedRifleAttachments", "Magazine", false);
					Global.Loadout.AdvancedRifleOptic = settings.ReadBoolean("AdvancedRifleAttachments", "Optic", true);
					Global.Loadout.AdvancedRifleFlashlight = settings.ReadBoolean("AdvancedRifleAttachments", "Flashlight", true);
					Global.Loadout.AdvancedRifleMuzzle = settings.ReadBoolean("AdvancedRifleAttachments", "Suppressor", false);
					Global.Loadout.AdvancedRifleMagazineString = settings.ReadString("AdvancedRifleComponentStrings", "Magazine", "COMPONENT_ADVANCEDRIFLE_CLIP_02");
					ValidateComponentStrings(3);
				}
			}

			if (Global.Loadout.SpecialCarbine) {
				if (Global.Loadout.SpecialCarbineAttachments) {
					Global.Loadout.SpecialCarbineMagazine = settings.ReadBoolean("SpecialCarbineAttachments", "Magazine", false);
					Global.Loadout.SpecialCarbineGrip = settings.ReadBoolean("SpecialCarbineAttachments", "Grip", true);
					Global.Loadout.SpecialCarbineOptic = settings.ReadBoolean("SpecialCarbineAttachments", "Optic", true);
					Global.Loadout.SpecialCarbineFlashlight = settings.ReadBoolean("SpecialCarbineAttachments", "Flashlight", true);
					Global.Loadout.SpecialCarbineMuzzle = settings.ReadBoolean("SpecialCarbineAttachments", "Suppressor", false);
					Global.Loadout.SpecialCarbineMagazineString = settings.ReadString("SpecialCarbineComponentStrings", "Magazine", "COMPONENT_SPECIALCARBINE_CLIP_02");
					ValidateComponentStrings(4);
				}
			}

			if (Global.Loadout.BullpupRifle) {
				if (Global.Loadout.BullpupRifleAttachments) {
					Global.Loadout.BullpupRifleMagazine = settings.ReadBoolean("BullpupRifleAttachments", "Magazine", false);
					Global.Loadout.BullpupRifleGrip = settings.ReadBoolean("BullpupRifleAttachments", "Grip", true);
					Global.Loadout.BullpupRifleOptic = settings.ReadBoolean("BullpupRifleAttachments", "Optic", true);
					Global.Loadout.BullpupRifleFlashlight = settings.ReadBoolean("BullpupRifleAttachments", "Flashlight", true);
					Global.Loadout.BullpupRifleMuzzle = settings.ReadBoolean("BullpupRifleAttachments", "Suppressor", false);
					Global.Loadout.BullpupRifleMagazineString = settings.ReadString("BullpupRifleComponentStrings", "Magazine", "COMPONENT_BULLPUPRIFLE_CLIP_02");
					ValidateComponentStrings(5);
				}
			}

			if (Global.Loadout.CompactRifle) {
				if (Global.Loadout.CompactRifleAttachments) {
					Global.Loadout.CompactRifleMagazine = settings.ReadBoolean("CompactRifleAttachments", "Magazine", false);
					Global.Loadout.CompactRifleMagazineString = settings.ReadString("CompactRifleComponentStrings", "Magazine", "COMPONENT_COMPACTRIFLE_CLIP_02");
					ValidateComponentStrings(6);
				}
			}

			if (Global.Loadout.AssaultRifleMK2) {
				if (Global.Loadout.AssaultRifleMK2Attachments) {
					Global.Loadout.AssaultRifleMK2Magazine = settings.ReadBoolean("AssaultRifleMK2Attachments", "Magazine", false);
					Global.Loadout.AssaultRifleMK2Grip = settings.ReadBoolean("AssaultRifleMK2Attachments", "Grip", true);
					Global.Loadout.AssaultRifleMK2Optic = settings.ReadBoolean("AssaultRifleMK2Attachments", "Optic", true);
					Global.Loadout.AssaultRifleMK2Flashlight = settings.ReadBoolean("AssaultRifleMK2Attachments", "Flashlight", true);
					Global.Loadout.AssaultRifleMK2Muzzle = settings.ReadBoolean("AssaultRifleMK2Attachments", "Muzzle", false);
					Global.Loadout.AssaultRifleMK2Barrel = settings.ReadBoolean("AssaultRifleMK2Attachments", "Barrel", false);
					Global.Loadout.AssaultRifleMK2MagazineString = settings.ReadString("AssaultRifleMK2ComponentStrings", "Magazine", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_02");
					Global.Loadout.AssaultRifleMK2OpticString = settings.ReadString("AssaultRifleMK2ComponentStrings", "Optic", "COMPONENT_AT_SCOPE_MACRO_MK2");
					Global.Loadout.AssaultRifleMK2MuzzleString = settings.ReadString("AssaultRifleMK2ComponentStrings", "Muzzle", "COMPONENT_AT_MUZZLE_01");
					Global.Loadout.AssaultRifleMK2BarrelString = settings.ReadString("AssaultRifleMK2ComponentStrings", "Barrel", "COMPONENT_AT_AR_BARREL_01");
					ValidateComponentStrings(7);
				}
			}

			if (Global.Loadout.CarbineRifleMK2) {
				if (Global.Loadout.CarbineRifleMK2Attachments) {
					Global.Loadout.CarbineRifleMK2Magazine = settings.ReadBoolean("CarbineRifleMK2Attachments", "Magazine", false);
					Global.Loadout.CarbineRifleMK2Grip = settings.ReadBoolean("CarbineRifleMK2Attachments", "Grip", true);
					Global.Loadout.CarbineRifleMK2Optic = settings.ReadBoolean("CarbineRifleMK2Attachments", "Optic", true);
					Global.Loadout.CarbineRifleMK2Flashlight = settings.ReadBoolean("CarbineRifleMK2Attachments", "Flashlight", true);
					Global.Loadout.CarbineRifleMK2Muzzle = settings.ReadBoolean("CarbineRifleMK2Attachments", "Muzzle", false);
					Global.Loadout.CarbineRifleMK2Barrel = settings.ReadBoolean("CarbineRifleMK2Attachments", "Barrel", false);
					Global.Loadout.CarbineRifleMK2MagazineString = settings.ReadString("CarbineRifleMK2ComponentStrings", "Magazine", "COMPONENT_CARBINERIFLE_MK2_CLIP_02");
					Global.Loadout.CarbineRifleMK2OpticString = settings.ReadString("CarbineRifleMK2ComponentStrings", "Optic", "COMPONENT_AT_SCOPE_MACRO_MK2");
					Global.Loadout.CarbineRifleMK2MuzzleString = settings.ReadString("CarbineRifleMK2ComponentStrings", "Muzzle", "COMPONENT_AT_MUZZLE_01");
					Global.Loadout.CarbineRifleMK2BarrelString = settings.ReadString("CarbineRifleMK2ComponentStrings", "Barrel", "COMPONENT_AT_CR_BARREL_01");
					ValidateComponentStrings(8);
				}
			}

			if (Global.Loadout.SpecialCarbineMK2) {
				if (Global.Loadout.SpecialCarbineMK2Attachments) {
					Global.Loadout.SpecialCarbineMK2Magazine = settings.ReadBoolean("SpecialCarbineMK2Attachments", "Magazine", false);
					Global.Loadout.SpecialCarbineMK2Grip = settings.ReadBoolean("SpecialCarbineMK2Attachments", "Grip", true);
					Global.Loadout.SpecialCarbineMK2Optic = settings.ReadBoolean("SpecialCarbineMK2Attachments", "Optic", true);
					Global.Loadout.SpecialCarbineMK2Flashlight = settings.ReadBoolean("SpecialCarbineMK2Attachments", "Flashlight", true);
					Global.Loadout.SpecialCarbineMK2Muzzle = settings.ReadBoolean("SpecialCarbineMK2Attachments", "Muzzle", false);
					Global.Loadout.SpecialCarbineMK2Barrel = settings.ReadBoolean("SpecialCarbineMK2Attachments", "Barrel", false);
					Global.Loadout.SpecialCarbineMK2MagazineString = settings.ReadString("SpecialCarbineMK2ComponentStrings", "Magazine", "COMPONENT_SPECIALCARBINE_MK2_CLIP_02");
					Global.Loadout.SpecialCarbineMK2OpticString = settings.ReadString("SpecialCarbineMK2ComponentStrings", "Optic", "COMPONENT_AT_SCOPE_MACRO_MK2");
					Global.Loadout.SpecialCarbineMK2MuzzleString = settings.ReadString("SpecialCarbineMK2ComponentStrings", "Muzzle", "COMPONENT_AT_MUZZLE_01");
					Global.Loadout.SpecialCarbineMK2BarrelString = settings.ReadString("SpecialCarbineMK2ComponentStrings", "Barrel", "COMPONENT_AT_SC_BARREL_01");
					ValidateComponentStrings(9);
				}
			}

			if (Global.Loadout.BullpupRifleMK2) {
				if (Global.Loadout.BullpupRifleMK2Attachments) {
					Global.Loadout.BullpupRifleMK2Magazine = settings.ReadBoolean("BullpupRifleMK2Attachments", "Magazine", false);
					Global.Loadout.BullpupRifleMK2Grip = settings.ReadBoolean("BullpupRifleMK2Attachments", "Grip", true);
					Global.Loadout.BullpupRifleMK2Optic = settings.ReadBoolean("BullpupRifleMK2Attachments", "Optic", true);
					Global.Loadout.BullpupRifleMK2Flashlight = settings.ReadBoolean("BullpupRifleMK2Attachments", "Flashlight", true);
					Global.Loadout.BullpupRifleMK2Muzzle = settings.ReadBoolean("BullpupRifleMK2Attachments", "Muzzle", false);
					Global.Loadout.BullpupRifleMK2Barrel = settings.ReadBoolean("BullpupRifleMK2Attachments", "Barrel", false);
					Global.Loadout.BullpupRifleMK2MagazineString = settings.ReadString("BullpupRifleMK2ComponentStrings", "Magazine", "COMPONENT_BULLPUPRIFLE_MK2_CLIP_02");
					Global.Loadout.BullpupRifleMK2OpticString = settings.ReadString("BullpupRifleMK2ComponentStrings", "Optic", "COMPONENT_AT_SCOPE_MACRO_02_MK2");
					Global.Loadout.BullpupRifleMK2MuzzleString = settings.ReadString("BullpupRifleMK2ComponentStrings", "Muzzle", "COMPONENT_AT_MUZZLE_01");
					Global.Loadout.BullpupRifleMK2BarrelString = settings.ReadString("BullpupRifleMK2ComponentStrings", "Barrel", "COMPONENT_AT_BP_BARREL_01");
					ValidateComponentStrings(10);
				}
			}

			if (Global.Loadout.PumpShotgunMK2) {
				if (Global.Loadout.PumpShotgunMK2Attachments) {
					Global.Loadout.PumpShotgunMK2Magazine = settings.ReadBoolean("PumpShotgunMK2Attachments", "Magazine", false);
					Global.Loadout.PumpShotgunMK2Optic = settings.ReadBoolean("PumpShotgunMK2Attachments", "Optic", true);
					Global.Loadout.PumpShotgunMK2Flashlight = settings.ReadBoolean("PumpShotgunMK2Attachments", "Flashlight", true);
					Global.Loadout.PumpShotgunMK2Muzzle = settings.ReadBoolean("PumpShotgunMK2Attachments", "Muzzle", false);
					Global.Loadout.PumpShotgunMK2MagazineString = settings.ReadString("PumpShotgunMK2ComponentStrings", "Magazine", "COMPONENT_PUMPSHOTGUN_MK2_CLIP_01");
					Global.Loadout.PumpShotgunMK2OpticString = settings.ReadString("PumpShotgunMK2ComponentStrings", "Optic", "COMPONENT_AT_SIGHTS");
					Global.Loadout.PumpShotgunMK2MuzzleString = settings.ReadString("PumpShotgunMK2ComponentStrings", "Barrel", "COMPONENT_AT_MUZZLE_08");
					ValidateComponentStrings(11);
				}
			}
		}

		private static void ValidateComponentStrings(int index) {
			bool IsError = false;
			switch (index) {
				case 1:
					if (Global.Loadout.AssaultRifleMagazine) {
						for (int i = 0; i < AssaultRifleMagazines.Length; i++) {
							if (Global.Loadout.AssaultRifleMagazineString.Equals(AssaultRifleMagazines[i]))
								i = AssaultRifleMagazines.Length + 1;
							else if (!Global.Loadout.AssaultRifleMagazineString.Equals(AssaultRifleMagazines[i]) && i == AssaultRifleMagazines.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.AssaultRifleMagazineString + " for Assault Rifle Extended Mag is invalid, defaulting to COMPONENT_ASSAULTRIFLE_CLIP_02!");
								Global.Loadout.AssaultRifleMagazineString = "COMPONENT_ASSAULTRIFLE_CLIP_02";
								IsError = true;
							}
						}
					}
				break;
				case 2:
					if (Global.Loadout.CarbineRifleMagazine) {
						for (int i = 0; i < CarbineRifleMagazines.Length; i++) {
							if (Global.Loadout.CarbineRifleMagazineString.Equals(CarbineRifleMagazines[i]))
								i = CarbineRifleMagazines.Length + 1;
							else if (!Global.Loadout.CarbineRifleMagazineString.Equals(CarbineRifleMagazines[i]) && i == CarbineRifleMagazines.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.CarbineRifleMagazineString + " for Carbine Rifle Extended Mag is invalid, defaulting to COMPONENT_CARBINERIFLE_CLIP_02!");
								Global.Loadout.CarbineRifleMagazineString = "COMPONENT_CARBINERIFLE_CLIP_02";
								IsError = true;
							}
						}
					}
					break;
				case 3:
					if (Global.Loadout.AdvancedRifleMagazine) {
						for (int i = 0; i < AdvancedRifleMagazines.Length; i++) {
							if (Global.Loadout.AdvancedRifleMagazineString.Equals(AdvancedRifleMagazines[i]))
								i = AdvancedRifleMagazines.Length + 1;
							else if (!Global.Loadout.AdvancedRifleMagazineString.Equals(AdvancedRifleMagazines[i]) && i == AdvancedRifleMagazines.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.AdvancedRifleMagazineString + " for Advanced Rifle Extended Mag is invalid, defaulting to COMPONENT_ADVANCEDRIFLE_CLIP_02!");
								Global.Loadout.AdvancedRifleMagazineString = "COMPONENT_ADVANCEDRIFLE_CLIP_02";
								IsError = true;
							}
						}
					}
					break;
				case 4:
					if (Global.Loadout.SpecialCarbineMagazine) {
						for (int i = 0; i < SpecialCarbineMagazines.Length; i++) {
							if (Global.Loadout.SpecialCarbineMagazineString.Equals(SpecialCarbineMagazines[i]))
								i = SpecialCarbineMagazines.Length + 1;
							else if (!Global.Loadout.SpecialCarbineMagazineString.Equals(SpecialCarbineMagazines[i]) && i == SpecialCarbineMagazines.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.SpecialCarbineMagazineString + " for Special Carbine Extended Mag is invalid, defaulting to COMPONENT_SPECIALCARBINE_CLIP_02!");
								Global.Loadout.SpecialCarbineMagazineString = "COMPONENT_SPECIALCARBINE_CLIP_02";
								IsError = true;
							}
						}
					}
					break;
				case 5:
					if (Global.Loadout.BullpupRifleMagazine) {
						for (int i = 0; i < BullpupRifleMagazines.Length; i++) {
							if (Global.Loadout.BullpupRifleMagazineString.Equals(BullpupRifleMagazines[i]))
								i = BullpupRifleMagazines.Length + 1;
							else if (!Global.Loadout.BullpupRifleMagazineString.Equals(BullpupRifleMagazines[i]) && i == BullpupRifleMagazines.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.BullpupRifleMagazineString + " for Bullpup Rifle Extended Mag is invalid, defaulting to COMPONENT_BULLPUPRIFLE_CLIP_02!");
								Global.Loadout.BullpupRifleMagazineString = "COMPONENT_BULLPUPRIFLE_CLIP_02";
								IsError = true;
							}
						}
					}
					break;
				case 6:
					if (Global.Loadout.CompactRifleMagazine) {
						for (int i = 0; i < CompactRifleMagazines.Length; i++) {
							if (Global.Loadout.CompactRifleMagazineString.Equals(CompactRifleMagazines[i]))
								i = CompactRifleMagazines.Length + 1;
							else if (!Global.Loadout.CompactRifleMagazineString.Equals(CompactRifleMagazines[i]) && i == CompactRifleMagazines.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.CompactRifleMagazineString + " for Compact Rifle Extended Mag is invalid, defaulting to COMPONENT_COMPACTRIFLE_CLIP_02!");
								Global.Loadout.CompactRifleMagazineString = "COMPONENT_COMPACTRIFLE_CLIP_02";
								IsError = true;
							}
						}
					}
					break;
				case 7:
					if (Global.Loadout.AssaultRifleMK2Magazine) {
						for (int i = 0; i < AssaultRifleMK2Magazines.Length; i++) {
							if (Global.Loadout.AssaultRifleMK2MagazineString.Equals(AssaultRifleMK2Magazines[i]))
								i = AssaultRifleMK2Magazines.Length + 1;
							else if (!Global.Loadout.AssaultRifleMK2MagazineString.Equals(AssaultRifleMK2Magazines[i]) && i == AssaultRifleMK2Magazines.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.AssaultRifleMK2MagazineString + " for Assault Rifle MK2 Extended Mag is invalid, defaulting to COMPONENT_ASSAULTRIFLE_MK2_CLIP_02!");
								Global.Loadout.AssaultRifleMK2MagazineString = "COMPONENT_ASSAULTRIFLE_MK2_CLIP_02";
								IsError = true;
							}
						}
					}

					if (Global.Loadout.AssaultRifleMK2Optic) {
						for (int i = 0; i < AssaultRifleMK2Optics.Length; i++) {
							if (Global.Loadout.AssaultRifleMK2OpticString.Equals(AssaultRifleMK2Optics[i]))
								i = AssaultRifleMK2Optics.Length + 1;
							else if (!Global.Loadout.AssaultRifleMK2OpticString.Equals(AssaultRifleMK2Optics[i]) && i == AssaultRifleMK2Optics.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.AssaultRifleMK2OpticString + " for Assault Rifle MK2 Optic is invalid, defaulting to COMPONENT_AT_SCOPE_MACRO_MK2!");
								Global.Loadout.AssaultRifleMK2OpticString = "COMPONENT_AT_SCOPE_MACRO_MK2";
								IsError = true;
							}
						}
					}

					if (Global.Loadout.AssaultRifleMK2Muzzle) {
						for (int i = 0; i < AssaultRifleMK2Muzzles.Length; i++) {
							if (Global.Loadout.AssaultRifleMK2MuzzleString.Equals(AssaultRifleMK2Muzzles[i]))
								i = AssaultRifleMK2Muzzles.Length + 1;
							else if (!Global.Loadout.AssaultRifleMK2MuzzleString.Equals(AssaultRifleMK2Muzzles[i]) && i == AssaultRifleMK2Muzzles.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.AssaultRifleMK2MuzzleString + " for Assault Rifle MK2 Muzzle is invalid, defaulting to COMPONENT_AT_MUZZLE_01!");
								Global.Loadout.AssaultRifleMK2MuzzleString = "COMPONENT_AT_MUZZLE_01";
								IsError = true;
							}
						}
					}

					if(Global.Loadout.AssaultRifleMK2Barrel) {
						for (int i = 0; i < AssaultRifleMK2Barrels.Length; i++) {
							if(Global.Loadout.AssaultRifleMK2BarrelString.Equals(AssaultRifleMK2Barrels[i]))
								i = AssaultRifleMK2Barrels.Length + 1;
							else if (!Global.Loadout.AssaultRifleMK2BarrelString.Equals(AssaultRifleMK2Barrels[i]) && i == AssaultRifleMK2Barrels.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.AssaultRifleMK2BarrelString + " for Assault Rifle MK2 Barrel is invalid, defaulting to COMPONENT_AT_AR_BARREL_01!");
								Global.Loadout.AssaultRifleMK2BarrelString = "COMPONENT_AT_AR_BARREL_01";
								IsError = true;
							}
						}
					}
					break;
				case 8:
					if (Global.Loadout.CarbineRifleMK2Magazine) {
						for (int i = 0; i < CarbineRifleMK2Magazines.Length; i++) {
							if (Global.Loadout.CarbineRifleMK2MagazineString.Equals(CarbineRifleMK2Magazines[i]))
								i = CarbineRifleMK2Magazines.Length + 1;
							else if (!Global.Loadout.CarbineRifleMK2MagazineString.Equals(CarbineRifleMK2Magazines[i]) && i == CarbineRifleMK2Magazines.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.CarbineRifleMK2MagazineString + " for Carbine Rifle MK2 Extended Mag is invalid, defaulting to COMPONENT_CARBINERIFLE_MK2_CLIP_02!");
								Global.Loadout.CarbineRifleMK2MagazineString = "COMPONENT_CARBINERIFLE_MK2_CLIP_02";
								IsError = true;
							}
						}
					}

					if (Global.Loadout.CarbineRifleMK2Optic) {
						for (int i = 0; i < CarbineRifleMK2Optics.Length; i++) {
							if (Global.Loadout.CarbineRifleMK2OpticString.Equals(CarbineRifleMK2Optics[i]))
								i = CarbineRifleMK2Optics.Length + 1;
							else if (!Global.Loadout.CarbineRifleMK2OpticString.Equals(CarbineRifleMK2Optics[i]) && i == CarbineRifleMK2Optics.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.CarbineRifleMK2OpticString + " for Carbine Rifle MK2 Optic is invalid, defaulting to COMPONENT_AT_SCOPE_MACRO_MK2!");
								Global.Loadout.CarbineRifleMK2OpticString = "COMPONENT_AT_SCOPE_MACRO_MK2";
								IsError = true;
							}
						}
					}

					if (Global.Loadout.CarbineRifleMK2Muzzle) {
						for (int i = 0; i < CarbineRifleMK2Muzzles.Length; i++) {
							if (Global.Loadout.CarbineRifleMK2MuzzleString.Equals(CarbineRifleMK2Muzzles[i]))
								i = CarbineRifleMK2Muzzles.Length + 1;
							else if (!Global.Loadout.CarbineRifleMK2MuzzleString.Equals(CarbineRifleMK2Muzzles[i]) && i == CarbineRifleMK2Muzzles.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.CarbineRifleMK2MuzzleString + " for Carbine Rifle MK2 Muzzle is invalid, defaulting to COMPONENT_AT_MUZZLE_01!");
								Global.Loadout.CarbineRifleMK2MuzzleString = "COMPONENT_AT_MUZZLE_01";
								IsError = true;
							}
						}
					}

					if(Global.Loadout.CarbineRifleMK2Barrel) {
						for (int i = 0; i < CarbineRifleMK2Barrels.Length; i++) {
							if (Global.Loadout.CarbineRifleMK2BarrelString.Equals(CarbineRifleMK2Barrels[i]))
								i = CarbineRifleMK2Barrels.Length + 1;
							else if (!Global.Loadout.CarbineRifleMK2BarrelString.Equals(CarbineRifleMK2Barrels[i]) && i == CarbineRifleMK2Barrels.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.CarbineRifleMK2BarrelString + " for Carbine Rifle MK2 Barrel is invalid, defaulting to COMPONENT_AT_CR_BARREL_01!");
								Global.Loadout.CarbineRifleMK2BarrelString = "COMPONENT_AT_CR_BARREL_01";
								IsError = true;
							}
						}
					}
					break;
				case 9:
					if (Global.Loadout.SpecialCarbineMK2Magazine) {
						for (int i = 0; i < SpecialCarbineMK2Magazines.Length; i++) {
							if (Global.Loadout.SpecialCarbineMK2MagazineString.Equals(SpecialCarbineMK2Magazines[i]))
								i = SpecialCarbineMK2Magazines.Length + 1;
							else if (!Global.Loadout.SpecialCarbineMK2MagazineString.Equals(SpecialCarbineMK2Magazines[i]) && i == SpecialCarbineMK2Magazines.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.SpecialCarbineMK2MagazineString + " for Special Carbine MK2 Extended Mag is invalid, defaulting to COMPONENT_SPECIALCARBINE_MK2_CLIP_02!");
								Global.Loadout.SpecialCarbineMK2MagazineString = "COMPONENT_SPECIALCARBINE_MK2_CLIP_02";
								IsError = true;
							}
						}
					}

					if (Global.Loadout.SpecialCarbineMK2Optic) {
						for (int i = 0; i < SpecialCarbineMK2Optics.Length; i++) {
							if (Global.Loadout.SpecialCarbineMK2OpticString.Equals(SpecialCarbineMK2Optics[i]))
								i = SpecialCarbineMK2Optics.Length + 1;
							else if (!Global.Loadout.SpecialCarbineMK2OpticString.Equals(SpecialCarbineMK2Optics[i]) && i == SpecialCarbineMK2Optics.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.SpecialCarbineMK2OpticString + " for Special Carbine MK2 Optic is invalid, defaulting to COMPONENT_AT_SCOPE_MACRO_MK2!");
								Global.Loadout.SpecialCarbineMK2OpticString = "COMPONENT_AT_SCOPE_MACRO_MK2";
								IsError = true;
							}
						}
					}

					if (Global.Loadout.SpecialCarbineMK2Muzzle) {
						for (int i = 0; i < SpecialCarbineMK2Muzzles.Length; i++) {
							if (Global.Loadout.SpecialCarbineMK2MuzzleString.Equals(SpecialCarbineMK2Muzzles[i]))
								i = SpecialCarbineMK2Muzzles.Length + 1;
							else if (!Global.Loadout.SpecialCarbineMK2MuzzleString.Equals(SpecialCarbineMK2Muzzles[i]) && i == SpecialCarbineMK2Muzzles.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.SpecialCarbineMK2MuzzleString + " for Special Carbine MK2 Muzzle is invalid, defaulting to COMPONENT_AT_MUZZLE_01!");
								Global.Loadout.SpecialCarbineMK2MuzzleString = "COMPONENT_AT_MUZZLE_01";
								IsError = true;
							}
						}
					}

					if (Global.Loadout.SpecialCarbineMK2Barrel) {
						for (int i = 0; i < SpecialCarbineMK2Barrels.Length; i++) {
							if (Global.Loadout.SpecialCarbineMK2BarrelString.Equals(SpecialCarbineMK2Barrels[i]))
								i = SpecialCarbineMK2Barrels.Length + 1;
							else if (!Global.Loadout.SpecialCarbineMK2BarrelString.Equals(SpecialCarbineMK2Barrels[i]) && i == SpecialCarbineMK2Barrels.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.SpecialCarbineMK2BarrelString + " for Special Carbine MK2 Barrel is invalid, defaulting to COMPONENT_AT_SC_BARREL_01!");
								Global.Loadout.SpecialCarbineMK2BarrelString = "COMPONENT_AT_SC_BARREL_01";
								IsError = true;
							}
						}
					}
					break;
				case 10:
					if (Global.Loadout.BullpupRifleMK2Magazine) {
						for (int i = 0; i < BullpupRifleMK2Magazines.Length; i++) {
							if (Global.Loadout.BullpupRifleMK2MagazineString.Equals(BullpupRifleMK2Magazines[i]))
								i = BullpupRifleMK2Magazines.Length + 1;
							else if (!Global.Loadout.BullpupRifleMK2MagazineString.Equals(BullpupRifleMK2Magazines[i]) && i == BullpupRifleMK2Magazines.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.BullpupRifleMK2MagazineString + " for Bullpup Rifle MK2 Extended Mag is invalid, defaulting to COMPONENT_BULLPUPRIFLE_MK2_CLIP_02!");
								Global.Loadout.BullpupRifleMK2MagazineString = "COMPONENT_BULLPUPRIFLE_MK2_CLIP_02";
								IsError = true;
							}
						}
					}

					if (Global.Loadout.BullpupRifleMK2Optic) {
						for (int i = 0; i < BullpupRifleMK2Optics.Length; i++) {
							if (Global.Loadout.BullpupRifleMK2OpticString.Equals(BullpupRifleMK2Optics[i]))
								i = BullpupRifleMK2Optics.Length + 1;
							else if (!Global.Loadout.BullpupRifleMK2OpticString.Equals(BullpupRifleMK2Optics[i]) && i == BullpupRifleMK2Optics.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.BullpupRifleMK2OpticString + " for Bullpup Rifle MK2 Optic is invalid, defaulting to COMPONENT_AT_SCOPE_MACRO_02_MK2!");
								Global.Loadout.BullpupRifleMK2OpticString = "COMPONENT_AT_SCOPE_MACRO_02_MK2";
								IsError = true;
							}
						}
					}

					if (Global.Loadout.BullpupRifleMK2Muzzle) {
						for (int i = 0; i < BullpupRifleMK2Muzzles.Length; i++) {
							if (Global.Loadout.BullpupRifleMK2MuzzleString.Equals(BullpupRifleMK2Muzzles[i]))
								i = BullpupRifleMK2Muzzles.Length + 1;
							else if (!Global.Loadout.BullpupRifleMK2MuzzleString.Equals(BullpupRifleMK2Muzzles[i]) && i == BullpupRifleMK2Muzzles.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.BullpupRifleMK2MuzzleString + " for Bullpup Rifle MK2 Muzzle is invalid, defaulting to COMPONENT_AT_MUZZLE_01!");
								Global.Loadout.BullpupRifleMK2MuzzleString = "COMPONENT_AT_MUZZLE_01";
								IsError = true;
							}
						}
					}

					if (Global.Loadout.BullpupRifleMK2Barrel) {
						for (int i = 0; i < BullpupRifleMK2Barrels.Length; i++) {
							if (Global.Loadout.BullpupRifleMK2BarrelString.Equals(BullpupRifleMK2Barrels[i]))
								i = BullpupRifleMK2Barrels.Length + 1;
							else if (!Global.Loadout.BullpupRifleMK2BarrelString.Equals(BullpupRifleMK2Barrels[i]) && i == BullpupRifleMK2Barrels.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.BullpupRifleMK2BarrelString + " for Bullpup Rifle MK2 Barrel is invalid, defaulting to COMPONENT_AT_BP_BARREL_01!");
								Global.Loadout.BullpupRifleMK2BarrelString = "COMPONENT_AT_BP_BARREL_01";
								IsError = true;
							}
						}
					}
					break;
				case 11:
					if(Global.Loadout.PumpShotgunMK2Magazine) {
						for (int i = 0; i < PumpShotgunMK2Magazines.Length; i++) {
							if (Global.Loadout.PumpShotgunMK2MagazineString.Equals(PumpShotgunMK2Magazines[i]))
								i = PumpShotgunMK2Magazines.Length + 1;
							else if (!Global.Loadout.PumpShotgunMK2MagazineString.Equals(PumpShotgunMK2Magazines[i]) && i == PumpShotgunMK2Magazines.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.PumpShotgunMK2MagazineString + " for Pump Shotgun MK2 Extended Mag is invalid, defaulting to COMPONENT_PUMPSHOTGUN_MK2_CLIP_01!");
								Global.Loadout.PumpShotgunMK2MagazineString = "COMPONENT_PUMPSHOTGUN_MK2_CLIP_01";
								IsError = true;
							}
						}
					}

					if(Global.Loadout.PumpShotgunMK2Optic) {
						for (int i = 0; i < PumpShotgunMK2Optics.Length; i++) {
							if (Global.Loadout.PumpShotgunMK2OpticString.Equals(PumpShotgunMK2Optics[i]))
								i = PumpShotgunMK2Optics.Length + 1;
							else if (!Global.Loadout.PumpShotgunMK2OpticString.Equals(PumpShotgunMK2Optics[i]) && i == PumpShotgunMK2Optics.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.PumpShotgunMK2OpticString + " for Pump Shotgun MK2 Extended Mag is invalid, defaulting to COMPONENT_AT_SIGHTS!");
								Global.Loadout.PumpShotgunMK2OpticString = "COMPONENT_AT_SIGHTS";
								IsError = true;
							}
						}
					}

					if(Global.Loadout.PumpShotgunMK2Muzzle) {
						for (int i = 0; i < PumpShotgunMK2Muzzles.Length; i++) {
							if (Global.Loadout.PumpShotgunMK2MuzzleString.Equals(PumpShotgunMK2Muzzles[i]))
								i = PumpShotgunMK2Muzzles.Length + 1;
							else if (!Global.Loadout.PumpShotgunMK2MuzzleString.Equals(PumpShotgunMK2Muzzles[i]) && i == PumpShotgunMK2Muzzles.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.PumpShotgunMK2MuzzleString + " for Pump Shotgun MK2 Extended Mag is invalid, defaulting to COMPONENT_AT_MUZZLE_08!");
								Global.Loadout.PumpShotgunMK2MuzzleString = "COMPONENT_AT_MUZZLE_08";
								IsError = true;
							}
						}
					}
					break;
			}
			if(IsError) {
				Notifier.Notify("~r~[ERROR] ~s~There was an error with your weapon component strings, check your logs for exact information!");
			}
		}
	}
}