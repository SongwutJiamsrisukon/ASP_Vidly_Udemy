using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Vidly_Udemy.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        //I was insert value from migration and forgottten 0,1,2,3 is? so I try to specify number again
        public static readonly byte Unknown = 0;//prevent magic string
        public static readonly byte PayAsYouGo = 1;//prevent magic string
        public static readonly byte Monthly = 2;//prevent magic string
        public static readonly byte Quarterly = 3;//prevent magic string
        public static readonly byte Annual = 4;//prevent magic string
    }
}