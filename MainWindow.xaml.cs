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
            IDataWriter dataWriter = new Payment(dataReader.Read());
            dataWriter.Write();
        }
    }
}
