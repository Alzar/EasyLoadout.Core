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

			//Machine Guns
			public static bool MicroSMG { get; set; }
			public static bool SMG { get; set; }
			public static bool AssaultSMG { get; set; }
			public static bool TommyGun { get; set; }
			public static bool MG { get; set; }
			public static bool CombatMG { get; set; }
			public static bool CombatPDW { get; set; }
			public static bool MiniSMG { get; set; }

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
			public static bool AssaultRifleAttachments { get; set; }
			public static bool CarbineRifle { get; set; }
			public static bool CarbineRifleAttachments { get; set; }
			public static bool AdvancedRifle { get; set; }
			public static bool AdvancedRifleAttachments { get; set; }
			public static bool SpecialCarbine { get; set; }
			public static bool SpecialCarbineAttachments { get; set; }
			public static bool BullpupRifle { get; set; }
			public static bool BullpupRifleAttachments { get; set; }
			public static bool CompactRifle { get; set; }
			public static bool CompactRifleAttachments { get; set; }

			//Snipers
			public static bool SniperRifle { get; set; }
			public static bool HeavySniper { get; set; }
			public static bool MarksmanRifle { get; set; }

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
	}
}
