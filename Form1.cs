using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        private TextBox display;
        private Button[] buttons;
        private string input = string.Empty;
        private string operand1 = string.Empty;
        private string operand2 = string.Empty;
        private char operation;
        private double result = 0.0;

        public Form1()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            this.Text = "Calculator";
            this.Size = new Size(300, 400);

            display = new TextBox();
            display.Size = new Size(260, 30);
            display.Location = new Point(10, 10);
            display.ReadOnly = true;
            this.Controls.Add(display);

            buttons = new Button[16];
            string[] buttonLabels = { "7", "8", "9", "/",
                                          "4", "5", "6", "*",
                                          "1", "2", "3", "-",
                                          "0", "C", "=", "+" };

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Size = new Size(60, 60);
                buttons[i].Text = buttonLabels[i];
                buttons[i].Location = new Point(10 + (i % 4) * 70, 50 + (i / 4) * 70);
                buttons[i].Click += new EventHandler(Button_Click);
                this.Controls.Add(buttons[i]);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text == "C")
            {
                display.Text = string.Empty;
                input = string.Empty;
                operand1 = string.Empty;
                operand2 = string.Empty;
                result = 0.0;
            }
            else if (button.Text == "=")
            {
                operand2 = input;
                double num1, num2;
                double.TryParse(operand1, out num1);
                double.TryParse(operand2, out num2);

                switch (operation)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            MessageBox.Show("Error: Division by zero is not allowed.");
                        }
                        break;
                }
                display.Text = result.ToString();
                input = string.Empty;
            }
            else if (button.Text == "+" || button.Text == "-" || button.Text == "*" || button.Text == "/")
            {
                operand1 = input;
                operation = button.Text[0];
                input = string.Empty;
            }
            else
            {
                input += button.Text;
                display.Text = input;
            }
        }
    }
}
