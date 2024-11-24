using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace collections
{
    public class MyTable
    {
        public string ColFIO{ get; set; }
        public string ColStreet{ get; set; }
        public string ColHome{ get; set; }
        public string ColApartment{ get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            this.Content = "Закрыл) И больше не открою)))";
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            ListEmployees1.Items.Add(new MyTable{
                ColFIO=FIO.Text,
                ColHome=Home.Text,
                ColStreet=Street.Text,
                ColApartment=Apartment.Text
            });
        }
        public static void SortDataGrid(DataGrid dataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            var column = dataGrid.Columns[columnIndex];

            // Clear current sort descriptions
            dataGrid.Items.SortDescriptions.Clear();

            // Add the new sort description
            dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));

            // Apply sort
            foreach (var col in dataGrid.Columns)
            {
                col.SortDirection = null;
            }
            column.SortDirection = sortDirection;

            // Refresh items to display sort
            dataGrid.Items.Refresh();
        }
        
        private void ButtonSort(object sender, RoutedEventArgs e)
        {
            // Очистка второго DataGrid перед добавлением новых элементов
            ListEmployees2.Items.Clear();

            // Поиск строк, где ColStreet содержит слово "Красной"
            foreach (var item in ListEmployees1.Items.OfType<MyTable>().Where(x => x.ColStreet.Contains("Красной")))
            {
                ListEmployees2.Items.Add(item);
            }
            SortDataGrid(ListEmployees2, 0, ListSortDirection.Ascending);
        }
    }
   
}
