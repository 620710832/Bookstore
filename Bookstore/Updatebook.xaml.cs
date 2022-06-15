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
    /// Interaction logic for Updatebook.xaml
    /// </summary>
    public partial class Updatebook : Window
    {
        String id = "";
        String ibsn = "";
        String name = "";
        public Updatebook(String uid)
        {
            InitializeComponent();
            CustomerDatabase customerDatabase = new CustomerDatabase();
            List<String> entries = CustomerDatabase.Get_Detail(uid);
            id = entries[0];
            name = entries[1];
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            Bookdatabase bookdatabase = new Bookdatabase();
            if (Bookdatabase.checkIBSN(IBSN.Text))
            {
                if (IBSN.Text.Trim() != "")
                {
                    List<String> entries = Bookdatabase.Get_data_onlyIBSN(IBSN.Text);
                    book_name_update.Text = entries[1].ToString();
                    book_price_update.Text = entries[2].ToString();
                }
                else
                {
                    MessageBox.Show("กรุณาใส่เลขหนังสือ(IBSN)");
                }
            }
            else
            {
                MessageBox.Show("IBSN : "+IBSN.Text+" ไม่มีอยู่ในรายชื่อหนังสือ");
                book_name_update.Text = "";
                book_price_update.Text = "";
            }
        }

        private void update_book_confirm_Click(object sender, RoutedEventArgs e)
        {
            Bookdatabase bookdatabase = new Bookdatabase();
            List<String> entries = Bookdatabase.Get_data_onlyIBSN(IBSN.Text);
            if (Bookdatabase.checkIBSN(IBSN.Text))
            {
                if (entries[3].ToString() == name)
                {
                    if(book_name_update.Text.Trim() != "" && book_price_update.Text.Trim() != "")
                    {
                        CustomerDatabase customerDatabase = new CustomerDatabase();
                        Bookdatabase.UpdateData(IBSN.Text,book_name_update.Text,book_price_update.Text);
                        MessageBox.Show("เราได้ทำการอัปเดตในรายการหนังสือเรียบร้อยแล้ว");
                        Hide();
                        Main_Page mn = new Main_Page(id);
                        mn.Show();
                    }
                }
                else
                {
                    MessageBox.Show("คุณไม่มีสิทธิ์เข้าถึงหนังสือเล่มนี้");
                    book_name_update.Text = "";
                    book_price_update.Text = "";
                }
            }
            else
            {
                MessageBox.Show("IBSN : " + IBSN.Text + " ไม่มีอยู่ในรายชื่อหนังสือ");
            }
        }

        private void add_book_cancle_Click(object sender, RoutedEventArgs e)
        {
            Main_Page mn = new Main_Page(id);
            Hide();
            mn.Show();
        }

        private void book_price_update_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
