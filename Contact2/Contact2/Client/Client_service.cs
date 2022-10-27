using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBook.Client
{
    class Client_service
    {
        Client.client res = new Client.client();
        public List<string[]> find_result()
        {
            MySqlDataReader reader = res.searchInfo();
            List<string[]> result = new List<string[]>();
            while (reader.Read())
            {
                string[] subItems = new string[]{
                    reader.GetInt32(0).ToString(),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)};
                result.Add(subItems);
            }
            reader.Close();
            return result;
        }
        public void add_frind(string name,string phone,string address)
        {
            res.addInfo(name,phone,address);
        }
        public void updata_friend(int id,string name,string phone,string address)
        {
            res.changeInfo(id, name, phone, address);
        }
        public void delete_friend(int id)
        {
            res.deteleInfo(id);
        }
    }
}
