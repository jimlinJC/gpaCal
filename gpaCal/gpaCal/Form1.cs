using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gpaCal
{
    public partial class Form1 : Form
    {
        int yposIN = 1;
        int xposIN = 1;
        List<Cal> score = new List<Cal>();
        int totalCredit = 0;
        double tt = 0;
        double avg = 0;
        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = this.button1;
            this.textBox1.Focus();
            this.textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(textBox2.Text);
            if (match.Success)
            {
                String tb1 = textBox1.Text;
                String tb2 = textBox2.Text;
                int x_pos = 50;
                int y_pos = 20;
                Cal calGpa = new Cal();
                double changed = change(tb1);


                //這邊開始
                Label lb = new Label();  //新增一個LABEL物件
                calGpa.gpa = changed;  
                calGpa.credit = int.Parse(tb2);
                totalCredit += int.Parse(tb2);
                score.Add(calGpa);
                lb.Name = "btn" + yposIN;   //這裡是lb物件的Name
                lb.Location = new System.Drawing.Point((x_pos), (y_pos * yposIN));//這行是設定物件的位置
                lb.Text = "等第: " + tb1;   //這行是設定Label顯示的文字
                lb.Size = new System.Drawing.Size(50, 12);//這是大小
                this.Controls.Add(lb);//這個是把lb加入到整個Form裡面




                Label lb2 = new Label();
                lb2.Name = "btn2" + yposIN;
                lb2.Location = new System.Drawing.Point((x_pos * 5), (y_pos * yposIN));
                lb2.Text = "學分: " + tb2;
                lb2.Size = new System.Drawing.Size(150, 12);
                this.Controls.Add(lb2);

                yposIN++;
            }
            else
            {
               
            }
            textBox1.Text = "";
            textBox2.Text = "";
            this.textBox1.Focus();
            this.textBox1.Select();
        }
        public double change(String a)
        {
           
            if (a.ToLower().Equals("a+"))
            {
                return 4.3;
            }
            if (a.ToLower().Equals("a"))
            {
                return 4.0;
            }
            if (a.ToLower().Equals("a-"))
            {
                return 3.7;
            }
            if (a.ToLower().Equals("b+"))
            {
                return 3.3;
            }
            if (a.ToLower().Equals("b"))
            {
                return 3.0;
            }
            if (a.ToLower().Equals("b-"))
            {
                return 2.7;
            }
            if (a.ToLower().Equals("c+"))
            {
                return 2.3;
            }
            if (a.ToLower().Equals("c"))
            {
                return 2.0;
            }
            if (a.ToLower().Equals("c-"))
            {
                return 1.7;
            }
            return -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x_pos = 300;
            int y_pos = 300;
            foreach (Cal c in score)
            {
                tt += c.total;
            }
            avg = tt / totalCredit;

            Label lb3 = new Label();
            lb3.Name = "btn3" + yposIN;
            lb3.Location = new System.Drawing.Point((x_pos), (y_pos));
            lb3.Text = avg.ToString("0.00");
            lb3.Size = new System.Drawing.Size(150, 12);
            this.Controls.Add(lb3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yposIN = 1;
            xposIN = 1;
            totalCredit = 0;
            tt = 0;
            avg = 0;
            score.Clear();
            this.Controls.Clear();
            this.InitializeComponent();
            this.AcceptButton = this.button1;
            this.textBox1.Focus();
            this.textBox1.Select();
        }
    }
}
