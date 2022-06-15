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
    /// Interaction logic for select_book.xaml
    /// </summary>
    public partial class select_book : Window
    {
        String id = "";
        String ibsn = "";
        String name = "";
        public select_book(String uid)
        {
            InitializeComponent();
            CustomerDatabase customerDatabase = new CustomerDatabase();
            List<String> entries = CustomerDatabase.Get_Detail(uid);
            id = entries[0];
            name = entries[1];
            user_name.Text = entries[1];
            address.Text = entries[2];
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            Bookdatabase bookdatabase = new Bookdatabase();
            if (Bookdatabase.checkIBSN(IBSN.Text))
            {
                if (IBSN.Text.Trim() != "")
                {
                    List<String> entries = Bookdatabase.Get_data_onlyIBSN(IBSN.Text);
                    book_name.Text = entries[1].ToString();
                    book_price.Text = entries[2].ToString();
                }
                else
                {
                    MessageBox.Show("กรุณาใส่เลขหนังสือ(IBSN)");
                }
            }
            else
            {
                MessageBox.Show("IBSN : " + IBSN.Text + " ไม่มีอยู่ในรายชื่อหนังสือ");
                book_name.Text = "";
                book_price.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int price = 0;
            Bookdatabase bookdatabase = new Bookdatabase();
            if (Bookdatabase.checkIBSN(IBSN.Text))
            {
                if (IBSN.Text.Trim() != ""&& book_count.Text.Trim() != "" && int.Parse(book_count.Text)>=1)
                {
                    List<String> entries = Bookdatabase.Get_data_onlyIBSN(IBSN.Text);
                    price = int.Parse(entries[2]);
                    count = int.Parse(book_count.Text);
                    total_price.Text = (price * count).ToString();
                }
                else
                {
                    MessageBox.Show("กรุณาใส่เลขหนังสือ(IBSN) ให้ถูกต้อง หรือ ระบุจำนวนหนังสือที่ต้องการให้ถูกต้อง");
                }
            }
            else
            {
                MessageBox.Show("IBSN : " + IBSN.Text + " ไม่มีอยู่ในรายชื่อหนังสือ");
                book_name.Text = "";
                book_price.Text = "";
            }
        }

        private void buy_book_cancle_Click(object sender, RoutedEventArgs e)
        {
            Main_Page mp = new Main_Page(id);
            Hide();
            mp.Show();
        }

        private void buy_book_confirm_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int price = 0;
            string total_price = "";
            Bookdatabase bookdatabase = new Bookdatabase();
            if (Bookdatabase.checkIBSN(IBSN.Text))
            {
                if (IBSN.Text.Trim() != "" && book_count.Text.Trim() != "" && int.Parse(book_count.Text) >= 1 && address.Text.Trim() != "")
                {
                    List<String> entries = Bookdatabase.Get_data_onlyIBSN(IBSN.Text);
                    price = int.Parse(entries[2]);
                    count = int.Parse(book_count.Text);
                    total_price = (price * count).ToString();
                    MessageBoxResult result = MessageBox.Show("รายละเอียดการจัดส่ง\n" + "เราจะทำการจัดส่งไปที่ คุณ" + user_name.Text + "\nที่อยู่ในการจัดส่ง " + address.Text + "\nยอดค้างชำระปลายทาง " + total_price.ToString() + "\nกรุณาตรวจสอบให้ถูกต้องด้วยครับ", "ตรวจสอบตวามถูกต้อง",MessageBoxButton.OKCancel);
                    if(result == MessageBoxResult.OK)
                    {
                        MessageBox.Show("ถ้ามีการสั่งซื้อเพิ่มที่ไม่เกิน 2 วัน เราจะทำการแพ็คส่งไปพร้อมกันทันที ขอบคุณครับ");
                    }
                }
                else
                {
                    MessageBox.Show("กรุณาใส่เลขหนังสือ(IBSN) ให้ถูกต้อง ระบุจำนวนหนังสือที่ต้องการให้ถูกต้อง หรือ ระบุที่อยู่ที่ต้องการจัดส่งให้ถูกต้อง");
                }
            }
            else
            {
                MessageBox.Show("IBSN : " + IBSN.Text + " ไม่มีอยู่ในรายชื่อหนังสือ");
                book_name.Text = "";
                book_price.Text = "";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
