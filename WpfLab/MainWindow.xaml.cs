using System.Data.Entity;
using System.Windows;
using WpfLab.Models;
using WpfLab.Services;

namespace WpfLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Context context;
        public readonly PeriodicalService periodicalService;

        public MainWindow()
        {
            InitializeComponent();

            context = new Context();
            context.Issuances.Load();
            context.Readers.Load();
            context.Publishings.Load();
            context.Publications.Load();

            periodicalService = new PeriodicalService(context);

            issuancesGrid.ItemsSource = context.Issuances.Local.ToBindingList();
            readersGrid.ItemsSource = context.Readers.Local.ToBindingList();
            publishingsGrid.ItemsSource = context.Publishings.Local.ToBindingList();
            publicationsGrid.ItemsSource = context.Publications.Local.ToBindingList();
        }
    }
}
