/*
 *	Developed By: Alzar
 *	Name: Loadout+
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */

namespace LoadoutPlus.Utils {
	using System.Media;
	using System.Windows.Forms;
	using Rage;

	internal static class Global {
		internal static class Application {
			public static float CurrentVersion { get; set; }
			public static float LatestVersion { get; set; }
		}

		internal static class Controls {
			public static Keys OpenMenu { get; set; }
			public static Keys OpenMenuModifier { get; set; }
			public static Keys GiveLoadout { get; set; }
			public static Keys GiveLoadoutModifier { get; set; }
		}

		internal static class LoadoutAmmo {
			public static short PistolAmmo { get; set; }
			public static short MGAmmo { get; set; }
			public static short ShotgunAmmo { get; set; }
			public static short RifleAmmo { get; set; }
			public static short SniperAmmo { get; set; }
			public static short HeavyAmmo { get; set; }
			public static short ThrowableCount { get; set; }
		}

		internal static class Loadout {
			//Loadout Title
			public static string LoadoutTitle { get; set; }

			//Pistols
			public static bool Pistol { get; set; }
			public static bool CombatPistol { get; set; }
			public static bool Pistol50 { get; set; }
			public static bool APPistol { get; set; }
			public static bool HeavyPistol { get; set; }
			public static bool SNSPistol { get; set; }
			public static bool VintagePistol { get; set; }
			public static bool MarksmanPistol { get; set; }
			public static bool HeavyRevolver { get; set; }
			public static bool MachinePistol { get; set; }
			public static bool PistolMK2 { get; set; }

			//Machine Guns
			public static bool MicroSMG { get; set; }
			public static bool SMG { get; set; }
			public static bool AssaultSMG { get; set; }
			public static bool TommyGun { get; set; }
			public static bool MG { get; set; }
			public static bool CombatMG { get; set; }
			public static bool CombatPDW { get; set; }
			public static bool MiniSMG { get; set; }
			public static bool SMGMK2 { get; set; }
			public static bool CombatMGMK2 { get; set; }

			//Shotguns
			public static bool PumpShotgun { get; set; }
			public static bool SawedOffShotgun { get; set; }
			public static bool AssaultShotgun { get; set; }
			public static bool BullpupShotgun { get; set; }
			public static bool HeavyShotgun { get; set; }
			public static bool Musket { get; set; }
			public static bool DoubleBarrel { get; set; }
			public static bool AutoShotgun { get; set; }

			//Rifles
			public static bool AssaultRifle { get; set; }
			public static bool CarbineRifle { get; set; }
			public static bool AdvancedRifle { get; set; }
			public static bool SpecialCarbine { get; set; }
			public static bool BullpupRifle { get; set; }
			public static bool CompactRifle { get; set; }
			public static bool AssaultRifleMK2 { get; set; }
			public static bool CarbineRifleMK2 { get; set; }

			//Attachments
			public static bool AssaultRifleAttachments { get; set; }
			public static bool CarbineRifleAttachments { get; set; }
			public static bool AdvancedRifleAttachments { get; set; }
			public static bool SpecialCarbineAttachments { get; set; }
			public static bool BullpupRifleAttachments { get; set; }
			public static bool CompactRifleAttachments { get; set; }
			public static bool AssaultRifleMK2Attachments { get; set; }
			public static bool CarbineRifleMK2Attachments { get; set; }

			//Rifle Attachments
			public static bool AssaultRifleExtendedMag { get; set; }
			public static string AssaultRifleExtendedMagString { get; set; }
			public static bool AssaultRifleGrip { get; set; }
			public static bool AssaultRifleOptic { get; set; }
			public static bool AssaultRifleFlashlight { get; set; }
			public static bool AssaultRifleMuzzle { get; set; }

			public static bool CarbineRifleExtendedMag { get; set; }
			public static string CarbineRifleExtendedMagString { get; set; }
			public static bool CarbineRifleGrip { get; set; }
			public static bool CarbineRifleOptic { get; set; }
			public static bool CarbineRifleFlashlight { get; set; }
			public static bool CarbineRifleMuzzle { get; set; }

			public static bool AdvancedRifleExtendedMag { get; set; }
			public static string AdvancedRifleExtendedMagString { get; set; }
			public static bool AdvancedRifleOptic { get; set; }
			public static bool AdvancedRifleFlashlight { get; set; }
			public static bool AdvancedRifleMuzzle { get; set; }

