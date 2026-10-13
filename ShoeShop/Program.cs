namespace ShoeShop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetDefaultFont(new Font("Times New Roman", 11F));
            // Любая ошибка показывается сообщением, приложение не закрывается аварийно
            Application.ThreadException += (s, e) => MessageBox.Show("Ошибка: " + e.Exception.Message + "\nПроверьте введённые данные и подключение к базе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Run(new Login());
        }
    }
}
