using System.Data;
using Npgsql;

namespace ShoeShop
{
    public partial class Form1 : Form
    {
        DataTable dt;
        string connStr = "Server=localhost;Port=5432;Database=shoes;User Id=postgres;Password=32351616aa";
        bool canFilter;
        Font strikeFont = new Font("Times New Roman", 11F, FontStyle.Strikeout);

        public Form1(string role, string fullName)
        {
            InitializeComponent();
            Icon = Icon.FromHandle(new Bitmap("Icon.png").GetHicon());
            label1.Text = fullName;
            canFilter = role == "Администратор" || role == "Менеджер";
            comboBox1.Items.Add("products");
            if (canFilter)
                comboBox1.Items.Add("orders");
            if (role == "Администратор")
            {
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                button2.Visible = true;
                buttonPhoto.Visible = true;
            }
            comboBoxSupplier.Items.Add("Все поставщики");
            var suppliers = new DataTable();
            new NpgsqlDataAdapter("select distinct supplier from products order by supplier", connStr).Fill(suppliers);
            foreach (DataRow row in suppliers.Rows)
                comboBoxSupplier.Items.Add(row["supplier"]);
            comboBoxSupplier.SelectedIndex = 0;
            comboBoxSort.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }

        // Загружает картинку без блокировки файла; если файла нет — заглушка picture.png
        static Image LoadImage(string path)
        {
            if (!File.Exists(path))
                path = "picture.png";
            return Image.FromStream(new MemoryStream(File.ReadAllBytes(path)));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            new NpgsqlDataAdapter("select * from " + comboBox1.Text + " order by id", connStr).Fill(dt);
            if (comboBox1.Text == "products")
            {
                // Вычисляемый столбец и фото — только для показа, в базу они не сохраняются
                dt.Columns.Add("Итоговая цена", typeof(decimal), "price * (100 - discount) / 100").SetOrdinal(dt.Columns.IndexOf("price") + 1);
                dt.Columns.Add("Фото", typeof(Image)).SetOrdinal(0);
                foreach (DataRow row in dt.Rows)
                    row["Фото"] = LoadImage(row["photo"].ToString());
                dt.AcceptChanges();
            }
            dataGridView1.DataSource = dt;
            if (dataGridView1.Columns["Фото"] is DataGridViewImageColumn photoColumn)
                photoColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            panelFilter.Visible = canFilter && comboBox1.Text == "products";
            ApplyFilter(null, null);
        }

        // Поиск, фильтр и сортировка работают вместе и сразу при изменении
        private void ApplyFilter(object sender, EventArgs e)
        {
            if (dt == null || comboBox1.Text != "products")
                return;
            string s = textBoxSearch.Text.Replace("'", "''");
            string filter = "1 = 1";
            if (s != "")
                filter += $" AND (article LIKE '%{s}%' OR name LIKE '%{s}%' OR category LIKE '%{s}%' OR description LIKE '%{s}%' OR manufacturer LIKE '%{s}%' OR supplier LIKE '%{s}%')";
            if (comboBoxSupplier.SelectedIndex > 0)
                filter += $" AND supplier = '{comboBoxSupplier.Text}'";
            dt.DefaultView.RowFilter = filter;
            dt.DefaultView.Sort = comboBoxSort.SelectedIndex == 0 ? "quantity ASC" : "quantity DESC";
        }

        // Подсветка строк: скидка > 15% — #2E8B57, нет на складе — голубой, старая цена зачёркнута красным
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var view = dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (comboBox1.Text != "products" || view == null || view["discount"] is not int discount)
                return;
            if (discount > 15)
                e.CellStyle.BackColor = Color.SeaGreen;
            if (view["quantity"] is 0)
                e.CellStyle.BackColor = Color.LightBlue;
            if (discount > 0 && dataGridView1.Columns[e.ColumnIndex].Name == "price")
            {
                e.CellStyle.Font = strikeFont;
                e.CellStyle.ForeColor = Color.Red;
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (comboBox1.Text == "products")
            {
                var orders = new DataTable();
                new NpgsqlDataAdapter($"select id from orders where articles like '%{e.Row.Cells["article"].Value}%'", connStr).Fill(orders);
                if (orders.Rows.Count > 0)
                {
                    MessageBox.Show("Этот товар есть в заказах, удалить его нельзя.", "Удаление невозможно", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
            e.Cancel = MessageBox.Show("Удалить запись? После сохранения её нельзя будет восстановить.", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No;
        }

        // Новое фото уменьшается до 300x200 и сохраняется в папку приложения, старое удаляется
        private void buttonPhoto_Click(object sender, EventArgs e)
        {
            var view = dataGridView1.CurrentRow?.DataBoundItem as DataRowView;
            if (comboBox1.Text != "products" || view == null)
            {
                MessageBox.Show("Выберите товар в таблице товаров.", "Фото товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            string fileName = DateTime.Now.Ticks + ".png";
            new Bitmap(LoadImage(openFileDialog1.FileName), 300, 200).Save(fileName);
            if (File.Exists(view["photo"].ToString()))
                File.Delete(view["photo"].ToString());
            view["photo"] = fileName;
            view["Фото"] = LoadImage(fileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            var da = new NpgsqlDataAdapter("select * from " + comboBox1.Text, connStr);
            new NpgsqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Изменения сохранены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
