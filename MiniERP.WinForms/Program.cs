using MiniERP.WinForms.Forms;
using MiniERP.WinForms.Services;
using System.Runtime.InteropServices;

namespace MiniERP.WinForms;

static class Program
{
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Debug için console aç
        AllocConsole();
        Console.WriteLine("=== MiniERP Windows Forms Debug Console ===");
        
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        // Tek bir ApiService instance'ı oluştur
        var apiService = new ApiService();
        
        // Login formunu göster
        var loginForm = new LoginForm(apiService);
        if (loginForm.ShowDialog() == DialogResult.OK)
        {
            // Login başarılıysa main formu aç
            var mainForm = new MainForm(apiService, loginForm.LoggedInUser!);
            Application.Run(mainForm);
        }
    }
}