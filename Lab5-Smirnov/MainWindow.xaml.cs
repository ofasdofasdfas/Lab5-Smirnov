using System;
using System.Windows;

namespace FuzzyNumberApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private FuzzyNumber GetFuzzyNumber(string xText, string e1Text, string e2Text)
        {
            if (double.TryParse(xText, out double x) &&
                double.TryParse(e1Text, out double e1) &&
                double.TryParse(e2Text, out double e2))
            {
                return new FuzzyNumber(x, e1, e2);
            }
            throw new InvalidOperationException("Invalid input values.");
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var A = GetFuzzyNumber(A_X.Text, A_E1.Text, A_E2.Text);
                var B = GetFuzzyNumber(B_X.Text, B_E1.Text, B_E2.Text);
                var result = A + B;
                ResultText.Text = "A + B = " + result;
            }
            catch (Exception ex)
            {
                ResultText.Text = ex.Message;
            }
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var A = GetFuzzyNumber(A_X.Text, A_E1.Text, A_E2.Text);
                var B = GetFuzzyNumber(B_X.Text, B_E1.Text, B_E2.Text);
                var result = A - B;
                ResultText.Text = "A - B = " + result;
            }
            catch (Exception ex)
            {
                ResultText.Text = ex.Message;
            }
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var A = GetFuzzyNumber(A_X.Text, A_E1.Text, A_E2.Text);
                var B = GetFuzzyNumber(B_X.Text, B_E1.Text, B_E2.Text);
                var result = A * B;
                ResultText.Text = "A * B = " + result;
            }
            catch (Exception ex)
            {
                ResultText.Text = ex.Message;
            }
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var A = GetFuzzyNumber(A_X.Text, A_E1.Text, A_E2.Text);
                var B = GetFuzzyNumber(B_X.Text, B_E1.Text, B_E2.Text);
                var result = A / B;
                ResultText.Text = "A / B = " + result;
            }
            catch (Exception ex)
            {
                ResultText.Text = ex.Message;
            }
        }

        private void Inverse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var A = GetFuzzyNumber(A_X.Text, A_E1.Text, A_E2.Text);
                var result = A.Inverse();
                ResultText.Text = "Inverse of A = " + result;
            }
            catch (Exception ex)
            {
                ResultText.Text = ex.Message;
            }
        }
    }
}
