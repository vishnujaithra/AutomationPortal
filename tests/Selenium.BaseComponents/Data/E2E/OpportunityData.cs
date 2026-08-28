using System;

namespace BaseSelenium.BaseComponents.Data.DIT4
{
    public static class OpportunityData
    {
        const string CurrentEnvironment = Environment.DIT4;

        class Environment
        {
            public const string DIT4 = "dit4";
        }

        public static class OpportunityDetails
        {
            public const string loginURL = "https://test.salesforce.com";
            public const string OpportunityLink = "https://dell--" + CurrentEnvironment + ".lightning.force.com/lightning/o/Opportunity/list?filterName=Recent";

            public const string StandardOppty = "0061800000BSXRlAAP";
            public const string ChannelOppty = "0061800000Bi3cJAAR";
            public const string SMBOppty = "0061800000Bi3fIAAR";

            public const string classicEnvUrl = "https://dell--" + CurrentEnvironment + ".my.salesforce.com/";
            public const string LexRecordLink = "https://dell--" + CurrentEnvironment + ".lightning.force.com/lightning/r/";
            public const string Lighthomepage = "https://dell--dit4.lightning.force.com/lightning/page/home";
            public const string OpptyLexLink = LexRecordLink + "Opportunity/";
            public const string ProductLink = LexRecordLink + "OpportunityLineItem/00k18000005v486AAA/view";
            public const string OpportunityDetailExtraLink = LexRecordLink + "Opportunity_Details_Extra__c/aD5180000004RpTCAU/view";
            public const string CreateStandardOpportunityLink = classicEnvUrl + "006/e?00NA00000063VZx=&accid=&ent=Opportunity&nooverride=1&RecordType=012300000004zf2&retURL=%2F006%2Fo";
            public const string CreateChannelOpportunityLink = classicEnvUrl + "006/e?00NA00000063VZx=&accid=&ent=Opportunity&nooverride=1&RecordType=012A0000000Vjtg&retURL=%2F006%2Fo";
            public const string CreateSMBOpportunityLink = classicEnvUrl + "006/e?00NA00000063VZx=&accid=&ent=Opportunity&nooverride=1&RecordType=012A0000000Vhy7&retURL=%2F006%2Fo";
            public const string CreateStandardOpportunityLgthg = "https://dell--dit4.lightning.force.com/lightning/o/Opportunity/new?recordTypeId=012300000004zf2AAA&nooverride=1&navigationLocation=MRU_LIST&backgroundContext=%2Flightning%2Fpage%2Fhome&count=1";
            public const string CreateChannelOpportunityLgthg = "https://dell--dit4.lightning.force.com/lightning/o/Opportunity/new?recordTypeId=012300000004zf2AAA&nooverride=1&navigationLocation=MRU_LIST&backgroundContext=%2Flightning%2Fpage%2Fhome&count=1";
            public const string CreateSMBOpportunityLgthg = "https://dell--dit4.lightning.force.com/lightning/o/Opportunity/new?recordTypeId=012A0000000Vhy7IAC&nooverride=1&navigationLocation=MRU_LIST&backgroundContext=%2Flightning%2Fo%2FOpportunity%2Fnew%3ForiginalUrl%3Dhttps%253A%252F%252Fdell--dit4.lightning.force.com%252Fapex%252FNewOppOverride%253FnavigationLocation%253DMRU_LIST%2526lexiSObjectName%253DOpportunity%2526lexiActionName%253Dnew%2526sfdc.override%253D1%2526vfRetURLInSFX%253D%25252F006%25252Fo%26inContextOfRef%3D1.eyJ0eXBlIjoic3RhbmRhcmRfX29iamVjdFBhZ2UiLCJhdHRyaWJ1dGVzIjp7Im9iamVjdEFwaU5hbWUiOiJPcHBvcnR1bml0eSIsImFjdGlvbk5hbWUiOiJsaXN0In0sInN0YXRlIjp7ImZpbHRlck5hbWUiOiJSZWNlbnQifX0%253D%26count%3D4&count=5";
        }

    
    }
}