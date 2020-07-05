using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace summer_practic
{
    public partial class LoginForm : Form
    {
        static string loginUser;
        static string passUser;
        public LoginForm()
        {
            InitializeComponent();

            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, loginField.Size.Height);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginUser = loginField.Text;
            passUser = passField.Text;
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                db.OpenConnection();
                DbDataReader reader = command.ExecuteReader();
                reader.Read();
                string pos = reader.GetString(5);
                reader.Close();
                db.CloseConnection();
                command.CommandText = "";
                this.Hide();
                if (pos.Equals("worker"))
                {
                    Form1 form = new Form1();
                    form.Show();
                }
                if (pos.Equals("admin"))
                {
                    //AdminMainForm form = new AdminMainForm();
                    //form.Show();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }

        }
    }
}
