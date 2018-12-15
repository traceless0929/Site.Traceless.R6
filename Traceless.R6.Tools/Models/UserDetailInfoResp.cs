using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.R6.Tools.Models
{
    public class UserDetailInfoResp
    {
        public string username { get; set; }
        public string platform { get; set; }
        public string ubisoft_id { get; set; }
        public string uplay_id { get; set; }
        public bool avatar_banned { get; set; }
        public DateTime last_updated { get; set; }
        public List<Alias> aliases { get; set; } = new List<Alias>();
        public List<object> profiles { get; set; } = new List<object>();
        /// <summary>
        /// 等级进度
        /// </summary>
        public Progression progression { get; set; } = new Progression();
        /// <summary>
        /// 曾用名(不太准确
        /// </summary>
        public List<Stat> stats { get; set; } = new List<Stat>();
        public List<Operator> operators { get; set; } = new List<Operator>();
    }

    public class Progression
    {
        /// <summary>
        /// 等级
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 战利品概率
        /// </summary>
        public int lootbox_probability { get; set; }
        /// <summary>
        /// 总经验
        /// </summary>
        public int total_xp { get; set; }
    }
    /// <summary>
    /// 曾用名
    /// </summary>
    public class Alias
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime last_seen_at { get; set; }
    }
    /// <summary>
    /// 数据
    /// </summary>
    public class Stat
    {
        /// <summary>
        /// 概况
        /// </summary>
        public General general { get; set; }
        /// <summary>
        /// 排位、休闲数据
        /// </summary>
        public Queue queue { get; set; }
        /// <summary>
        /// 游戏模式数据
        /// </summary>
        public Gamemode gamemode { get; set; }
        /// <summary>
        /// 数据时间
        /// </summary>
        public Timestamps timestamps { get; set; }
    }

    public class General
    {
        /// <summary>
        /// 助攻
        /// </summary>
        public int assists { get; set; }
        /// <summary>
        /// 封阻次数
        /// </summary>
        public int barricades_deployed { get; set; }
        /// <summary>
        /// 致盲击杀
        /// </summary>
        public int blind_kills { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int bullets_fired { get; set; }
        public int bullets_hit { get; set; }
        public int dbnos { get; set; }
        public int deaths { get; set; }
        public int distance_travelled { get; set; }
        /// <summary>
        /// 装备摧毁数
        /// </summary>
        public int gadgets_destroyed { get; set; }
        public int headshots { get; set; }
        public float kd { get; set; }
        public int kills { get; set; }
        public int losses { get; set; }
        public int melee_kills { get; set; }
        public int penetration_kills { get; set; }
        public int playtime { get; set; }
        public int rappel_breaches { get; set; }
        public int reinforcements_deployed { get; set; }
        public int revives { get; set; }
        public int suicides { get; set; }
        public int wins { get; set; }
        public float wl { get; set; }
    }

    public class Queue
    {
        public Casual casual { get; set; }
        public Ranked ranked { get; set; }
    }

    public class Casual
    {
        public int deaths { get; set; }
        public int games_played { get; set; }
        public float kd { get; set; }
        public int kills { get; set; }
        public int losses { get; set; }
        public int playtime { get; set; }
        public int wins { get; set; }
        public float wl { get; set; }
    }

    public class Ranked
    {
        public int deaths { get; set; }
        public int games_played { get; set; }
        public float kd { get; set; }
        public int kills { get; set; }
        public int losses { get; set; }
        public int playtime { get; set; }
        public int wins { get; set; }
        public float wl { get; set; }
    }

    public class Gamemode
    {
        public Bomb bomb { get; set; }
        public Secure_Area secure_area { get; set; }
        public Hostage hostage { get; set; }
    }

    public class Bomb
    {
        public int best_score { get; set; }
        public int games_played { get; set; }
        public int losses { get; set; }
        public int playtime { get; set; }
        public int wins { get; set; }
        public float wl { get; set; }
    }

    public class Secure_Area
    {
        public int best_score { get; set; }
        public int games_played { get; set; }
        public int kills_as_attacker_in_objective { get; set; }
        public int kills_as_defender_in_objective { get; set; }
        public int losses { get; set; }
        public int playtime { get; set; }
        public int times_objective_secured { get; set; }
        public int wins { get; set; }
        public float wl { get; set; }
    }

    public class Hostage
    {
        public int best_score { get; set; }
        public int games_played { get; set; }
        public int losses { get; set; }
        public int playtime { get; set; }
        public int extractions_denied { get; set; }
        public int wins { get; set; }
        public float wl { get; set; }
    }

    public class Timestamps
    {
        public DateTime created { get; set; }
        public DateTime last_updated { get; set; }
    }

    public class Operator
    {
        public int kills { get; set; }
        public int deaths { get; set; }
        public float kd { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public float wl { get; set; }
        public int headshots { get; set; }
        public int dbnos { get; set; }
        public int melee_kills { get; set; }
        public int experience { get; set; }
        public int playtime { get; set; }
        public Ability[] abilities { get; set; }
        public Operator1 _operator { get; set; }
    }

    public class Operator1
    {
        public string name { get; set; }
        public string internal_name { get; set; }
        public string role { get; set; }
        public string ctu { get; set; }
        public Images images { get; set; }
    }

    public class Images
    {
        public string badge { get; set; }
        public string bust { get; set; }
        public string figure { get; set; }
    }

    public class Ability
    {
        public string key { get; set; }
        public string title { get; set; }
        public int value { get; set; }
    }

}
