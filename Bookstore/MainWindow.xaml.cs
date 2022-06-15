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

namespace Bookstore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CustomerDatabase.InitializeDatabase();
        }

        private void sign_up_Click(object sender, RoutedEventArgs e)
        {
            sign_up_window sign_up = new sign_up_window();
            Hide();
            sign_up.Show();
        }

        private void sign_in_Click(object sender, RoutedEventArgs e)
        {
            CustomerDatabase login_page = new CustomerDatabase();
            List<String> entries = CustomerDatabase.Getuser_password(user.Text);
            if (CustomerDatabase.checknull(user.Text))
            {
                if (entries[3].ToString() == user.Text && entries[4].ToString() == password.Password)
                {
                    MessageBox.Show("ยินดีต้อนรับกลับมาคุณ " + entries[1].ToString() + "\nหมายเลขของคุณคือ " + entries[0].ToString());
                    Hide();
                    Main_Page main_Page = new Main_Page(entries[0]);
                    main_Page.DataContext = this;
                    main_Page.ShowDialog();
                    MessageBox.Show("sds");
                }
                else
                {
                    MessageBox.Show("มีบางอย่างผิดพลาด กรุณตรวจสอบ email และ password ");
                    password.Password = "";
                }
            }
        else
            {
                MessageBox.Show("มีบางอย่างผิดพลาด กรุณตรวจสอบ email และ password ");
            }
        }
    }
}
