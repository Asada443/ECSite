using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_a.DTO
{
    public class MemberDTO
    {
        public string MemberId { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string MailAddress { get; set; }

        public string Role { get; set; }

        public string HomePlanet { get; set; }

        public string PreferredEnvironment { get; set; }
    }
}