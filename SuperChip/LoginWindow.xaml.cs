using BAL.Service;
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
using System.Windows.Shapes;

namespace SuperChip
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        //chip chip qua chip ko tot
        private readonly SystemUserService systemUserService;
        public LoginWindow()
        {
            InitializeComponent();
            systemUserService = new SystemUserService();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var userEmail = txtEmail.Text;
            var userPassword = txtPassword.Password;
            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userPassword))
            {
                MessageBox.Show("Please enter both email and password.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!systemUserService.IsValidUser(userEmail, userPassword))
            {
                MessageBox.Show("You have no permission to access this function!");
            }
            else
            {
                var roleId = systemUserService.GetRoleId(userEmail);
                if (roleId != 2 && roleId != 3)
                {
                    MessageBox.Show("You have no permission to access this function!");
                }
                else
                {
                    JLPTMockTestManagement window = new JLPTMockTestManagement(userEmail);
                    window.Show();
                    this.Close();
                }
            }
        }

    }
}
