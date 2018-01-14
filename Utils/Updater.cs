/*
 *	Developed By: Alzar
 *	Name: Easy Loadout
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */

namespace EasyLoadout.Utils {
	using System;
	using System.Net;

	internal static class Updater {
		private static readonly WebClient wc = new WebClient();

		public static bool CheckUpdate() {
			string response = null;

			try {
				response = wc.DownloadStringTaskAsync(new Uri("https://raw.githubusercontent.com/sr7066/EasyLoadout/master/latest.txt")).Result;
			}
			catch (Exception) {
				/// TODO
			}

			//If we get a null respone then the download failed and we just return false
			if (string.IsNullOrWhiteSpace(response)) {
				return false;
			}

			Global.Application.LatestVersion = response;

			Version current = new Version(Global.Application.CurrentVersion);
			Version latest = new Version(Global.Application.LatestVersion);

			//Current is somehow being reported as higher than latest, this isn't correct so we'll display an error to be safe
			if (current.CompareTo(latest) > 0) {
				return false;
			}
			//Latest is greater than current, return false to warn user that there is an update available
			else if(current.CompareTo(latest) < 0) {
				return false;
			}
			//Current version matches latest, return true
			else {
				return true;
			}
		}
	}
}
