using ShoppingSite_a.DTO;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ShoppingSite_a.DAO
{
    public class MemberDAO
    {
        public void Insert(MemberDTO member)
        {
            string connStr =
                ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
            INSERT INTO users
            (MEMBER_ID, PASSWORD, LAST_NAME, FIRST_NAME, ADDRESS,ROLE, MAIL_ADDRESS, HOME_PLANET, PREFERRED_ENVIRONMENT)
            VALUES
            (@MemberId, @Password, @LastName, @FirstName, @Address, @Role, @MailAddress, @HomePlanet, @PreferredEnvironment)
        ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MemberId", member.MemberId);
                    cmd.Parameters.AddWithValue("@Password", member.Password);
                    cmd.Parameters.AddWithValue("@LastName", member.LastName);
                    cmd.Parameters.AddWithValue("@FirstName", member.FirstName);
                    cmd.Parameters.AddWithValue("@Address", member.Address);
                    cmd.Parameters.AddWithValue("@Role", member.Role);
                    cmd.Parameters.AddWithValue("@MailAddress", member.MailAddress);
                    cmd.Parameters.AddWithValue("@HomePlanet", member.HomePlanet);
                    cmd.Parameters.AddWithValue("@PreferredEnvironment", member.PreferredEnvironment);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(string memberId)
        {
            string connStr =
                ConfigurationManager
                .ConnectionStrings["ShoppingSiteDB"]
                .ConnectionString;

            using (SqlConnection conn =
                new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    DELETE FROM users
                    WHERE MEMBER_ID = @MemberId
                ";

                using (SqlCommand cmd =
                    new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@MemberId",
                        memberId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(
            MemberDTO member)
        {
            string connStr =
                ConfigurationManager
                .ConnectionStrings["ShoppingSiteDB"]
                .ConnectionString;

            using (SqlConnection conn =
                new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    UPDATE users
                    SET
                        PASSWORD = @Password,
                        LAST_NAME = @LastName,
                        FIRST_NAME = @FirstName,
                        ADDRESS = @Address,
                        MAIL_ADDRESS = @MailAddress,
                            HOME_PLANET = @HomePlanet,
                            PREFERRED_ENVIRONMENT = @PreferredEnvironment
                    WHERE MEMBER_ID = @MemberId
                ";

                using (SqlCommand cmd =
                    new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MemberId", member.MemberId);
                    cmd.Parameters.AddWithValue("@Password", member.Password);
                    cmd.Parameters.AddWithValue("@LastName", member.LastName);
                    cmd.Parameters.AddWithValue("@FirstName", member.FirstName);
                    cmd.Parameters.AddWithValue("@Address", member.Address);
                    cmd.Parameters.AddWithValue("@MailAddress", member.MailAddress);
                    cmd.Parameters.AddWithValue("@HomePlanet", member.HomePlanet);
                    cmd.Parameters.AddWithValue("@PreferredEnvironment", member.PreferredEnvironment);

                    cmd.ExecuteNonQuery();
                }
            }
        }

      
        public MemberDTO Login(string memberId, string password)
        {
            string connStr =
                ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
          SELECT MEMBER_ID,
       PASSWORD,
       LAST_NAME,
       FIRST_NAME,
       ADDRESS,
       MAIL_ADDRESS,
       ROLE,
       HOME_PLANET,
       PREFERRED_ENVIRONMENT
FROM users
WHERE MEMBER_ID = @MemberId
AND PASSWORD = @Password
        ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MemberDTO member = new MemberDTO();

                            member.MemberId = reader["MEMBER_ID"].ToString();
                            member.Password = reader["PASSWORD"].ToString();
                            member.LastName = reader["LAST_NAME"].ToString();
                            member.FirstName = reader["FIRST_NAME"].ToString();
                            member.Address = reader["ADDRESS"].ToString();
                            member.MailAddress = reader["MAIL_ADDRESS"].ToString();
                            member.Role = reader["ROLE"].ToString(); 
                            member.HomePlanet = reader["HOME_PLANET"].ToString();
                            member.PreferredEnvironment = reader["PREFERRED_ENVIRONMENT"].ToString();

                            return member;
                        }
                    }
                }
            }

            return null;
        }

        public MemberDTO GetMember(string memberId)
        {

            string connStr =
                ConfigurationManager
                .ConnectionStrings["ShoppingSiteDB"]
                .ConnectionString;

            using (SqlConnection conn =
                new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
            SELECT
                MEMBER_ID,
        PASSWORD,
        LAST_NAME,
        FIRST_NAME,
        ADDRESS,
        MAIL_ADDRESS,
        ROLE,
        HOME_PLANET,
        PREFERRED_ENVIRONMENT
            FROM users
            WHERE MEMBER_ID = @MemberId
        ";

                using (SqlCommand cmd =
                    new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@MemberId",
                        memberId);

                    using (SqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MemberDTO member =
                                new MemberDTO();

                            member.MemberId =
                                reader["MEMBER_ID"].ToString();

                            member.Password = reader["PASSWORD"].ToString();

                            member.LastName =
                                reader["LAST_NAME"].ToString();

                            member.FirstName =
                                reader["FIRST_NAME"].ToString();

                            member.Address = reader["ADDRESS"].ToString();

                            member.MailAddress = reader["MAIL_ADDRESS"].ToString();

                            member.Role = reader["ROLE"].ToString();

                            member.HomePlanet = reader["HOME_PLANET"].ToString();

                            member.PreferredEnvironment = reader["PREFERRED_ENVIRONMENT"].ToString();

                            return member;
                        }
                    }
                }
            }




            return null;
        }

        public bool Exists(string memberId)
        {
            MemberDTO member = GetMember(memberId);

            return member != null;
        }
    }
}