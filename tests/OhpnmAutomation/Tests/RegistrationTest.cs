using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium.BaseComponents;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.BaseComponents.Utilities;
using OhpnmAutomation.Pages.Registration;
using OhpnmAutomation.Models.Registration;
using SeleniumExtensions.Configurations;
using OhpnmAutomation.Pages;
using System.Data;
using OhpnmAutomation.Utilities;
using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;
using NUnit.Framework.Interfaces;

namespace OhpnmAutomation.Tests
{
    [TestFixture("ProviderAdmin")] // ProviderAdmin

    public class RegistrationTest : BaseFeatureFixture
    {


        public RegistrationTest(string profile) : base(profile)
        {

        }


        [Test]
        [Author("Vishnuvardhan Reddy")]
        [Category("IntegrationTests")]
        [System.ComponentModel.Description("Verify new provider creation flow")]
        [CancelAfter(600000)]
        public void CreateNewProvider()
        {
            string? filePath = (default(string));

            var param = TestContext.Parameters;

            string testName = TestContext.CurrentContext.Test.Name;

            #region Commented Code

            Models.Registration.Registration registration = (Models.Registration.Registration)DataRepository.GetAutomationData("Registration"); // DataRepository.GetRegistrationData();

            WebDriverWait wait = new WebDriverWait(TestWebDriver, TimeoutConfiguration.Element);
            try
            {
                NewProviderPage newProviderPage = new NewProviderPage(TestWebDriver);
                newProviderPage.NewProviderBtn().Click();
                newProviderPage.StandardType().Click();
                newProviderPage.IndividualType().Click();

                if (!newProviderPage.isNewProviderloaded())
                {
                    Assert.Fail("New Provider page is not loaded.");
                }

                NewProviderDTO newProviderDTO = registration.NewProviderDTO; //RegistrationData.GetNewProviderDTO();
                newProviderPage.SetNewProviderPage(newProviderDTO);

                newProviderPage.ProviderSavebtn.Click();

                newProviderPage.WaitUntilTaxonomyVisible();

                newProviderPage.SetTaxonomy(newProviderDTO.Taxonomy);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(newProviderPage.ProviderSavebtn)).Click();
                newProviderPage.WaitUntilLoaderDisappear();

                RegistrationPage registrationPage = new RegistrationPage(TestWebDriver);

                #region Provider Information

                if (!registrationPage.isRequiredMessageAppear)
                {
                    Helper.PrintScreenShot(TestWebDriver, "ProviderInfo");
                    ClickElementWhenClickable(wait, registrationPage.BtnNext);
                }
                else
                {
                    registrationPage.SetPracticeType("GENERAL HOSPITAL", wait);

                    registrationPage.SetOwnershipType("COUNTY (GOVT)", wait);

                    registrationPage.SetResident("No");
                    Helper.PrintScreenShot(TestWebDriver, "ProviderInfo");
                    ClickElementWhenClickable(wait, registrationPage.BtnNext);
                }



                #endregion

                #region Primary Contact Information

                ProviderContactInformation providerContactInformation = new ProviderContactInformation(TestWebDriver, registrationPage.RegID);

                if (providerContactInformation.RegistrationTitle != null && providerContactInformation.RegistrationTitle.Text == "Primary Contact Information")
                {
                    if (!registrationPage.isRequiredMessageAppear)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "PrimaryContactInformation");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        ProviderContactInfo providerContactInfo = registration.ProviderContactInfo; //RegistrationData.GetproviderContactInfo();
                        providerContactInformation.SetProviderContactInformation(providerContactInfo);
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.Id("ctl00_MainContent_ucPrimaryContactAddress_699695_btnHistory")));

                        ClickElementWhenClickable(wait, registrationPage.BtnNext);

