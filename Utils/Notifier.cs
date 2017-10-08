/*
 *	Developed By: Alzar
 *	Name: Loadout+
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */

namespace LoadoutPlus.Utils {
	using Rage;
	internal static class Notifier {
		private const string NotificationPrefix = "Loadout+";

		//Simple log line
		internal static void Notify(string body) {
			string notice = string.Format("~p~[{0}]~s~: {1}", NotificationPrefix, body);

			Game.DisplayNotification(notice);
		}
	}
}