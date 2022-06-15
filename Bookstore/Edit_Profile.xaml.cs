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
    /// Interaction logic for Edit_Profile.xaml
    /// </summary>
    public partial class Edit_Profile : Window
    {
        String id = "";
        public Edit_Profile(String UID)
        {
            id = UID;
            InitializeComponent();
            CustomerDatabase login_page = new CustomerDatabase();
            List<String> entries = CustomerDatabase.Get_Detail(UID);
            name_edit.Text = entries[1];
            address_edit.Text = entries[2];
            email_edit.Text = entries[3];
        }

        private void sign_up_Click(object sender, RoutedEventArgs e)
        {
            if (name_edit.Text.Trim() == "" || email_edit.Text.Trim() == "" || address_edit.Text.Trim() == "" || password_edit.Password.Trim() == "" || password_edit.Password.Trim() == "") 
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
            }
            else if(name_edit.Text.Trim() != "" || email_edit.Text.Trim() != "" || address_edit.Text.Trim() != "" || password_edit.Password.Trim() != "" || password_edit.Password.Trim() != "")
                {
                if (password_edit.Password != password_edit_confirm.Password)
                {
                    MessageBox.Show("รหัสผ่านไม่ตรงกันกรุณาลองใหม่");
                    password_edit.Password = "";
                    password_edit_confirm.Password = "";
                }
                else if (password_edit.Password == password_edit_confirm.Password) 
                {
                     CustomerDatabase login_Page = new CustomerDatabase();
                    List<String> entries = CustomerDatabase.Get_Detail(id);
                    if (entries[3] == email_edit.Text) 
                    {
                        CustomerDatabase.UpdateData(name_edit.Text, email_edit.Text, address_edit.Text, password_edit.Password, id);
                        MessageBox.Show("อัปเดทข้อมูล คุณ" + name_edit.Text + " เรียบร้อยแล้วครับ");
                        Main_Page mn = new Main_Page(id);
                        mn.Show();
                        Hide();
                    }
                    else if (CustomerDatabase.checkemail(email_edit.Text))
                    {
                        CustomerDatabase.UpdateData(name_edit.Text, email_edit.Text, address_edit.Text, password_edit.Password, id);
                        MessageBox.Show("อัปเดทข้อมูล คุณ" + name_edit.Text + " เรียบร้อยแล้วครับ");
                        Main_Page mn = new Main_Page(id);
                        mn.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("อีเมล "+email_edit.Text+" มีผู้ใช้ใช้แล้ว");
                        email_edit.Text = entries[3];
                    }
                }
                else
                {
                    MessageBox.Show("มีบางอย่างผิดพลาก กรุณาลองใหม่");
                }
                }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            CustomerDatabase login_Page = new CustomerDatabase();
            List<String> entries = CustomerDatabase.Get_Detail(id);
            MessageBoxResult result = MessageBox.Show("Customer ID : " +id, "ยืนยันการลบข้อมูล", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if(result == MessageBoxResult.Yes)
            {
                CustomerDatabase.DeleteData(id);
                MessageBox.Show("เราได้ทำการลบข้อมูลของ คุณ" + entries[1] +" เรียบร้อยแล้ว");
                MainWindow mn = new MainWindow();
                Hide();
                mn.Show();
            }
        }
    }
}
