using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Календарь
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Event> Events { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Events = new ObservableCollection<Event>();
            eventsListView.ItemsSource = Events;

            // Устанавливаем текст в TextBlock на текущую дату
            currentDateTextBlock.Text = DateTime.Now.ToString("dd.MM.yyyy");

            // Устанавливаем текст в TextBlock на текущий день недели
            dayOfWeekTextBlock.Text = DateTime.Now.ToString("dddd");

            // Устанавливаем текст в TextBlock на текущее время
            currentTimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            // Вызов окна для добавления нового события.
            var addEventWindow = new AddEventWindow();
            if (addEventWindow.ShowDialog() == true)
            {
                Events.Add(addEventWindow.Event);
            }
        }

        private void EditEvent_Click(object sender, RoutedEventArgs e)
        {
            // Вызваем окно для редактирования существующего события.
            if (eventsListView.SelectedItem != null)
            {
                var editEventWindow = new EditEventWindow(eventsListView.SelectedItem as Event);
                if (editEventWindow.ShowDialog() == true)
                {
                    // Обновляем событие в коллекции.
                    eventsListView.Items.Refresh();
                }
            }
        }

        private void DeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            // Здесь удаляем выбранное событие из коллекции.
            if (eventsListView.SelectedItem != null)
            {
                Events.Remove(eventsListView.SelectedItem as Event);
            }
        }
    }
}