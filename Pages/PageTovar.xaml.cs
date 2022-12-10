using ISRPO_PR15_Cherednichenko.ApplicationData;
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

namespace ISRPO_PR15_Cherednichenko.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTovar.xaml
    /// </summary>
    public partial class PageTovar : Page
    {
        public PageTovar()
        {
            InitializeComponent();
            DGTovars.ItemsSource = SofaEntities.GetContext().Tovars.ToList();
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new PageAdd(null));
        }

        private void btnRedact_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new PageAdd((sender as Button).DataContext as Tovars));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility.Visible == Visibility)
            {
                SofaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGTovars.ItemsSource = SofaEntities.GetContext().Tovars.ToList();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var _TovarForDel = DGTovars.SelectedItems.Cast<Tovars>().ToList();
            if (MessageBox.Show("Вы действительно хотите удалить?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    SofaEntities.GetContext().Tovars.RemoveRange(_TovarForDel);
                    SofaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                    DGTovars.ItemsSource = SofaEntities.GetContext().Tovars.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
