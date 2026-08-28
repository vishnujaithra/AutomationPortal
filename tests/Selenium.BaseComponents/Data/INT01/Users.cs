using System;

namespace BaseSelenium.BaseComponents.Data.DIT2
{
	public static class Users
	{
		const string CurrentEnvironment = Environment.DIT2;

		class Environment
		{
			public const string DIT2 = "dit2";
		}

		public static class DellMain_Thor_SalesRepEUDS
		{
			public const string Username = "srep_e_uds@dell.com." + CurrentEnvironment;
			public const string Password = "csmG2dit2";
		}
        public static class DellMain_Thor_NASrep
        {
            public const string Username = "na_srep@dell.com." + CurrentEnvironment;
            public const string Password = "csmG2dit2";
        }
        public static class DellMain_Thor_PRMOpAdmin
        {
            public const string Username = "test_na_ops@dell.com." + CurrentEnvironment;
            public const string Password = "csmG2dit2";
        }

    }
}
