using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace CCNet.Plugins.Labellers.Specs
{
    // Use cases from: http://www.codinghorror.com/blog/2007/02/whats-in-a-version-number-anyway.html

    public class when_encoding_date_on_17_oct_2005_for_product_started_in_2003 : OfficeLikeLabellerContext
    {
        Establish context = () =>
            _labeller.StartYear = 2003;

        Because of = () =>
            _result = _labeller.EncodeDate(new DateTime(2005, 10, 17));

        It should_result_in_3417 = () =>
            _result.ShouldEqual("3417");
    }

    public class when_encoding_date_on_10_jan_2005_for_product_started_in_2003 : OfficeLikeLabellerContext
    {
        Establish context = () =>
            _labeller.StartYear = 2003;

        Because of = () =>
            _result = _labeller.EncodeDate(new DateTime(2005, 01, 10));

        It should_result_in_2510 = () =>
            _result.ShouldEqual("2510");
    }

    public class when_encoding_date_on_23_jan_2004_for_product_started_in_2003 : OfficeLikeLabellerContext
    {
        Establish context = () =>
            _labeller.StartYear = 2003;

        Because of = () =>
            _result = _labeller.EncodeDate(new DateTime(2004, 01, 23));

        It should_result_in_1323 = () =>
            _result.ShouldEqual("1323");
    }

    public class when_encoding_date_on_08_aug_2003_for_product_started_in_2000 : OfficeLikeLabellerContext
    {
        Establish context = () =>
            _labeller.StartYear = 2000;

        Because of = () =>
            _result = _labeller.EncodeDate(new DateTime(2003, 08, 08));

        // Comments: For 5608 to work, "Month 1" for Office 2003 and XP would have been Jan 1999, 
        // Mal on February 16, 2007 7:52 AM
        It should_result_in_5608 = () =>
            _result.ShouldEqual("4408");
    }

    public class when_encoding_date_on_01_jan_2001_for_product_started_in_2001 : OfficeLikeLabellerContext
    {
        Establish context = () =>
            _labeller.StartYear = 2001;

        Because of = () =>
            _result = _labeller.EncodeDate(new DateTime(2001, 01, 01));

        It should_result_in_5608 = () =>
            _result.ShouldEqual("0101");
    }
}
