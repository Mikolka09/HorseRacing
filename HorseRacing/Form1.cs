using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HorseRacing
{
    public partial class Form1 : Form
    {
        Random rand;
        public int horse1 = 1;
        public int horse2 = 2;
        public int horse3 = 3;
        public int horse4 = 4;
        public int horse5 = 5;
        public List<int> listFinish;
        public Thread horse_1;
        public Thread horse_2;
        public Thread horse_3;
        public Thread horse_4;
        public Thread horse_5;

        public Form1()
        {
            InitializeComponent();
        }

        public Color RandColor()
        {
            Random randGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randColorName = names[randGen.Next(names.Length)];
            Color randomColor = Color.FromKnownColor(randColorName);
            Thread.Sleep(50);
            return randomColor;
        }

        public void Horse_1(object obj)
        {
            try
            {
                ProgressBar bar = (ProgressBar)obj;
                int i = 0;
                bool ex = true;
                while (ex)
                {
                    i = 0;
                    i = rand.Next(1, 20);
                    if (bar.InvokeRequired)
                        bar.Invoke(new Action(() => bar.Increment(i)));
                    if (bar.Value == bar.Maximum)
                    {
                        ex = false;
                        listFinish.Add(horse1);
                        if (listFinish.Count == 5)
                            PrintFinish(listFinish);
                    }
                    else
                        ex = true;
                    Thread.Sleep(500);
                }
            }
            finally { }

        }

        public void Horse_2(object obj)
        {
            try
            {
                ProgressBar bar = (ProgressBar)obj;
                int i = 0;
                bool ex = true;
                while (ex)
                {
                    i = rand.Next(1, 20);
                    if (bar.InvokeRequired)
                        bar.Invoke(new Action(() => bar.Increment(i)));
                    if (bar.Value == bar.Maximum)
                    {
                        ex = false;
                        listFinish.Add(horse2);
                        if (listFinish.Count == 5)
                            PrintFinish(listFinish);
                    }
                    Thread.Sleep(500);
                }
            }
            finally { }
        }

        public void Horse_3(object obj)
        {
            try
            {
                ProgressBar bar = (ProgressBar)obj;
                int i = 0;
                bool ex = true;
                while (ex)
                {
                    i = rand.Next(1, 20);
                    if (bar.InvokeRequired)
                        bar.Invoke(new Action(() => bar.Increment(i)));
                    if (bar.Value == bar.Maximum)
                    {
                        ex = false;
                        listFinish.Add(horse3);
                        if (listFinish.Count == 5)
                            PrintFinish(listFinish);
                    }
                    Thread.Sleep(500);
                }
            }
            finally { }
        }

        public void Horse_4(object obj)
        {
            try
            {
                ProgressBar bar = (ProgressBar)obj;
                int i = 0;
                bool ex = true;
                while (ex)
                {
                    i = rand.Next(1, 20);
                    if (bar.InvokeRequired)
                        bar.Invoke(new Action(() => bar.Increment(i)));
                    if (bar.Value == bar.Maximum)
                    {
                        ex = false;
                        listFinish.Add(horse4);
                        if (listFinish.Count == 5)
                            PrintFinish(listFinish);
                    }
                    Thread.Sleep(500);
                }
            }
            finally { }
        }

        public void Horse_5(object obj)
        {
            try
            {
                ProgressBar bar = (ProgressBar)obj;
                int i = 0;
                bool ex = true;
                while (ex)
                {
                    i = rand.Next(1, 20);
                    if (bar.InvokeRequired)
                        bar.Invoke(new Action(() => bar.Increment(i)));
                    if (bar.Value == bar.Maximum)
                    {
                        ex = false;
                        listFinish.Add(horse5);
                        if (listFinish.Count == 5)
                            PrintFinish(listFinish);
                    }
                    Thread.Sleep(500);
                }
            }
            finally { }
        }

        public void StartProgram()
        {
            rand = new Random();
            listFinish = new List<int>();

            progressBarHorse1.ForeColor = RandColor();
            progressBarHorse1.Style = ProgressBarStyle.Continuous;

            progressBarHorse2.ForeColor = RandColor();
            progressBarHorse2.Style = ProgressBarStyle.Continuous;

            progressBarHorse3.ForeColor = RandColor();
            progressBarHorse3.Style = ProgressBarStyle.Continuous;

            progressBarHorse4.ForeColor = RandColor();
            progressBarHorse4.Style = ProgressBarStyle.Continuous;

            progressBarHorse5.ForeColor = RandColor();
            progressBarHorse5.Style = ProgressBarStyle.Continuous;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartProgram();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            horse_1 = new Thread(Horse_1);
            horse_1.IsBackground = true;
            horse_1.Start(progressBarHorse1);

            horse_2 = new Thread(Horse_2);
            horse_2.IsBackground = true;
            horse_2.Start(progressBarHorse2);

            horse_3 = new Thread(Horse_3);
            horse_3.IsBackground = true;
            horse_3.Start(progressBarHorse3);

            horse_4 = new Thread(Horse_4);
            horse_4.IsBackground = true;
            horse_4.Start(progressBarHorse4);

            horse_5 = new Thread(Horse_5);
            horse_5.IsBackground = true;
            horse_5.Start(progressBarHorse5);


        }

        public string Position(int hr)
        {
            switch (hr)
            {
                case 1:
                    return "Первая Лошадь";
                case 2:
                    return "Вторая Лошадь";
                case 3:
                    return "Третья Лошадь";
                case 4:
                    return "Четвертая Лошадь";
                case 5:
                    return "Пятая Лошадь";
                default:
                    return "";
            }
        }

        public void PrintFinish(List<int> list)
        {
            MessageBox.Show($"Конные скачки ПОБЕДИТЕЛИ:\n\n" +
                $" 1. {Position(list[0])}\n 2. {Position(list[1])}\n 3. {Position(list[2])}\n " +
                $"4. {Position(list[3])}\n 5. {Position(list[4])}", "ТАБЛИЦА РЕЗУЛЬТАТОВ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonResStart_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if ((item as ProgressBar) == item)
                    (item as ProgressBar).Value = 0;
            }
            if (horse_1 != null)
                horse_1.Abort();
            if (horse_2 != null)
                horse_2.Abort();
            if (horse_3 != null)
                horse_3.Abort();
            if (horse_4 != null)
                horse_4.Abort();
            if (horse_5 != null)
                horse_5.Abort();
            buttonStart.Enabled = true;
            StartProgram();
        }
    }
}
