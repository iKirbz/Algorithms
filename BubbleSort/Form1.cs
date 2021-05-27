using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleSort
{
    public partial class Form1 : Form
    {
        private int[] array = new int[50];
        public Form1()
        {
            InitializeComponent();

            FillArray();
            DrawBars();
        }

        private void FillArray()
        {
            array = Enumerable.Range(1, 50).ToArray();
        }

        private void DrawBars()
        {
            panel.Controls.Clear();

            for (int i = 0; i < array.Length; i++)
            {
                PictureBox bar = new PictureBox
                {
                    Width = 20,
                    Location = new Point(20*i + 2*i, 150-array[i]*3),
                    Height = array[i]*3,
                    BackColor = Color.Red
                };

                panel.Controls.Add(bar);
            }
        }

        private void btn_randomize_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            array = array.OrderBy(x => rnd.Next()).ToArray();
            DrawBars();
        }

        private void btn_sort_Click(object sender, EventArgs e)
        {
            BubbleSort(array);

            DrawBars();
        }

        private void BubbleSort(int[] toSort)
        {
            int temp;

            for (int j = 0; j <= toSort.Length - 2; j++)
            {
                for (int i = 0; i <= toSort.Length - 2; i++)
                {
                    if (toSort[i] > toSort[i + 1])
                    {
                        temp = toSort[i + 1];
                        toSort[i + 1] = toSort[i];
                        toSort[i] = temp;
                    }
                }
            }
        }
    }
}
