/*
 *	Developed By: Alzar
 *	Name: Easy Loadout
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */

namespace EasyLoadout.Core.Utils {
	using Rage;
	public static class Notifier {
		private const string NotificationPrefix = "Easy Loadout";

		//Simple log line
		public static void Notify(string body) {
			string notice = string.Format("~p~[{0}]~s~: {1}", NotificationPrefix, body);
			Game.DisplayNotification(notice);
			Logger.DebugLog("Notification Sent.");
		}
	}
}