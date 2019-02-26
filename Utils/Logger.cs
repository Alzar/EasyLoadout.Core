/*
 *	Developed By: Alzar
 *	Name: Easy Loadout
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */

namespace EasyLoadout.Core.Utils {
	using Rage;
	public static class Logger {
		//Simple log line
		public static void Log(string LogLine) {
			string log = string.Format("{0}", LogLine);

			Game.LogTrivial(log);
		}

		//Simple log line
		public static void Log(string extraTag, string LogLine) {
			string log = string.Format("[{0}]: {1}", extraTag, LogLine);

			Game.LogTrivial(log);
		}

		//Simple log line that will be ran only if the global setting for debug logging is enabled
		public static void DebugLog(string LogLine) {
			if (Global.Application.DebugLogging) {
				string log = string.Format("[DEBUG]: {0}", LogLine);

				Game.LogTrivial(log);
			}
		}

		//Simple log line that will be ran only if the global setting for debug logging is enabled
		public static void DebugLog(string extraTag, string LogLine) {
			if (Global.Application.DebugLogging) {
				string log = string.Format("[{0}][DEBUG]: {1}", extraTag, LogLine);

				Game.LogTrivial(log);
			}
		}
	}
}