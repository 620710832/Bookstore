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

namespace Bookstore
{
    /// <summary>
    /// Interaction logic for sign_up_window.xaml
    /// </summary>
    public partial class sign_up_window : Window
    {
        public sign_up_window()
        {
            InitializeComponent();
            CustomerDatabase.InitializeDatabase();
        }
        private void sign_up_Click(object sender, RoutedEventArgs e)
        {
            CustomerDatabase customerDatabase = new CustomerDatabase();
            if (cus_name.Text.Trim() == "" || cus_email.Text.Trim() == "" || cus_address.Text.Trim() == "" || cus_password.Password.Trim() == "" || cus_password_confirm.Password.Trim() == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วนด้วยครับ\n");
            }
               else if (cus_password.Password.ToString() != cus_password_confirm.Password.ToString())
                {
                    MessageBox.Show("กรุณายืนยันรหัสผ่านใหม่ด้วยครับ\n ");
                    cus_password.Password = "";
                    cus_password_confirm.Password = "";
                }
                else if(CustomerDatabase.checkemail(cus_email.Text))
                {
                    CustomerDatabase.AddData(cus_name.Text, cus_email.Text, cus_address.Text, cus_password.Password.ToString());
                    MessageBox.Show("ยินดีต้อนรับเข้าสู่ร้านของเรา " + cus_name.Text);
                    MainWindow mn = new MainWindow();
                    Hide();
                    mn.Show();
                }
                else if (CustomerDatabase.checkemail(cus_email.Text)==false)
                {
                    MessageBox.Show("อีเมลนี้มีผู้ใช้ใช้แล้ว");
                    cus_email.Text = "";
                }
           else
           {
               MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน ");
           }
        }
    }
}
