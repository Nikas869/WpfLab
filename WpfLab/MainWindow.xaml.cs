using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using WpfLab.Models;
using WpfLab.Services;
using WpfLab.Views;

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
            context.Publications.Load();

            periodicalService = new PeriodicalService(context);

            issuancesGrid.ItemsSource = periodicalService.Issuances.ToBindingList();
            readersGrid.ItemsSource = periodicalService.Readers.ToBindingList();
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

        private void AddReaderButton_Click(object sender, RoutedEventArgs e)
        {
            var readerAddWindow = new ReaderAddWindow();
            if (readerAddWindow.ShowDialog().Value)
            {
                periodicalService.AddReader(readerAddWindow.Reader);
            }
        }

        private void DeleteReader_Click(object sender, RoutedEventArgs e)
        {
            if (readersGrid.SelectedIndex != -1)
            {
                periodicalService.RemoveReader(((Reader)readersGrid.SelectedItem).Id);
            }
        }

        private void AddPublicationButton_Click(object sender, RoutedEventArgs e)
        {
            var publicationAddWindow = new PublicationAddWindow();
            if (publicationAddWindow.ShowDialog().Value)
            {
                periodicalService.AddPublication(publicationAddWindow.Publication);
            }
        }

        private void AddIssuanceButton_Click(object sender, RoutedEventArgs e)
        {
            var issuanceAddWindow = new IssuanceAddWindow();
            if (issuanceAddWindow.ShowDialog().Value)
            {
                try
                {
                    periodicalService.AddIssuance(issuanceAddWindow.Issuance);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CloseIssuance_Click(object sender, RoutedEventArgs e)
        {
            if (issuancesGrid.SelectedIndex != -1)
            {
                periodicalService.CloseIssuance(((Issuance)issuancesGrid.SelectedItem).Id);
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            periodicalService.Reload();
        }
    }
}
