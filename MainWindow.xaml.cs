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
using TicketBookingSystem.Models;
namespace TicketBookingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CodeFirstContext2 db = new CodeFirstContext2();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Txtname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Bsubmit_Click(object sender, RoutedEventArgs e)
        {
            string name = Txtname.Text;
            string em = Txtemail.Text;
            string phone = Txtphone.Text;
            DateTime dt = DateTime.Parse(Datepick.Text);
            var d = dt.Date;

            DateTime tpp = DateTime.Now;
            var p = tpp.TimeOfDay;
            var de=d.Add(p);
            //string Time = tpp.ToString("HH:mm:ss:tt");
            

            string tt = "";
            if(Rbstandard.IsChecked == true)
            {
                tt = "Standard";
            }
            if (Rvip.IsChecked == true)
            {
                tt = "VIP";
            }
            string tn = Txtticket.Text;
            string cmt = Txtcomment.Text;





            
           // MessageBox.Show(title + "\n" + publisher + "\n" + category + "\n" + price);


            try
            {
                
                Ticket t = new Ticket();
                t.Name=name;
                t.Email=em;
                t.Phone=phone;
                 t.BDate=de;


                t.Tickettype = tt;
                t.Ticketcount = Int32.Parse(tn);
                t.Comment = cmt;

              

                db.Tickets.Add(t);
                int res = db.SaveChanges();
                if (res == 1)
                {
                    MessageBox.Show("data inserted succesfully");
                }
                var data = db.Tickets.ToList();
                Dgrid.DataContext = data;
                Dgrid.ItemsSource = data;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }




        }
    }
}
