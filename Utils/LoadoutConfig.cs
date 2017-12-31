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
		private static string[] AssaultRifleExtendedMags = new string[] { "COMPONENT_ASSAULTRIFLE_CLIP_01", "COMPONENT_ASSAULTRIFLE_CLIP_02", "COMPONENT_ASSAULTRIFLE_CLIP_03" };
		private static string[] CarbineRifleExtendedMags = new string[] { "COMPONENT_CARBINERIFLE_CLIP_01", "COMPONENT_CARBINERIFLE_CLIP_02", "COMPONENT_CARBINERIFLE_CLIP_03" };
		private static string[] AdvancedRifleExtendedMags = new string[] { "COMPONENT_ADVANCEDRIFLE_CLIP_01", "COMPONENT_ADVANCEDRIFLE_CLIP_02" };
		private static string[] SpecialCarbineExtendedMags = new string[] { "COMPONENT_SPECIALCARBINE_CLIP_01", "COMPONENT_SPECIALCARBINE_CLIP_02", "COMPONENT_SPECIALCARBINE_CLIP_03" };
		private static string[] BullpupRifleExtendedMags = new string[] { "COMPONENT_BULLPUPRIFLE_CLIP_01", "COMPONENT_BULLPUPRIFLE_CLIP_02" };
		private static string[] CompactRifleExtendedMags = new string[] { "COMPONENT_COMPACTRIFLE_CLIP_01", "COMPONENT_COMPACTRIFLE_CLIP_02", "COMPONENT_COMPACTRIFLE_CLIP_03" };

		//MK2 Variants
		private static string[] AssaultRifleMK2ExtendedMags = new string[] { "COMPONENT_ASSAULTRIFLE_MK2_CLIP_01", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_02", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_ARMORPIERCING", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_FMJ", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_INCENDIARY", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_TRACER" };
		private static string[] AssaultRifleMK2Optics = new string[] { "COMPONENT_AT_SIGHTS", "COMPONENT_AT_SCOPE_MACRO_MK2", "COMPONENT_AT_SCOPE_MEDIUM_MK2" };
		private static string[] AssaultRifleMK2Muzzles = new string[] { "COMPONENT_AT_AR_SUPP_02", "COMPONENT_AT_MUZZLE_01", "COMPONENT_AT_MUZZLE_02", "COMPONENT_AT_MUZZLE_03", "COMPONENT_AT_MUZZLE_04", "COMPONENT_AT_MUZZLE_05", "COMPONENT_AT_MUZZLE_06", "COMPONENT_AT_MUZZLE_07" };
		private static string[] AssaultRifleMK2Barrels = new string[] { "COMPONENT_AT_AR_BARREL_01", "COMPONENT_AT_AR_BARREL_02" };

		private static string[] CarbineRifleMK2ExtendedMags = new string[] { "COMPONENT_CARBINERIFLE_MK2_CLIP_01", "COMPONENT_CARBINERIFLE_MK2_CLIP_02", "COMPONENT_CARBINERIFLE_MK2_CLIP_ARMORPIERCING", "COMPONENT_CARBINERIFLE_MK2_CLIP_FMJ", "COMPONENT_CARBINERIFLE_MK2_CLIP_INCENDIARY", "COMPONENT_CARBINERIFLE_MK2_CLIP_TRACER" };
		private static string[] CarbineRifleMK2Optics = new string[] { "COMPONENT_AT_SIGHTS", "COMPONENT_AT_SCOPE_MACRO_MK2", "COMPONENT_AT_SCOPE_MEDIUM_MK2" };
		private static string[] CarbineRifleMK2Muzzles = new string[] { "COMPONENT_AT_AR_SUPP", "COMPONENT_AT_MUZZLE_01", "COMPONENT_AT_MUZZLE_02", "COMPONENT_AT_MUZZLE_03", "COMPONENT_AT_MUZZLE_04", "COMPONENT_AT_MUZZLE_05", "COMPONENT_AT_MUZZLE_06", "COMPONENT_AT_MUZZLE_07" };
		private static string[] CarbineRifleMK2Barrels = new string[] { "COMPONENT_AT_CR_BARREL_01", "COMPONENT_AT_CR_BARREL_02" };

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

			//Rifles
			Global.Loadout.AssaultRifle = settings.ReadBoolean("Loadout", "AssaultRifle", false);
			Global.Loadout.CarbineRifle = settings.ReadBoolean("Loadout", "CarbineRifle", false);
			Global.Loadout.AdvancedRifle = settings.ReadBoolean("Loadout", "AdvancedRifle", false);
			Global.Loadout.SpecialCarbine = settings.ReadBoolean("Loadout", "SpecialCarbine");
			Global.Loadout.BullpupRifle = settings.ReadBoolean("Loadout", "BullpupRifle", false);
			Global.Loadout.CompactRifle = settings.ReadBoolean("Loadout", "CompactRifle", false);
			Global.Loadout.AssaultRifleMK2 = settings.ReadBoolean("Loadout", "AssaultRifleMK2", false);
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



			///All config stuff for attachments and component strings are loaded here aswell as sent to be validated as to if they're valid or not
			if (Global.Loadout.AssaultRifle) {
				if (Global.Loadout.AssaultRifleAttachments) {
					Global.Loadout.AssaultRifleExtendedMag = settings.ReadBoolean("AssaultRifleAttachments", "ExtendedMag", false);
					Global.Loadout.AssaultRifleGrip = settings.ReadBoolean("AssaultRifleAttachments", "Grip", true);
					Global.Loadout.AssaultRifleOptic = settings.ReadBoolean("AssaultRifleAttachments", "Optic", true);
					Global.Loadout.AssaultRifleFlashlight = settings.ReadBoolean("AssaultRifleAttachments", "Flashlight", true);
					Global.Loadout.AssaultRifleMuzzle = settings.ReadBoolean("AssaultRifleAttachments", "Suppressor", false);
					Global.Loadout.AssaultRifleExtendedMagString = settings.ReadString("AssaultRifleComponentStrings", "ExtendedMag", "COMPONENT_ASSAULTRIFLE_CLIP_02");
					ValidateComponentStrings(1);
				}
			}

			if (Global.Loadout.CarbineRifle) {
				if (Global.Loadout.CarbineRifleAttachments) {
					Global.Loadout.CarbineRifleExtendedMag = settings.ReadBoolean("CarbineRifleAttachments", "ExtendedMag", false);
					Global.Loadout.CarbineRifleGrip = settings.ReadBoolean("CarbineRifleAttachments", "Grip", true);
					Global.Loadout.CarbineRifleOptic = settings.ReadBoolean("CarbineRifleAttachments", "Optic", true);
					Global.Loadout.CarbineRifleFlashlight = settings.ReadBoolean("CarbineRifleAttachments", "Flashlight", true);
					Global.Loadout.CarbineRifleMuzzle = settings.ReadBoolean("CarbineRifleAttachments", "Suppressor", false);
					Global.Loadout.CarbineRifleExtendedMagString = settings.ReadString("CarbineRifleComponentStrings", "ExtendedMag", "COMPONENT_CARBINERIFLE_CLIP_02");
					ValidateComponentStrings(2);
				}
			}

			if (Global.Loadout.AdvancedRifle) {
				if (Global.Loadout.AdvancedRifleAttachments) {
					Global.Loadout.AdvancedRifleExtendedMag = settings.ReadBoolean("AdvancedRifleAttachments", "ExtendedMag", false);
					Global.Loadout.AdvancedRifleOptic = settings.ReadBoolean("AdvancedRifleAttachments", "Optic", true);
					Global.Loadout.AdvancedRifleFlashlight = settings.ReadBoolean("AdvancedRifleAttachments", "Flashlight", true);
					Global.Loadout.AdvancedRifleMuzzle = settings.ReadBoolean("AdvancedRifleAttachments", "Suppressor", false);
					Global.Loadout.AdvancedRifleExtendedMagString = settings.ReadString("AdvancedRifleComponentStrings", "ExtendedMag", "COMPONENT_ADVANCEDRIFLE_CLIP_02");
					ValidateComponentStrings(3);
				}
			}

			if (Global.Loadout.SpecialCarbine) {
				if (Global.Loadout.SpecialCarbineAttachments) {
					Global.Loadout.SpecialCarbineExtendedMag = settings.ReadBoolean("SpecialCarbineAttachments", "ExtendedMag", false);
					Global.Loadout.SpecialCarbineGrip = settings.ReadBoolean("SpecialCarbineAttachments", "Grip", true);
					Global.Loadout.SpecialCarbineOptic = settings.ReadBoolean("SpecialCarbineAttachments", "Optic", true);
					Global.Loadout.SpecialCarbineFlashlight = settings.ReadBoolean("SpecialCarbineAttachments", "Flashlight", true);
					Global.Loadout.SpecialCarbineMuzzle = settings.ReadBoolean("SpecialCarbineAttachments", "Suppressor", false);
					Global.Loadout.SpecialCarbineExtendedMagString = settings.ReadString("SpecialCarbineComponentStrings", "ExtendedMag", "COMPONENT_SPECIALCARBINE_CLIP_02");
					ValidateComponentStrings(4);
				}
			}

			if (Global.Loadout.BullpupRifle) {
				if (Global.Loadout.BullpupRifleAttachments) {
					Global.Loadout.BullpupRifleExtendedMag = settings.ReadBoolean("BullpupRifleAttachments", "ExtendedMag", false);
					Global.Loadout.BullpupRifleGrip = settings.ReadBoolean("BullpupRifleAttachments", "Grip", true);
					Global.Loadout.BullpupRifleOptic = settings.ReadBoolean("BullpupRifleAttachments", "Optic", true);
					Global.Loadout.BullpupRifleFlashlight = settings.ReadBoolean("BullpupRifleAttachments", "Flashlight", true);
					Global.Loadout.BullpupRifleMuzzle = settings.ReadBoolean("BullpupRifleAttachments", "Suppressor", false);
					Global.Loadout.BullpupRifleExtendedMagString = settings.ReadString("BullpupRifleComponentStrings", "ExtendedMag", "COMPONENT_BULLPUPRIFLE_CLIP_02");
					ValidateComponentStrings(5);
				}
			}

			if (Global.Loadout.CompactRifle) {
				if (Global.Loadout.CompactRifleAttachments) {
					Global.Loadout.CompactRifleExtendedMag = settings.ReadBoolean("CompactRifleAttachments", "ExtendedMag", false);
					Global.Loadout.CompactRifleExtendedMagString = settings.ReadString("CompactRifleComponentStrings", "ExtendedMag", "COMPONENT_COMPACTRIFLE_CLIP_02");
					ValidateComponentStrings(6);
				}
			}

			if (Global.Loadout.AssaultRifleMK2) {
				if (Global.Loadout.AssaultRifleMK2Attachments) {
					Global.Loadout.AssaultRifleMK2ExtendedMag = settings.ReadBoolean("AssaultRifleMK2Attachments", "ExtendedMag", false);
					Global.Loadout.AssaultRifleMK2Grip = settings.ReadBoolean("AssaultRifleMK2Attachments", "Grip", true);
					Global.Loadout.AssaultRifleMK2Optic = settings.ReadBoolean("AssaultRifleMK2Attachments", "Optic", true);
					Global.Loadout.AssaultRifleMK2Flashlight = settings.ReadBoolean("AssaultRifleMK2Attachments", "Flashlight", true);
					Global.Loadout.AssaultRifleMK2Muzzle = settings.ReadBoolean("AssaultRifleMK2Attachments", "Muzzle", false);
					Global.Loadout.AssaultRifleMK2Barrel = settings.ReadBoolean("AssaultRifleMK2Attachments", "Barrel", false);
					Global.Loadout.AssaultRifleMK2ExtendedMagString = settings.ReadString("AssaultRifleMK2ComponentStrings", "ExtendedMag", "COMPONENT_BULLPUPRIFLE_CLIP_02");
					Global.Loadout.AssaultRifleMK2OpticString = settings.ReadString("AssaultRifleMK2ComponentStrings", "Optic", "COMPONENT_AT_SCOPE_MACRO_MK2");
					Global.Loadout.AssaultRifleMK2BarrelString = settings.ReadString("AssaultRifleMK2ComponentStrings", "Muzzle", "COMPONENT_AT_MUZZLE_01");
					Global.Loadout.AssaultRifleMK2MuzzleString = settings.ReadString("AssaultRifleMK2ComponentStrings", "Barrel", "COMPONENT_AT_AR_BARREL_01");
					ValidateComponentStrings(7);
				}
			}

			if (Global.Loadout.CarbineRifleMK2) {
				if (Global.Loadout.CarbineRifleMK2Attachments) {
					Global.Loadout.CarbineRifleMK2ExtendedMag = settings.ReadBoolean("CarbineRifleMK2Attachments", "ExtendedMag", false);
					Global.Loadout.CarbineRifleMK2Grip = settings.ReadBoolean("CarbineRifleMK2Attachments", "Grip", true);
					Global.Loadout.CarbineRifleMK2Optic = settings.ReadBoolean("CarbineRifleMK2Attachments", "Optic", true);
					Global.Loadout.CarbineRifleMK2Flashlight = settings.ReadBoolean("CarbineRifleMK2Attachments", "Flashlight", true);
					Global.Loadout.CarbineRifleMK2Muzzle = settings.ReadBoolean("CarbineRifleMK2Attachments", "Muzzle", false);
					Global.Loadout.CarbineRifleMK2Barrel = settings.ReadBoolean("CarbineRifleMK2Attachments", "Barrel", false);
					Global.Loadout.CarbineRifleMK2ExtendedMagString = settings.ReadString("CarbineRifleMK2ComponentStrings", "ExtendedMag", "COMPONENT_BULLPUPRIFLE_CLIP_02");
					Global.Loadout.CarbineRifleMK2OpticString = settings.ReadString("CarbineRifleMK2ComponentStrings", "Optic", "COMPONENT_AT_SCOPE_MACRO_MK2");
					Global.Loadout.CarbineRifleMK2BarrelString = settings.ReadString("CarbineRifleMK2ComponentStrings", "Muzzle", "COMPONENT_AT_MUZZLE_01");
					Global.Loadout.CarbineRifleMK2MuzzleString = settings.ReadString("CarbineRifleMK2ComponentStrings", "Barrel", "COMPONENT_AT_AR_BARREL_01");
					ValidateComponentStrings(8);
				}
			}
		}

		private static void ValidateComponentStrings(int index) {
			bool IsError = false;
			switch (index) {
				case 1:
					if (Global.Loadout.AssaultRifleExtendedMag) {
						for (int i = 0; i < AssaultRifleExtendedMags.Length; i++) {
							if (Global.Loadout.AssaultRifleExtendedMagString.Equals(AssaultRifleExtendedMags[i]))
								i = AssaultRifleExtendedMags.Length + 1;
							else if (!Global.Loadout.AssaultRifleExtendedMagString.Equals(AssaultRifleExtendedMags[i]) && i == AssaultRifleExtendedMags.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.AssaultRifleExtendedMagString + " for Assault Rifle Extended Mag is invalid, defaulting to COMPONENT_ASSAULTRIFLE_CLIP_02!");
								Global.Loadout.AssaultRifleExtendedMagString = "COMPONENT_ASSAULTRIFLE_CLIP_02";
								IsError = true;
							}
						}
					}
				break;
				case 2:
					if (Global.Loadout.CarbineRifleExtendedMag) {
						for (int i = 0; i < CarbineRifleExtendedMags.Length; i++) {
							if (Global.Loadout.CarbineRifleExtendedMagString.Equals(CarbineRifleExtendedMags[i]))
								i = CarbineRifleExtendedMags.Length + 1;
							else if (!Global.Loadout.CarbineRifleExtendedMagString.Equals(CarbineRifleExtendedMags[i]) && i == CarbineRifleExtendedMags.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.CarbineRifleExtendedMagString + " for Carbine Rifle Extended Mag is invalid, defaulting to COMPONENT_CARBINERIFLE_CLIP_02!");
								Global.Loadout.CarbineRifleExtendedMagString = "COMPONENT_CARBINERIFLE_CLIP_02";
								IsError = true;
							}
						}
					}
					break;
				case 3:
					if (Global.Loadout.AdvancedRifleExtendedMag) {
						for (int i = 0; i < AdvancedRifleExtendedMags.Length; i++) {
							if (Global.Loadout.AdvancedRifleExtendedMagString.Equals(AdvancedRifleExtendedMags[i]))
								i = AdvancedRifleExtendedMags.Length + 1;
							else if (!Global.Loadout.AdvancedRifleExtendedMagString.Equals(AdvancedRifleExtendedMags[i]) && i == AdvancedRifleExtendedMags.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.AdvancedRifleExtendedMagString + " for Advanced Rifle Extended Mag is invalid, defaulting to COMPONENT_ADVANCEDRIFLE_CLIP_02!");
								Global.Loadout.AdvancedRifleExtendedMagString = "COMPONENT_ADVANCEDRIFLE_CLIP_02";
								IsError = true;
							}
						}
					}
					break;
				case 4:
					if (Global.Loadout.SpecialCarbineExtendedMag) {
						for (int i = 0; i < SpecialCarbineExtendedMags.Length; i++) {
							if (Global.Loadout.SpecialCarbineExtendedMagString.Equals(SpecialCarbineExtendedMags[i]))
								i = SpecialCarbineExtendedMags.Length + 1;
							else if (!Global.Loadout.SpecialCarbineExtendedMagString.Equals(SpecialCarbineExtendedMags[i]) && i == SpecialCarbineExtendedMags.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.SpecialCarbineExtendedMagString + " for Special Carbine Extended Mag is invalid, defaulting to COMPONENT_SPECIALCARBINE_CLIP_02!");
								Global.Loadout.SpecialCarbineExtendedMagString = "COMPONENT_SPECIALCARBINE_CLIP_02";
								IsError = true;
							}
						}
					}
					break;
				case 5:
					if (Global.Loadout.BullpupRifleExtendedMag) {
						for (int i = 0; i < BullpupRifleExtendedMags.Length; i++) {
							if (Global.Loadout.BullpupRifleExtendedMagString.Equals(BullpupRifleExtendedMags[i]))
								i = BullpupRifleExtendedMags.Length + 1;
							else if (!Global.Loadout.BullpupRifleExtendedMagString.Equals(BullpupRifleExtendedMags[i]) && i == BullpupRifleExtendedMags.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.BullpupRifleExtendedMagString + " for Bullpup Rifle Extended Mag is invalid, defaulting to COMPONENT_BULLPUPRIFLE_CLIP_02!");
								Global.Loadout.BullpupRifleExtendedMagString = "COMPONENT_BULLPUPRIFLE_CLIP_02";
								IsError = true;
							}
						}
					}
					break;
				case 6:
					if (Global.Loadout.CompactRifleExtendedMag) {
						for (int i = 0; i < CompactRifleExtendedMags.Length; i++) {
							if (Global.Loadout.CompactRifleExtendedMagString.Equals(CompactRifleExtendedMags[i]))
								i = CompactRifleExtendedMags.Length + 1;
							else if (!Global.Loadout.CompactRifleExtendedMagString.Equals(CompactRifleExtendedMags[i]) && i == CompactRifleExtendedMags.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.CompactRifleExtendedMagString + " for Compact Rifle Extended Mag is invalid, defaulting to COMPONENT_COMPACTRIFLE_CLIP_02!");
								Global.Loadout.CompactRifleExtendedMagString = "COMPONENT_COMPACTRIFLE_CLIP_02";
								IsError = true;
							}
						}
					}
					break;
				case 7:
					if (Global.Loadout.AssaultRifleMK2ExtendedMag) {
						for (int i = 0; i < AssaultRifleMK2ExtendedMags.Length; i++) {
							if (Global.Loadout.AssaultRifleMK2ExtendedMagString.Equals(AssaultRifleMK2ExtendedMags[i]))
								i = AssaultRifleMK2ExtendedMags.Length + 1;
							else if (!Global.Loadout.AssaultRifleMK2ExtendedMagString.Equals(AssaultRifleMK2ExtendedMags[i]) && i == AssaultRifleMK2ExtendedMags.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.AssaultRifleMK2ExtendedMagString + " for Assault Rifle MK2 Extended Mag is invalid, defaulting to COMPONENT_ASSAULTRIFLE_MK2_CLIP_02!");
								Global.Loadout.AssaultRifleMK2ExtendedMagString = "COMPONENT_ASSAULTRIFLE_MK2_CLIP_02";
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
					if (Global.Loadout.CarbineRifleMK2ExtendedMag) {
						for (int i = 0; i < CarbineRifleMK2ExtendedMags.Length; i++) {
							if (Global.Loadout.CarbineRifleMK2ExtendedMagString.Equals(CarbineRifleMK2ExtendedMags[i]))
								i = CarbineRifleMK2ExtendedMags.Length + 1;
							else if (!Global.Loadout.CarbineRifleMK2ExtendedMagString.Equals(CarbineRifleMK2ExtendedMags[i]) && i == CarbineRifleMK2ExtendedMags.Length - 1) {
								Logger.Log("Component String " + Global.Loadout.CarbineRifleMK2ExtendedMagString + " for Carbine Rifle MK2 Extended Mag is invalid, defaulting to COMPONENT_CARBINERIFLE_MK2_CLIP_02!");
								Global.Loadout.CarbineRifleMK2ExtendedMagString = "COMPONENT_CARBINERIFLE_MK2_CLIP_02";
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
			}
			if(IsError) {
				Notifier.Notify("~r~[ERROR] ~s~There was an error with your weapon component strings, check your logs for exact information!");
			}
		}
	}
}