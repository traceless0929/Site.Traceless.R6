using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.R6.Tools.Models
{
    public class UserBaseInfoResp
    {
        public string msg { get; set; }
        public Result result { get; set; }
        public string status { get; set; }
        public string version { get; set; }


        public class Result
        {
            public Player_List[] player_list { get; set; }
            public string query { get; set; }
        }

        public class Player_List
        {
            public string avatar { get; set; }
            public string id { get; set; }
            public string mmr { get; set; }
            public string name { get; set; }
        }
    }

}
