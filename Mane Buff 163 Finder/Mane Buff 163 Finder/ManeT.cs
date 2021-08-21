using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mane_Buff_163_Finder
{
    public class ManeT
    {
        public struct Good
        {
            public DateTime fetch_time { get; set; }
            public string appid { get; set; }
            public string goodid { get; set; }
            public string hash_name { get; set; }
            public string lowest_price { get; set; }
            public string volume { get; set; }
            public string Rate { get; set; }
        }
    }
}