			public static bool SpecialCarbineExtendedMag { get; set; }
			public static string SpecialCarbineExtendedMagString { get; set; }
			public static bool SpecialCarbineGrip { get; set; }
			public static bool SpecialCarbineOptic { get; set; }
			public static bool SpecialCarbineFlashlight { get; set; }
			public static bool SpecialCarbineMuzzle { get; set; }

			public static bool BullpupRifleExtendedMag { get; set; }
			public static string BullpupRifleExtendedMagString { get; set; }
			public static bool BullpupRifleGrip { get; set; }
			public static bool BullpupRifleOptic { get; set; }
			public static bool BullpupRifleFlashlight { get; set; }
			public static bool BullpupRifleMuzzle { get; set; }

			public static bool CompactRifleExtendedMag { get; set; }
			public static string CompactRifleExtendedMagString { get; set; }

			public static bool AssaultRifleMK2ExtendedMag { get; set; }
			public static bool AssaultRifleMK2Grip { get; set; }
			public static bool AssaultRifleMK2Optic { get; set; }
			public static bool AssaultRifleMK2Flashlight { get; set; }
			public static bool AssaultRifleMK2Barrel { get; set; }
			public static bool AssaultRifleMK2Muzzle { get; set; }
			public static string AssaultRifleMK2ExtendedMagString { get; set; }
			public static string AssaultRifleMK2OpticString { get; set; }
			public static string AssaultRifleMK2BarrelString { get; set; }
			public static string AssaultRifleMK2MuzzleString { get; set; }

			public static bool CarbineRifleMK2ExtendedMag { get; set; }
			public static bool CarbineRifleMK2Grip { get; set; }
			public static bool CarbineRifleMK2Optic { get; set; }
			public static bool CarbineRifleMK2Flashlight { get; set; }
			public static bool CarbineRifleMK2Barrel { get; set; }
			public static bool CarbineRifleMK2Muzzle { get; set; }
			public static string CarbineRifleMK2ExtendedMagString { get; set; }
			public static string CarbineRifleMK2OpticString { get; set; }
			public static string CarbineRifleMK2BarrelString { get; set; }
			public static string CarbineRifleMK2MuzzleString { get; set; }

			//Snipers
			public static bool SniperRifle { get; set; }
			public static bool HeavySniper { get; set; }
			public static bool MarksmanRifle { get; set; }
			public static bool HeavySniperMK2 { get; set; }

			//Heavy Weapons
			public static bool GrenadeLauncher { get; set; }
			public static bool RPG { get; set; }
			public static bool Minigun { get; set; }
			public static bool FireworkLauncher { get; set; }
			public static bool HomingLauncher { get; set; }
			public static bool RailGun { get; set; }
			public static bool CompactLauncher { get; set; }

			//Throwables
			public static bool Flare { get; set; }
			public static bool BZGas { get; set; }
			public static bool TearGas { get; set; }
			public static bool Molotov { get; set; }
			public static bool Grenade { get; set; }
			public static bool StickyBomb { get; set; }
			public static bool ProximityMine { get; set; }
			public static bool PipeBomb { get; set; }
			public static bool Snowball { get; set; }
			public static bool Baseball { get; set; }

			//Melee Weapons
			public static bool Nightstick { get; set; }
			public static bool Knife { get; set; }
			public static bool Hammer { get; set; }
			public static bool BaseballBat { get; set; }
			public static bool Crowbar { get; set; }
			public static bool GolfClub { get; set; }
			public static bool BrokenBottle { get; set; }
			public static bool AntiqueDagger { get; set; }
			public static bool Hatchet { get; set; }
			public static bool BrassKnuckles { get; set; }
			public static bool Machete { get; set; }
			public static bool Switchblade { get; set; }
			public static bool BattleAxe { get; set; }
			public static bool Wrench { get; set; }
			public static bool PoolCue { get; set; }

			//Other
			public static bool Taser { get; set; }
			public static bool FlareGun { get; set; }
			public static bool Flashlight { get; set; }
			public static bool FireExtinguisher { get; set; }
			public static bool GasCan { get; set; }

