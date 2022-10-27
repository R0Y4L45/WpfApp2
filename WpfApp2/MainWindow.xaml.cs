using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        decimal? result = null;
        decimal first, second;
        bool mul = false, div = false, plus = false, minus = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        void NumberButton(string number)
        {
            if (textBox.Text == "Null")
            {
                textBox.Clear();
                textBox.Text = number;
            }
            else if (textBox.Text == "0")
            {
                textBox.Clear();
                textBox.Text = number.ToString();
            }
            else if (textBox.Text != "0")
            {
                if (textBox.Text.Length < 13)
                    textBox.Text += number.ToString();
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;



            switch (btn?.Name)
            {
                case "btnDiv": // Division
                    if (mul && textBox.Text.Length > 0)
                        goto case "btnMul";
                    else if (plus && textBox.Text.Length > 0)
                        goto case "btnPlus";
                    else if (minus && textBox.Text.Length > 0)
                        goto case "btnMinus";


                    if (!div && textBox.Text.Length > 0)
                    {
                        if (textBox.Text == "Null")
                        {
                            textBox.Clear();
                            return;
                        }

                        if (decimal.TryParse(textBox.Text, out first))
                        {
                            label.Content = null;
                            if (textBox.Text == "0.")
                                textBox.Text = "0";
                            label.Content = textBox.Text + " /";
                        }
                        else
                        {
                            string b;
                            if (label.Content == null)
                            {
                                b = textBox.Text;

                                if (b.Contains('e'))
                                {
                                    int index = b.IndexOf('e');
                                    b = b.Substring(0, index);
                                    first = decimal.Parse(b);
                                }
                                else
                                {
                                    b = b.Substring(0, b.Length - 2);
                                    first = decimal.Parse(b);
                                }

                                label!.Content = null;
                                label.Content = b + " /";
                            }
                            else
                            {
                                b = label.Content.ToString()!;
                                if (b.Contains('e'))
                                {
                                    int index = b.IndexOf('e');
                                    b = b.Substring(0, index);
                                    first = decimal.Parse(b);
                                }
                                else
                                {
                                    b = b.Substring(0, b.Length - 2);
                                    first = decimal.Parse(b);
                                }
                            }
                        }
                        textBox.Clear();

                        mul = false;
                        plus = false;
                        minus = false;
                        div = true;
                    }
                    else if (div && textBox.Text.Length > 0)
                    {
                        if (decimal.TryParse(textBox.Text, out second))
                        {
                            textBox.Clear();

                            if (second == 0)
                                result = null;
                            else
                                result = first / second;

                            string res = result.ToString()!;
                            if (result == null)
                                textBox.Text = "Null";
                            else if (res.Length > 13)
                            {
                                textBox.FontSize = 35;
                                textBox.Text = res.Substring(0, 13) + "e" + $"+{res.Length - 13}";
                            }
                            else
                                textBox.Text = res;

                            label.Content = null;
                        }
                        else
                        {
                            MessageBox.Show("Error");
                            label!.Content = null;
                            first = 0;
                            second = 0;
                            textBox.Clear();
                        }
                        div = false;
                    }
                    else if (!div && textBox.Text.Length == 0 && label.Content != null)
                    {
                        string b;

                        div = true;
                        plus = false;
                        minus = false;
                        mul = false;
                        b = label.Content.ToString()!.Substring(0, label.Content.ToString()!.Length - 2);
                        label.Content = b + " /";
                    }
                    else
                        MessageBox.Show("Please add digits to complete operation", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

                case "btnMul":// Multiplication
                    if (div && textBox.Text.Length > 0)
                        goto case "btnDiv";
                    else if (plus && textBox.Text.Length > 0)
                        goto case "btnPlus";
                    else if (minus && textBox.Text.Length > 0)
                        goto case "btnMinus";

                    if (!mul && textBox.Text.Length > 0)
                    {

                        if (textBox.Text == "Null")
                        {
                            textBox.Clear();
                            return;
                        }

                        if (decimal.TryParse(textBox.Text, out first))
                        {
                            label.Content = null;
                            if (textBox.Text == "0.")
                                textBox.Text = "0";
                            label.Content = textBox.Text + " *";
                        }
                        else
                        {
                            string b;
                            if (label.Content == null)
                            {
                                b = textBox.Text;

                                if (b.Contains('e'))
                                {
                                    int index = b.IndexOf('e');
                                    b = b.Substring(0, index);
                                    first = decimal.Parse(b);
                                }
                                else
                                {
                                    b = b.Substring(0, b.Length - 2);
                                    first = decimal.Parse(b);
                                }

                                label!.Content = null;
                                label.Content = b + " *";
                            }
                            else
                            {
                                b = label.Content.ToString()!;
                                if (b.Contains('e'))
                                {
                                    int index = b.IndexOf('e');
                                    b = b.Substring(0, index);
                                    first = decimal.Parse(b);
                                }
                                else
                                {
                                    b = b.Substring(0, b.Length - 2);
                                    first = decimal.Parse(b);
                                }
                            }
                        }
                        textBox.Clear();

                        mul = true;
                        plus = false;
                        minus = false;
                        div = false;
                    }
                    else if (mul && textBox.Text.Length > 0)
                    {
                        if (decimal.TryParse(textBox.Text, out second))
                        {
                            textBox.Clear();

                            result = first * second;

                            string res = result.ToString()!;

                            if (res.Length > 13)
                            {
                                textBox.FontSize = 35;
                                textBox.Text = res.Substring(0, 13) + "e" + $"+{res.Length - 13}";
                            }
                            else
                                textBox.Text = res;

                            label.Content = null;
                        }
                        else
                        {
                            MessageBox.Show("Error");
                            label!.Content = null;
                            first = 0;
                            second = 0;
                            textBox.Clear();
                        }
                        mul = false;
                    }
                    else if (!mul && textBox.Text.Length == 0 && label.Content != null)
                    {
                        string b;

                        div = false;
                        plus = false;
                        minus = false;
                        mul = true;
                        b = label.Content.ToString()!.Substring(0, label.Content.ToString()!.Length - 2);
                        label.Content = b + " *";
                    }
                    else
                        MessageBox.Show("Please add digits to complete operation", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

                case "btnPlus": // addition
                    if (mul && textBox.Text.Length > 0)
                        goto case "btnMul";
                    else if (div && textBox.Text.Length > 0)
                        goto case "btnDiv";
                    else if (minus && textBox.Text.Length > 0)
                        goto case "btnMinus";


                    if (!plus && textBox.Text.Length > 0)
                    {
                        if (textBox.Text == "Null")
                        {
                            textBox.Clear();
                            return;
                        }

                        if (decimal.TryParse(textBox.Text, out first))
                        {
                            label.Content = null;
                            if (textBox.Text == "0.")
                                textBox.Text = "0";
                            label.Content = textBox.Text + " +";
                        }
                        else
                        {
                            string b;
                            if (label.Content == null)
                            {
                                b = textBox.Text;

                                if (b.Contains('e'))
                                {
                                    int index = b.IndexOf('e');
                                    b = b.Substring(0, index);
                                    first = decimal.Parse(b);
                                }
                                else
                                {
                                    b = b.Substring(0, b.Length - 2);
                                    first = decimal.Parse(b);
                                }

                                label!.Content = null;
                                label.Content = b + " +";

                            }
                            else
                            {
                                b = label.Content.ToString()!;
                                if (b.Contains('e'))
                                {
                                    int index = b.IndexOf('e');
                                    b = b.Substring(0, index + 1);
                                    first = decimal.Parse(b);
                                }
                                else
                                {
                                    b = b.Substring(0, b.Length - 2);
                                    first = decimal.Parse(b);
                                }
                            }
                        }
                        textBox.Clear();

                        mul = false;
                        plus = true;
                        minus = false;
                        div = false;
                    }
                    else if (plus && textBox.Text.Length > 0)
                    {
                        if (decimal.TryParse(textBox.Text, out second))
                        {
                            textBox.Clear();

                            result = (first) + (second);

                            string res = result.ToString()!;

                            if (res!.Length > 13)
                                textBox.Text = res.Substring(0, 13);
                            else
                                textBox.Text = res;

                            label.Content = null;
                        }
                        else
                        {
                            MessageBox.Show("Error");
                            label!.Content = null;
                            first = 0;
                            second = 0;
                            textBox.Clear();
                        }
                        plus = false;
                    }
                    else if (!plus && textBox.Text.Length == 0 && label.Content != null)
                    {
                        string b;

                        div = false;
                        plus = true;
                        minus = false;
                        mul = false;
                        b = label.Content.ToString()!.Substring(0, label.Content.ToString()!.Length - 2);
                        label.Content = b + " +";
                    }
                    else
                        MessageBox.Show("Please add digits to complete operation", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                    break;

                case "btnMinus": // subtraction

                    if (mul && textBox.Text.Length > 0)
                        goto case "btnMul";
                    else if (div && textBox.Text.Length > 0)
                        goto case "btnDiv";
                    else if (plus && textBox.Text.Length > 0)
                        goto case "btnPlus";


                    if (!minus && textBox.Text.Length > 0)
                    {
                        if (textBox.Text == "Null")
                        {
                            textBox.Clear();
                            return;
                        }

                        if (decimal.TryParse(textBox.Text, out first))
                        {
                            label.Content = null;
                            if (textBox.Text == "0.")
                                textBox.Text = "0";
                            label.Content = textBox.Text + " -";
                        }
                        else
                        {
                            string b;
                            if (label.Content == null)
                            {
                                b = textBox.Text;

                                if (b.Contains('e'))
                                {
                                    int index = b.IndexOf('e');
                                    b = b.Substring(0, index);
                                    first = decimal.Parse(b);
                                }
                                else
                                {
                                    b = b.Substring(0, b.Length - 2);
                                    first = decimal.Parse(b);
                                }

                                label!.Content = null;
                                label.Content = b + " -";

                            }
                            else
                            {
                                b = label.Content.ToString()!;
                                if (b.Contains('e'))
                                {
                                    int index = b.IndexOf('e');
                                    b = b.Substring(0, index + 1);
                                    first = decimal.Parse(b);
                                }
                                else
                                {
                                    b = b.Substring(0, b.Length - 2);
                                    first = decimal.Parse(b);
                                }
                            }
                        }
                        textBox.Clear();

                        mul = false;
                        plus = false;
                        minus = true;
                        div = false;
                    }
                    else if (minus && textBox.Text.Length > 0)
                    {
                        if (decimal.TryParse(textBox.Text, out second))
                        {
                            textBox.Clear();

                            result = (first) - (second);

                            string res = result.ToString()!;

                            if (res!.Length > 13)
                                textBox.Text = res.Substring(0, 13);
                            else
                                textBox.Text = res;

                            label.Content = null;
                        }
                        else
                        {
                            MessageBox.Show("Error");
                            label!.Content = null;
                            first = 0;
                            second = 0;
                            textBox.Clear();
                        }
                        minus = false;
                    }
                    else if (!minus && textBox.Text.Length == 0 && label.Content != null)
                    {
                        string b;

                        div = false;
                        plus = false;
                        minus = true;
                        mul = false;
                        b = label.Content.ToString()!.Substring(0, label.Content.ToString()!.Length - 2);
                        label.Content = b + " -";
                    }
                    else
                        MessageBox.Show("Please add digits to complete operation", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                    break;

                case "btnC": // clear
                    textBox.Clear();
                    textBox.Text = "0";
                    result = null;
                    break;

                case "btnCE": //CE
                    textBox.Clear();
                    textBox.Text = "0";
                    label.Content = null;
                    mul = false;
                    plus = false;
                    minus = false;
                    div = false;
                    result = null;
                    break;

                case "btnDel": // delete
                    if (textBox.Text != "0" && textBox.Text != string.Empty)
                    {
                        textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                        if (textBox.Text.Length == 0)
                        {
                            textBox.Text = "0";
                            result = 0;
                        }
                    }
                    break;

                case "btn7":
                    NumberButton("7");
                    break;

                case "btn8":
                    NumberButton("8");
                    break;

                case "btn9":
                    NumberButton("9");
                    break;

                case "btn4":
                    NumberButton("4");
                    break;

                case "btn5":
                    NumberButton("5");
                    break;

                case "btn6":
                    NumberButton("6");
                    break;

                case "btn1":
                    NumberButton("1");
                    break;

                case "btn2":
                    NumberButton("2");
                    break;

                case "btn3":
                    NumberButton("3");
                    break;

                case "btn0":
                    if (textBox.Text != "0")
                        if (textBox.Text.Length < 13)
                            textBox.Text += 0.ToString();
                        else
                            textBox.Text = "0";
                    break;

                case "btnMinusPlus":
                    decimal number;
                    if (textBox.Text != "0" && textBox.Text != "Null")
                    {
                        if (textBox.Text.Contains('e'))
                        {
                            textBox.Text = textBox.Text.Substring(0, textBox.Text.IndexOf('e'));
                            number = decimal.Parse(textBox.Text);
                            textBox.Text = (-1 * number).ToString();
                        }
                        else if (textBox.Text.Contains(' '))
                        {
                            textBox.Text = textBox.Text.Substring(0, textBox.Text.IndexOf(' '));
                            number = decimal.Parse(textBox.Text);
                            textBox.Text = (-1 * number).ToString();
                        }
                        else
                        {
                            number = decimal.Parse(textBox.Text);
                            textBox.Text = (-1 * number).ToString();
                        }
                    }
                    break;

                case "btnPoint":
                    if (textBox.Text == string.Empty || textBox.Text == "0")
                        textBox.Text = "0.";
                    else if (!textBox.Text.Contains('.'))
                    {
                        decimal dec;
                        dec = decimal.Parse(textBox.Text);
                        textBox.Text = dec.ToString() + ".";
                    }
                    break;

                case "btnEqual":
                    if (mul)
                        goto case "btnMul";
                    else if (div)
                        goto case "btnDiv";
                    else if (plus)
                        goto case "btnPlus";
                    else if (minus)
                        goto case "btnMinus";

                    break;
            }
        }
    }
}
