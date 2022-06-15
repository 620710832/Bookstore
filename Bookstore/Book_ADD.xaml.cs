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
    /// Interaction logic for Book_ADD.xaml
    /// </summary>
    public partial class Book_ADD : Window
    {
        String id = "";
        public Book_ADD(String uid)
        {
            InitializeComponent();
            CustomerDatabase customerDatabase = new CustomerDatabase();
            Bookdatabase.InitializeDatabase();
            List<String> entries = CustomerDatabase.Get_Detail(uid);
            UID.Text = entries[0];
            id = entries[0];
        }

        private void add_book_cancle_Click(object sender, RoutedEventArgs e)
        {
            Main_Page mn = new Main_Page(id);
            Hide();
            mn.Show();
        }

        private void add_book_confirm_Click(object sender, RoutedEventArgs e)
        {
            if (Book_name.Text.Trim() != "" && Book_price.Text.Trim() != "")
            {
                Bookdatabase bookdatabase = new Bookdatabase();
                CustomerDatabase customerDatabase = new CustomerDatabase();
                List<String> entries = CustomerDatabase.Get_Detail(id);
                String biller = entries[1];
                bookdatabase.AddData(Book_name.Text, Book_price.Text, biller);
                MessageBox.Show("เราได้เพิ่มหนังสือเข้าระบบเรียบร้อยแล้วครับ");
                Book_name.Text = "";
                Book_price.Text = "";
            }
            else
            {
                MessageBox.Show("กรุณาหรอกข้อมูลให้ครับถ้วนด้วยครับ");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
