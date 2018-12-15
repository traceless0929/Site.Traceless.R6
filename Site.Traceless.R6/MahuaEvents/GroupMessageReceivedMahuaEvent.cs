using Newbe.Mahua.MahuaEvents;
using System;
using Newbe.Mahua;
using Traceless.TExtension.Tools;
using Traceless.R6.Tools;
using Traceless.R6.Tools.Models;
using System.Linq;

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
                if (nowModel.What.ToUpper() == "R6战绩")
                {
                    UserDetailInfoResp res = Apis.GetUserDetailInfo(nowModel.Who, "pc");
                    if (res != null)
                    {
                        var gen = res.stats.FirstOrDefault().general;
                        var que = res.stats.FirstOrDefault().queue;
                        _mahuaApi.SendGroupMessage(context.FromGroup)
                            .Text($"[{res.progression.level}]{res.username}-刷包概率{res.progression.lootbox_probability} 的战绩如下:").Newline()
                            .Text($"总计：").Newline()
                            .Text($"KD(击杀/死亡):{gen.kd}({gen.kills}/{gen.deaths})").Newline()
                            .Text($"近战/穿透/致盲:{gen.melee_kills}/{gen.penetration_kills}/{gen.blind_kills}").Newline()
                            .Text($"胜率(胜/负):{gen.wl}/{gen.wins}/{gen.losses}").Newline()
                            .Text($"休闲：").Newline()
                            .Text($"KD(击杀/死亡):{que.casual.kd}({que.casual.kills}/{que.casual.deaths})").Newline()
                            .Text($"胜率(胜/负):{que.casual.wl}/{que.casual.wins}/{que.casual.losses}").Newline()
                            .Text($"排位：").Newline()
                            .Text($"KD(击杀/死亡):{que.ranked.kd}({que.ranked.kills}/{que.ranked.deaths})").Newline()
                            .Text($"胜率(胜/负):{que.ranked.wl}/{que.ranked.wins}/{que.ranked.losses}").Newline()
                            .Text(@"详情:https://r6stats.com/zh/stats/" + res.uplay_id).Done();
                    }
                    else
                    {
                        _mahuaApi.SendGroupMessage(context.FromGroup)
                            .Text(@"[R6战绩]查无此人").Done();
                    }
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
