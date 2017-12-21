﻿using System.Windows;
using WpfLab.Models;

namespace WpfLab.Views
{
    /// <summary>
    /// Interaction logic for PublicationAddWindow.xaml
    /// </summary>
    public partial class PublicationAddWindow : Window
    {
        public PublicationAddWindow()
        {
            InitializeComponent();
        }

        public Publication Publication { get; set; }
        private int numValue = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Publication = new Publication();
            txtNum.Text = numValue.ToString();
        }

        private void txtNum_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (txtNum == null)
            {
                return;
            }

            if (!int.TryParse(txtNum.Text, out numValue))
                txtNum.Text = numValue.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(iSSNTextBox.Text) || string.IsNullOrWhiteSpace(nameTextBox.Text) || !dateDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            Publication.Name = nameTextBox.Text;
            Publication.ISSN = iSSNTextBox.Text;
            Publication.Date = dateDatePicker.SelectedDate.Value;
            Publication.Quantity = numValue;
            DialogResult = true;
            Close();
        }
    }
}
