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
            UserBaseInfoResp res = TExtension.Tools.ToolClass.GetAPI<UserBaseInfoResp>(
                BASEURL + BASEINFO + "/" + userName + "/" + pla);
            return res;
        }

        public static UserDetailInfoResp GetUserDetailInfo(string userName, string pla)
        {
            UserBaseInfoResp res = TExtension.Tools.ToolClass.GetAPI<UserBaseInfoResp>(
                BASEURL + BASEINFO + "/" + userName + "/" + pla);
            if (res != null && res.data != null && res.data.Count() > 0)
            {
                UserBaseInfoResp.UserBaseItem userBaseItem = res.data.FirstOrDefault();
                UserDetailInfoResp userDetailInfoResp = TExtension.Tools.ToolClass.GetAPI<UserDetailInfoResp>(BASEURL + DETAILINFO + userBaseItem.uplay_id);
                return userDetailInfoResp;
            }
            return null;
        }

    }
}
