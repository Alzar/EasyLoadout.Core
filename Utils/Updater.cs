/*
 *	Developed By: Alzar
 *	Name: Easy Loadout
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */

namespace EasyLoadout.Core.Utils {
	using System;
	using System.Net;

	public static class Updater {
		private static readonly WebClient wc = new WebClient();
		private static string response;
		private static string CurrentVersion = "";
		private static string LatestVersion = "";

		public static void VersionCheck(string tag, string url, string current) {
			CurrentVersion = current;
			int versionStatus = Updater.CheckUpdate(url);

			if (versionStatus == -1) {
				Notifier.Notify("Plugin(" + tag + ") is out of date! (Current Version: ~r~" + CurrentVersion + " ~s~) - (Latest Version: ~g~" + LatestVersion + "~s~) Please update the plugin!");
				Logger.Log(tag, "Plugin is out of date. (Current Version: " + CurrentVersion + ") - (Latest Version: " + LatestVersion + ")");
			}
			else if (versionStatus == -2) {
				Logger.Log(tag, "There was an issue checking plugin versions, the plugin may be out of date!");
			}
			else if (versionStatus == 1) {
				Logger.Log(tag, "Current version of plugin is higher than the version reported on the official GitHub, this could be an error that you may want to report!");
			}
			else {
				Notifier.Notify("Plugin(" + tag + ") loaded ~g~successfully~s~!");
				Logger.Log(tag, "Plugin Version v" + CurrentVersion + " loaded successfully");
			}
		}

		private static int CheckUpdate(string url) {
			try {
				Logger.DebugLog("Fetching latest plugin version from GitHub");
				response = wc.DownloadStringTaskAsync(new Uri(url)).Result;
				//response = wc.DownloadStringTaskAsync(new Uri("https://raw.githubusercontent.com/sr7066/EasyLoadout.Core/master/latest.txt")).Result;
			}
			catch (Exception) {
				/// TODO
			}

			//If we get a null respone then the download failed and we just return -2 and inform user of failing the download
			if (string.IsNullOrWhiteSpace(response)) {
				return -2;
			}

			LatestVersion = response;

			//This is where we're checking the results
			//If the plugin is newer than what's being reported then we'll return 1 (This will just log the issue, no notification)
			//If the plugin is older than what's being reported then we'll return -1(This Logs aswell as displays a notification)
			//If the plugin is the same version as what's being reported than we'll return 0 (This logs & displays notification that it loaded successfully)
			if (CurrentVersion.CompareTo(LatestVersion) > 0) {
				return 1;
			}
			else if (CurrentVersion.CompareTo(LatestVersion) < 0) {
				return -1;
			}
			else {
				return 0;
			}
		}
	}
}
