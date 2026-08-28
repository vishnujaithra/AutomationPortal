using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OpenQA.Selenium;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class GroupFacilityHospitalAffiliations : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public GroupFacilityHospitalAffiliations(IWebDriver webDriver, string RegID) : base(webDriver)
        {

            this.webDriver = webDriver;

            string url = this.webDriver.Url;

            if (!string.IsNullOrEmpty(RegID))
            {
                this.RegID = RegID;
            }
            else
            {
                var regIDTag = url.Split('?').Last();
                var regID = regIDTag.Split('=').Last();
                this.RegID = regID;
            }
        }
        #region Group Facility & Hospality Affiliations
        public IWebElement? RegistrationTitle
        {
            get
            {
                return Selenium.BaseComponents.Utilities.PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }
        public IWebElement AddGroupAffiliations
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_btnAdd"), null);
            }
        }
        public IWebElement GroupAffiliations_MedicaidID
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucPendingGroupAffiliations_txtMedicaidID"), null);
            }
        }
        public IWebElement GroupAffiliations_NPI
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucPendingGroupAffiliations_txtNPI"), null);
            }
        }
        public IWebElement GroupAffiliations_Save
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucPendingGroupAffiliations_btnSave"), null);
            }
        }
        public IWebElement GroupAffiliations_Cancel
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucPendingGroupAffiliations_btnCancel"), null);
            }
        }
        public IWebElement AddHospitalAffiliations
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ImageButton1"), null);
            }
        }
        public IWebElement PatientSetting_No
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_rblInpatientSetting_1"), null);
            }
        }
        public IWebElement PatientSetting_Yes
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_rblInpatientSetting_0"), null);
            }
        }
        public IWebElement HospitalPrivileges_No
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_rblHospitalPrivileges_1"), null);
            }
        }
        public IWebElement HospitalPrivileges_Yes
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_rblHospitalPrivileges_0"), null);
            }
        }
        public IWebElement HospitalPrivileges_Reason
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_txtHospitalPrivilegesReason"), null);
            }
        }
        public IWebElement PrimaryFacility
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_chkIsPrimaryFacility"), null);
            }
        }
        public IWebElement OhioMedicaidID
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_txtMedicaidIDSearch"), null);
            }
        }
        public IWebElement FacilityName
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_txtFacilityName"), null);
            }
        }
        public IWebElement Staffcategory
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_ddlStaffCategoryID"), null);
            }
        }
        public IWebElement StatusOfPrivileges
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_ddlAffiliationPrivilegesStatus"), null);
            }
        }
        public IWebElement StartDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_txtStart_Date"), null);
            }
        }
        public IWebElement RestrictedPrivileges_No
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_rblRestrictedPrivileges_1"), null);
            }
        }
        public IWebElement RestrictedPrivileges_Yes
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_rblRestrictedPrivileges_0"), null);
            }
        }
        public IWebElement RestrictedPrivileges_Reason
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_txtResponseComment"), null);
            }
        }
        
        public IWebElement HospitalAffiliation_Save
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_btnSave"), null);
            }
        }
        public IWebElement HospitalAffiliation_Cancel
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupAndFacility_{RegID}_ucHealthCareAffiliations_btnCancel"), null);
            }
        }
        #endregion
    }
}
