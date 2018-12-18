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
        private const string BASEURL = @"https://r6stats.com/api/";
        private const string BASEINFO = @"player-search/";
        private const string DETAILINFO = @"stats/";
        private const string SEAAONINFO = @"/seasonal";
        /// <summary>
        /// 获取基础信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pla"></param>
        /// <returns></returns>
        public static UserBaseInfoResp GetUserBaseInfo(string userName,string pla)
        {
            UserBaseInfoResp res = new UserBaseInfoResp();
            try
            {
                res = Newtonsoft.Json.JsonConvert.DeserializeObject<UserBaseInfoResp>(TExtension.Tools
                    .ToolClass.GetAPI(
                        BASEURL + BASEINFO + "/" + userName + "/" + pla).Replace("[", "").Replace("]", "").Trim());
            }
            catch
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
                    UserDetailInfoResp userDetailInfoResp =
                        TExtension.Tools.ToolClass.GetAPI<UserDetailInfoResp>(BASEURL + DETAILINFO + res.uplay_id);
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
                        TExtension.Tools.ToolClass.GetAPI<UserSeasonResp>(BASEURL + DETAILINFO + res.uplay_id+ SEAAONINFO);
                    return userSeasonResp;
                }
            }
            catch
            {
                res = null;
            }

            return null;
        }

    }
}
