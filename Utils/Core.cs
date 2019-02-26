/*
 *	Developed By: Alzar
 *	Name: Easy Loadout
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */

[assembly: Rage.Attributes.Plugin("Easy Loadout Core", Author = "sr7066", Description = "Core library for Easy Loadout functions", SupportUrl = "https://github.com/Alzar/EasyLoadout.Core/issues")]

namespace EasyLoadout.Core.Utils {
	using System.Collections.Generic;
	using Rage;
	using Rage.Native;
	using RAGENativeUI;
	using RAGENativeUI.Elements;

	public static class Core {
		public static List<LoadoutData> loadouts;
		public static List<UIMenuCheckboxItem> pLoadouts;

		public static void Setup(bool isLSPDFR = false, bool onDuty = false) {
			string CurrentVersion = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
			Global.Application.ConfigPath = "Plugins/EasyLoadout/Configs/";
			Global.Application.Tag = "Core";

			Updater.VersionCheck(Global.Application.Tag, "https://raw.githubusercontent.com/Alzar/EasyLoadout.Core/master/core-latest.txt", CurrentVersion);

			Config.LoadConfig(isLSPDFR, onDuty);
			SetupLoadouts();
			SetupConfig();
		}

		public static void SetupLoadouts() {
			Logger.DebugLog("Core Plugin Function Started");
			loadouts = new List<LoadoutData>();
			pLoadouts = new List<UIMenuCheckboxItem>();

			//This is where the user-defined loadout count happens at and is initially loaded
			//We're running through all of the configs and adding them to the loadouts list aswell as adding a menu item for them
			for (int i = 0; i < Global.Application.LoadoutCount; i++) {
				loadouts.Add(new LoadoutData("Loadout" + (i + 1), Config.GetConfigFile(i + 1)));

				LoadoutConfig.SetConfigPath(Global.Application.ConfigPath + loadouts[i].LoadoutConfig);
				LoadoutConfig.LoadConfigTitle();
				pLoadouts.Add(new UIMenuCheckboxItem(Global.Loadout.LoadoutTitle, true, "Set " + Global.Loadout.LoadoutTitle + " as the active loadout."));
			}

			SetupConfig();
		}

		private static void SetupConfig() {

			//Error checking for default loadout, this should allow us to ensure that if an invalid loadout is chosen then it'll default to the first loadout config
			for (int i = 0; i <= Global.Application.LoadoutCount; i++) {
				if (i == Global.Application.LoadoutCount) {
					Logger.DebugLog(Global.Application.DefaultLoadout.LoadoutNumber + " Is Not A Valid Loadout. Defaulting to " + loadouts[0].LoadoutNumber + " as default.");
					LoadoutConfig.SetConfigPath(Global.Application.ConfigPath + loadouts[0].LoadoutConfig);
					LoadoutConfig.LoadConfig();
					UpdateActiveLoadout(0);
				}
				else if (Global.Application.DefaultLoadout.LoadoutNumber.Equals(loadouts[i].LoadoutNumber)) {
					Logger.DebugLog(Global.Application.DefaultLoadout.LoadoutNumber + " Is A Valid Loadout, Setting It To Load By Default.");
					LoadoutConfig.SetConfigPath(Global.Application.ConfigPath + Global.Application.DefaultLoadout.LoadoutConfig);
					LoadoutConfig.LoadConfig();
					UpdateActiveLoadout(i);
					break;
				}
			}
		}

		public static void UpdateActiveLoadout(int loadout) {
			//Quick logic to uncheck non-active loadouts
			for (int i = 0; i < Global.Application.LoadoutCount; i++)
				if (i == loadout)
					pLoadouts[i].Checked = true;
				else
					pLoadouts[i].Checked = false;

			Logger.DebugLog("Starting Active Loadout Change.");

			//Setting and loading config file
			LoadoutConfig.SetConfigPath(Global.Application.ConfigPath + loadouts[(loadout)].LoadoutConfig);
			LoadoutConfig.LoadConfig();

			Logger.DebugLog("Setting Loadout #" + (loadout + 1) + " as Active Loadout.");
			Logger.DebugLog("Loadout Title: " + Global.Loadout.LoadoutTitle + " FilePath: " + LoadoutConfig.GetConfigPath());
			pLoadouts[loadout].Checked = true;
			pLoadouts[loadout].Text = Global.Loadout.LoadoutTitle;

			//Sending notification of active loadout change
			Notifier.Notify(Global.Loadout.LoadoutTitle + " set as active loadout ~g~Successfully~s~!");
			Logger.DebugLog("Active Loadout Changed");
		}
	}
}
