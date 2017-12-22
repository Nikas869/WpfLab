using System.Data.Entity;
using System.Windows;
using WpfLab.Models;

namespace WpfLab.Views
{
    /// <summary>
    /// Interaction logic for IssuanceAddWindow.xaml
    /// </summary>
    public partial class IssuanceAddWindow : Window
    {
        public IssuanceAddWindow()
        {
            InitializeComponent();
            Issuance = new Issuance();

            var ctx = new Context();
            ctx.Readers.Load();
            ctx.Publications.Load();

            readersList.ItemsSource = ctx.Readers.Local.ToBindingList();
            publicationsList.ItemsSource = ctx.Publications.Local.ToBindingList();
        }

        public Issuance Issuance { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (readersList.SelectedIndex == -1 || publicationsList.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            Issuance.Reader = (Reader)readersList.SelectedItem;
            Issuance.Publication = (Publication)publicationsList.SelectedItem;
            Issuance.Quantity = quantity.Value.Value;
            DialogResult = true;
            Close();
        }
    }
}
