using ShoppingSite_a.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace ShoppingSite_a.DAO
{
    /// <summary>
    /// 商品テーブル（products）に関するデータベース操作（SQL実行）を専門に行うクラス
    /// </summary>
    public class ProductDAO
    {
        /// <summary>
        /// 【全件取得】登録されているすべての商品を、登録が新しい順（CREATED_AT DESC）に取得します。
        /// </summary>
        /// <returns>商品のリスト</returns>
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

        /// <summary>
        /// 【並び替え付き全件取得】一般画面用：新着順や価格の安い順など、指定された条件でソートして全商品を取得します。
        /// </summary>
        /// <param name="sortType">"NEW"(新着), "PRICE_ASC"(安い順), "PRICE_DESC"(高い順), "NAME_ASC"(名前にあいうえお順), "NAME_DESC"(名前逆順)</param>
        /// <returns>並び替えられた商品のリスト</returns>
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

        /// <summary>
        /// 【あいまい検索】商品名に入力されたキーワードが含まれる商品を探します（新着順）。
        /// </summary>
        /// <param name="keyword">検索窓に入力された文字列</param>
        /// <returns>ヒットした商品のリスト</returns>
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
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

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

        /// <summary>
        /// 【並び替え付き・あいまい検索】一般画面用：キーワード検索された結果を、さらに価格順などで並び替えて取得します。
        /// </summary>
        /// <param name="keyword">検索窓に入力された文字列</param>
        /// <param name="sortType">並び替え条件（PRICE_ASC など）</param>
        /// <returns>ヒットして並び替えられた商品のリスト</returns>
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
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

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

        /// <summary>
        /// 【1件取得】商品ID（主キー）を元に、商品の詳しい情報を1件だけ取得します（詳細画面や編集画面用）。
        /// </summary>
        /// <param name="productId">取得したい商品のID</param>
        /// <returns>見つかった商品のデータ（なければnull）</returns>
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

        /// <summary>
        /// 【新規登録】画面から入力された商品データをデータベース（productsテーブル）に保存します。
        /// </summary>
        /// <param name="p">登録したい商品データが入ったDTOオブジェクト</param>
        public void Insert(ProductDTO p)
        {
            string connStr =
                ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    INSERT INTO products (
                        PRODUCT_NAME,
                        PRICE,
                        PLANET,
                        STOCK,
                        DESCRIPTION,
                        IMAGE_PATH,
                        RECOMMENDED_ENVIRONMENT,
                        CREATED_AT
                    ) VALUES (
                        @productName,
                        @price,
                        @planet,
                        @stock,
                        @description,
                        @imagePath,
                        @recommendedEnvironment,
                        GETDATE()
                    )
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@productName", p.ProductName);
                    cmd.Parameters.AddWithValue("@price", p.Price);
                    cmd.Parameters.AddWithValue("@planet", p.Planet);
                    cmd.Parameters.AddWithValue("@stock", p.Stock);
                    cmd.Parameters.AddWithValue("@description", p.Description ?? "");
                    cmd.Parameters.AddWithValue("@imagePath", ""); // 画像は一旦空
                    cmd.Parameters.AddWithValue("@recommendedEnvironment", p.RecommendedEnvironment ?? "");

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 商品情報を更新する（UPDATE）
        /// </summary>
        public void Update(ProductDTO product)
        {
            string connStr =
           ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (var connection = new SqlConnection(connStr))
            {
                string sql = @"
            UPDATE products
            SET 
                PRODUCT_NAME = @ProductName,
                PRICE = @Price,
                STOCK = @Stock,
                PLANET = @Planet,
                DESCRIPTION = @Description,
                RECOMMENDED_ENVIRONMENT = @RecommendedEnvironment
            WHERE 
                PRODUCT_ID = @ProductId";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@Planet", product.Planet);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@RecommendedEnvironment", product.RecommendedEnvironment);
                    command.Parameters.AddWithValue("@ProductId", product.ProductId); // 誰を更新するか特定するID

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 商品を削除する（DELETE）
        /// </summary>
        public void Delete(int productId)
        {
            string connStr =
        ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (var connection = new SqlConnection(connStr))
            {
                string sql = "DELETE FROM products WHERE PRODUCT_ID = @ProductId";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 未ログイン用：人気商品トップ3を取得する（在庫が少ない順）
        /// </summary>
        public List<ProductDTO> GetPopularProducts()
        {
            List<ProductDTO> list = new List<ProductDTO>();

            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            string sql = @"SELECT TOP 3 
                        PRODUCT_ID, PRODUCT_NAME, PRICE, PLANET, 
                        STOCK, DESCRIPTION, IMAGE_PATH, RECOMMENDED_ENVIRONMENT 
                   FROM products 
                   ORDER BY STOCK ASC";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductDTO dto = new ProductDTO();
                        dto.ProductId = Convert.ToInt32(reader["PRODUCT_ID"]);
                        dto.ProductName = reader["PRODUCT_NAME"].ToString();
                        dto.Price = Convert.ToInt32(reader["PRICE"]);
                        dto.Planet = reader["PLANET"].ToString();
                        dto.Stock = Convert.ToInt32(reader["STOCK"]);
                        dto.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                        dto.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                        dto.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                        list.Add(dto);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// ログイン中用：好みの環境に一致するおすすめ商品を全件取得する
        /// </summary>
        public List<ProductDTO> GetRecommendedProducts(string preferredEnvironment)
        {
            List<ProductDTO> list = new List<ProductDTO>();

            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            string sql = @"SELECT 
                        PRODUCT_ID, PRODUCT_NAME, PRICE, PLANET, 
                        STOCK, DESCRIPTION, IMAGE_PATH, RECOMMENDED_ENVIRONMENT 
                   FROM products 
                   WHERE RECOMMENDED_ENVIRONMENT = @PreferredEnvironment
                   ORDER BY PRODUCT_ID DESC";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PreferredEnvironment", preferredEnvironment ?? (object)DBNull.Value);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductDTO dto = new ProductDTO();
                        dto.ProductId = Convert.ToInt32(reader["PRODUCT_ID"]);
                        dto.ProductName = reader["PRODUCT_NAME"].ToString();
                        dto.Price = Convert.ToInt32(reader["PRICE"]);
                        dto.Planet = reader["PLANET"].ToString();
                        dto.Stock = Convert.ToInt32(reader["STOCK"]);
                        dto.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                        dto.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                        dto.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                        list.Add(dto);
                    }
                }
            }
            return list;
        }
    }
}