using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TvorchestvoProgram.Context;
using TvorchestvoProgram.Views.Windows;

namespace TvorchestvoProgram
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbLogin.Text == "" && txbPassword.Text == "")
                {
                    throw new Exception("Заполнитен все поля!");
                }
                else
                {
                    var currentUser = Data.u01.User.FirstOrDefault(item => item.UserLogin == txbLogin.Text && item.UserPassword == txbPassword.Text);
                    if (currentUser != null)
                    {
                        switch (currentUser.UserRole)
                        {
                            case 1:
                                AdminWindow adminWindow = new AdminWindow();
                                adminWindow.ShowDialog();
                                break;
                            case 2:
                                ManagerWindow managerWindow = new ManagerWindow();
                                managerWindow.ShowDialog();
                                break;
                        }

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CancelBth_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
