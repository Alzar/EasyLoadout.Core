[assembly: Rage.Attributes.Plugin("Loadout+", Author = "Alzar", Description = "Loads specified loadout when going on duty aswell as having a keybind that you can press to give you the loadout anytime.", SupportUrl = "http://www.lcpdfr.com/messenger/compose/?to=324491")]

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
		}

		private static void StartPlugin() {
			GameFiber.StartNew(delegate { Core.RunPlugin(); });
		}

		public override void Finally() {
			Game.LogTrivial("Plugin unloaded successfully!");
		}
	}
}
