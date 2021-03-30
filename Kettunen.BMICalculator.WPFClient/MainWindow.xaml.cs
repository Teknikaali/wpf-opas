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

namespace Kettunen.BMICalculator.WPFClient
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var isWeightValid = double.TryParse(WeightInput.Text, out var weight);
            var isHeightValid = double.TryParse(HeightInput.Text, out var height);
            if (isWeightValid && isHeightValid)
            {
                height = height / 100;
                var bodyMassIndex = weight / Math.Pow(height, 2);
                var resultMessage = $"BMI: {bodyMassIndex:N1}";
                MessageBox.Show(resultMessage);
            }
        }
    }
}
