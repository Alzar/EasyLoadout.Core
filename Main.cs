[assembly: Rage.Attributes.Plugin("Loadout+", Author = "Alzar", Description = "Loads specified loadout when going on duty aswell as having a keybind that you can press to give you the loadout anytime.", SupportUrl = "https://github.com/iAlzar/LoadoutPlus/issues")]

namespace LoadoutPlus{
	using Rage;
	using LSPD_First_Response.Mod.API;
	using LoadoutPlus.Utils;

    public class Main : Plugin {
		public override void Initialize() {
			Functions.OnOnDutyStateChanged += this.DutyStateChange;
		}

		public void DutyStateChange(bool OnDuty) {
			Config.LoadConfig();
			Game.DisplayNotification("~p~Loadout+ ~s~has been loaded ~g~successfully!");

			StartPlugin();
		}

		private static void StartPlugin() {
			GameFiber.StartNew(delegate { Core.RunPlugin(); });
		}

		public override void Finally() {
			Game.LogTrivial("[Loadout+]: Plugin unloaded successfully!");
		}
	}
}
