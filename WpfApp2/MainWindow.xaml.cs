using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        decimal? result = null;
        decimal first, second;
        bool mul = false, div = false, plus = false, minus = false, access = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;



            switch (btn?.Name)
            {
                case "btnDiv":
                    if (mul && textBox.Text.Length > 0)
                        goto case "btnMul";
                    //else if (plus)
                    //    goto case "btnMul";
                    //else if(minus)
                    //    goto case "btnMul";


                    if (!div && textBox.Text.Length > 0)
                    {
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
                                b = textBox.Text?.ToString()!.Substring(0, textBox.Text.Length - 3)!;
                                first = decimal.Parse(b);

                                label!.Content = null;
                                label.Content = b + " /";

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
                        minus = false;
                        div = true;
                    }
                    else if (div && textBox.Text.Length > 0)
                    {
                        if (decimal.TryParse(textBox.Text, out second))
                        {
                            textBox.Clear();

                            result = first / second;

                            string res = result.ToString()!;

                            if (res!.Length > 12)
                                textBox.Text = res.Substring(0, 12);
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
                    {
                        MessageBox.Show("Please add digits to complete operation", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;
                case "btnMul":
                    if (div && textBox.Text.Length > 0)
                        goto case "btnDiv";
                    //else if (plus)
                    //    goto case "btnplus";
                    //else if (minus)
                    //    goto case "btnMul";

                    if (!mul && textBox.Text.Length > 0)
                    {
                        mul = true;
                        plus = false;
                        minus = false;
                        div = false;

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
                                b = textBox.Text?.ToString()!.Substring(0, textBox.Text.Length - 3)!;
                                first = decimal.Parse(b);

                                label!.Content = null;
                                label.Content = b + " /";

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
                    }
                    else if (mul && textBox.Text.Length > 0)
                    {
                        if (decimal.TryParse(textBox.Text, out second))
                        {
                            textBox.Clear();

                            result = first * second;

                            string res = result.ToString();

                            if (res.Length > 12)
                            {
                                textBox.FontSize = 35;
                                textBox.Text = res.Substring(0, 12) + "e" + $"+{res.Length - 12}";
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
                    {
                        MessageBox.Show("Please add digits to complete operation", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;
                case "btnC":
                    textBox.Clear();
                    textBox.Text = "0";
                    result = null; 
                    break;
                case "btnCE":
                    textBox.Clear();
                    textBox.Text = "0";
                    label.Content = null;
                    mul = false;
                    plus = false;
                    minus = false;
                    div = false;
                    result = null;
                    break;
                case "btnDel":
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
                    if (textBox.Text == "0")
                    {
                        textBox.Clear();
                        textBox.Text = 7.ToString();
                    }
                    else if (textBox.Text != "0")
                    {
                        if (textBox.Text.Length < 12)
                            textBox.Text += 7.ToString();
                    }
                    break;
                case "btn8":
                    if (textBox.Text == "0")
                    {
                        textBox.Clear();
                        textBox.Text = 8.ToString();
                    }
                    else if (textBox.Text != "0")
                    {
                        if (textBox.Text.Length < 12)
                        {
                            textBox.Text += 8.ToString();
                        }
                    }
                    break;
                case "btn9":
                    if (textBox.Text == "0")
                    {
                        textBox.Clear();
                        textBox.Text = 9.ToString();
                    }
                    else if (textBox.Text != "0")
                    {
                        if (textBox.Text.Length < 12)
                        {
                            textBox.Text += 9.ToString();
                        }
                    }
                    break;
                case "btn4":
                    if (textBox.Text == "0")
                    {
                        textBox.Clear();
                        textBox.Text = 4.ToString();
                    }
                    else if (textBox.Text != "0")
                    {
                        if (textBox.Text.Length < 12)
                        {
                            textBox.Text += 4.ToString();
                        }
                    }
                    break;
                case "btn5":
                    if (textBox.Text == "0")
                    {
                        textBox.Clear();
                        textBox.Text = 5.ToString();
                    }
                    else if (textBox.Text != "0")
                    {
                        if (textBox.Text.Length < 12)
                        {
                            textBox.Text += 5.ToString();
                        }
                    }
                    break;
                case "btn6":
                    if (textBox.Text == "0")
                    {
                        textBox.Clear();
                        textBox.Text = 6.ToString();
                    }
                    else if (textBox.Text != "0")
                    {
                        if (textBox.Text.Length < 12)
                        {
                            textBox.Text += 6.ToString();
                        }
                    }

                    break;
                case "btn1":
                    if (textBox.Text == "0")
                    {
                        textBox.Clear();
                        textBox.Text = 1.ToString();
                    }
                    else if (textBox.Text != "0")
                    {
                        if (textBox.Text.Length < 12)
                        {
                            textBox.Text += 1.ToString();
                        }
                    }
                    break;
                case "btn2":
                    if (textBox.Text == "0")
                    {
                        textBox.Clear();
                        textBox.Text = 2.ToString();
                    }
                    else if (textBox.Text != "0")
                    {
                        if (textBox.Text.Length < 12)
                        {
                            textBox.Text += 2.ToString();
                        }
                    }
                    break;
                case "btn3":
                    if (textBox.Text == "0")
                    {
                        textBox.Clear();
                        textBox.Text = 3.ToString();
                    }
                    else if (textBox.Text != "0")
                    {
                        if (textBox.Text.Length < 12)
                        {
                            textBox.Text += 3.ToString();
                        }
                    }
                    break;
                case "btn0":
                    if (textBox.Text != "0")
                    {
                        if (textBox.Text.Length < 12)
                        {
                            textBox.Text += 0.ToString();
                        }
                    }
                    else
                        textBox.Text = "0";
                    break;
                case "btnPoint":
                    if (!textBox.Text.Contains('.'))
                    {
                        textBox.Text += ".";
                    }
                    break;
                case "btnEqual":
                    if (mul)
                        goto case "btnMul";
                    else if (div)
                        goto case "btnDiv";
                    break;
            }
        }
    }
}
