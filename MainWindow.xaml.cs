using System.Windows;
using RentailInvoice.DataReader;
using RentailInvoice.DataWriter;
using RentailInvoice.Interfaces;

namespace RentailInvoiceWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LabelDrop_Drop(object sender, DragEventArgs e)
        {
            var droppedPaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            TextFilePath.Text = droppedPaths[0];
            //
            IDataReader dataReader = new CalculateDataReader(TextFilePath.Text);
            IDataWriter dataWriter;
            try
            {
                dataWriter = new Payment(dataReader.Read());
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтения данных", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }

            try
            {
                dataWriter.Write();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка формирования данных", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }

            Complete complete = new Complete
            {
                DataWriter = dataWriter
            };
            complete.ShowDialog();
            TextFilePath.Text = "Перетащите каталог сюда";
        }
    }
}
