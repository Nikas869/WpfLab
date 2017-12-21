using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
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

            issuancesGrid.ItemsSource = periodicalService.Issuances.ToBindingList();
            readersGrid.ItemsSource = periodicalService.Readers.ToBindingList();
            publishingsGrid.ItemsSource = periodicalService.Publishings.ToBindingList();
            publicationsGrid.ItemsSource = periodicalService.Publications.ToBindingList();
        }

        private void readersGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var reader = e.Row.DataContext as Reader;

            if (reader != null)
            {
                if (reader.Id > 0)
                {
                    periodicalService.UpdateReader(reader);
                }
                else
                {
                    periodicalService.AddReader(reader);
                }
            }
        }
    }
}
