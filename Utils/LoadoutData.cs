namespace EasyLoadout.Utils {
	class LoadoutData {
		private string LoadoutNumber;
		private string LoadoutConfig;

		public LoadoutData(string num, string config) {
			LoadoutNumber = num;
			LoadoutConfig = config;
		}

		public string GetNumber() {
			return LoadoutNumber;
		}

		public string GetConfig() {
			return LoadoutConfig;
		}

		public void SetNumber(string num) {
			LoadoutNumber = num;
		}

		public void SetConfig(string config) {
			LoadoutConfig = config;
		}
	}
}
