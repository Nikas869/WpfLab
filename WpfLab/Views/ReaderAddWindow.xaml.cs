using System.Windows;
using WpfLab.Models;

namespace WpfLab.Views
{
    /// <summary>
    /// Interaction logic for ReaderEditWindow.xaml
    /// </summary>
    public partial class ReaderAddWindow : Window
    {
        public ReaderAddWindow()
        {
            InitializeComponent();
        }

        public Reader Reader { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Reader = new Reader();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrWhiteSpace(phoneTextBox.Text) || !birthdayDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            Reader.Name = nameTextBox.Text;
            Reader.Phone = phoneTextBox.Text;
            Reader.Birthday = birthdayDatePicker.SelectedDate.Value;
            DialogResult = true;
            Close();
        }
    }
}
