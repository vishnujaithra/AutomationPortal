using Newtonsoft.Json;
using OhpnmAutomation.Models.PA;
using OhpnmAutomation.Models.Registration;
using OhpnmAutomation.Utilities;
using Selenium.BaseComponents.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OhpnmAutomation.Utilities
{
    public static class DataRepository
    {
        public static Models.Registration.Registration GetRegistrationData()
        {
            DataSet ds = ExcelReader.GetExcelFileAsDataSet("C:\\Projects\\RegistationTestData.xlsx", true);

            Models.Registration.Registration registration = new Models.Registration.Registration();

            var properties = typeof(Models.Registration.Registration).GetProperties();
            foreach (var propertyInfo in properties)
            {
                string key = propertyInfo.Name;
                DataTable dt = ds.Tables[key];

                if (key.Equals("NewProviderDTO"))
                    registration.NewProviderDTO = Mapper.BindData<NewProviderDTO>(dt);

                if (key.Equals("ProviderContactInfo"))
                    registration.ProviderContactInfo = Mapper.BindData<ProviderContactInfo>(dt);

                if (key.Equals("PrimaryAddressServiceDTO"))
                    registration.PrimaryAddressServiceDTO = Mapper.BindData<PrimaryAddressServiceDTO>(dt);

                if (key.Equals("BillingAndPaymentAddressDTO"))
                    registration.BillingAndPaymentAddressDTO = Mapper.BindData<BillingAndPaymentAddressDTO>(dt);

                if (key.Equals("OtherServiceLocationsDTO"))
                    registration.OtherServiceLocationsDTO = Mapper.BindData<OtherServiceLocationsDTO>(dt);

                if (key.Equals("Adress1099"))
                    registration.Adress1099 = Mapper.BindData<Adress1099>(dt);

                if (key.Equals("HomeOfficeAddressDTO"))
                    registration.HomeOfficeAddressDTO = Mapper.BindData<HomeOfficeAddressDTO>(dt);

                if (key.Equals("SpecialitiesDTO"))
                    registration.SpecialitiesDTO = Mapper.BindData<SpecialitiesDTO>(dt);

                if (key.Equals("TaxonomiesDTO"))
                    registration.TaxonomiesDTO = Mapper.BindData<TaxonomiesDTO>(dt);

                if (key.Equals("ProfessionalLicenses"))
                    registration.ProfessionalLicenses = Mapper.BindData<ProfessionalLicenses>(dt);

                if (key.Equals("BoardCertificateDTO"))
                    registration.BoardCertificateDTO = Mapper.BindData<BoardCertificateDTO>(dt);

                if (key.Equals("CorrespondenceAddressDTO"))
                    registration.CorrespondenceAddressDTO = Mapper.BindData<CorrespondenceAddressDTO>(dt);

                if (key.Equals("CLIACertificationsDTO"))
                    registration.CLIACertificationsDTO = Mapper.BindData<CLIACertificationsDTO>(dt);

                if (key.Equals("MediCareNumberDTO"))
                    registration.MediCareNumberDTO = Mapper.BindData<MediCareNumberDTO>(dt);

                if (key.Equals("GroupFacilityHospital"))
                    registration.GroupFacilityHospital = Mapper.BindData<GroupFacilityHospital>(dt);

                if (key.Equals("MCPAffiliationDTO"))
                    registration.MCPAffiliationDTO = Mapper.BindData<MCPAffiliationDTO>(dt);

                if (key.Equals("StateCDSNumberDTO"))
                    registration.StateCDSNumberDTO = Mapper.BindData<StateCDSNumberDTO>(dt);

                if (key.Equals("FederalDEARegistrationDTO"))
                    registration.FederalDEARegistrationDTO = Mapper.BindData<FederalDEARegistrationDTO>(dt);

                if (key.Equals("ProfessionalLiabilityInsurance"))
                    registration.ProfessionalLiabilityInsurance = Mapper.BindData<ProfessionalLiabilityInsurance>(dt);

                if (key.Equals("EducationDTO"))
                    registration.EducationDTO = Mapper.BindData<EducationDTO>(dt);

                if (key.Equals("MalPracticeClaimsHistoryDTO"))
                    registration.MalPracticeClaimsHistoryDTO = Mapper.BindData<MalPracticeClaimsHistoryDTO>(dt);

                if (key.Equals("WorkHistoryDTO"))
                    registration.WorkHistoryDTO = Mapper.BindData<WorkHistoryDTO>(dt);

                if (key.Equals("W9FormDTO"))
                    registration.W9FormDTO = Mapper.BindData<W9FormDTO>(dt);

                if (key.Equals("EFTBankingDTO"))
                    registration.EFTBankingDTO = Mapper.BindData<EFTBankingDTO>(dt);

                if (key.Equals("RequiredDocumentsDTO"))
                    registration.RequiredDocumentsDTO = Mapper.BindData<RequiredDocumentsDTO>(dt);

                if (key.Equals("AgreementsDTO"))
                    registration.AgreementsDTO = Mapper.BindData<AgreementsDTO>(dt);
            }

            return registration;
        }

        public static object GetAutomationData(string flowName)
        {
            var aPIGatway = new APIGatway();
            var automationDatas = aPIGatway.GetAutomationData(flowName).Result;

            if (automationDatas == null || automationDatas.Count == 0)
                return null;

            foreach (var data in automationDatas)
            {
                if (!string.IsNullOrEmpty(data.TestContent))
                {
                    data.automationContents = JsonConvert.DeserializeObject<List<AutomationContent>>(data.TestContent);
                }
            }

            return flowName switch
            {
                "Registration" => BuildRegistration(automationDatas),
                "DentalPA" => BuildDentalPA(automationDatas),
                "SearchRA" => BindSingle<Models.SearchRA.SearchRA>(automationDatas, "SearchRAParams"),
                "SearchPA" => BindSingle<Models.SearchPA>(automationDatas, "SearchPAParams"),
                "SearchMemberEligiblity" => BindSingle<Models.SearchEligibility>(automationDatas, "SearchMemberEligiblity"),
                _ => null
            };
        }

        private static Models.Registration.Registration BuildRegistration(List<AutomationData> automationDatas)
        {
            var registration = new Models.Registration.Registration();

            var map = new Dictionary<string, Action<List<AutomationContent>>>
            {
                ["NewProviderDTO"] = dt => registration.NewProviderDTO = Mapper.BindData<NewProviderDTO>(dt),
                ["ProviderContactInfo"] = dt => registration.ProviderContactInfo = Mapper.BindData<ProviderContactInfo>(dt),
                ["PrimaryAddressServiceDTO"] = dt => registration.PrimaryAddressServiceDTO = Mapper.BindData<PrimaryAddressServiceDTO>(dt),
                ["BillingAndPaymentAddressDTO"] = dt => registration.BillingAndPaymentAddressDTO = Mapper.BindData<BillingAndPaymentAddressDTO>(dt),
                ["OtherServiceLocationsDTO"] = dt => registration.OtherServiceLocationsDTO = Mapper.BindData<OtherServiceLocationsDTO>(dt),
                ["Adress1099"] = dt => registration.Adress1099 = Mapper.BindData<Adress1099>(dt),
                ["HomeOfficeAddressDTO"] = dt => registration.HomeOfficeAddressDTO = Mapper.BindData<HomeOfficeAddressDTO>(dt),
                ["SpecialitiesDTO"] = dt => registration.SpecialitiesDTO = Mapper.BindData<SpecialitiesDTO>(dt),
                ["TaxonomiesDTO"] = dt => registration.TaxonomiesDTO = Mapper.BindData<TaxonomiesDTO>(dt),
                ["ProfessionalLicenses"] = dt => registration.ProfessionalLicenses = Mapper.BindData<ProfessionalLicenses>(dt),
                ["BoardCertificateDTO"] = dt => registration.BoardCertificateDTO = Mapper.BindData<BoardCertificateDTO>(dt),
                ["CorrespondenceAddressDTO"] = dt => registration.CorrespondenceAddressDTO = Mapper.BindData<CorrespondenceAddressDTO>(dt),
                ["CLIACertificationsDTO"] = dt => registration.CLIACertificationsDTO = Mapper.BindData<CLIACertificationsDTO>(dt),
                ["MediCareNumberDTO"] = dt => registration.MediCareNumberDTO = Mapper.BindData<MediCareNumberDTO>(dt),
                ["GroupFacilityHospital"] = dt => registration.GroupFacilityHospital = Mapper.BindData<GroupFacilityHospital>(dt),
                ["MCPAffiliationDTO"] = dt => registration.MCPAffiliationDTO = Mapper.BindData<MCPAffiliationDTO>(dt),
                ["StateCDSNumberDTO"] = dt => registration.StateCDSNumberDTO = Mapper.BindData<StateCDSNumberDTO>(dt),
                ["FederalDEARegistrationDTO"] = dt => registration.FederalDEARegistrationDTO = Mapper.BindData<FederalDEARegistrationDTO>(dt),
                ["ProfessionalLiabilityInsurance"] = dt => registration.ProfessionalLiabilityInsurance = Mapper.BindData<ProfessionalLiabilityInsurance>(dt),
                ["EducationDTO"] = dt => registration.EducationDTO = Mapper.BindData<EducationDTO>(dt),
                ["MalPracticeClaimsHistoryDTO"] = dt => registration.MalPracticeClaimsHistoryDTO = Mapper.BindData<MalPracticeClaimsHistoryDTO>(dt),
                ["WorkHistoryDTO"] = dt => registration.WorkHistoryDTO = Mapper.BindData<WorkHistoryDTO>(dt),
                ["W9FormDTO"] = dt => registration.W9FormDTO = Mapper.BindData<W9FormDTO>(dt),
                ["EFTBankingDTO"] = dt => registration.EFTBankingDTO = Mapper.BindData<EFTBankingDTO>(dt),
                ["RequiredDocumentsDTO"] = dt => registration.RequiredDocumentsDTO = Mapper.BindData<RequiredDocumentsDTO>(dt),
                ["AgreementsDTO"] = dt => registration.AgreementsDTO = Mapper.BindData<AgreementsDTO>(dt)
            };

            foreach (var data in automationDatas)
            {
                if (map.TryGetValue(data.SectionName, out var binder))
                {
                    binder(data.automationContents);
                }
            }

            return registration;
        }

        private static Models.PA.DentalPA BuildDentalPA(List<AutomationData> automationDatas)
        {
            var dentalPA = new Models.PA.DentalPA();

            var map = new Dictionary<string, Action<List<AutomationContent>>>
            {
                ["DentalInformation"] = dt => dentalPA.DentalInformation = Mapper.BindData<DentalInformation>(dt),
                ["DentalRecipientInformation"] = dt => dentalPA.DentalRecipientInformation = Mapper.BindData<DentalRecipientInformation>(dt),
                ["DentalContactInformation"] = dt => dentalPA.DentalContactInformation = Mapper.BindData<DentalContactInformation>(dt),
                ["DentalServiceInformation"] = dt => dentalPA.DentalServiceInformation = Mapper.BindData<DentalServiceInformation>(dt),
                ["DentalServiceProviderInformation"] = dt => dentalPA.DentalServiceProviderInformation = Mapper.BindData<DentalServiceProviderInformation>(dt),
                ["DentalOrderingProviderInformation"] = dt => dentalPA.DentalOrderingProviderInformation = Mapper.BindData<DentalOrderingProviderInformation>(dt),
                ["DentalDiagnosisInformation"] = dt => dentalPA.DentalDiagnosisInformation = Mapper.BindData<DentalDiagnosisInformation>(dt),
                ["DentalServiceDetails"] = dt => dentalPA.DentalServiceDetails = Mapper.BindData<DentalServiceDetails>(dt),
                ["DentalProviderNotes"] = dt => dentalPA.DentalProviderNotes = Mapper.BindData<DentalProviderNotes>(dt),
                ["DentalAttachments"] = dt => dentalPA.DentalAttachments = Mapper.BindData<DentalAttachments>(dt)
            };

            foreach (var data in automationDatas)
            {
                if (map.TryGetValue(data.SectionName, out var binder))
                {
                    binder(data.automationContents);
                }
            }

            return dentalPA;
        }

        private static T BindSingle<T>(List<AutomationData> automationDatas, string sectionName)
        {
            var data = automationDatas.FirstOrDefault(d => d.SectionName == sectionName);
            return data != null ? Mapper.BindData<T>(data.automationContents) : default;
        }

    }
}