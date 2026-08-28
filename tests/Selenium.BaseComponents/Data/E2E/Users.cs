using System;

namespace BaseSelenium.BaseComponents.Data.DIT4
{
	public static class Users
	{
		const string CurrentEnvironment = Environment.DIT4;

		class Environment
		{
			public const string DIT4 = "dit4";
		}

		public static class DellMain_Thor_SalesRepEUDS
		{
			public const string Username = "srep_e_uds@dell.com." + CurrentEnvironment;
			public const string Password = "csmG4dit4";
		}
        public static class DellMain_Thor_NASrep
        {
            public const string Username = "na_srep@dell.com." + CurrentEnvironment;
            public const string Password = "csmG4dit4";
        }

    }
}
