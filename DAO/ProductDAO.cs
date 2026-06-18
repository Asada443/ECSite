using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using ShoppingSite_a.DTO;

namespace ShoppingSite_a.DAO
{
    public class ProductDAO
    {
        public List<ProductDTO> GetAll()
        {
            List<ProductDTO> list = new List<ProductDTO>();

            string connStr =
                ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    SELECT
                        PRODUCT_ID,
                        PRODUCT_NAME,
                        PRICE,
                        PLANET,
                        STOCK,
                        DESCRIPTION,
                        IMAGE_PATH,
                        RECOMMENDED_ENVIRONMENT,
                        CREATED_AT
                    FROM products
                    ORDER BY CREATED_AT DESC
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductDTO p = new ProductDTO();

                            p.ProductId = (int)reader["PRODUCT_ID"];
                            p.ProductName = reader["PRODUCT_NAME"].ToString();
                            p.Price = (int)reader["PRICE"];
                            p.Planet = reader["PLANET"].ToString();
                            p.Stock = (int)reader["STOCK"];

                            p.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();


                            p.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();

                            p.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                            p.CreatedAt = (DateTime)reader["CREATED_AT"];

                            list.Add(p);
                        }
                    }
                }
            }

            return list;
        }

        public List<ProductDTO> GetAll(string sortType)
        {
            List<ProductDTO> list = new List<ProductDTO>();

            string orderBy = "CREATED_AT DESC";

            if (sortType == "NEW")
                orderBy = "CREATED_AT DESC";
            else if (sortType == "PRICE_ASC")
                orderBy = "PRICE ASC";
            else if (sortType == "PRICE_DESC")
                orderBy = "PRICE DESC";
            else if (sortType == "NAME_ASC")
                orderBy = "PRODUCT_NAME ASC";
            else if (sortType == "NAME_DESC")
                orderBy = "PRODUCT_NAME DESC";

            string connStr =
                ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = $@"
            SELECT
                PRODUCT_ID,
                PRODUCT_NAME,
                PRICE,
                PLANET,
                STOCK,
                DESCRIPTION,
                IMAGE_PATH,
                RECOMMENDED_ENVIRONMENT,
                CREATED_AT
            FROM products
            ORDER BY {orderBy}
        ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductDTO p = new ProductDTO();

                            p.ProductId = (int)reader["PRODUCT_ID"];
                            p.ProductName = reader["PRODUCT_NAME"].ToString();
                            p.Price = (int)reader["PRICE"];
                            p.Planet = reader["PLANET"].ToString();
                            p.Stock = (int)reader["STOCK"];

                            p.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                            p.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                            p.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                            p.CreatedAt = (DateTime)reader["CREATED_AT"];

                            list.Add(p);
                        }
                    }
                }
            }

            return list;
        }
        public List<ProductDTO> Search(string keyword)
        {
            List<ProductDTO> list = new List<ProductDTO>();

            string connStr =
                ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
            SELECT
                PRODUCT_ID,
                PRODUCT_NAME,
                PRICE,
                PLANET,
                STOCK,
                DESCRIPTION,
                IMAGE_PATH,
                RECOMMENDED_ENVIRONMENT,
                CREATED_AT
            FROM products
            WHERE PRODUCT_NAME LIKE @keyword
            ORDER BY CREATED_AT DESC
        ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@keyword",
                        "%" + keyword + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductDTO p = new ProductDTO();

                            p.ProductId = (int)reader["PRODUCT_ID"];
                            p.ProductName = reader["PRODUCT_NAME"].ToString();
                            p.Price = (int)reader["PRICE"];
                            p.Planet = reader["PLANET"].ToString();
                            p.Stock = (int)reader["STOCK"];

                            p.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                            p.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                            p.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                            p.CreatedAt = (DateTime)reader["CREATED_AT"];

                            list.Add(p);
                        }
                    }
                }
            }

            return list;
        }

        public List<ProductDTO> Search(string keyword, string sortType)
        {
            List<ProductDTO> list = new List<ProductDTO>();

            string orderBy = "CREATED_AT DESC";

            if (sortType == "PRICE_ASC")
                orderBy = "PRICE ASC";
            else if (sortType == "PRICE_DESC")
                orderBy = "PRICE DESC";
            else if (sortType == "NAME_ASC")
                orderBy = "PRODUCT_NAME ASC";
            else if (sortType == "NAME_DESC")
                orderBy = "PRODUCT_NAME DESC";

            string connStr =
                ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = $@"
            SELECT
                PRODUCT_ID,
                PRODUCT_NAME,
                PRICE,
                PLANET,
                STOCK,
                DESCRIPTION,
                IMAGE_PATH,
                RECOMMENDED_ENVIRONMENT,
                CREATED_AT
            FROM products
            WHERE PRODUCT_NAME LIKE @keyword
            ORDER BY {orderBy}
        ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@keyword",
                        "%" + keyword + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductDTO p = new ProductDTO();

                            p.ProductId = (int)reader["PRODUCT_ID"];
                            p.ProductName = reader["PRODUCT_NAME"].ToString();
                            p.Price = (int)reader["PRICE"];
                            p.Planet = reader["PLANET"].ToString();
                            p.Stock = (int)reader["STOCK"];

                            p.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                            p.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                            p.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                            p.CreatedAt = (DateTime)reader["CREATED_AT"];

                            list.Add(p);
                        }
                    }
                }
            }

            return list;
        }
        public ProductDTO GetById(int productId)
        {
            ProductDTO p = null;

            string connStr =
                ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
            SELECT
                PRODUCT_ID,
                PRODUCT_NAME,
                PRICE,
                PLANET,
                STOCK,
                DESCRIPTION,
                IMAGE_PATH,
                RECOMMENDED_ENVIRONMENT,
                CREATED_AT
            FROM products
            WHERE PRODUCT_ID = @productId
        ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p = new ProductDTO();

                            p.ProductId = (int)reader["PRODUCT_ID"];
                            p.ProductName = reader["PRODUCT_NAME"].ToString();
                            p.Price = (int)reader["PRICE"];
                            p.Planet = reader["PLANET"].ToString();
                            p.Stock = (int)reader["STOCK"];

                            p.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                            p.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                            p.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                            p.CreatedAt = (DateTime)reader["CREATED_AT"];
                        }
                    }
                }
            }

            return p;
        }

    }
}
