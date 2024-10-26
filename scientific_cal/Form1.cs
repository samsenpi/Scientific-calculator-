using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace scientific_cal
{
    public partial class calculator : Form
    {
        private String myCal = "";
        int err = 0;
        public calculator()
        {
            InitializeComponent();
        }

       

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }



        private void minimize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void restoreWindow_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;

            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }



        private void btnNum_click(object sender, EventArgs e)
        {
            Button num = (Button)sender;

            char[] op = { '+', '-', '*', '÷', '%' ,'^'};

            int index = myCal.IndexOfAny(op);


            textBox_His.Text += num.Text;
            myCal = textBox_His.Text;
           

             if (index == -1)
            {
                textBox_curr.Text += num.Text;


            }

                textBox_curr.Text = num.Text;
            







        }

        private void operator_Click(object sender, EventArgs e)
        {


            char[] oper = { '+', '-', '*', '/', '%', '^' };
            Button op = (Button)sender;

            int index = myCal.IndexOfAny(oper);
            if (string.IsNullOrEmpty(myCal))
            {
                textBox_curr.Text=myCal=textBox_curr.Text="0";
            }else if (!oper.Contains(myCal[myCal.Length - 1]))
            {

                if (index != -1)
                {
                    preformCal();


                }

                textBox_His.Text = textBox_curr.Text + op.Text;



                myCal = textBox_His.Text;
            }else if (err == 1)
            {
                myCal=textBox_His.Text=textBox_curr.Text=" ";
            }

            

            




        }
        private void preformCal()
        {
            float res;

            if (myCal.Contains("+"))
            {
                String[] num = myCal.Split('+');
                res = float.Parse(num[0]) + float.Parse(num[1]);


            }
            else if (myCal.Contains("-"))
            {
                String[] num = myCal.Split('-');
                res = float.Parse(num[0]) - float.Parse(num[1]);


            }
            else if (myCal.Contains("*"))
            {
                String[] num = myCal.Split('*');
                res = float.Parse(num[0]) * float.Parse(num[1]);


            }
            else if (myCal.Contains("%"))
            {
                String[] num = myCal.Split('%');
                res = float.Parse(num[0]) % float.Parse(num[1]);


            }
            else if (myCal.Contains("/"))
            {
                String[] num = myCal.Split('/');

                if (num[1] == "0")
                {
                    res = -1;


                }
                else
                {
                    res = float.Parse(num[0]) / float.Parse(num[1]);
                }



            }
            else if (myCal.Contains("^"))
            {
                String[] num = myCal.Split('^');
                float d = float.Parse(num[0]);
                float d2 = float.Parse(num[1]);
                 res = (float)Math.Pow(d, d2);

            }
            else
            {
                res = -2;

            }
            if (res > 0)
            {
                textBox_curr.Text = res.ToString();
            }
            else if (res == -1)
            {
                textBox_curr.Text = "Cann`t divide with zero";
                textBox_His.Text = "";
                err = 1;
            }
            else
            {
                textBox_curr.Text = "Math Error";
                textBox_His.Text = "";
                err = 1;
            }



        }

        private void btn_equal(object sender, EventArgs e)
        {

            char[] op = { '+', '-', '*', '/', '%','^' };

            int index = myCal.IndexOfAny(op);

            


            if (index != -1&&index!= myCal.Length - 1)
            {
                preformCal();


            }



            textBox_His.Text = myCal;

        }






        private void btn_evalue_click(object sender, EventArgs e)
        {
            double eval = Math.E;
            myCal = textBox_His.Text = textBox_curr.Text += $"{eval}";


        }

        private void btn_allDel(object sender, EventArgs e)
        {
            textBox_curr.Text = "";
            myCal = textBox_curr.Text;
            textBox_His.Text = myCal;
        }

        private void btn_lastDel_click(object sender, EventArgs e)
        {
            myCal=textBox_His.Text=textBox_curr.Text = textBox_curr.Text.Remove(textBox_curr.Text.Length - 1, 1);
        }



        private void btnPi_click(object sender, EventArgs e)
        {
            double pi = Math.PI;
            myCal = textBox_His.Text = textBox_curr.Text += $"{pi}";

        }

        private void btnSq_click(object sender, EventArgs e)
        {

            textBox_curr.Text = Convert.ToString(Math.Pow(double.Parse(textBox_curr.Text), 2));
            myCal += textBox_curr.Text;
            textBox_His.Text = myCal;
        }

        private void btnOver_click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_curr.Text))
            {

                textBox_curr.Text = "Cann`t divide with zero";
                myCal=textBox_His.Text = " ";
                err = 1;

            }
            else
            {
                double num = double.Parse(textBox_curr.Text);
                double res = 1 / num;
                textBox_curr.Text = $"{res}";
                textBox_His.Text = $"1/{num}";
                myCal = textBox_His.Text;



            }
        }

        private void btn_pow(object sender, EventArgs e)
        {

            Button op = (Button)sender;



            op.Text = "^";
            operator_Click(op,e);
  

        }

        private void btnSqrt_click(object sender, EventArgs e)
        {


            if (String.IsNullOrEmpty(textBox_curr.Text))
            {

                textBox_curr.Text = "invalid input";


            }
            else
            {


                double number = double.Parse(textBox_curr.Text);
                if (number >= 0)
                {
                    double result = Math.Sqrt(number);
                    textBox_curr.Text = result.ToString();
                    myCal = textBox_His.Text = $"√{number} = {result}";
                }
                else
                {
                    textBox_curr.Text = "Math Error";
                    myCal =     textBox_His.Text = "";

                }

            }



        }

        private void log_click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;


            if (String.IsNullOrEmpty(textBox_curr.Text))
            {

                textBox_curr.Text = "invalid input";


            }
            else
            {


                double result;
                double number = double.Parse(textBox_curr.Text);
                if (number > 0)
                {
                    if (btn.Text.Equals("log"))
                    {
                         result = Math.Log10(number);

                    }
                    else
                    {
                         result = Math.Log(number);
                    }
                    textBox_curr.Text = result.ToString();
                    myCal = textBox_His.Text = $"log({number}) = {result}";
                }
                else
                {
                    textBox_curr.Text = "Math Error";
                    myCal = textBox_His.Text = "";
                }

            }




        }

        

        private void btn_trig_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (String.IsNullOrEmpty(textBox_curr.Text))
            {

                textBox_curr.Text = "0";


            }


            double degrees = double.Parse(textBox_curr.Text);
            double radians = degrees * (Math.PI / 180);
            double result;
            if (btn.Text.Equals("sin"))
            {
                 result = Math.Sin(radians);


            }
            else if (btn.Text.Equals("cos"))
            {
               result = Math.Cos(radians);

            }
            else
            {   
                result = Math.Tan(radians);
            }
                textBox_curr.Text = result.ToString();
            myCal = textBox_His.Text = $"{btn.Text}({degrees}°) = {result}";
        }
    }

      
}
