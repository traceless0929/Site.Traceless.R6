using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Traceless.R6.Tools.Models;

namespace Traceless.R6.Tools
{
    public class Utils
    {
        public static string ConvertToRankDes(int rank)
        {
            if (rank == 0) return "无";
            rank = rank - 1;
            int rankAera = rank / 4;
            int rankLevel = 4 - (rank % 4);
            StringBuilder sb = new StringBuilder();
            switch (rankAera)
            {
                case 0:
                    sb.Append("紫铜");
                    break;
                case 1:
                    sb.Append("青铜");
                    break;
                case 2:
                    sb.Append("白银");
                    break;
                case 3:
                    sb.Append("黄金");
                    break;
                case 4:
                    sb.Append("白金");
                    break;
                case 5:
                    sb.Append("钻石");
                    break;

            }
            sb.Append(rankLevel);
            return sb.ToString();
        }
        public static string ConvertToDetailStr(UserDetailInfoResp.Game_Queues queue)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{queue.queue}-{queue.main1}[{queue.desc1}]-{queue.main2}[{queue.desc2}]");
            int i = 0;
            foreach (var header in queue.headers)
            {
                sb.Append(
                    $"[{header.k}{(string.IsNullOrWhiteSpace(header.score) ? "" : $"({header.score})")}]{header.v}");
                if ((i + 1) % 2 == 1)
                {
                    sb.Append("\t");
                }
                if ((i + 1) % 2 == 0)
                {
                    sb.Append("\n");
                }

                i++;
            }
            sb.Append("\n");
            i = 0;
            foreach (var detail in queue.details)
            {
                sb.Append(
                    $"[{detail.k}{(string.IsNullOrWhiteSpace(detail.score) ? "" : $"({detail.score})")}]{detail.v}");
                if ((i + 1) % 2 == 1)
                {
                    sb.Append("\t");
                }
                if ((i + 1) % 2 == 0)
                {
                    sb.Append("\n");
                }
                i++;
            }
            sb.Append("\n");
            return sb.ToString().Trim().Replace("\n\n","\n");
        }
    }
}
