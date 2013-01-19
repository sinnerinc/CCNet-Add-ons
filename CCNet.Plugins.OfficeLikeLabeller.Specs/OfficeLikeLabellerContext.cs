using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace CCNet.Plugins.Labellers.Specs
{
    public class OfficeLikeLabellerContext
    {
        Establish context = () =>
            _labeller = new OfficeLikeLabeller();

        protected static string _result;
        protected static OfficeLikeLabeller _labeller;

    }
}
