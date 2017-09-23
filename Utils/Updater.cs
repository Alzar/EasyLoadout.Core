using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadoutPlus.Utils {
	using System;
	using System.Net;

	class Updater {
		private static readonly WebClient Web = new WebClient();

		public static bool CheckUpdate() {
			string response = null;

			// Try to get the LatestVersion from a Git file
			try {
				response = Web.DownloadStringTaskAsync(new Uri("https://raw.githubusercontent.com/sr7066/LoadoutPlus/master/latest.txt")).Result;
			}
			catch (Exception) {
				// TODO : ErrorHandling in Updater
			}

			// If the Response if NULL or empty the Download wasnt successfull -> Return
			if (string.IsNullOrWhiteSpace(response)) {
				return false;
			}

			// If the Plugin came so far the download was successfull and the Response can be parsed into a Float
			if (float.TryParse(response, out float result)) {
				Global.Application.LatestVersion = result;
			}

			//Current Version doesn't match latest version, return false!
			if (Global.Application.CurrentVersion != Global.Application.LatestVersion) {
				return false;
			}
			//Current version matches latest, return true!
			else {
				return true;
			}
		}

		public static float GetCurrentVersion() {
			return Global.Application.CurrentVersion;
		}
	}
}
