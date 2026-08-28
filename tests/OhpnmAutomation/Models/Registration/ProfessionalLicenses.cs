using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhpnmAutomation.Models.Registration
{
    public class ProfessionalLicenses
    {
        public string State { get; set; }
        public string LicenseBoardName { get; set; }
        public string LicenseNumber { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpirationDate { get; set; }
        public string FilePath { get; set; }
    }
}
