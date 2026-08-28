using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.BaseComponents.CommonPages
{
    interface ILoginPage
    {
       void Login(string loginUrl, string userName, string password);

    }
}
