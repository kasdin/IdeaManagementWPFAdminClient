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
using IdeaManagementWPFAdminClient.Model;
using IdeaManagementWPFAdminClient.ViewController;

namespace IdeaManagementWPFAdminClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginController loginController = new LoginController();
            loginController.LoginTest(TxtUsername.Text, TxtPassword.Password);
            Console.WriteLine("BUtton is clicked");

            GrdAdminCreateNew.Visibility = Visibility.Visible;
            //GrdManage.Visibility = Visibility.Visible;
            GrdLogin.Visibility = Visibility.Collapsed;
            //GrdManage1.Visibility = Visibility.Visible;
            
        }

        private void BtnAddNew_Click(object sender, RoutedEventArgs e)
        {
            Customers customer = new Customers();

            customer.fld_name = TxtName.Text;

            customer.fld_mail = TxtMail.Text;

            customer.fld_phoneNo = TxtPhoneNo.Text;

            customer.fld_url = TxtURL.Text;

            CustomersController controller = new CustomersController();
            bool isSuccess = controller.CreateCustomers(customer);

            if (isSuccess)
            {
                TxtName.Clear();
                TxtMail.Clear();
                TxtPhoneNo.Clear();
                TxtURL.Clear();
                MessageBox.Show("The customer was created successfully");
            }
            else
            {
                MessageBox.Show("Something went wrong try again.");
            }

        }

        private void BtnManage_Click(object sender, RoutedEventArgs e)
        {
            BtnManage.Name = "Back";
            BtnManage.Click += BtnLogin_Click;
            GrdAdminCreateNew.Visibility = Visibility.Collapsed;
            GrdManage1.Visibility = Visibility.Visible;
            CustomersController controller = new CustomersController();
            List<Button> listOfBtns = controller.GenerateCustomerList();
            foreach (var button in listOfBtns)
            {
                button.Click += EditCustomer_Click;
                    StackListOfCustomers.Children.Add(button);
            }

            ScrollCustomerList.Content = StackListOfCustomers;
        }

        public void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(sender.ToString().Remove(0, 32));
            CustomersController controller = new CustomersController();
            Customers customer = controller.GetCustomerInfo(sender.ToString().Remove(0,32));
            GrdEdit.Visibility = Visibility.Visible;
            TxtEditName.Text = customer.fld_name;
            TxtEditMail.Text = customer.fld_mail;
            TxtEditPhoneNo.Text = customer.fld_phoneNo;
            TxtEditUrl.Text = customer.fld_url;
        }
    }
}
