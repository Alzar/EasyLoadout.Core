/*
 *	Developed By: Alzar
 *	Name: Easy Loadout
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */


namespace EasyLoadout.Core.Utils {
	using System.Windows.Forms;
	using Rage;

	public static class Config {
		private static InitializationFile initialiseFile(string filepath) {
			InitializationFile ini = new InitializationFile(filepath);
			ini.Create();
			return ini;
		}

		public static string GetConfigFile(int count) {
			InitializationFile settings = initialiseFile(Global.Application.ConfigPath + "EasyLoadout.ini");
			string tmp = settings.ReadString("MultiLoadout", "Loadout" + count);

			//We're just checking if the string is set to nothing because this is an indicator that it wasn't set in the config file thus something is wrong.
			if (tmp == "") {
				Logger.Log("Loadout" + count + " is not a valid config file. Please verify configs are valid and exist in " + Global.Application.ConfigPath + " before reporting this as a potential bug.");
			}

			return tmp;
		}

		public static void LoadConfig(bool isLSPDFR, bool OnDuty) {
			InitializationFile settings = initialiseFile(Global.Application.ConfigPath + "EasyLoadout.ini");

			Global.Application.DebugLogging = LoadoutConfig.ToBoolean(settings.ReadString("General", "DebugLogging", "false"));
			Logger.DebugLog("General Config Loading Started.");

			KeysConverter kc = new KeysConverter();

			string opTemp, opmTemp, glTemp, glmTemp, dlnTemp, dlcTemp;

			opTemp = settings.ReadString("Keybinds", "OpenMenu", "F8");
			opmTemp = settings.ReadString("Keybinds", "OpenMenuModifier", "None");
			glTemp = settings.ReadString("Keybinds", "GiveLoadout", "F7");
			glmTemp = settings.ReadString("Keybinds", "GiveLoadoutModifier", "None");

			Global.Controls.OpenMenu = (Keys)kc.ConvertFromString(opTemp);
			Global.Controls.OpenMenuModifier = (Keys)kc.ConvertFromString(opmTemp);
			Global.Controls.GiveLoadout = (Keys)kc.ConvertFromString(glTemp);
			Global.Controls.GiveLoadoutModifier = (Keys)kc.ConvertFromString(glmTemp);


			if(isLSPDFR) {
				if(OnDuty) {
					dlnTemp = settings.ReadString("LSPDFR", "OnDuty", "Loadout1");
					dlcTemp = settings.ReadString("LSPDFR", dlnTemp, "Loadout1");
				}
				else {
					dlnTemp = settings.ReadString("LSPDFR", "OffDuty", "Loadout1");
					dlcTemp = settings.ReadString("LSPDFR", dlnTemp, "Loadout1");
				}

				if (dlnTemp.Equals("DefaultLoadout")) {
					dlnTemp = settings.ReadString("General", "DefaultLoadout", "Loadout1");
					dlcTemp = settings.ReadString("General", dlnTemp, "Loadout1");
				}
			}
			else {
				dlnTemp = settings.ReadString("General", "DefaultLoadout", "Loadout1");
				dlcTemp = settings.ReadString("General", dlnTemp, "Loadout1");
			}
			Global.Application.DefaultLoadout = new LoadoutData(dlnTemp, dlcTemp);
			Global.Application.LoadoutCount = settings.ReadInt32("MultiLoadout", "LoadoutCount", 3);

			//Ammo Count
			Global.LoadoutAmmo.PistolAmmo = settings.ReadInt16("Ammo", "PistolAmmo", 10000);
			Global.LoadoutAmmo.MGAmmo = settings.ReadInt16("Ammo", "MGAmmo", 10000);
			Global.LoadoutAmmo.ShotgunAmmo = settings.ReadInt16("Ammo", "ShotgunAmmo", 10000);
			Global.LoadoutAmmo.RifleAmmo = settings.ReadInt16("Ammo", "RifleAmmo", 10000);
			Global.LoadoutAmmo.SniperAmmo = settings.ReadInt16("Ammo", "SniperAmmo", 10000);
			Global.LoadoutAmmo.HeavyAmmo = settings.ReadInt16("Ammo", "HeavyAmmo", 10000);
			Global.LoadoutAmmo.ThrowableCount = settings.ReadInt16("Ammo", "ThrowableCount", 10000);

			Logger.DebugLog("General Config Loading Finished.");
		}
	}
}