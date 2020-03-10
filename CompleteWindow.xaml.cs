using System.Windows;
using Microsoft.Win32;
using RentailInvoice.Interfaces;

namespace RentailInvoiceWPF
{
    /// <summary>
    /// Interaction logic for Complete.xaml
    /// </summary>
    public partial class Complete : Window
    {
        public Complete()
        {
            InitializeComponent();
        }

        public IDataWriter DataWriter { get; set; }

        private void buttonSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы Excel|*.xlsx";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    DataWriter.Save(saveFileDialog.FileName);
                    this.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения файла", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }
            }
        }
    }
}
