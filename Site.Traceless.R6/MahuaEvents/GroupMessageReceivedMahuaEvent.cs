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
                    var ret = Apis.GetUserBaseInfo(nowModel.Who);
                    UserDetailInfoResp resp = Apis.GetUserDetailInfo(ret);
                    if (resp == null)
                    {
                        _mahuaApi.SendGroupMessage(context.FromGroup)
                            .Text(@"[R6战绩]查无此人").Done();
                        return;
                    }

                    var res = resp.result;
                    var gen = res.game_queues[0];
                    var rank= res.game_queues[1];
                    var cas= res.game_queues[2];
                    _mahuaApi.SendGroupMessage(context.FromGroup)
                        .Text($"[{res.player.level}]{res.player.nickname}-{res.player.update_desc}更新 战绩如下:").Newline()
                        .Text(Utils.ConvertToDetailStr(gen)).Newline().Newline()
                        .Text(Utils.ConvertToDetailStr(rank)).Newline().Newline()
                        .Text(Utils.ConvertToDetailStr(cas))
                        .Done();
                }
                else if(cmd=="R6排位")
                {
                    UserBaseInfoResp baseRes = Apis.GetUserBaseInfo(nowModel.Who);
                    UserSeasonResp res = Apis.GetUserSeasonInfo(baseRes);
                    if (res == null)
                    {
                        _mahuaApi.SendGroupMessage(context.FromGroup)
                            .Text(@"[R6排位]查无此人").Done();
                    }
                    List<SeasonItem> infos = res.seasons.Getinfos().OrderByDescending(p => p.id).Take(3).ToList();
                    StringBuilder sb = new StringBuilder();
                    RegionsItem nowSeason = infos.FirstOrDefault().regions.getBest();
                    var rankItem = infos.FirstOrDefault().rankings;
                    sb.AppendLine($"{baseRes.result.player_list.FirstOrDefault().name}-排名(全球/亚/美/欧):{rankItem.global}/{rankItem.apac}/{rankItem.ncsa}/{rankItem.emea}-MMR[{nowSeason.mmr}]-({nowSeason.prev_rank_mmr}/{nowSeason.next_rank_mmr})");
                    infos.ForEach(p =>
                    {
                        var item = p.regions.getBest();
                        sb.AppendLine($"[{p.name}]现/顶:{Utils.ConvertToRankDes(item.rank)}/{Utils.ConvertToRankDes(item.max_rank)}-能力:{item.skill_mean}(±{item.skill_standard_deviation})");
                    });
                    _mahuaApi.SendGroupMessage(context.FromGroup)
                        .Text(sb.ToString())
                        .Text(@"详情:https://r6stats.com/zh/stats/" + res.uplay_id + "/seasons").Done();
                }
                else if (cmd == "R6记录")
                {
                    var ret = Apis.GetUserBaseInfo(nowModel.Who);
                    UserDetailInfoResp resp = Apis.GetUserDetailInfo(ret);
                    if (resp == null)
                    {
                        _mahuaApi.SendGroupMessage(context.FromGroup)
                            .Text(@"[R6记录]查无此人").Done();
                        return;
                    }

                    var res = resp.result;
                    var hisItems = res.items.FirstOrDefault(p=>p.type== "matches");
                    StringBuilder sb = new StringBuilder();
                    foreach (var his in hisItems.content)
                    {
                        if (his.mode == "休闲")
                        {
                            sb.AppendLine(
                                $"[{his.mode}]-场次(胜/负){his.count}({his.win}/{his.lose})-KD(K/D){his.kd}({his.k}/{his.d})-{his.time}");
                        }
                        else
                        {
                            sb.AppendLine(
                                $"[{his.rating}{(his.trend=="down"?"↓":"↑")}({his.diff})]-场次(胜/负){his.count}({his.win}/{his.lose})-KD(K/D){his.kd}({his.k}/{his.d})-{his.time}");
                        }
                    }

                    _mahuaApi.SendGroupMessage(context.FromGroup)
                        .Text($"[{res.player.level}]{res.player.nickname}-{res.player.update_desc}更新 记录如下:").Newline()
                        .Text(sb.ToString().Trim()).Done();

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
