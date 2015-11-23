using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsCalculator
{
    class Calculator
    {
        private Stack<double> stack;

        public Calculator()
        {
            stack = new Stack<double>();
        }

        /// <summary>
        /// Pushes the passed value on to the stack
        /// </summary>
        /// <param name="displayNumber"></param>
        public void Enter(string displayNumber)
        {
            stack.Push(double.Parse(displayNumber));
        }

        /// <summary>
        /// Adds the passed value to the stack top value.
        /// Pops the top stack value.
        /// </summary>
        /// <param name="displayNumber"></param>
        /// <returns>the sum</returns>
        public double Add(string displayNumber)
        {
            double result = 0.0;
            double stackTopValue = 0.0;

            try
            { 
                if(stack.Count > 0)
                {
                    stackTopValue = Pop();
                    result = double.Parse(displayNumber) + stackTopValue;
                }
                else
                {
                    // Just return the original number.
                    result = double.Parse(displayNumber);
                }
            }
            catch
            {
                // Just return the original number.
                result = double.Parse(displayNumber);
            }
            return result;
        }

        /// <summary>
        /// Subtracts the passed value from the stack top value.
        /// Pops the top stack value.
        /// </summary>
        /// <param name="displayNumber"></param>
        /// <returns>the difference</returns>
        public double Subtract(string displayNumber)
        {
            double result = 0.0;
            double stackTopValue = 0.0;

            try
            {
                if (stack.Count > 0)
                {
                    stackTopValue = Pop();
                    result = stackTopValue - double.Parse(displayNumber);
                }
                else
                {
                    // Just return the original number.
                    result = double.Parse(displayNumber);
                }
            }
            catch
            {
                // Just return the original number.
                result = double.Parse(displayNumber);
            }
            
            return result;
        }

        /// <summary>
        /// Multiplies the passed value to the stack top value.
        /// Pops the top stack value.
        /// </summary>
        /// <param name="displayNumber"></param>
        /// <returns>the result</returns>
        public double Multiply(string displayNumber)
        {
            double result = 0.0;
            double stackTopValue = 0.0;

            try
            {
                if (stack.Count > 0)
                {
                    stackTopValue = Pop();
                    result = double.Parse(displayNumber) * stackTopValue;
                }
                else
                {
                    // Just return the original number.
                    result = double.Parse(displayNumber);
                }
            }
            catch
            {
                // Just return the original number.
                result = double.Parse(displayNumber);
            }

            return result;
        }

        /// <summary>
        /// Checks to see if the passed value is zero. 
        ///     If it is then display error message.
        /// Divides the passed value into the stack top value.
        /// Pops the top stack value.
        /// </summary>
        /// <param name="displayNumber"></param>
        /// <returns>the result</returns>
        public double Divide(string displayNumber) //, out bool divideByZeroError)
        {
            double result = 0.0;
            double stackTopValue = 0.0;
            double displayValue = 0.0;

            try
            {
                displayValue = double.Parse(displayNumber);
                if(displayValue != 0.0)
                {
                    if (stack.Count > 0)
                    {
                        stackTopValue = stack.Pop();
                        result = stackTopValue / displayValue;
                    }
                    else
                    {
                        // Just return the original number.
                        result = double.Parse(displayNumber);
                    }
                }
                else 
                {
                    throw new DivideByZeroException();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            return result;
        }

      
        /// <summary>
        /// Sets all the values of the stack to zero.
        /// </summary>
        public void AllClear()
        {
            stack.Clear();
        }

        /// <summary>
        /// Swaps the displayed value with the top stack value.
        /// </summary>
        /// <returns>The new display value</returns>
        public double Swap(string displayValue)
        {
            double returnValue = 0.0;

            returnValue = stack.Pop();
            stack.Push(double.Parse(displayValue));
           
            return returnValue;
        }

        /// <summary>
        /// Pops the top value of the stack
        /// </summary>
        public double Pop()
        {
            double topStackValue = 0.0;

            topStackValue = stack.Pop();
            
            return topStackValue;
        }


    }
}