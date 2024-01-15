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
using System.Windows.Shapes;

namespace Календарь
{
    public partial class AddEventWindow : Window
    {
        // В окне вводим событие
        public Event Event { get; set; }

        public AddEventWindow()
        {
            InitializeComponent();
            Event = new Event();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Здесь сохраняем введенные данные в свойство Event и закрываем окно.
            DialogResult = true;
            Close();
        }

        // Если ваше событие является праздником, ставим галочку и тип события будет Праздник, по умолчанию оно Событие
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
