using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_a.DTO
{
    public class MemberDTO
    {
        // ログイン用の会員ID (DB: UserId)
        public string UserId { get; set; }

        //  パスワード (DB: Password)
        public string Password { get; set; }

        // 宇宙人の名前 (DB: UserName)
        public string UserName { get; set; }

        // 故郷の星 (DB: HometownPlanet)
        public string HometownPlanet { get; set; }

        // 好みの環境 (DB: RecommendedEnvironment)
        
        public string RecommendedEnvironment { get; set; }

        // 支配者（管理者）か一般人かを見分ける権限
        
        public string Role { get; set; }
    }
}