                        ClickElementWhenClickable(wait, providerContactInformation.AddressConfirmationbtn);
                        Helper.PrintScreenShot(TestWebDriver, "PrimaryContactInformation");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }

                #endregion

                #region Credentialing Contact

                CredentailContactDTO credentailContactDTO = null;

                if (providerContactInformation.RegistrationTitle != null && providerContactInformation.RegistrationTitle.Text == "Credentialing Contact")
                {
                    if (registrationPage.RequiredMessage != null &&
                        registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && credentailContactDTO == null)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "CredentialingContact");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        // Fill Credential Contact information.
                        Helper.PrintScreenShot(TestWebDriver, "CredentialingContact");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }

                #endregion

                #region Primary Address Service
                PrimaryAddressService primaryAddressService = new PrimaryAddressService(TestWebDriver, registrationPage.RegID);
                if (primaryAddressService.RegistrationTitle != null && primaryAddressService.RegistrationTitle.Text == "Primary Service Address")
                {
                    if (!registrationPage.isRequiredMessageAppear)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "PrimaryAddressService");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        PrimaryAddressServiceDTO primaryAddressServiceDTO = registration.PrimaryAddressServiceDTO; //RegistrationData.GetPrimaryAddressServiceDTO();
                        primaryAddressService.SetPrimaryAddressInformation(primaryAddressServiceDTO);
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        ClickElementWhenClickable(wait, primaryAddressService.AddressConfirmationbtn);

                        Helper.PrintScreenShot(TestWebDriver, "PrimaryAddressService");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region Billing & Payment Address
                BillingAndPaymentAddress billingAndPaymentAddress = new BillingAndPaymentAddress(TestWebDriver, registrationPage.RegID);
                if (billingAndPaymentAddress.RegistrationTitle != null && billingAndPaymentAddress.RegistrationTitle.Text == "Billing & Payment Address")
                {
                    if (!registrationPage.isRequiredMessageAppear)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "BillingAndPaymentAddress");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        BillingAndPaymentAddressDTO billingAndPaymentAddressDTO = registration.BillingAndPaymentAddressDTO; // RegistrationData.GetBillingAndPaymentAddressDTO();

                        if (billingAndPaymentAddressDTO.isSameAsPracticeLocation == "Yes")
                        {
                            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(billingAndPaymentAddress.SameAsPracticeLocation)).Click();
                        }
                        else
                        {
                            billingAndPaymentAddress.SetBillingAddressInformation(billingAndPaymentAddressDTO);
                        }
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        ClickElementWhenClickable(wait, billingAndPaymentAddress.AddressConfirmationbtn);
                        Helper.PrintScreenShot(TestWebDriver, "BillingAndPaymentAddress");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region Correspondence Address
                CorrespondenceAddressDTO correspondenceAddressDTO = registration.CorrespondenceAddressDTO; //RegistrationData.GetCorrespondenceAddressDTO();
                CorrespondenceAddress correspondenceAddress = new CorrespondenceAddress(TestWebDriver, registrationPage.RegID);
                if (correspondenceAddress.RegistrationTitle != null && correspondenceAddress.RegistrationTitle.Text == "Correspondence Address")
                {
                    if (!registrationPage.isRequiredMessageAppear)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "CorrespondenceAddress");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        if (correspondenceAddressDTO.isSameAsPracticeLocation == "Yes")
                        {
                            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(correspondenceAddress.SameAsPracticeLocation)).Click();
                        }
                        else
                        {
                            correspondenceAddress.SetCorrespnodencAe(correspondenceAddressDTO);
                        }
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        ClickElementWhenClickable(wait, correspondenceAddress.AddressConfirmationbtn);

                        Helper.PrintScreenShot(TestWebDriver, "CorrespondenceAddress");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }

                #endregion

                #region Other Service Locations

                OtherServiceLocationsDTO OtherServiceLocationsDTO = registration.OtherServiceLocationsDTO; // RegistrationData.GetOtherServiceLocationsDTO();
                OtherServiceLocations otherServiceLocations = new OtherServiceLocations(TestWebDriver, registrationPage.RegID);
                if (otherServiceLocations.RegistrationTitle != null && otherServiceLocations.RegistrationTitle.Text == "Other Service Locations")
                {
                    if (!registrationPage.isRequiredMessageAppear && registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && OtherServiceLocationsDTO == null)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "OtherServiceLocations");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        ClickElementWhenClickable(wait, otherServiceLocations.AddOtherLocationBtn);
                        otherServiceLocations.SetOtherServiceLocations(OtherServiceLocationsDTO);
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        ClickElementWhenClickable(wait, otherServiceLocations.AddressConfirmationbtn);

                        Helper.PrintScreenShot(TestWebDriver, "OtherServiceLocations");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }

                #endregion

                #region Address 1099

                Adress1099 address1099Data = registration.Adress1099; // RegistrationData.GetAddress1099Information();
                Address1099 address1099 = new Address1099(TestWebDriver, registrationPage.RegID);
                if (address1099.RegistrationTitle != null && address1099.RegistrationTitle.Text == "1099 Address")
                {
                    if (!registrationPage.isRequiredMessageAppear && registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && address1099 == null)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "Address1099");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        if (address1099Data.SameBillingLocation == "Yes")
                        {
                            ClickElementWhenClickable(wait, address1099.SameBillingLocation);

                        }
                        else if (address1099Data.SamePracticeLocation == "Yes")
                        {
                            ClickElementWhenClickable(wait, address1099.SamePracticeLocation);
                        }
                        else
                        {
                            address1099.SetAddress1099Information(address1099Data);
                            ClickElementWhenClickable(wait, registrationPage.BtnNext);
                            ClickElementWhenClickable(wait, address1099.AddressConfirmationbtn);
                            Helper.PrintScreenShot(TestWebDriver, "Address1099");
                            ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        }

                    }
                }

                #endregion

                #region Home Office Address

                HomeOfficeAddressDTO homeOfficeAddressDTO = registration.HomeOfficeAddressDTO;  //RegistrationData.GetHomeOfficeAddressInformation();
                HomeOfficeAddress homeOfficeAddress = new HomeOfficeAddress(TestWebDriver, registrationPage.RegID);
                if (homeOfficeAddress.RegistrationTitle != null && homeOfficeAddress.RegistrationTitle.Text == "Home Office Address")
                {
                    if (!registrationPage.isRequiredMessageAppear && registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && homeOfficeAddressDTO == null)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "HomeOfficeAddress");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        if (homeOfficeAddressDTO.SamePracticeLocation == "Yes")
                        {
                            ClickElementWhenClickable(wait, homeOfficeAddress.SamePracticeLocation);
                        }
                        else
                        {
                            homeOfficeAddress.SetHomeOfficeInformation(homeOfficeAddressDTO);
                            ClickElementWhenClickable(wait, registrationPage.BtnNext);
                            ClickElementWhenClickable(wait, homeOfficeAddress.AddressConfirmationbtn);
                            Helper.PrintScreenShot(TestWebDriver, "HomeOfficeAddress");
                            ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        }

                    }
                }

                #endregion

                #region Specalities

                SpecialitiesDTO specialitiesDTO = registration.SpecialitiesDTO; //  RegistrationData.GetSpecialitiesInformation();
                Specialties specialties = new Specialties(TestWebDriver, registrationPage.RegID);
                if (specialties.RegistrationTitle != null && specialties.RegistrationTitle.Text == "Specialties")
                {
                    if (!registrationPage.isRequiredMessageAppear && registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && homeOfficeAddressDTO == null)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "Specalities");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        ClickElementWhenClickable(wait, specialties.AddSpecalities);
                        specialties.SetSpecalityInformation(specialitiesDTO);
                        Helper.PrintScreenShot(TestWebDriver, "Specalities");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);

                    }
                }

                #endregion

                #region Taxonomy Information

                TaxonomiesDTO taxonomiesDTO = registration.TaxonomiesDTO; // RegistrationData.GetTaxonomiesInformation();
                Taxonomies taxonomies = new Taxonomies(TestWebDriver, registrationPage.RegID);
                if (taxonomies.RegistrationTitle != null && taxonomies.RegistrationTitle.Text == "Taxonomies")
                {
                    if (!registrationPage.isRequiredMessageAppear && registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && taxonomies == null)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "TaxonomyInformation");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        if (taxonomies.TaxonomyTable != null && Convert.ToBoolean(taxonomiesDTO.AddNewtaxonomy) == false)
                        {
                            ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        }
                        else
                        {
                            ClickElementWhenClickable(wait, taxonomies.AddTaxonomyBtn);
                            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(taxonomies.AddTaxonomyBtn)).Click();
                            taxonomies.SetTaxonomyInformation(taxonomiesDTO);
                            Helper.PrintScreenShot(TestWebDriver, "TaxonomyInformation");
                            ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        }
                    }
                }

                #endregion

                #region Professional License

                ProfessionalLicenses professionalLicenseDTO = registration.ProfessionalLicenses; // RegistrationData.GetProfessionalLicenses();
                ProfessionalLicense professionalLicense = new ProfessionalLicense(TestWebDriver, registrationPage.RegID);
                if (professionalLicense.RegistrationTitle != null && professionalLicense.RegistrationTitle.Text == "Professional Licenses")
                {
                    if (!registrationPage.isRequiredMessageAppear && registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && professionalLicense == null)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "ProfessionalLicense");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        ClickElementWhenClickable(wait, professionalLicense.AddLicenseBtn);
                        // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(professionalLicense.AddLicenseBtn)).Click();
                        professionalLicense.SetProfessionalLicense(professionalLicenseDTO);



                        Helper.PrintScreenShot(TestWebDriver, "ProfessionalLicense");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region Board Certification

                BoardCertificateDTO boardCertificateDTO = registration.BoardCertificateDTO; // RegistrationData.GetBoardCertificateDTO();
                BoardCertificate boardCertificate = new BoardCertificate(TestWebDriver, registrationPage.RegID);
                if (boardCertificate.RegistrationTitle != null && boardCertificate.RegistrationTitle.Text == "Board Certification")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && Convert.ToBoolean(boardCertificateDTO.AddNewCertificate) == false)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "BoardCertification");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        ClickElementWhenClickable(wait, boardCertificate.AddBoardCertificate);
                        Helper.PrintScreenShot(TestWebDriver, "BoardCertification");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }

                #endregion

                #region CLIA Certifications
                CLIACertificationsDTO cLIACertificationsDTO = registration.CLIACertificationsDTO; //RegistrationData.GetCLIACertificationsDTO();
                CLIACertifications cLIACertifications = new CLIACertifications(TestWebDriver, registrationPage.RegID);
                if (cLIACertifications.RegistrationTitle != null && cLIACertifications.RegistrationTitle.Text == "CLIA Certifications")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && Convert.ToBoolean(cLIACertificationsDTO.AddNewCLIACertificate) == false)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "CLIACertifications");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        ClickElementWhenClickable(wait, cLIACertifications.AddCLIACertification);
                        Helper.PrintScreenShot(TestWebDriver, "CLIACertifications");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region MediCare Number
                MediCareNumberDTO mediCareNumberDTO = registration.MediCareNumberDTO; // RegistrationData.GetMediCareNumberDTO();
                MediCareNumber mediCareNumber = new MediCareNumber(TestWebDriver, registrationPage.RegID);
                if (mediCareNumber.RegistrationTitle != null && mediCareNumber.RegistrationTitle.Text == "Medicare Number")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && Convert.ToBoolean(mediCareNumberDTO.AddNewMediCareNumber) == false)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "MediCareNumber");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        ClickElementWhenClickable(wait, mediCareNumber.AddMediCareNumber);
                        Helper.PrintScreenShot(TestWebDriver, "MediCareNumber");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region Group Facility & Hospital Affiliations
                GroupFacilityHospital groupFacilityDTO = registration.GroupFacilityHospital; // RegistrationData.GetGroupFacilityHospitalAffiliationsDTO();
                GroupFacilityHospitalAffiliations groupFacility = new GroupFacilityHospitalAffiliations(TestWebDriver, registrationPage.RegID);
                if (mediCareNumber.RegistrationTitle != null && mediCareNumber.RegistrationTitle.Text == "Group, Facility & Hospital Affiliations (Individual)")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && Convert.ToBoolean(groupFacilityDTO.AddFacility) == false)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "GroupFacilityANDHospitalAffiliations");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        ClickElementWhenClickable(wait, groupFacility.AddGroupAffiliations);
                        Helper.PrintScreenShot(TestWebDriver, "GroupFacilityANDHospitalAffiliations");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region MCP Affiliation
                MCPAffiliationDTO mcpAffiliationDTO = registration.MCPAffiliationDTO; //RegistrationData.GetMCPAffiliationDTO();
                MCPAffiliation mcpAffiliation = new MCPAffiliation(TestWebDriver, registrationPage.RegID);
                if (mcpAffiliation.RegistrationTitle != null && mcpAffiliation.RegistrationTitle.Text == "MCP Affiliation")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && Convert.ToBoolean(mcpAffiliationDTO.AddMCPAffiliation) == false)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "MCPAffiliation");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        ClickElementWhenClickable(wait, mcpAffiliation.ManagedCarePlans_No);
                        Helper.PrintScreenShot(TestWebDriver, "MCPAffiliation");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region State CDS Number
                StateCDSNumberDTO stateCDSNumberDTO = registration.StateCDSNumberDTO; //RegistrationData.GetStateCDSNumberDTO();
                StateCDSNumber stateCDSNumber = new StateCDSNumber(TestWebDriver, registrationPage.RegID);
                if (stateCDSNumber.RegistrationTitle != null && stateCDSNumber.RegistrationTitle.Text == "State CDS Number")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && Convert.ToBoolean(stateCDSNumberDTO.AddStateCDSNumber) == false)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "StateCDSNumber");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        ClickElementWhenClickable(wait, stateCDSNumber.AddStateCDSNumber);
                        Helper.PrintScreenShot(TestWebDriver, "StateCDSNumber");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region Federal DEA Registration
                FederalDEARegistrationDTO federalDEARegistrationDTO = registration.FederalDEARegistrationDTO; // RegistrationData.GetFederalDEARegistrationDTO();
                FederalDEARegistration federalDEARegistration = new FederalDEARegistration(TestWebDriver, registrationPage.RegID);
                if (federalDEARegistration.RegistrationTitle != null && federalDEARegistration.RegistrationTitle.Text == "Federal DEA Registration")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button.")
                    {
                        Helper.PrintScreenShot(TestWebDriver, "FederalDEARegistration");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        federalDEARegistration.SetFederalDEARegistrationInformation(federalDEARegistrationDTO);
                        Helper.PrintScreenShot(TestWebDriver, "FederalDEARegistration");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region Professional Liability Insurance
                ProfessionalLiabilityInsurance professionalLiabilityInsuranceDTO = registration.ProfessionalLiabilityInsurance; //  RegistrationData.GetProfessionalLiabilityInsuranceDTO();
                ProfessionalLiabilityInsurancePage professionalLiabilityInsurance = new ProfessionalLiabilityInsurancePage(TestWebDriver, registrationPage.RegID);
                if (professionalLiabilityInsurance.RegistrationTitle != null && professionalLiabilityInsurance.RegistrationTitle.Text == "Professional Liability Insurance")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button.")
                    {
                        Helper.PrintScreenShot(TestWebDriver, "ProfessionalLiabilityInsurance");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(professionalLiabilityInsurance.AddNewInsurance)).Click();
                        professionalLiabilityInsurance.SetProfessionalLiabilityInsurance(professionalLiabilityInsuranceDTO);
                        Helper.PrintScreenShot(TestWebDriver, "ProfessionalLiabilityInsurance");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region Education
                EducationDTO educationDTO = registration.EducationDTO;// RegistrationData.GetEducationDTO();
                Education education = new Education(TestWebDriver, registrationPage.RegID);
                if (education.RegistrationTitle != null && education.RegistrationTitle.Text == "Education")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button.")
                    {
                        Helper.PrintScreenShot(TestWebDriver, "Education");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(education.AddEducation)).Click();
                        education.SetEducationDetails(educationDTO);
                        Helper.PrintScreenShot(TestWebDriver, "Education");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region MalPractice Claims History
                MalPracticeClaimsHistoryDTO malPracticeClaimsHistoryDTO = registration.MalPracticeClaimsHistoryDTO; // RegistrationData.GetMalPracticeClaimsHistoryDTO();
                MalPracticeClaimsHistory malPracticeClaimsHistory = new MalPracticeClaimsHistory(TestWebDriver, registrationPage.RegID);
                if (malPracticeClaimsHistory.RegistrationTitle != null && malPracticeClaimsHistory.RegistrationTitle.Text == "Malpractice Claims History")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button.")
                    {
                        Helper.PrintScreenShot(TestWebDriver, "MalPracticeClaimsHistory");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(malPracticeClaimsHistory.AddNewClaims)).Click();
                        malPracticeClaimsHistory.SetMalPracticeClaimsHistory(malPracticeClaimsHistoryDTO);
                        Helper.PrintScreenShot(TestWebDriver, "MalPracticeClaimsHistory");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region Work History
                WorkHistoryDTO workHistoryDTO = registration.WorkHistoryDTO; // RegistrationData.GetWorkHistoryDTO();
                WorkHistory workHistory = new WorkHistory(TestWebDriver, registrationPage.RegID);
                if (workHistory.RegistrationTitle != null && workHistory.RegistrationTitle.Text == "Work History")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button.")
                    {
                        Helper.PrintScreenShot(TestWebDriver, "WorkHistory");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        Thread.Sleep(3000);
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(workHistory.AddWorkHistory)).Click();
                        workHistory.SetWorkHistory(workHistoryDTO);
                        Thread.Sleep(3000);
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(workHistory.AddGapHistory)).Click();
                        Thread.Sleep(3000);
                        workHistory.SetGapHistoryDetails(workHistoryDTO);
                        Thread.Sleep(3000);
                        Helper.PrintScreenShot(TestWebDriver, "WorkHistory");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region W9 Form

                W9FormDTO w9FormDTO = registration.W9FormDTO; // RegistrationData.GetW9FormDTO();

                filePath = w9FormDTO.FilePath;

                W9Form w9Form = new W9Form(TestWebDriver, registrationPage.RegID);
                if (w9Form.RegistrationTitle != null && w9Form.RegistrationTitle.Text == "W9 Form")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button.")
                    {
                        Helper.PrintScreenShot(TestWebDriver, "W9Form");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        try
                        {
                            w9Form.SetW9FormDetails(w9FormDTO);
                            ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        }
                        catch
                        {
                            Thread.Sleep(4000);
                            w9Form.SetW9FormDetails(w9FormDTO);
                            ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        }

                        // w9Form.WaitUntilImgProgressDisappear();

                        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(w9Form.FileDownload));
                        //Console.WriteLine("W9 Form is Executed Succesfully");
                        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(w9Form.ETFBankingImage)).Click();
                        //Console.WriteLine("EFT Banking button is Clicked Succesfully");
                        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(w9Form.PopUp_Confirmation)).Click();
                        //Console.WriteLine("Pop up Button is clicked");
                        Helper.PrintScreenShot(TestWebDriver, "W9Form");
                    }
                }
                #endregion

                #region EFT Banking Information
                EFTBankingDTO eFTBankingDTO = registration.EFTBankingDTO; // RegistrationData.GetEFTBankingDTO();
                EFTBanking eFTBanking = new EFTBanking(TestWebDriver, registrationPage.RegID);
                if (eFTBanking.RegistrationTitle != null && eFTBanking.RegistrationTitle.Text == "EFT Banking Information")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && Convert.ToBoolean(eFTBankingDTO.AddDateToPage) == false)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "EFTBankingInformation");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        eFTBanking.SelectEFTBankingOptions(eFTBankingDTO);
                        if (eFTBankingDTO.SupplementalPoolPayments == "Yes")
                        {
                            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(eFTBanking.AddBankingInformation)).Click();
                            eFTBanking.SetBankingInformation(eFTBankingDTO);

                            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(eFTBanking.AddEFTContact)).Click();
                            eFTBanking.SetEFTInformation(eFTBankingDTO);
                            eFTBanking.ConfirmInformation.Click();
                            Helper.PrintScreenShot(TestWebDriver, "EFTBankingInformation");
                            ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        }
                        else
                        {
                            Helper.PrintScreenShot(TestWebDriver, "EFTBankingInformation");
                            ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        }

                    }
                }
                #endregion

                #region Required Documents
                RequiredDocumentsDTO requiredDocumentsDTO = registration.RequiredDocumentsDTO; // RegistrationData.GetRequiredDocumentsDTO();
                RequiredDocuments requiredDocuments = new RequiredDocuments(TestWebDriver, registrationPage.RegID);
                if (requiredDocuments.RegistrationTitle != null && requiredDocuments.RegistrationTitle.Text == "Required Documents")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button." && Convert.ToBoolean(requiredDocumentsDTO.AddDetailsOnPage) == false)
                    {
                        Helper.PrintScreenShot(TestWebDriver, "RequiredDocuments");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        // requiredDocuments.SetRequiredDocument(requiredDocumentsDTO);
                        Helper.PrintScreenShot(TestWebDriver, "RequiredDocuments");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                }
                #endregion

                #region Agreements
                AgreementsDTO agreementsDTO = registration.AgreementsDTO; // RegistrationData.GetAgreementsDTO();
                Agreements agreements = new Agreements(TestWebDriver, registrationPage.RegID);
                if (agreements.RegistrationTitle != null && agreements.RegistrationTitle.Text == "Agreements")
                {
                    if (registrationPage.RequiredMessage != null && registrationPage.RequiredMessage.Text == "This is not a required section. To skip this section click on Next button.")
                    {
                        Helper.PrintScreenShot(TestWebDriver, "Agreements");
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                    }
                    else
                    {
                        agreements.SetAgreemntsInformationForAnestesia(agreementsDTO);
                        ClickElementWhenClickable(wait, registrationPage.BtnNext);
                        Thread.Sleep(3000);
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(agreements.ReviewModelPopup));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(agreements.ReviewModelPopupOK)).Click();
                    }
                }
                Helper.PrintScreenShot(TestWebDriver, "SubmitForReview");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(registrationPage.BtnSubmitForReview)).Click();

                SubmissionConfirmation submissionConfirmation = new SubmissionConfirmation(TestWebDriver);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(submissionConfirmation.btnReturnToHome)).Click();

                ProviderHomeNew providerHomeNew = new ProviderHomeNew(TestWebDriver, registrationPage.RegID);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(providerHomeNew.RegIDFilterTextBox)).Set(registrationPage.RegID, true);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(providerHomeNew.RegIDFilter)).Click();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(providerHomeNew.RegIDFilterEqualsTo)).Click();
                Helper.PrintScreenShot(TestWebDriver, "ProviderHome");


                #endregion
                string regId = registrationPage.RegID;



                LogOut();
                LoginByProfile(Roles.StateAdmin);

                WorkflowPage workflowPage = new WorkflowPage(TestWebDriver, regId);
                workflowPage.RunWorkflow();

                LoginByProfile(Roles.EnrollementSpecialist);

                MyQueue MyQueue = new MyQueue(TestWebDriver, registrationPage.RegID);

                MyQueue.WaitUntilElementIsVisible();

                MyQueue.SidebarMenu.Click();


                if (MyQueue.ProviderSearch != null)
                {
                    MyQueue.ProviderSearch.Click();
                }

                GroupReview GroupReview = new GroupReview(TestWebDriver, registrationPage.RegID);
                GroupReview.txtRegID.Set(regId);
                GroupReview.Search.Click();
                GroupReview.WaitUntilRowCountIsVisible();
                GroupReview.Review.Click();


                RegistrationPage Registration = new RegistrationPage(TestWebDriver);

                Registration.WaitUntilPageLoad();

                if (!Registration.IsPanelExpandedByStyle(TestWebDriver))
                {
                    Registration.Less.Click();
                }

                Registration.SetAssignmentUser();

                Registration.SidebarMenu.Click();
                Registration.NavigateToMyQueue();


                PageHelper.WaitUntilElementIsVisible(TestWebDriver, By.XPath("//h2[text()='Work Items Summary']"), TimeoutConfiguration.Element);


                bool screeningClicked = false;


                GetQueueLinkByTaskName(regId, Tasks.ProviderScreening, ref screeningClicked);

                if (screeningClicked)
                    ApproveProviderScreening(regId, filePath);


                bool providerReviewClicked = false;

                GetQueueLinkByTaskName(regId, Tasks.ProviderReview, ref providerReviewClicked);

                bool isApplicationSubmitted = false;

                if (providerReviewClicked)
                {
                    Registration = new RegistrationPage(TestWebDriver);

                    Registration.WaitUntilPageLoad();

                    while (!isApplicationSubmitted)
                    {

                        if (GetRegistrationTitle() != null && GetRegistrationTitle().Text == OhpnmAutomation.Utilities.Pages.NPIAndMedID)
                        {
                            NPIAndMedID nPIAndMedID = new NPIAndMedID(TestWebDriver, regId);
                            nPIAndMedID.UpdateEffectiveDate();
                        }
                        else if (GetRegistrationTitle() != null && GetRegistrationTitle().Text == OhpnmAutomation.Utilities.Pages.ApplicationDisposition)
                        {
                            ConfirmSpecialtyPopupIfDisplayed(TestWebDriver);
                            TimeSpan timeout = TimeSpan.FromSeconds(10);
                            var applicationCompleteBtn = Registration.WaitForApplicationCompleteButton(TestWebDriver, timeout);



                            if (applicationCompleteBtn != null)
                            {
                                applicationCompleteBtn.Click();
                            }
                            else
                            {
                                Assert.Fail("Application Complete button was not found or not enabled.");
                            }

                            isApplicationSubmitted = true;
                            break;
                        }

                        Registration.BtnApprove.Click();
                    }
                }

                LoginByProfile(Roles.StateAdmin);

                workflowPage = new WorkflowPage(TestWebDriver, regId);
                workflowPage.RunWorkflow();

                LoginByProfile(Roles.StateAdmin);

                GroupReview = new GroupReview(TestWebDriver, regId);
                GroupReview.SidebarMenu.Click();
                GroupReview.ProviderSearch.Click();

                GroupReview.txtRegID.Set(regId);
                GroupReview.Search.Click();

                TestContext.WriteLine($"{testName} is successfully executed and newly Created RegId is::{regId}");

            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"{testName}- failed:{ex.Message}");
                Assert.Fail($"{testName}- failed:{ex.Message}");

                TestWebDriver.Close();
                TestWebDriver.Quit();
                TestWebDriver.Dispose();
                TestWebDriver = null;
            }
            #endregion
        }

        private void ClickElementWhenClickable(WebDriverWait wait, IWebElement element, int retryCount = 3)
        {
            for (int attempt = 0; attempt < retryCount; attempt++)
            {
                try
                {
                    wait.Until(driver => element.Displayed && element.Enabled);

                    ((IJavaScriptExecutor)TestWebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

                    try
                    {
                        element.Click();
                    }
                    catch (ElementClickInterceptedException)
                    {
                        ((IJavaScriptExecutor)TestWebDriver).ExecuteScript("arguments[0].click();", element);
                    }

                    return; // Success
                }
                catch (StaleElementReferenceException)
                {
                    if (attempt == retryCount - 1)
                    {
                        throw; // Cannot recover after retries
                    }
                    // Optionally wait a short time before retrying to give page time to stabilize
                    System.Threading.Thread.Sleep(200);
                }
            }
        }

        private void GetQueueLinkByTaskName(string regId, string taskName, ref bool screeningClicked)
        {
            bool isBroken = false;

            var gridView = TestWebDriver.FindElement(By.Id("ctl00_MainContent_gvAssignedDetail"));
            if (gridView != null)
            {
                var rows = gridView.FindElements(By.TagName("tr"));

                if (rows != null && rows.Count() > 0)
                {
                    foreach (var row in rows)
                    {
                        var columns = row.FindElements(By.TagName("td"));

                        foreach (var column in columns)
                        {
                            if (column.Text == regId)
                            {
                                if (taskName == "Provider Screening")
                                {
                                    IWebElement screening = columns.Where(c => c.Text == taskName).SingleOrDefault();

                                    if (screening != null)
                                    {
                                        screening.Click();
                                        screeningClicked = true;
                                        isBroken = true;
                                        break;
                                    }
                                }
                                else if (taskName == "Provider Review")
                                {
                                    IWebElement providerReview = columns.Where(c => c.Text == taskName).SingleOrDefault();

                                    if (providerReview != null)
                                    {
                                        providerReview.Click();
                                        screeningClicked = true;
                                        isBroken = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (isBroken)
                            break;
                    }
                }
            }
        }


        public bool IsSpecialtiesConfirmModalDisplayed(IWebDriver driver)
        {
            try
            {
                IWebElement modal = driver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_pnlspecialityConfirmMP"));
                return modal.Displayed;
            }
            catch (NoSuchElementException)
            {
                // Modal element not found, so not displayed
                return false;
            }
        }
        private void ApproveProviderScreening(string regId, string filePath)
        {
            IWebElement provideScreener = TestWebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitlePS"));

            if (provideScreener == null || provideScreener.Text != "Provider Screening")
            {

            }

            IWebElement elem = TestWebDriver.FindElement(By.XPath($"//*[@id='ctl00_MainContent_ucScreeningSteps_{regId}_ucScreeningActivities_grdScreeningDetails']"));

            ////*[@id="ctl00_MainContent_ucScreeningSteps_597969_ucScreeningActivities_grdScreeningDetails"]

            if (PageHelper.IsElementIsVisible(TestWebDriver, By.XPath($"//*[@id='ctl00_MainContent_ucScreeningSteps_{regId}_ucScreeningActivities_grdScreeningDetails']"), TimeoutConfiguration.Element))
            {
                var screeningDetails = TestWebDriver.FindElement(By.XPath($"//*[@id='ctl00_MainContent_ucScreeningSteps_{regId}_ucScreeningActivities_grdScreeningDetails']"));
                VerifyLicenseStatus(screeningDetails, regId, filePath);
            }

            if (PageHelper.IsElementIsVisible(TestWebDriver, By.XPath($"//*[@id='ctl00_MainContent_ucRegistrationNavigation_btnTakeAction']"), TimeoutConfiguration.Element))
            {
                TestWebDriver.FindElement(By.XPath("//*[@id='ctl00_MainContent_ucRegistrationNavigation_btnTakeAction']")).Click();

                PageHelper.WaitUntilElementIsVisible(TestWebDriver, By.XPath("//*[@id='ctl00_MainContent_ucRegistrationNavigation_lblMpeTitle']"), TimeoutConfiguration.Element);

                TestWebDriver.FindElement(By.XPath("//*[@id='ctl00_MainContent_ucRegistrationNavigation_chkScreeningComplete']")).Click();

                TestWebDriver.FindElement(By.XPath("//*[@id='ctl00_MainContent_ucRegistrationNavigation_btnSavempe']")).Click();
            }

            if (PageHelper.IsElementIsVisible(TestWebDriver, By.XPath("//*[@id='ctl00_rptWorkflowActions_ctl00_btnAction']"), TimeoutConfiguration.Element))
            {
                TestWebDriver.FindElement(By.XPath("//*[@id='ctl00_rptWorkflowActions_ctl00_btnAction']")).Click();
            }
        }

        private void VerifyLicenseStatus(IWebElement screeningDetails, string regId, string filePath)
        {
            if (screeningDetails != null)
            {
                var screening = screeningDetails.FindElements(By.TagName("tr"));

                if (screening != null && screening.Count() > 0)
                {
                    bool isBroken = false;
                    foreach (var row in screening)
                    {
                        if (isBroken)
                            break;

                        var columns = row.FindElements(By.TagName("td"));

                        foreach (var column in columns)
                        {

                            if (column.Text == "License Verification")
                            {
                                var columnss = row.FindElements(By.TagName("td"));

                                IWebElement? licensePending = columnss.Where(c => c.Text == "Pending").FirstOrDefault();

                                if (licensePending != null)
                                {
                                    IWebElement acnhorElement = licensePending.FindElement(By.TagName("a"));
                                    Thread.Sleep(1000);

                                    acnhorElement.Click();

                                    Thread.Sleep(1000);

                                    IWebElement matchResultsElem = TestWebDriver.FindElement(By.XPath($"//*[@id='ctl00_MainContent_ucScreeningSteps_{regId}_ucScreeningResult_ddlMatchResults']"));

                                    if (matchResultsElem != null)
                                    {

                                    }

                                    SelectElement verificationResults = new SelectElement(TestWebDriver.FindElement(By.XPath($"//*[@id='ctl00_MainContent_ucScreeningSteps_{regId}_ucScreeningResult_ddlMatchResults']")));
                                    verificationResults.SelectByText("Verified");

                                    Thread.Sleep(1000);

                                    TestWebDriver.FindElement(By.XPath($"//*[@id='ctl00_MainContent_ucScreeningSteps_{regId}_ucScreeningResult_txtAdverseAction']")).Set("Test", true);

                                    IWebElement fileUploadElement = PageHelper.FindElement(TestWebDriver, By.XPath($"//*[@id='ctl00_MainContent_ucUploadDocument_filUploadFile']"), null);

                                    if (fileUploadElement != null)
                                    {
                                        fileUploadElement.SendKeys(filePath);
                                        Thread.Sleep(4000);

                                        TestWebDriver.FindElement(By.XPath($"//*[@id='ctl00_MainContent_ucUploadDocument_UploadButton']")).Click();

                                        Thread.Sleep(3000);

                                        PageHelper.WaitUntilElementIsVisible(TestWebDriver, By.XPath("//*[@id='ctl00_MainContent_ucUploadDocument_gvUploadedDocs']"), TimeoutConfiguration.Element);

                                        TestWebDriver.FindElement(By.XPath($"//*[@id='ctl00_MainContent_ucScreeningSteps_{regId}_ucScreeningResult_btnConfirm']")).Click();

                                        Thread.Sleep(4000);

                                        var newScreeningDetails = TestWebDriver.FindElement(By.XPath($"//*[@id='ctl00_MainContent_ucScreeningSteps_{regId}_ucScreeningActivities_grdScreeningDetails']"));
                                        isBroken = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }


        }

        private IWebElement GetRegistrationTitle()
        {
            IWebElement element = PageHelper.IsElementExist(TestWebDriver, By.XPath("//*[@id='ctl00_MainContent_ucRegistrationNavigation_lblTitlePS']")) ?
                   TestWebDriver.FindElement(By.XPath("//*[@id='ctl00_MainContent_ucRegistrationNavigation_lblTitlePS']")) : null;

            if (element != null)
            {
                return element;
            }
            return null;
        }

        private bool RunWorkflow(string regId)
        {

            bool status = false;

            TestWebDriver.FindElement(By.Id("menu")).Click();

            PageHelper.WaitUntilElementIsVisible(TestWebDriver, By.XPath($"//a[@title='Workflow Engine']"), TimeoutConfiguration.Element);

            IWebElement workflowSearch = TestWebDriver.FindElement(By.XPath($"//a[@title='Workflow Engine']"));

            if (workflowSearch != null)
            {
                workflowSearch.Click();
            }

            PageHelper.WaitUntilElementIsVisible(TestWebDriver, By.XPath($"//*[@id='btnRefresh']"), TimeoutConfiguration.Element);

            WebDriverWait wait = new WebDriverWait(TestWebDriver, TimeoutConfiguration.Element);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='gvAwaitingAction_ctl00_ctl02_ctl02_FilterTextBox_REGISTRATION_ID']"))).Set(regId, true);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='gvAwaitingAction_ctl00_ctl02_ctl02_Filter_REGISTRATION_ID']"))).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id='gvAwaitingAction_rfltMenu_detached']/ul/li/a[span[text()='EqualTo']]"))).Click();

            bool isRecordProcessed = false;
            bool isNoRecordsFound = false;

            while (!isRecordProcessed)
            {
                try
                {
                    IWebElement resultGridMain = TestWebDriver.FindElement(By.XPath("//*[@id='gvAwaitingAction_ctl00']//tr[contains(@class,'rgNoRecords')]"));
                    if (resultGridMain != null || resultGridMain.IsElementVisible())
                    {
                        isNoRecordsFound = true;
                        isRecordProcessed = true;
                    }
                }
                catch
                {

                }
                if (!isNoRecordsFound)
                {
                    IWebElement resultGrid = TestWebDriver.FindElement(By.XPath("//*[@id='gvAwaitingAction_ctl00']//a[text()='Process']"));
                    if (resultGrid.IsElementVisible())
                        resultGrid.Click();
                    else
                        isRecordProcessed = true;
                }
            }
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id='btnLogout']"))).Click();
            return status;
        }


        private void ConfirmSpecialtyPopupIfDisplayed(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            By popupLocator = By.Id("ctl00_MainContent_ucRegistrationNavigation_pnlspecialityConfirmMP");

            bool popupDisplayed = false;
            try
            {
                popupDisplayed = wait.Until(d =>
                {
                    var popup = d.FindElement(popupLocator);
                    return popup.Displayed;
                });
            }
            catch (WebDriverTimeoutException)
            {
                popupDisplayed = false;
            }

            if (popupDisplayed)
            {
                IWebElement checkbox = driver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_chkSpecialityMP"));
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }

                IWebElement confirmButton = wait.Until(d =>
                {
                    var btn = d.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_btnSpecialityConfirmMP"));
                    return btn.Enabled ? btn : null;
                });

                confirmButton.Click();

                Console.WriteLine("Specialty Confirm popup handled: checkbox checked and Confirm clicked.");
            }
            else
            {
                Console.WriteLine("Specialty Confirm popup is not displayed.");
            }
        }
    }
}
