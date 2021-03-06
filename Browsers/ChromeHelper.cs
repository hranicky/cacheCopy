﻿using System;
using System.Collections.Generic;
using SYS = System.Environment;

namespace cacheCopy
{
    /// <summary>
    /// Helper class to detect Chrome browser
    /// </summary>
    class ChromeHelper : DefaultBrowser, IBrowserHelper
    {
        protected override List<string> GetListOfPossiblePaths()
        {
            List<String> paths = new List<String> 
            {	
                SYS.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Google\Chrome\User Data\Default\Cache\",
                SYS.GetEnvironmentVariable("USERPROFILE") + @"\Local Settings\Application Data\Google\Chrome\User Data\Default\Cache",

            };
            return paths;
        }

        protected override string GetBrowserName()
        {
            return "Chrome";
        }

        protected override bool UseOnlyFirstExisting()
        {
            return true;
        }
    }
}
