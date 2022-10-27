using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBook.Client
{
    class client
    {
        private string connString = "";
        Dao.book res = new Dao.book();
        public client()
        {
            connString = res.get_init_sql();
        }
        //查询
        public MySqlDataReader searchInfo()
        {
            String sql = res.get_search_sql();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        //添加
        public void addInfo(string name, string phone, string address)
        {

            string sql = res.get_add_sql(name, phone, address);
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //修改
        public void changeInfo(int id, string name, string phone, string address)
        {
            string sql = res.get_change_sql(id, name, phone, address);
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //删除
        public void deteleInfo(int id)
        {
            string sql = res.get_delete_sql(id);
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
