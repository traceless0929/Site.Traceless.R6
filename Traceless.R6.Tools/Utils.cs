using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.R6.Tools
{
    public class Utils
    {
        public static string ConvertToRankDes(int rank)
        {
            int rankAera = rank / 4;
            int rankLevel = (rank % 4)+1;
            StringBuilder sb = new StringBuilder();
            switch(rankAera)
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
    }
}
