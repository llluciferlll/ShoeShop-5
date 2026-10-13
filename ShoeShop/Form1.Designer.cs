namespace ShoeShop
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            pictureBoxLogo = new PictureBox();
            labelTitle = new Label();
            label1 = new Label();
            button1 = new Button();
            panelTools = new Panel();
            comboBox1 = new ComboBox();
            panelFilter = new Panel();
            textBoxSearch = new TextBox();
            comboBoxSupplier = new ComboBox();
            comboBoxSort = new ComboBox();
            buttonPhoto = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            openFileDialog1 = new OpenFileDialog();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelTools.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.Chartreuse;
            panelHeader.Controls.Add(pictureBoxLogo);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(button1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1100, 70);
            panelHeader.TabIndex = 0;
            //
            // pictureBoxLogo
            //
            pictureBoxLogo.ImageLocation = "Icon.png";
            pictureBoxLogo.Location = new Point(10, 5);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(60, 60);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            //
            // labelTitle
            //
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            labelTitle.Location = new Point(80, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(140, 25);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "ООО «Обувь»";
            //
            // label1
            //
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.Location = new Point(620, 10);
            label1.Name = "label1";
            label1.Size = new Size(350, 50);
            label1.TabIndex = 2;
            label1.Text = "ФИО";
            label1.TextAlign = ContentAlignment.MiddleRight;
            //
            // button1
            //
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.MediumSpringGreen;
            button1.Location = new Point(980, 15);
            button1.Name = "button1";
            button1.Size = new Size(105, 40);
            button1.TabIndex = 3;
            button1.Text = "Выход";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            //
            // panelTools
            //
            panelTools.Controls.Add(comboBox1);
            panelTools.Controls.Add(panelFilter);
            panelTools.Controls.Add(buttonPhoto);
            panelTools.Controls.Add(button2);
            panelTools.Dock = DockStyle.Top;
            panelTools.Location = new Point(0, 70);
            panelTools.Name = "panelTools";
            panelTools.Size = new Size(1100, 50);
            panelTools.TabIndex = 1;
            //
            // comboBox1
            //
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Location = new Point(10, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(130, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            //
            // panelFilter
            //
            panelFilter.Controls.Add(textBoxSearch);
            panelFilter.Controls.Add(comboBoxSupplier);
            panelFilter.Controls.Add(comboBoxSort);
            panelFilter.Location = new Point(150, 0);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(640, 50);
            panelFilter.TabIndex = 1;
            panelFilter.Visible = false;
            //
            // textBoxSearch
            //
            textBoxSearch.Location = new Point(0, 12);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Поиск...";
            textBoxSearch.Size = new Size(220, 27);
            textBoxSearch.TabIndex = 0;
            textBoxSearch.TextChanged += ApplyFilter;
            //
            // comboBoxSupplier
            //
            comboBoxSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSupplier.Location = new Point(230, 12);
            comboBoxSupplier.Name = "comboBoxSupplier";
            comboBoxSupplier.Size = new Size(180, 28);
            comboBoxSupplier.TabIndex = 1;
            comboBoxSupplier.SelectedIndexChanged += ApplyFilter;
            //
            // comboBoxSort
            //
            comboBoxSort.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSort.Items.AddRange(new object[] { "Количество: по возрастанию", "Количество: по убыванию" });
            comboBoxSort.Location = new Point(420, 12);
            comboBoxSort.Name = "comboBoxSort";
            comboBoxSort.Size = new Size(215, 28);
            comboBoxSort.TabIndex = 2;
            comboBoxSort.SelectedIndexChanged += ApplyFilter;
            //
            // buttonPhoto
            //
            buttonPhoto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonPhoto.Location = new Point(830, 7);
            buttonPhoto.Name = "buttonPhoto";
            buttonPhoto.Size = new Size(125, 36);
            buttonPhoto.TabIndex = 2;
            buttonPhoto.Text = "Фото товара";
            buttonPhoto.UseVisualStyleBackColor = true;
            buttonPhoto.Visible = false;
            buttonPhoto.Click += buttonPhoto_Click;
            //
            // button2
            //
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.MediumSpringGreen;
            button2.Location = new Point(965, 7);
            button2.Name = "button2";
            button2.Size = new Size(120, 36);
            button2.TabIndex = 3;
            button2.Text = "Сохранить";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            //
            // dataGridView1
            //
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 120);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 70;
            dataGridView1.Size = new Size(1100, 530);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.UserDeletingRow += dataGridView1_UserDeletingRow;
            //
            // openFileDialog1
            //
            openFileDialog1.Filter = "Изображения|*.jpg;*.jpeg;*.png";
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(1100, 650);
            Controls.Add(dataGridView1);
            Controls.Add(panelTools);
            Controls.Add(panelHeader);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ООО «Обувь» — Товары и заказы";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelTools.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private PictureBox pictureBoxLogo;
        private Label labelTitle;
        private Label label1;
        private Button button1;
        private Panel panelTools;
        private ComboBox comboBox1;
        private Panel panelFilter;
        private TextBox textBoxSearch;
        private ComboBox comboBoxSupplier;
        private ComboBox comboBoxSort;
        private Button buttonPhoto;
        private Button button2;
        private DataGridView dataGridView1;
        private OpenFileDialog openFileDialog1;
    }
}
