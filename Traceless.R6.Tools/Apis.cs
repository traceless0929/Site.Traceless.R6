using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traceless.R6.Tools.Models;

namespace Traceless.R6.Tools
{
    public class Apis
    {
        private const string BASEURL = @"https://api.xiaoheihe.cn/game/r6/";
        private const string BASEINFO = @"search/?q=";
        private const string DETAILINFO = @"get_player_overview/?player_id=";
        private const string SEAAONBASE = @"https://r6stats.com/api/stats/";
        private const string SEAAONINFO = @"/seasonal";
        /// <summary>
        /// 获取基础信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pla"></param>
        /// <returns></returns>
        public static UserBaseInfoResp GetUserBaseInfo(string userName)
        {
            UserBaseInfoResp res = new UserBaseInfoResp();
            try
            {
                res = Newtonsoft.Json.JsonConvert.DeserializeObject<UserBaseInfoResp>(TExtension.Tools.StringHelper.UnicodeDencode(TExtension.Tools.ToolClass.GetAPI(BASEURL + BASEINFO+userName)));
            }
            catch(Exception ex)
            {
                res = null;
            }
            
            return res;
        }
        /// <summary>
        /// 获取详细用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pla"></param>
        /// <returns></returns>

        public static UserDetailInfoResp GetUserDetailInfo(UserBaseInfoResp res)
        {
            try
            {
                if (res != null)
                {
                    UserDetailInfoResp userDetailInfoResp = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDetailInfoResp>(TExtension.Tools.StringHelper.UnicodeDencode(TExtension.Tools.ToolClass.GetAPI(BASEURL + DETAILINFO + res.result.player_list.FirstOrDefault().id)));
                    if (userDetailInfoResp.result.player == null)
                        return null;
                    return userDetailInfoResp;
                }
            }
            catch
            {
                res = null;
            }

            return null;
        }

        public static UserSeasonResp GetUserSeasonInfo(UserBaseInfoResp res)
        {
            try
            {
                if (res != null)
                {
                    UserSeasonResp userSeasonResp =
                        TExtension.Tools.ToolClass.GetAPI<UserSeasonResp>(SEAAONBASE + res.result.player_list.FirstOrDefault().id + SEAAONINFO);
                    return userSeasonResp;
                }
            }
            catch (Exception ex)
            {
                res = null;
            }

            return null;
        }
    }
}
