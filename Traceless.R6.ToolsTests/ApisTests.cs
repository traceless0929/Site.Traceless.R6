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
            UserBaseInfoResp res1 = Apis.GetUserBaseInfo("wantcnm.Tang", "pc");
            UserDetailInfoResp res = Apis.GetUserDetailInfo(res1);
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUserSeasonInfoTest()
        {
            UserBaseInfoResp baseRes = Apis.GetUserBaseInfo("wantcnm.Tang", "pc");
            UserSeasonResp res = Apis.GetUserSeasonInfo(baseRes);
            if (res == null)
            {
                return;
            }
            List<SeasonItem> infos = res.seasons.Getinfos().OrderByDescending(p => p.id).Take(3).ToList();
            StringBuilder sb = new StringBuilder();
            RegionsItem nowSeason = infos.FirstOrDefault().regions.getBest();
            sb.AppendLine($"[{baseRes.progressionStats.level}]{baseRes.username}-能力值(修正){nowSeason.skill_mean}(±{nowSeason.skill_standard_deviation})-{Utils.ConvertToRankDes(nowSeason.rank)}-MMR[{nowSeason.mmr}]-({nowSeason.prev_rank_mmr}/{nowSeason.next_rank_mmr})");
            infos.ForEach(p =>
            {
                var item = p.regions.getBest();
                sb.AppendLine($"赛季{p.id}[{p.name}]-最高:{Utils.ConvertToRankDes(item.max_rank)}-当前:{Utils.ConvertToRankDes(item.rank)}-能力值(修正){item.skill_mean}(±{item.skill_standard_deviation})");
            });
            Assert.Fail();
        }
    }
}