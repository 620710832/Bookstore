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
    /// Interaction logic for Main_Page.xaml
    /// </summary>
    public partial class Main_Page : Window
    {
        string id = "";
        public Main_Page(String uid)
        {
            InitializeComponent();
            CustomerDatabase customerDatabase = new CustomerDatabase();
            Bookdatabase.InitializeDatabase();
            List<String> entries = CustomerDatabase.Get_Detail(uid);
            UID.Text = entries[0];
            user_name.Text = "สวัสดีครับคุณ : "+entries[1];
            id = entries[0];
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Edit_Profile ed = new Edit_Profile(UID.Text);
            ed.Show();
            Hide();
        }

        private void add_book_Click(object sender, RoutedEventArgs e)
        {
            Book_ADD book_ADD = new Book_ADD(id);
            Hide();
            book_ADD.Show();
        }

        private void search_book_Click(object sender, RoutedEventArgs e)
        {
            Bookdatabase bookdatabase = new Bookdatabase();
            List<String> entries = Bookdatabase.Get_data();
            int count = 0;
            for (int i = 0; i<(entries.Count/4);i++ ) {
                MessageBox.Show("รายละเอียดของหนังสือ\nIBSN : " + entries[count] + "\nชื่อหนังสือ : " + entries[count+1] + "\nราคา : " + entries[count+2] + "\nรายชื่อผู้ที่เพิ่มหนังสือ : " + entries[count+3]);
                count += 4;
            }
        }

        private void update_book__Click(object sender, RoutedEventArgs e)
        {
            Updatebook updatebook = new Updatebook(id);
            Hide();
            updatebook.Show();
        }

        private void buy_book_Click(object sender, RoutedEventArgs e)
        {
            select_book select_Book = new select_book(id);
            Hide();
            select_Book.Show();
        }
    }
}
