﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace cacheCopy
{

    /// <summary>
    /// Class - template for finding paths of the default browsers. Contains basic processing
    /// information. Child classes only need to provide name of the browser and list of possible cache locations.
    /// </summary>
    abstract class DefaultBrowser : IBrowserHelper
    {
        public List<ProfilePath> getProfiles()
        {
            List<String> paths = GetListOfPossiblePaths();

            // remove all invalid paths
            paths.RemoveAll(path => !Directory.Exists(path));

            // if nothing exists, return empty list
            if (paths.Count == 0)
                return new List<ProfilePath>();

            var profiles = from p in paths
                           select new ProfilePath(GetBrowserName(), p);

            return profiles.ToList<ProfilePath>();
        }


        /// <summary>
        /// Gets the list of possible paths.
        /// </summary>
        /// <returns></returns>
        protected abstract List<String> GetListOfPossiblePaths();


        /// <summary>
        /// Gets the name of the browser.
        /// </summary>
        /// <returns></returns>
        protected abstract String GetBrowserName(); 
    }
}
