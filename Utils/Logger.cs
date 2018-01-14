/*
 *	Developed By: Alzar
 *	Name: Easy Loadout
 *	Dependent: Rage Plugin Hook & LSPDFR
 *	Released On: GitHub & LSPDFR
 */

namespace EasyLoadout.Utils {
	using Rage;
	internal static class Logger {
		//ONLY INCLUDE PLUGIN NAME
		private const string LogPrefix = "Easy Loadout";
		
		//Simple log line
		internal static void Log(string LogLine) {
			string log = string.Format("[{0}]: {1}", LogPrefix, LogLine);

			Game.LogTrivial(log);
		}
	}
}