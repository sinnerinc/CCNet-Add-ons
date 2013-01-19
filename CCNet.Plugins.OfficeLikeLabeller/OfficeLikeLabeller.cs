using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThoughtWorks.CruiseControl.Core.Label;
using Exortech.NetReflector;
using ThoughtWorks.CruiseControl.Core;

namespace CCNet.Plugins.Labellers
{
    /// <summary>
    /// Office-like labeller inspired by following post of Jeff Atwood:
    /// http://www.codinghorror.com/blog/2007/02/whats-in-a-version-number-anyway.html
    /// </summary>
    [ReflectorType("officeLikeLabeller")]
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
            string encodedDate = EncodeDate();
            Version lastVersion = new Version(integrationResult.Label);

            int newRevisionNumber = lastVersion.Revision + 1;
            if (lastVersion.Major != Major ||
                lastVersion.Minor != Minor ||
                lastVersion.Build.ToString() != encodedDate)
            {
                newRevisionNumber = 0;
            }

            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}.{1}.{2}.{3}",
                Major, Minor, encodedDate, newRevisionNumber);
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
