using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab2_1
{

    public partial class Form1 : Form
    {
        
        int sumA = 0;
        int sumBPlus = 0;
        int sumB = 0;
        int sumCPlus = 0;
        int sumC = 0;
        int sumDPlus = 0;
        int sumD = 0;
        int sumF = 0;
        double gpa = 0;
        List<Students> listStudent = new List<Students>();
        public Form1()
        {
            InitializeComponent();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void stPoint2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void stIDBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void averageBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void stIDMinBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void stNameMinBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (stIDBox.Text == "" || stNameBox.Text == "" || stPointBox.Text == "")
            {
                string message = "กรุณาพิมพ์ให้ครบทุกช่อง";
                string title = "เกิดข้อผิดพลาด";
                MessageBox.Show(message, title);
            }
            else
            {
                try
                {

                    int stPointCheck = int.Parse(stPointBox.Text);

                    if (stPointCheck < 0 || stPointCheck > 100)
                    {
                        string message = "กรุณาพิมพ์ตัวเลขคะเเนนให้อยู่ในช่วงตั้งเเต่ 0-100!";
                        string title = "เกิดข้อผิดพลาด";
                        MessageBox.Show(message, title);
                    }
                    else
                    {
                        string inputID = stIDBox.Text;
                        string inputName = stNameBox.Text;
                        string inputScore = stPointBox.Text;
                        double inputScoreFake = double.Parse(inputScore);
                        Students student = new Students();
                        student.name = inputName;
                        student.studentid = inputID;
                        student.score = double.Parse(inputScore);
                        listStudent.Add(student);
                        resetextbox();
                        findMaxMinScore();
                        sumofscore();
                        /////////ยังหาวิธีรับข้อมูลไม่เจอคับเลยใส่เเบบนี้ไปก่อน//////////
                        if (inputScoreFake >= 80 && inputScoreFake <= 100)
                        {
                            sumA++;
                        }
                        if (inputScoreFake >= 75 && inputScoreFake <= 79)
                        {
                            sumBPlus++;
                        }
                        if (inputScoreFake >= 70 && inputScoreFake <= 74)
                        {
                            sumB++;
                        }
                        if (inputScoreFake >= 65 && inputScoreFake <= 69)
                        {
                            sumCPlus++;
                        }
                        if (inputScoreFake >= 60 && inputScoreFake <= 64)
                        {
                            sumC++;
                        }
                        if (inputScoreFake >= 55 && inputScoreFake <= 59)
                        {
                            sumDPlus++;
                        }
                        if (inputScoreFake >= 50 && inputScoreFake <= 54)
                        {
                            sumD++;
                        }
                        if (inputScoreFake >= 0 && inputScoreFake <= 49)
                        {
                            sumF++;
                        }
                        gpa = ((sumA * 4.0) + (sumBPlus * 3.5) + (sumB * 3.0) + (sumCPlus * 2.5) + (sumC * 2.0) + (sumDPlus * 1.5) + (sumD * 1.0)) / listStudent.Count;
                        gABOX.Text = sumA.ToString();
                        gBPLUSBOX.Text = sumBPlus.ToString();
                        gBBOX.Text = sumB.ToString();
                        gCPLUSBOX.Text = sumCPlus.ToString();
                        gCBOX.Text = sumC.ToString();
                        gDPLUSBOX.Text = sumDPlus.ToString();
                        gDBOX.Text = sumD.ToString();
                        gFBOX.Text = sumF.ToString();
                        gpaBox.Text = gpa.ToString();

                    }
                }
                catch (FormatException)
                {
                    string message = "กรุณาพิมพ์ตัวเลขในช่องคะแนน เเละ ห้ามใช้ตัวอักษร!";
                    string title = "เกิดข้อผิดพลาด";
                    MessageBox.Show(message, title);
                }
                catch (IndexOutOfRangeException)
                {
                    string message = "ข้อความของคุณยาวเกินไป!";
                    string title = "เกิดข้อผิดพลาด";
                    MessageBox.Show(message, title);
                }
            }
        }

        private void label1_Click_4(object sender, EventArgs e)
        {

        }

        private void gradeDPlus_Click(object sender, EventArgs e)
        {

        }

        private void gradeD_Click(object sender, EventArgs e)
        {

        }

        private void gradeBPlus_Click(object sender, EventArgs e)
        {

        }

        private void answer_Enter(object sender, EventArgs e)
        {

        }

        private void gpaBox_TextChanged(object sender, EventArgs e)
        {

        }
        void findMaxMinScore()
        { 
            double maxScore = 0;
            double minScore = 100;

            //for (int i = 0; i < listStudent.Count; i++)
            {
               foreach(Students student in listStudent)
                {
                    if (student.score > maxScore) 
                    { 
                        maxScore = student.score;
                        stIDMaxBox.Text =  student.studentid;
                        stNameMaxBox.Text = student.name;
                        stPointMaxBox.Text = student.score.ToString();
                    }
                    if (student.score < minScore)
                    {
                        minScore = student.score;
                        stIDMinBox.Text = student.studentid;
                        stNameMinBox.Text = student.name;
                        stPointMinBox.Text = student.score.ToString();
                    }
                }
            }
        }
        void resetextbox()
        {
            stIDBox.Text = string.Empty;
            stNameBox.Text = string.Empty;
            stPointBox.Text = string.Empty;
        }       
        void sumofscore()
        {
            double score = 0;
            {
                foreach (Students student in listStudent)
                {   
                    score += student.score;
                }
                double scoretrue = score/ listStudent.Count;
                averageBox.Text = scoretrue.ToString();
            }
        }
    }
}
