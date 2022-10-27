using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBook.Dao
{
    class book
    {
        public string get_init_sql()
        {
            return "server=127.0.0.1;port=3306;database=contact;username=root;password=lzx12138.; SslMode=none;";
        }
        public string get_add_sql(string name, string phone, string address)
        {
            return "insert into friend(name,phone,address) values(" + "'" + name + "'" + "," + "'" + phone + "'" + "," + "'" + address + "'" + ")";
        }
        public string get_search_sql()
        {
           return "select id, name, phone, address from friend";
        }
        public string get_delete_sql(int id)
        {
            return "delete from friend where id=" + id.ToString();
        }
        public string get_change_sql(int id,string name, string phone, string address)
        {
            return "update friend set name='" + name + "',phone='" + phone + "',address = '" + address + "'" + "where id=" + id.ToString();
        }
    }
}
