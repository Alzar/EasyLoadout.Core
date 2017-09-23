

namespace LoadoutPlus.Utils {
	using System.Media;
	using System.Windows.Forms;
	using Rage;

	internal static class Global {
		public static class Application {
			public static float CurrentVersion { get; set; }
			public static float LatestVersion { get; set; }
		}

		public static class Controls {
			public static Keys GiveLoadout { get; set; }
			public static Keys GiveLoadoutModifier { get; set; }
		}

		public static class Loadout {
			//Pistols
			public static bool Pistol { get; set; }
			public static bool CombatPistol { get; set; }
			public static bool Pistol50 { get; set; }
			public static bool APPistol { get; set; }
			public static bool HeavyPistol { get; set; }
			//SMG
			public static bool MicroSMG { get; set; }
			public static bool SMG { get; set; }
			public static bool AssaultSMG { get; set; }
			public static bool TommyGun { get; set; }
			//Shotguns
			public static bool PumpShotgun { get; set; }
			public static bool SawedOffShotgun { get; set; }
			public static bool AssaultShotgun { get; set; }
			public static bool BullpupShotgun { get; set; }
			public static bool HeavyShotgun { get; set; }
			//LMG
			public static bool MG { get; set; }
			public static bool CombatMG { get; set; }
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
			//Snipers
			public static bool SniperRifle { get; set; }
			public static bool HeavySniper { get; set; }
			public static bool MarksmanRifle { get; set; }
			//Other
			public static bool Nightstick { get; set; }
			public static bool Taser { get; set; }
			public static bool Flashlight { get; set; }
			public static bool Flare { get; set; }
			public static bool FireExtinguisher { get; set; }
			//Misc
			public static bool AttachFlashlightToAll { get; set; }
		}
	}
}
