using ShoppingSite_a.DTO;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ShoppingSite_a.DAO
{
    public class MemberDAO
    {
        // 会員登録 (Insert)
        public void Insert(MemberDTO member)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    INSERT INTO Users
                    (UserId, Password, UserName, HometownPlanet, RecommendedEnvironment, Role)
                    VALUES
                    (@UserId, @Password, @UserName, @HometownPlanet, @RecommendedEnvironment, @Role)
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", member.UserId);
                    cmd.Parameters.AddWithValue("@Password", member.Password);
                    cmd.Parameters.AddWithValue("@UserName", member.UserName);
                    cmd.Parameters.AddWithValue("@HometownPlanet", member.HometownPlanet);
                    cmd.Parameters.AddWithValue("@RecommendedEnvironment", member.RecommendedEnvironment);
                    cmd.Parameters.AddWithValue("@Role", member.Role);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 会員削除 (Delete)
        public void Delete(string userId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    DELETE FROM Users
                    WHERE UserId = @UserId
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 会員情報修正 (Update)
        public void Update(MemberDTO member)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    UPDATE Users
                    SET
                        Password = @Password,
                        UserName = @UserName,
                        HometownPlanet = @HometownPlanet,
                        RecommendedEnvironment = @RecommendedEnvironment
                    WHERE UserId = @UserId
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", member.UserId);
                    cmd.Parameters.AddWithValue("@Password", member.Password);
                    cmd.Parameters.AddWithValue("@UserName", member.UserName);
                    cmd.Parameters.AddWithValue("@HometownPlanet", member.HometownPlanet);
                    cmd.Parameters.AddWithValue("@RecommendedEnvironment", member.RecommendedEnvironment);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ログイン認証 (Login)
        public MemberDTO Login(string userId, string password)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    SELECT UserId, Password, UserName, HometownPlanet, RecommendedEnvironment, Role
                    FROM Users
                    WHERE UserId = @UserId
                    AND Password = @Password
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MemberDTO member = new MemberDTO();

                            member.UserId = reader["UserId"].ToString();
                            member.Password = reader["Password"].ToString();
                            member.UserName = reader["UserName"].ToString();
                            member.HometownPlanet = reader["HometownPlanet"].ToString();
                            member.RecommendedEnvironment = reader["RecommendedEnvironment"].ToString();
                            member.Role = reader["Role"].ToString();

                            return member;
                        }
                    }
                }
            }
            return null;
        }

        // 1件の会員情報を取得 (GetMember)
        public MemberDTO GetMember(string userId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    SELECT UserId, Password, UserName, HometownPlanet, RecommendedEnvironment, Role
                    FROM Users
                    WHERE UserId = @UserId
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MemberDTO member = new MemberDTO();

                            
                            member.UserId = reader["UserId"].ToString();
                            member.Password = reader["Password"].ToString();
                            member.UserName = reader["UserName"].ToString();
                            member.HometownPlanet = reader["HometownPlanet"].ToString();
                            member.RecommendedEnvironment = reader["RecommendedEnvironment"].ToString();
                            member.Role = reader["Role"].ToString();

                            return member;
                        }
                    }
                }
            }
            return null;
        }

        //  重複チェック (Exists)
        public bool Exists(string userId)
        {
            MemberDTO member = GetMember(userId);
            return member != null;
        }
    }
}