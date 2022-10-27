using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace addressBook
{
    public partial class Form1 : Form
    {
        private int Fid;
        Client.client res = new Client.client();
        public Form1()
        {
            InitializeComponent();
        }

        private void getInfo()
        {
            MySqlDataReader reader =  res.searchInfo();
            try
            {
                this.listView1.Items.Clear();
                while (reader.Read())
                {
                    string[] subItems = new string[]{
                    reader.GetInt32(0).ToString(),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)};
                    this.listView1.Items.Add(new ListViewItem(subItems));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
                return;
            if (this.listView1.FocusedItem == null)
                return;
            ListViewItem item = listView1.SelectedItems[0];
            txtName.Text = item.SubItems[1].Text;
            txtPhone.Text = item.SubItems[2].Text;
            txtAddress.Text = item.SubItems[3].Text;
            this.Fid = int.Parse(item.SubItems[0].Text);
            update_Fid(Fid);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.getInfo();
        }
        private void enableInfo()
        {
            this.clearInfo();
            this.Fid = 0;
            this.getInfo();
            this.txtAddress.Enabled = true;
            this.txtName.Enabled = true;
        }
        private void clearInfo()
        {
            this.listView1.Items.Clear();
        }
        private void update_Fid(int friend_id)
        {
            label7.Text = friend_id.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(this.txtName.Text == ""&&this.txtPhone.Text == ""&&this.txtAddress.Text=="")
            {
                MessageBox.Show("请先输入联系人信息！");
                return;
            }
            try
            {
                res.addInfo(this.txtName.Text, this.txtPhone.Text, this.txtAddress.Text);
                MessageBox.Show("成功添加联系人。");
                this.getInfo();
                this.enableInfo();
                this.txtName.Text = "";
                this.txtPhone.Text = "";
                this.txtAddress.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Fid == 0)
            {
                MessageBox.Show("请先选中联系人信息！");
                return;
            }
            try
            {
                res.changeInfo(Fid, this.txtName.Text, this.txtPhone.Text, this.txtAddress.Text);
                MessageBox.Show("成功修改联系人信息。");
                this.getInfo();
                this.enableInfo();
                this.txtName.Text = "";
                this.txtPhone.Text = "";
                this.txtAddress.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //删除
        private void button5_Click(object sender, EventArgs e)
        {
            if (Fid == 0)
            {
                MessageBox.Show("请先选中联系人信息！");
                return;
            }
            try
            {
                res.deteleInfo(Fid);
                MessageBox.Show("删除联系人成功！");
                this.getInfo();
                this.enableInfo();
                this.txtName.Text = "";
                this.txtPhone.Text = "";
                this.txtAddress.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
