using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCalculator
{
    public partial class RPNCalculator : Form
    {
        Calculator calc;
        bool newDisplayNumberInput;
        bool operationCompleted;

        public RPNCalculator()
        {
            InitializeComponent();
            calc = new Calculator();
            newDisplayNumberInput = false;
            operationCompleted = false;
            numberDisplay.Text = "0";
        }

        /// <summary>
        /// Append number to the display number.
        /// If display number is "0" then clear display number first.
        /// </summary>
        private void number_Click(object sender, EventArgs e)
        {
            Button mybutton = sender as Button;

            try
            {
                if(newDisplayNumberInput)
                {
                    // Push displayed value on the stack if this value is a result of an operation.
                    // Clear old displayed value and reset.
                    if(operationCompleted)
                    {
                        calc.Enter(numberDisplay.Text);
                        operationCompleted = false;
                    }
                
                    newDisplayNumberInput = false;
                    numberDisplay.Text = "";
                }
                else if((numberDisplay.Text == "0.0") || (numberDisplay.Text == "0"))
                {
                    numberDisplay.Text = ""; // clear so the numbers look right.
                }
                numberDisplay.Text += mybutton.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            
        }

        /// <summary>
        /// Appends the "." to the display number according to the following:
        /// 1) If only "0" is displayed then display "0."
        /// 2) Only one "." can be displayed.
        /// 3) If no "." is found then append.
        /// </summary>
        private void dot_Click(object sender, EventArgs e)
        {
            try
            {
                if(numberDisplay.Text.IndexOf('.') == -1)
                {
                    if ((newDisplayNumberInput) || (numberDisplay.Text == "0"))
                    {
                        // Push displayed value on the stack if this value is a result of an operation.
                        // Clear old displayed value and reset.
                        if (operationCompleted)
                        {
                            calc.Enter(numberDisplay.Text);
                            operationCompleted = false;
                        }
                        newDisplayNumberInput = false;
                        numberDisplay.Text = "0.";
                    }
                    else
                    {
                        numberDisplay.Text += ".";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            
        }

        /// <summary>
        /// Pushes the displayed value on the stack.
        /// Keeps the displayed value as is until the user clicks a number/dot button
        /// or clicks +-*/.
        /// </summary>
        private void enter_Click(object sender, EventArgs e)
        {
            try
            {
                calc.Enter(numberDisplay.Text);
                newDisplayNumberInput = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            
        }

        /// <summary>
        /// Takes the displayed value and adds it to the top stack value.
        /// Replaces the displayed value with the new sum.
        /// Pops the top value from the stack.
        /// </summary>
        private void add_Click(object sender, EventArgs e)
        {
            double newValue = 0.0;

            try
            {
                newValue = calc.Add(numberDisplay.Text);
                numberDisplay.Text = newValue.ToString();
                newDisplayNumberInput = true;
                operationCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            
        }

        /// <summary>
        /// Takes the displayed value and subtracts it from the top stack value.
        /// Replaces the displayed value with the new sum.
        /// Pops the top value from the stack.
        /// </summary>
        private void subtract_Click(object sender, EventArgs e)
        {
            double newValue = 0.0;
            
            try
            {
                newValue = calc.Subtract(numberDisplay.Text);
                numberDisplay.Text = newValue.ToString();
                newDisplayNumberInput = true;
                operationCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Takes the displayed value and multiplies it to the top stack value.
        /// Replaces the displayed value with the new sum.
        /// Pops the top value from the stack.
        /// </summary>
        private void multiply_Click(object sender, EventArgs e)
        {
            double newValue = 0.0;

            try
            {
                newValue = calc.Multiply(numberDisplay.Text);
                numberDisplay.Text = newValue.ToString();
                newDisplayNumberInput = true;
                operationCompleted = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Checks to see if the displayed value is zero.
        ///     If it is display error message.
        ///     If it isn't zero then continue on with the calculation.
        /// Takes the displayed value and divides it into the top stack value.
        /// Replaces the displayed value with the new sum.
        /// Pops the top value from the stack.
        /// </summary>
        private void divide_Click(object sender, EventArgs e)
        {
           // bool isDivideByZero = false;

            //double newValue = calc.Divide(numberDisplay.Text, out isDivideByZero);
            try
            {
                double newValue = calc.Divide(numberDisplay.Text);
                numberDisplay.Text = newValue.ToString();
                newDisplayNumberInput = true;
                operationCompleted = true;
            }
            catch(Exception ex)
            {
                if (true) //(ex.GetType() is  DivideByZeroException)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
        }

        /// <summary>
        /// Invert the the displayed value sign.
        /// </summary>
        private void plusMinus_Click(object sender, EventArgs e)
        {
            try
            {
                int minusIndex = numberDisplay.Text.IndexOf('-');
                if(minusIndex == -1)
                {
                    numberDisplay.Text = "-" + numberDisplay.Text;
                }
                else
                {
                    // Remove the leading '-'
                    numberDisplay.Text = numberDisplay.Text.Substring(minusIndex + 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            
            
        }
        /// <summary>
        /// Remove the right most digit. 
        /// If string is "0" then just return "0".
        /// </summary>
        private void back_Click(object sender, EventArgs e)
        {
            try
            {
                int numberLength = numberDisplay.Text.Length;
                if(numberLength > 1)
                {
                    numberDisplay.Text = numberDisplay.Text.Remove(numberLength - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            
        }

        /// <summary>
        /// Clears the displayed value leaving the stack alone.
        /// </summary>
        /// 
        private void clear_Click(object sender, EventArgs e)
        {
            numberDisplay.Text = "0";
        }

        /// <summary>
        /// Sets all stack entries to zero.
        /// Sets the displayed value to zero.
        /// </summary>
        /// 
        private void clearStack_Click(object sender, EventArgs e)
        {
            try
            {
                calc.AllClear();
                numberDisplay.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            
        }

        /// <summary>
        /// Swaps the displayed value with the top stack value.
        /// </summary>
        /// 
        private void swap_Click(object sender, EventArgs e)
        {
            try
            {
                numberDisplay.Text = calc.Swap(numberDisplay.Text).ToString();
                newDisplayNumberInput = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            
        }

        /// <summary>
        /// Pops the top value from the stack.
        /// Replaces the displayed value with the new stack top value.
        /// </summary>
        private void pop_Click(object sender, EventArgs e)
        {
            try
            {
                numberDisplay.Text = "";
                numberDisplay.Text = calc.Pop().ToString();
                newDisplayNumberInput = true;
            }
            catch
            {
                MessageBox.Show("Can't pop an empty stack.");
            }
        }

        
    }
}