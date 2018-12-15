﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.R6.Tools.Models
{
    public class UserBaseInfoResp
    {

        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 用户的UplayId
        /// </summary>
        public string uplay_id { get; set; }
        /// <summary>
        /// 用户的育碧id(目前是一样的)
        /// </summary>
        public string ubisoft_id { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 平台pc/ps4/xbox
        /// </summary>
        public string platform { get; set; }
        /// <summary>
        /// ？？？大概是是不是被封号了？
        /// </summary>
        public bool avatar_banned { get; set; }
        /// <summary>
        /// 等级信息
        /// </summary>
        public Progressionstats progressionStats { get; set; }
        /// <summary>
        /// 对局数据概况
        /// </summary>
        public Genericstats genericStats { get; set; }

        public class Progressionstats
        {
            /// <summary>
            /// 等级
            /// </summary>
            public int level { get; set; }
        }

        public class Genericstats
        {
            /// <summary>
            /// 击杀
            /// </summary>
            public int kills { get; set; }
            /// <summary>
            /// 死亡
            /// </summary>
            public int deaths { get; set; }
            /// <summary>
            /// 胜场
            /// </summary>
            public int wins { get; set; }
            /// <summary>
            /// 负场
            /// </summary>
            public int losses { get; set; }
            /// <summary>
            /// 击杀死亡比
            /// </summary>
            public double kd
            {
                get { return kills / deaths; }
            }
            /// <summary>
            /// 胜率
            /// </summary>
            public double winRate
            {
                get { return wins / (wins + losses); }
            }

        }

    }
}
