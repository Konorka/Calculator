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

namespace WpfTest3
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
        bool isOperator;
        double solution = 0;
        
        bool isFirstNumber = true;
        
        private void NumberClick(object sender, RoutedEventArgs e)
        {
            if (!isOperator)
            {
                valueTextBox.Text = "";
            }
            
            isOperator = true;
            var button = (Button)sender;
            var value = double.Parse(button.Content.ToString());
           
            if (valueTextBox.Text == "0" && value == 0)
                valueTextBox.Text = value.ToString();
            else if (valueTextBox.Text=="0" && value !=0)
                valueTextBox.Text = value.ToString();
            else
                valueTextBox.Text += value.ToString();
        }
        
        private void OperatorClick(object sender, RoutedEventArgs e)
        {
            if (isOperator)
            {
                
                calculatorLabel.Content += valueTextBox.Text;

                var button = (Button)sender;
                var value = char.Parse(button.Content.ToString());
                calculatorLabel.Content  += value.ToString();
                isOperator = false;
                if (value=='+' )
                { 
                        solution += double.Parse(valueTextBox.Text);
                        valueTextBox.Text = "";
                        valueTextBox.Text = solution.ToString();  
                }

                else if (value == '-')
                {

                    if (isFirstNumber)
                    {
                        solution -= (double.Parse(valueTextBox.Text) - (2 * (double.Parse(valueTextBox.Text))));
                        valueTextBox.Text = "";
                        valueTextBox.Text = solution.ToString();
                        isFirstNumber = false;
                    }
                    else
                    {
                        solution -= double.Parse(valueTextBox.Text);
                        valueTextBox.Text = "";
                        valueTextBox.Text = solution.ToString();
                    }
                }
                else if (value == '*')
                {
                    if (isFirstNumber)
                    {
                        solution = 1;
                        solution = (solution * double.Parse(valueTextBox.Text));
                        valueTextBox.Text = "";
                        valueTextBox.Text = solution.ToString();
                        isFirstNumber = false;
                    }
                    else
                    {
                        solution = (solution * double.Parse(valueTextBox.Text));
                        valueTextBox.Text = "";
                        valueTextBox.Text = solution.ToString();
                    }

                    }
                else if (value =='/')
                {
                    if (valueTextBox.Text!="0" && solution!=0)
                    {
                        solution = (solution/double.Parse(valueTextBox.Text));
                        valueTextBox.Text = "";
                        valueTextBox.Text = solution.ToString();
                    }else
                    {
                        MessageBox.Show("Nem lehet nullával osztani");
                    }
                    
                }
            }

        }

       

        private void CleanClick(object sender, RoutedEventArgs e)
        {
            valueTextBox.Text= "";
            isOperator = false;
            solution = 0;
            
            isFirstNumber = true;
            calculatorLabel.Content = "";
        }

        private void EqualClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
