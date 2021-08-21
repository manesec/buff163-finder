using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace Mane_Buff_163_Finder
{
    
    public static class ManeDB
    {
        /// <summary>
        /// Connect DB
        /// </summary>
        /// <returns>0 ok</returns>
        public static int ManeDBConnect()
        {
            Quanju.Mane_SqliteConnection = new SqliteConnection("Data Source=Goods.db");
            Quanju.Mane_SqliteConnection.Open();
            ManeDBCheckStacture();
            return 0;
        }

        public static void ManeDBClose()
        {
            Quanju.Mane_SqliteConnection.Close();
        }

        private static void ManeDBCheckStacture()
        {
            // Check table if exits
            bool tables_exits = false;
            using(SqliteCommand sql = Quanju.Mane_SqliteConnection.CreateCommand())
            {
                sql.CommandText = @"SELECT count(*) FROM sqlite_master WHERE type='table' AND name='goods' limit 1;";
                SqliteDataReader sqlreader = sql.ExecuteReader();
                while (sqlreader.Read())
                {
                    tables_exits = !(sqlreader[0].ToString() == "0");
                }
                sqlreader.Close();
            }

            // Create Tables
            if (!tables_exits){
                Debug.WriteLine("# Creating Table = goods");
                using(SqliteCommand sql = Quanju.Mane_SqliteConnection.CreateCommand())
                {
                    sql.CommandText = @"
                       create table goods(
                        id integer PRIMARY KEY autoincrement, 
                        fetch_time DATETIME,
                        appid varchar(20),
                        goodid varchar(20),
                        hash_name varchar(200),
                        lowest_price varchar(100),
                        rate varchar(20),
                        volume varchar(50)
                    ) ";
                    sql.ExecuteNonQuery();
                }
            }
            ManeDBFlushDB();
        }

        private static void ManeDBFlushDB()
        {
            Debug.WriteLine("# Flushing DB ...");
            using(SqliteCommand sql = Quanju.Mane_SqliteConnection.CreateCommand())
            {
                sql.CommandText = "DELETE from goods";
                sql.ExecuteNonQuery();
                sql.CommandText = "VACUUM";
                sql.ExecuteNonQuery();
            }
        }

        public static void ManeDBInsertGood(ManeT.Good good)
        {
            using (SqliteCommand sql = Quanju.Mane_SqliteConnection.CreateCommand())
            {
                sql.CommandText = $@"
                    INSERT into goods (fetch_time,appid,goodid,hash_name,lowest_price,volume,rate) values(
                        '{good.fetch_time.ToString("yyyy-MM-dd HH:mm:ss")}','{good.appid}','{good.goodid}','{good.hash_name}','{good.lowest_price}','{good.volume}','{good.Rate}'
                    )
                ";
                sql.ExecuteNonQuery();
            }
        }


        public static List<ManeT.Good> ManeDBListGoods()
        {
            List<ManeT.Good> Return_Goods = new List<ManeT.Good>();
            using (SqliteCommand sql = Quanju.Mane_SqliteConnection.CreateCommand())
            {
                sql.CommandText = @"select fetch_time,appid,goodid,hash_name,lowest_price,volume,rate from goods ORDER BY id ASC limit 50;";
                SqliteDataReader datareader = sql.ExecuteReader();
                while (datareader.Read())
                {
                    ManeT.Good agood = new ManeT.Good();
                    agood.appid = datareader["appid"].ToString();
                    agood.goodid = datareader["goodid"].ToString();
                    agood.fetch_time = DateTime.ParseExact(datareader["fetch_time"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    agood.hash_name = datareader["hash_name"].ToString();
                    agood.lowest_price = datareader["lowest_price"].ToString();
                    agood.volume = datareader["volume"].ToString();
                    agood.Rate = datareader["rate"].ToString();
                    Return_Goods.Add(agood);
                }
            }
            return Return_Goods;
        }

    }
}
