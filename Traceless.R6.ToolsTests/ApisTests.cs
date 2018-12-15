using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traceless.R6.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traceless.R6.Tools.Models;

namespace Traceless.R6.Tools.Tests
{
    [TestClass()]
    public class ApisTests
    {
        [TestMethod()]
        public void GetUserBaseInfoTest()
        {
            UserBaseInfoResp res = Apis.GetUserBaseInfo("wantcnm.Tang", "pc");
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUserDetailInfoTest()
        {
            UserDetailInfoResp res = Apis.GetUserDetailInfo("wantcnm.Tang", "pc");
            Assert.Fail();
        }
    }
}