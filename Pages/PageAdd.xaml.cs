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
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        private Tovars _currentTovars = new Tovars();

        public PageAdd(Tovars selectedTovars)
        {
            InitializeComponent();
            if (selectedTovars != null)
            {
                _currentTovars = selectedTovars;
            }

            DataContext = _currentTovars;
            ComboColour.ItemsSource = SofaEntities.GetContext().Colour.ToList();
            ComboMather.ItemsSource = SofaEntities.GetContext().Matherial.ToList();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentTovars.nameTovar))
                errors.AppendLine("Укажите название товара");
            if (_currentTovars.type == null)
                errors.AppendLine("Укажите тип товара (диван или кресло)");
            if (_currentTovars.Colour == null)
                errors.AppendLine("Укажите цвет товара");
            if (_currentTovars.Matherial == null)
                errors.AppendLine("Укажите материал товара");
            if (_currentTovars.cena <= 0)
                errors.AppendLine("Цена не может быть меньше или равна 0");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //добавление
            if (_currentTovars.idTovar == 0)
                SofaEntities.GetContext().Tovars.Add(_currentTovars);
            //сохранение
            try
            {
                SofaEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
