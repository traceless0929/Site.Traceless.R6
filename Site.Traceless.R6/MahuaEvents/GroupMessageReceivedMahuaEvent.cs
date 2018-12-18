using Newbe.Mahua.MahuaEvents;
using System;
using Newbe.Mahua;
using Traceless.TExtension.Tools;
using Traceless.R6.Tools;
using Traceless.R6.Tools.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Site.Traceless.R6.MahuaEvents
{
    /// <summary>
    /// 群消息接收事件
    /// </summary>
    public class GroupMessageReceivedMahuaEvent
        : IGroupMessageReceivedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public GroupMessageReceivedMahuaEvent(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public void ProcessGroupMessage(GroupMessageReceivedContext context)
        {
            try
            {
                AnalysisMsg nowModel = new AnalysisMsg(context.Message);
                string cmd = nowModel.What.ToUpper();
                if (cmd == "R6战绩")
                {
                    UserDetailInfoResp res = Apis.GetUserDetailInfo(Apis.GetUserBaseInfo(nowModel.Who, "pc"));
                    if (res != null)
                    {
                        var gen = res.stats.FirstOrDefault().general;
                        var que = res.stats.FirstOrDefault().queue;
                        _mahuaApi.SendGroupMessage(context.FromGroup)
                            .Text($"[{res.progression.level}]{res.username}-刷包概率{res.progression.lootbox_probability} 的战绩如下:").Newline()
                            .Text($"总计：").Newline()
                            .Text($"KD(击杀/死亡):{gen.kd}({gen.kills}/{gen.deaths})").Newline()
                            .Text($"近战/穿透/致盲:{gen.melee_kills}/{gen.penetration_kills}/{gen.blind_kills}").Newline()
                            .Text($"胜负比(胜/负):{gen.wl}/{gen.wins}/{gen.losses}").Newline()
                            .Text($"休闲：").Newline()
                            .Text($"KD(击杀/死亡):{que.casual.kd}({que.casual.kills}/{que.casual.deaths})").Newline()
                            .Text($"胜负比(胜/负):{que.casual.wl}/{que.casual.wins}/{que.casual.losses}").Newline()
                            .Text($"排位：").Newline()
                            .Text($"KD(击杀/死亡):{que.ranked.kd}({que.ranked.kills}/{que.ranked.deaths})").Newline()
                            .Text($"胜负比(胜/负):{que.ranked.wl}/{que.ranked.wins}/{que.ranked.losses}").Newline()
                            .Text(@"详情:https://r6stats.com/zh/stats/" + res.uplay_id).Done();
                    }
                    else
                    {
                        _mahuaApi.SendGroupMessage(context.FromGroup)
                            .Text(@"[R6战绩]查无此人").Done();
                    }
                }
                else if(cmd=="R6排位")
                {
                    UserBaseInfoResp baseRes = Apis.GetUserBaseInfo(nowModel.Who, "pc");
                    UserSeasonResp res = Apis.GetUserSeasonInfo(baseRes);
                    if (res == null)
                    {
                        _mahuaApi.SendGroupMessage(context.FromGroup)
                            .Text(@"[R6战绩]查无此人").Done();
                    }
                    List<SeasonItem> infos = res.seasons.Getinfos().OrderByDescending(p => p.id).Take(3).ToList();
                    StringBuilder sb = new StringBuilder();
                    RegionsItem nowSeason = infos.FirstOrDefault().regions.getBest();
                    var rankItem = infos.FirstOrDefault().rankings;
                    sb.AppendLine($"[{baseRes.progressionStats.level}]{baseRes.username}-排名(全球/亚/美/欧):{rankItem.global}/{rankItem.apac}/{rankItem.ncsa}/{rankItem.emea}-MMR[{nowSeason.mmr}]-({nowSeason.prev_rank_mmr}/{nowSeason.next_rank_mmr})");
                    infos.ForEach(p =>
                    {
                        var item = p.regions.getBest();
                        sb.AppendLine($"赛季{p.id}[{p.name}]-最高:{Utils.ConvertToRankDes(item.max_rank)}-当前:{Utils.ConvertToRankDes(item.rank)}-能力值(修正){item.skill_mean}(±{item.skill_standard_deviation})");
                    });
                    _mahuaApi.SendGroupMessage(context.FromGroup)
                           .Text(sb.ToString())
                           .Text(@"详情:https://r6stats.com/zh/stats/" + res.uplay_id + "/seasons").Done();
                }
            }
            catch(Exception ex)
            {
                _mahuaApi.SendPrivateMessage("415206409").Text(ex.ToString()).Done();
            }
            // 不要忘记在MahuaModule中注册
        }
    }
}
