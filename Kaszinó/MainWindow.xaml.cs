using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace casino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        private ObservableCollection<Table> tables;
        private Dictionary<string, ObservableCollection<Table>> tablesByType;
        private ObservableCollection<string> Keys;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            Tables = new();
            tablesByType = new();
            DataContext = this;
            Keys1 = new();
        }

        public ObservableCollection<Table> Tables { get => tables; set => tables = value; }
        public ObservableCollection<string> Keys1 { get => Keys;
            set { Keys = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Keys)));} }

        private void Button_Load(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.InitialDirectory = "H:\12.B\Progi\5.WPF\WPF - Beadand-\Kaszinó";
            bool success = dialog.ShowDialog() ?? false;
            if (!success) return;
            string path = dialog.FileName;
            using StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine()!.Split(";");
                string type = temp[0];
                string name = temp[1];
                bool active = bool.Parse(temp[2]);
                int spaces = int.Parse(temp[3]);
                Table table = new(type,name,active,spaces);
                tables.Add(table);
            }
            AddListboxtable(tables);
        }

        private void AddListboxtable(ObservableCollection<Table> tables)
        {
            foreach (Table table in tables)
            {
                if (!tablesByType.ContainsKey(table.Type))
                {
                    tablesByType.Add(table.Type, new ObservableCollection<Table>());
                    tablesByType[table.Type].Add(table);
                } else
                {
                    tablesByType[table.Type].Add(table);
                }
            }
            foreach (var key in tablesByType.Keys)
            {
                MessageBox.Show(key);
                Keys1.Append(key);
            }

        }
    }
}