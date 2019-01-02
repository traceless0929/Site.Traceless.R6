using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.R6.Tools.Models
{
    public class UserDetailInfoResp
    {
        public string msg { get; set; }
        public Result result { get; set; }
        public string status { get; set; }
        public string version { get; set; }

        public class Result
        {
            public string download_url { get; set; }
            public Game_Queues[] game_queues { get; set; }
            public Item[] items { get; set; }
            public Player player { get; set; }
            public int show_bind_box { get; set; }
        }

        public class Player
        {
            public string avatar { get; set; }
            public string avatar_btn_state { get; set; }
            public string avatar_desc { get; set; }
            public string id { get; set; }
            public string level { get; set; }
            public string nickname { get; set; }
            public string update_desc { get; set; }
        }

        public class Game_Queues
        {
            public string desc1 { get; set; }
            public string desc2 { get; set; }
            public Detail[] details { get; set; }
            public Header[] headers { get; set; }
            public string history_rank_tips { get; set; }
            public History_Ranks[] history_ranks { get; set; }
            public string main1 { get; set; }
            public string main2 { get; set; }
            public string queue { get; set; }
            public Radar radar { get; set; }
        }

        public class Radar
        {
            public string desc1 { get; set; }
            public string desc2 { get; set; }
            public string main1 { get; set; }
            public string main2 { get; set; }
            public string percent1 { get; set; }
            public string percent2 { get; set; }
            public Score[] score { get; set; }
        }

        public class Score
        {
            public string k { get; set; }
            public string v { get; set; }
        }

        public class Detail
        {
            public string k { get; set; }
            public string v { get; set; }
            public string score { get; set; }
        }

        public class Header
        {
            public string k { get; set; }
            public string type { get; set; }
            public string v { get; set; }
            public string score { get; set; }
            public string icon { get; set; }
        }

        public class History_Ranks
        {
            public string desc { get; set; }
            public string icon { get; set; }
            public string medal { get; set; }
            public string mmr { get; set; }
            public string season { get; set; }
        }

        public class Item
        {
            public Content[] content { get; set; }
            public string type { get; set; }
            public string title { get; set; }
        }

        public class Content
        {
            public string content_url { get; set; }
            public string desc { get; set; }
            public int enable { get; set; }
            public string image_url { get; set; }
            public string key { get; set; }
            public int tips_time { get; set; }
            public string type { get; set; }
            public string count { get; set; }
            public string d { get; set; }
            public string k { get; set; }
            public string kd { get; set; }
            public string lose { get; set; }
            public string mode { get; set; }
            public string rating { get; set; }
            public string time { get; set; }
            public string win { get; set; }
            public string diff { get; set; }
            public string trend { get; set; }
            public string category { get; set; }
            public string d_per_round { get; set; }
            public string detail_url { get; set; }
            public string hs_d_ratio { get; set; }
            public string icon { get; set; }
            public string k_per_round { get; set; }
            public string mmr { get; set; }
            public string name { get; set; }
            public string rank { get; set; }
            public string rounds_played { get; set; }
            public string rounds_survived { get; set; }
            public string timeplayed { get; set; }
            public int timeplayed_v { get; set; }
            public string win_rate { get; set; }
            public Content1[] content { get; set; }
            public string headshot { get; set; }
            public string hit_ratio { get; set; }
            public string hs_k { get; set; }
        }

        public class Content1
        {
            public string k { get; set; }
            public string v { get; set; }
            public string rank { get; set; }
        }
    }

    
}
