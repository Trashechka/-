using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Спортивный_клуб.Классы;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Спортивный_клуб
{
    public partial class ДомашняяСтраница : Form
    {
        public ДомашняяСтраница()
        {
            InitializeComponent();
            events events = new events();
            events.Event(listBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Абонемент абонемент = new Абонемент();
            абонемент.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {

            }
            else
            {
                search search = new search();
                search.SearchAb(textBox1, textBox2, textBox3,textBox4);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            АккаунтАдминистратора аккаунт = new АккаунтАдминистратора();
            аккаунт.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ДомашняяСтраница_Load(object sender, EventArgs e)
        {

        }
    }
}
