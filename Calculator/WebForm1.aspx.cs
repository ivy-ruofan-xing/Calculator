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

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrNumberString = "0";
            Expression = "";
            LastEntry = '0';

            if (IsPostBack)
            {
                CurrNumberString = Session["CurrNumberString"].ToString();
                Expression = Session["Expression"].ToString();
                LastEntry = (char)Session["LastEntry"];
                Operation = (Operation)Session["Operation"];
            }
            else
            {
                Session["CurrNumberString"] = CurrNumberString;
                Session["Expression"] = Expression;
                Session["LastEntry"] = LastEntry;
                Session["Operation"] = Operation;
            }

            if (!char.IsDigit(LastEntry))
            {
                ExpressionText.Text = Expression;
            }
            
            CurrNumberText.Text = CurrNumberString;
            
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

                if (Expression == "")
                {
                    Expression = CurrNumberString;
                }
                Expression = Expression.Insert(Expression.Length, ButtonText);
                LastEntry = Expression[Expression.Length - 1];
            }
            else if (LastEntry == '=')
            {
                Expression = CurrNumberString.Insert(CurrNumberString.Length, ButtonText);
                LastEntry = Expression[Expression.Length - 1];
            }
            // if last entry is not a digit, aka it's an operand, update the operation and change the expression and last entry
            else
            {
                Operation.Operand = ButtonText;

                if (Expression != "")
                {
                    Expression = Expression.Remove(Expression.Length - 1);
                }
                else
                {
                    Expression = CurrNumberString;
                }
                Expression = Expression.Insert(Expression.Length, ButtonText);
                LastEntry = Expression[Expression.Length - 1];
            }

            ExpressionText.Text = Expression;
            CurrNumberText.Text = CurrNumberString;

            if (Operation.OperationFlag == 1)
            {
                CurrNumberText.Text = "Cannot divide by zero";
                CurrNumberString = "0";
                Expression = "";
                ExpressionText.Text = Expression;
                LastEntry = '0';
                Operation.OperationFlag = 0;
            }
            else if (Operation.OperationFlag == 2)
            {
                CurrNumberText.Text = "Result is undefined";
                CurrNumberString = "0";
                Expression = "";
                ExpressionText.Text = Expression;
                LastEntry = '0';
                Operation.OperationFlag = 0;
            }

            Session["CurrNumberString"] = CurrNumberString;
            Session["Expression"] = Expression;
            Session["LastEntry"] = LastEntry;
            Session["Operation"] = Operation;
        }

        protected void CEButton_Click(object sender, EventArgs e)
        {
            if (CurrNumberString != "0")
            {
                Expression = Expression.Substring(0, Expression.Length - CurrNumberString.Length);
            }

            CurrNumberString = "0";

            CurrNumberText.Text = CurrNumberString;

            Session["CurrNumberString"] = CurrNumberString;
            Session["Expression"] = Expression;
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

            Session["CurrNumberString"] = CurrNumberString;
            Session["Expression"] = Expression;
            Session["LastEntry"] = LastEntry;
            Session["Operation"] = Operation;
        }

        protected void ButtonDEL_Click(object sender, EventArgs e)
        {
            if (char.IsDigit(LastEntry))
            {
                if (CurrNumberString.Length > 1)
                {
                    CurrNumberString = CurrNumberString.Substring(0, CurrNumberString.Length - 1);
                    Expression = Expression.Substring(0, Expression.Length - 1);
                }
                else
                {
                    if (CurrNumberString.Length == 1 & CurrNumberString != "0")
                    {
                        Expression = Expression.Substring(0, Expression.Length - 1);
                    }
                    CurrNumberString = "0";
                }
            }

            CurrNumberText.Text = CurrNumberString;

            Session["CurrNumberString"] = CurrNumberString;
            Session["Expression"] = Expression;
        }

        protected void ButtonEQU_Click(object sender, EventArgs e)
        {
            Operation.SecondNumber = Double.Parse(CurrNumberString);
            CurrNumberString = Math.Round(Operation.Calculate(), 10).ToString();
            Operation.FirstNumber = Double.Parse(CurrNumberString);
            Expression = "";
            LastEntry = '=';

            ExpressionText.Text = Expression;
            CurrNumberText.Text = CurrNumberString;

            if (Operation.OperationFlag == 1)
            {
                CurrNumberText.Text = "Cannot divide by zero";
                CurrNumberString = "0";
                Expression = "";
                ExpressionText.Text = Expression;
                LastEntry = '0';
                Operation.OperationFlag = 0;
            }
            else if (Operation.OperationFlag == 2)
            {
                CurrNumberText.Text = "Result is undefined";
                CurrNumberString = "0";
                Expression = "";
                ExpressionText.Text = Expression;
                LastEntry = '0';
                Operation.OperationFlag = 0;
            }

            Session["CurrNumberString"] = CurrNumberString;
            Session["Expression"] = Expression;
            Session["LastEntry"] = LastEntry;
            Session["Operation"] = Operation;
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

            Session["CurrNumberString"] = CurrNumberString;
            Session["Expression"] = Expression;
            Session["LastEntry"] = LastEntry;
            Session["Operation"] = Operation;
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

            Session["CurrNumberString"] = CurrNumberString;
            Session["Expression"] = Expression;
            Session["LastEntry"] = LastEntry;
        }
    }
}