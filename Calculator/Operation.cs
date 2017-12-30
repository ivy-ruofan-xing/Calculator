using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator
{
    public class Operation
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operand { get; set; }
        public int OperationFlag { get; set; }

        public Operation(double firstNumber, string operand)
        {
            FirstNumber = firstNumber;
            Operand = operand;
        }

        public double Calculate()
        {
            switch (Operand)
            {
                case "+":
                    return FirstNumber + SecondNumber;
                case "-":
                    return FirstNumber - SecondNumber;
                case "*":
                    return FirstNumber * SecondNumber;
                case "/":
                    if (0 == SecondNumber)
                    {
                        if (0 == FirstNumber)
                        {
                            // 0/0
                            OperationFlag = 2;
                        }
                        else
                        {
                            // n/0
                            OperationFlag = 1;
                        }
                        return 0;
                    }
                    else
                    {
                        return FirstNumber / SecondNumber;
                    }
                default:
                    return 0;
            }
        }
    }
}