using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThoughtWorks.CruiseControl.Core.Label;
using Exortech.NetReflector;

namespace CCNet.Plugins.Labellers
{
    /// <summary>
    /// Office-like labeller inspired by following post of Jeff Atwood:
    /// http://www.codinghorror.com/blog/2007/02/whats-in-a-version-number-anyway.html
    /// </summary>
    public class OfficeLikeLabeller : LabellerBase
    {
        [ReflectorProperty("startYear", Required = true)]
        public int StartYear = 2003;

        [ReflectorProperty("major", Required = true)]
        public int Major = 0;

        [ReflectorProperty("minor", Required = true)]
        public int Minor = 0;

        public override string Generate(ThoughtWorks.CruiseControl.Core.IIntegrationResult integrationResult)
        {
            //ThoughtWorks.CruiseControl.Core.Util.Log.Debug("");
            
            throw new NotImplementedException();
        }

        /// <summary>
        /// Encode given date using StartYear and Office-like generating scheme.
        /// </summary>
        /// <param name="now">Date to be encoded. If null then Now is used.</param>
        /// <returns></returns>
        public string EncodeDate(DateTime? now = null)
        {
            if (!now.HasValue)
                now = DateTime.Now;

            var startDate = new DateTime(StartYear, 01, 01);
            int months = ((now.Value.Year - startDate.Year) * 12) + now.Value.Month - startDate.Month + 1;

            return string.Concat(months.ToString("00"), now.Value.Day.ToString("00"));
        }
    }
}
