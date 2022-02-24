using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte ID { get; set; }
        public short Signupfee { get; set; }
        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

        public String MembershipTypeName { get; set; }

    }
}