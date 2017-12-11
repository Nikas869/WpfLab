using System.Data.Entity;
using System.Windows;
using WpfLab.Models;

namespace WpfLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Context context;

        public MainWindow()
        {
            InitializeComponent();

            context = new Context();
            context.Issuances.Load();
            context.Readers.Load();

            issuancesGrid.ItemsSource = context.Issuances.Local.ToBindingList();
            readersGrid.ItemsSource = context.Readers.Local.ToBindingList();
        }
    }
}
