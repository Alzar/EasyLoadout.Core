/*
 *	Developed By: Alzar
 *	Name: Easy Loadout
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */

[assembly: Rage.Attributes.Plugin("Easy Loadout", Author = "sr7066", Description = "Loads specified loadout when going on duty aswell as having a keybind that you can press to give you the loadout anytime.", SupportUrl = "https://github.com/iAlzar/EasyLoadout/issues")]

namespace EasyLoadout{
	using Rage;
	using System;
	using LSPD_First_Response.Mod.API;
	using EasyLoadout.Utils;

    public class Main : Plugin {

		public override void Initialize() {
			Functions.OnOnDutyStateChanged += this.DutyStateChange;
			Global.Application.CurrentVersion = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
			Global.Application.ConfigPath = "Plugins/LSPDFR/EasyLoadout/Configs/";
		}

		public void DutyStateChange(bool OnDuty) {
			int versionStatus = Updater.CheckUpdate();
			if (versionStatus == -1) {
				Notifier.Notify("Plugin is out of date! (Current Version: ~r~" + Global.Application.CurrentVersion + " ~s~) - (Latest Version: ~g~" + Global.Application.LatestVersion + "~s~) Please update the plugin!");
				Logger.Log("Plugin is out of date. (Current Version: " + Global.Application.CurrentVersion + ") - (Latest Version: " + Global.Application.LatestVersion + ")");
			}
			else if(versionStatus == -2) {
				Logger.Log("There was an issue checking plugin versions, the plugin may be out of date!");
			}
			else if (versionStatus == 1) {
				Logger.Log("Current version of plugin is higher than the version reported on the official GitHub, this could be an error that you may want to report!");
			}
			else {
				Notifier.Notify("Plugin loaded ~g~successfully~s~!");
				Logger.Log("Plugin Version v" + Global.Application.CurrentVersion + " loaded successfully");
			}

			//Loading general config
			Config.LoadConfig();

			StartPlugin();
		}

		private static void StartPlugin() {
			GameFiber.StartNew(delegate { Core.RunPlugin(); });
		}

		public override void Finally() {
			Logger.Log("Plugin unloaded successfully");
		}
	}
}