			//Misc
			public static bool BodyArmor { get; set; }
			public static bool AttachFlashlightToAll { get; set; }
		}

		//This is where any and all valid component strings are stored. These will be our control so we can input validate options that the user selects and ensure they're correct so we dont crash
		internal static class WeaponAttachments {
			static string[] AssaultRifleExtendedMags = { "COMPONENT_ASSAULTRIFLE_CLIP_01", "COMPONENT_ASSAULTRIFLE_CLIP_02", "COMPONENT_ASSAULTRIFLE_CLIP_03" };
			static string[] CarbineRifleExtendedMags = { "COMPONENT_CARBINERIFLE_CLIP_01", "COMPONENT_CARBINERIFLE_CLIP_02", "COMPONENT_CARBINERIFLE_CLIP_03" };
			static string[] AdvancedRifleExtendedMags = { "COMPONENT_ADVANCEDRIFLE_CLIP_01", "COMPONENT_ADVANCEDRIFLE_CLIP_02" };
			static string[] SpecialCarbineExtendedMags = { "COMPONENT_SPECIALCARBINE_CLIP_01", "COMPONENT_SPECIALCARBINE_CLIP_02", "COMPONENT_SPECIALCARBINE_CLIP_03" };
			static string[] BullpupRifleExtendedMags = { "COMPONENT_BULLPUPRIFLE_CLIP_01", "COMPONENT_BULLPUPRIFLE_CLIP_02" };
			static string[] CompactRifleExtendedMags = { "COMPONENT_COMPACTRIFLE_CLIP_01", "COMPONENT_COMPACTRIFLE_CLIP_02", "COMPONENT_COMPACTRIFLE_CLIP_03" };
			
			//MK2 Variants
			static string[] AssaultRifleMK2ExtendedMags = { "COMPONENT_ASSAULTRIFLE_MK2_CLIP_01", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_02", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_ARMORPIERCING", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_FMJ", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_INCENDIARY", "COMPONENT_ASSAULTRIFLE_MK2_CLIP_TRACER" };
			static string[] AssaultRifleMK2Optics = { "COMPONENT_AT_SIGHTS", "COMPONENT_AT_SCOPE_MACRO_MK2", "COMPONENT_AT_SCOPE_MEDIUM_MK2" };
			static string[] AssaultRifleMK2Muzzles = { "COMPONENT_AT_AR_SUPP_02", "COMPONENT_AT_MUZZLE_01", "COMPONENT_AT_MUZZLE_02", "COMPONENT_AT_MUZZLE_03", "COMPONENT_AT_MUZZLE_04", "COMPONENT_AT_MUZZLE_05", "COMPONENT_AT_MUZZLE_06", "COMPONENT_AT_MUZZLE_07" };
			static string[] AssaultRifleMK2Barrels = { "COMPONENT_AT_AR_BARREL_01", "COMPONENT_AT_AR_BARREL_02" };

			static string[] CarbineRifleMK2ExtendedMags = { "COMPONENT_CARBINERIFLE_MK2_CLIP_01", "COMPONENT_CARBINERIFLE_MK2_CLIP_02", "COMPONENT_CARBINERIFLE_MK2_CLIP_ARMORPIERCING", "COMPONENT_CARBINERIFLE_MK2_CLIP_FMJ", "COMPONENT_CARBINERIFLE_MK2_CLIP_INCENDIARY", "COMPONENT_CARBINERIFLE_MK2_CLIP_TRACER" };
			static string[] CarbineRifleMK2Optics = { "COMPONENT_AT_SIGHTS", "COMPONENT_AT_SCOPE_MACRO_MK2", "COMPONENT_AT_SCOPE_MEDIUM_MK2" };
			static string[] CarbineRifleMK2Muzzles = { "COMPONENT_AT_AR_SUPP", "COMPONENT_AT_MUZZLE_01", "COMPONENT_AT_MUZZLE_02", "COMPONENT_AT_MUZZLE_03", "COMPONENT_AT_MUZZLE_04", "COMPONENT_AT_MUZZLE_05", "COMPONENT_AT_MUZZLE_06", "COMPONENT_AT_MUZZLE_07" };
			static string[] CarbineRifleMK2Barrels = { "COMPONENT_AT_CR_BARREL_01", "COMPONENT_AT_CR_BARREL_02" };
		}
	}
}
