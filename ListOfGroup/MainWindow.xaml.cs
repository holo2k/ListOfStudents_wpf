using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListOfGroup
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> names; // объявляем список

        //в качестве источника применяется класс ObservableCollection, который находится в пространстве имен System.Collections.ObjectModel.
        //Его преимущество заключается в том, что при любом изменении ObservableCollection может уведомлять элементы, которые применяют привязку,
        // в результате чего обновляется не только сам объект ObservableCollection, но и привязанные к нему элементы интерфейса.


        // Чтобы объект мог полноценно реализовать механизм привязки, нам надо реализовать в его классе интерфейс INotifyPropertyChanged.
        //Когда объект класса изменяет значение свойства, то он через событие PropertyChanged извещает систему об изменении свойства.
        //А система обновляет все привязанные объекты.

        class ObservableCollection : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName]string prop = "")
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

        }


        public MainWindow()
        {
            InitializeComponent();
            // заполняем ListBox данными
            names = new ObservableCollection<string> { "Беликов Никита", "Чухарев кирилл" };
            namesList.ItemsSource = names;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((NameTextBox.Text != "")&&(SecondNameTextBox.Text!=""))
            {
                string fullName = NameTextBox.Text+" "+SecondNameTextBox.Text;
                // добавляем новый элемент в список
                names.Add(fullName);
            }
            else MessageBox.Show("Введите элемент списка  тесктовое поле");
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                names.Remove(namesList.SelectedItem.ToString());
            }
            catch
            {
                MessageBox.Show("Выберите элемент списка");
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            namesList.Items.Clear();
        }
    }
}

