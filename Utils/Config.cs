/*
 *	Developed By: Alzar
 *	Name: Easy Loadout
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */


namespace EasyLoadout.Utils {
	using System.Windows.Forms;
	using Rage;

	internal static class Config {
		private static InitializationFile initialiseFile(string filepath) {
			//InitializationFile is a Rage class.
			InitializationFile ini = new InitializationFile(filepath);
			ini.Create();
			return ini;
		}

		public static void LoadConfig() {
			InitializationFile settings = initialiseFile(Global.Application.ConfigPath + "EasyLoadout.ini");
			KeysConverter kc = new KeysConverter();

			string opTemp, opmTemp, glTemp, glmTemp;

			opTemp = settings.ReadString("Keybinds", "OpenMenu", "F8");
			opmTemp = settings.ReadString("Keybinds", "OpenMenuModifier", "None");
			glTemp = settings.ReadString("Keybinds", "GiveLoadout", "F7");
			glmTemp = settings.ReadString("Keybinds", "GiveLoadoutModifier", "None");

			Global.Controls.OpenMenu = (Keys)kc.ConvertFromString(opTemp);
			Global.Controls.OpenMenuModifier = (Keys)kc.ConvertFromString(opmTemp);
			Global.Controls.GiveLoadout = (Keys)kc.ConvertFromString(glTemp);
			Global.Controls.GiveLoadoutModifier = (Keys)kc.ConvertFromString(glmTemp);

			Global.Application.DefaultLoadout = settings.ReadInt16("General", "DefaultLoadout", 1);

			//Ammo Count
			Global.LoadoutAmmo.PistolAmmo = settings.ReadInt16("Ammo", "PistolAmmo", 10000);
			Global.LoadoutAmmo.MGAmmo = settings.ReadInt16("Ammo", "MGAmmo", 10000);
			Global.LoadoutAmmo.ShotgunAmmo = settings.ReadInt16("Ammo", "ShotgunAmmo", 10000);
			Global.LoadoutAmmo.RifleAmmo = settings.ReadInt16("Ammo", "RifleAmmo", 10000);
			Global.LoadoutAmmo.SniperAmmo = settings.ReadInt16("Ammo", "SniperAmmo", 10000);
			Global.LoadoutAmmo.HeavyAmmo = settings.ReadInt16("Ammo", "HeavyAmmo", 10000);
			Global.LoadoutAmmo.ThrowableCount = settings.ReadInt16("Ammo", "ThrowableCount", 10000);
		}
	}
}