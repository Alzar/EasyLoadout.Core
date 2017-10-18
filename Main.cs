/*
 *	Developed By: Alzar
 *	Name: Loadout+
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */

[assembly: Rage.Attributes.Plugin("Loadout+", Author = "Alzar", Description = "Loads specified loadout when going on duty aswell as having a keybind that you can press to give you the loadout anytime.", SupportUrl = "https://github.com/iAlzar/LoadoutPlus/issues")]

namespace LoadoutPlus{
	using Rage;
	using LSPD_First_Response.Mod.API;
	using LoadoutPlus.Utils;

    public class Main : Plugin {

		public override void Initialize() {
			Functions.OnOnDutyStateChanged += this.DutyStateChange;

			Global.Application.CurrentVersion = 1.6f;
		}

		public void DutyStateChange(bool OnDuty) {
			if (!Updater.CheckUpdate()) {
				Notifier.Notify("Plugin is out of date! (Current Version: ~r~" + Global.Application.CurrentVersion + " ~s~) - (Latest Version: ~g~" + Global.Application.LatestVersion + "~s~) Please update the plugin!");
				Logger.Log("Plugin is out of date. (Current Version: " + Global.Application.CurrentVersion + ") - (Latest Version: " + Global.Application.LatestVersion + ")");
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
