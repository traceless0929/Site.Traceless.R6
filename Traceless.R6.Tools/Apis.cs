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
        /// <summary>
        /// 获取基础信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pla"></param>
        /// <returns></returns>
        public static UserBaseInfoResp GetUserBaseInfo(string userName,string pla)
        {
            UserBaseInfoResp res =  Newtonsoft.Json.JsonConvert.DeserializeObject<UserBaseInfoResp>(TExtension.Tools.ToolClass.GetAPI(
                BASEURL + BASEINFO + "/" + userName + "/" + pla).Replace("[","").Replace("]","").Trim());
            return res;
        }

        public static UserDetailInfoResp GetUserDetailInfo(string userName, string pla)
        {
            UserBaseInfoResp res = GetUserBaseInfo(userName, pla);
            if (res != null)
            {
                UserDetailInfoResp userDetailInfoResp = TExtension.Tools.ToolClass.GetAPI<UserDetailInfoResp>(BASEURL + DETAILINFO + res.uplay_id);
                return userDetailInfoResp;
            }
            return null;
        }

    }
}
