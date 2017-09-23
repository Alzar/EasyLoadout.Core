/*
 *	Developed By: Alzar
 *	Name: Loadout+
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */

namespace LoadoutPlus.Utils {
	using System;
	using System.Net;

	internal static class Updater {
		private static readonly WebClient wc = new WebClient();

		public static bool CheckUpdate() {
			string response = null;

			try {
				response = wc.DownloadStringTaskAsync(new Uri("https://raw.githubusercontent.com/sr7066/LoadoutPlus/master/latest.txt")).Result;
			}
			catch (Exception) {
				// TODO
			}

			//If we get a null respone then the download failed and we just return false
			if (string.IsNullOrWhiteSpace(response)) {
				return false;
			}

			//Got a valid response, parsing into float
			if (float.TryParse(response, out float result)) {
				Global.Application.LatestVersion = result;
			}

			//Current Version doesn't match latest version, return false
			if (Global.Application.CurrentVersion != Global.Application.LatestVersion) {
				return false;
			}
			//Current version matches latest, return true
			else {
				return true;
			}
		}
	}
}
