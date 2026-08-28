using System;

namespace BaseSelenium.BaseComponents.Data.DIT4
{
    public static class OhpnmE2E
    {
        public const string CurrentEnvironment = Environment.E2E;

        class Environment
        {
            public const string E2E = "E2E";
        }

        public static class OhpnmDetailsE2E
        {
            public const string loginURL = "https://ohpnm-e2e.omes.maximus.com/OH_PNM_E2E/Account/Login.aspx";
          
        }
    }
}