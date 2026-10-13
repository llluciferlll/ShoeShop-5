using System.Data;
using Npgsql;

namespace ShoeShop
{
    public partial class Login : Form
    {
        string connStr = "Server=localhost;Port=5432;Database=shoes;User Id=postgres;Password=32351616aa";

        public Login()
        {
            InitializeComponent();
            Icon = Icon.FromHandle(new Bitmap("Icon.png").GetHicon());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var users = new DataTable();
            var da = new NpgsqlDataAdapter("SELECT role, full_name FROM users WHERE login = @l AND password = @p", connStr);
            da.SelectCommand.Parameters.AddWithValue("@l", textBox1.Text);
            da.SelectCommand.Parameters.AddWithValue("@p", textBox2.Text);
            da.Fill(users);
            if (users.Rows.Count == 0)
            {
                MessageBox.Show("Неверный логин или пароль.\nПроверьте раскладку клавиатуры и повторите ввод.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenMain(users.Rows[0]["role"].ToString(), users.Rows[0]["full_name"].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenMain("Гость", "Гость");
        }

        void OpenMain(string role, string fullName)
        {
            Hide();
            new Form1(role, fullName).ShowDialog();
            textBox2.Clear();
            Show();
        }
    }
}
