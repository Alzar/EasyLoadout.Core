namespace LoadoutPlus.Utils {
	using Rage;
	internal static class Logger {
		//ONLY INCLUDE PLUGIN NAME
		private const string LogPrefix = "Loadout+";
		
		//Simple log line
		internal static void Log(string LogLine) {
			string e = string.Format("[{0}]: {1}", LogPrefix, LogLine);

			Game.LogTrivial(e);
		}
	}
}