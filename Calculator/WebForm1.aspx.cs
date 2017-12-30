using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string CurrNumberString { get; set; }
        private string Expression { get; set; }
        private char LastEntry { get; set; }
        private Operation Operation = new Operation(0, "+");
        private bool Started = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Started)
            {
                CurrNumberString = "0";
                Expression = "";
                LastEntry = '0';

                ExpressionText.Text = Expression;
                CurrNumberText.Text = CurrNumberString;

                Started = true;
            }
            
        }

        protected void OpButton_Click(object sender, EventArgs e)
        {
            Button Button = (Button)sender;
            string ButtonText = Button.Text;

            // if last entry is a digit, calculate the new result and record the new operand and add it to the expression
            if (char.IsDigit(LastEntry))
            {
                Operation.SecondNumber = Double.Parse(CurrNumberString);
                CurrNumberString = Math.Round(Operation.Calculate(), 10).ToString();

                Operation.FirstNumber = Double.Parse(CurrNumberString);
                Operation.Operand = ButtonText;

                Expression = Expression.Insert(Expression.Length, ButtonText);
                LastEntry = Expression[Expression.Length - 1];
            }
            // if last entry is not a digit, aka it's an operand, update the operation and change the expression and last entry
            else
            {
                Operation.Operand = ButtonText;

                Expression.Remove(Expression.Length);
                Expression = Expression.Insert(Expression.Length, ButtonText);
                LastEntry = Expression[Expression.Length - 1];
            }

            ExpressionText.Text = Expression;
            CurrNumberText.Text = CurrNumberString;
        }

        protected void CEButton_Click(object sender, EventArgs e)
        {
            if (CurrNumberString != "0")
            {
                Expression = Expression.Substring(0, Expression.Length - CurrNumberString.Length);
            }

            CurrNumberString = "0";

            CurrNumberText.Text = CurrNumberString;
        }

        protected void CButton_Click(object sender, EventArgs e)
        {
            CurrNumberString = "0";
            Expression = "";
            LastEntry = '0';

            ExpressionText.Text = Expression;
            CurrNumberText.Text = CurrNumberString;

            Operation.FirstNumber = 0;
            Operation.Operand = "+";
        }

        protected void ButtonDEL_Click(object sender, EventArgs e)
        {
            if (CurrNumberString.Length > 1)
            {
                CurrNumberString = CurrNumberString.Substring(0, CurrNumberString.Length - 1);
                Expression = Expression.Substring(0, Expression.Length - 1);
            }
            else
            {
                if (CurrNumberString.Length == 1 & CurrNumberString != "0" )
                {
                    Expression = Expression.Substring(0, Expression.Length - 1);
                }
                CurrNumberString = "0";
            }

            CurrNumberText.Text = CurrNumberString;
        }

        protected void ButtonEQU_Click(object sender, EventArgs e)
        {
            Operation.SecondNumber = Double.Parse(CurrNumberString);
            CurrNumberString = Math.Round(Operation.Calculate(), 10).ToString();
            Expression = "";
            LastEntry = '0';

            ExpressionText.Text = Expression;
            CurrNumberText.Text = CurrNumberString;
        }

        protected void NumButton_Click(object sender, EventArgs e)
        {
            Button Button = (Button)sender;
            string ButtonText = Button.Text;

            // if the last entry is a digit, append the digit to the number; 
            // if not, aka the last entry is an operand, create a new number string with the digit
            if (char.IsDigit(LastEntry))
            {
                if (CurrNumberString == "0")
                {
                    CurrNumberString = ButtonText;
                }
                else
                {
                    CurrNumberString = CurrNumberString.Insert(CurrNumberString.Length, ButtonText);
                }
            }
            else
            {
                CurrNumberString = ButtonText;
            }

            Expression = Expression.Insert(Expression.Length, ButtonText);
            LastEntry = Expression[Expression.Length - 1];
            
            CurrNumberText.Text = CurrNumberString;
        }

        protected void ButtonDOT_Click(object sender, EventArgs e)
        {
            Button Button = (Button)sender;
            string ButtonText = Button.Text;

            // if last entry is a digit, append the dot to the number string;
            // if not, aka the last entry is an operand, create a new number string "0." and change last entry to 0
            if (char.IsDigit(LastEntry))
            {
                CurrNumberString = CurrNumberString.Insert(CurrNumberString.Length, ButtonText);
                Expression = Expression.Insert(Expression.Length, ButtonText);
            }
            else
            {
                CurrNumberString = "0.";
                Expression = Expression.Insert(Expression.Length, CurrNumberString);
                LastEntry = '0';
            }
            
            CurrNumberText.Text = CurrNumberString;
        }
    }
}