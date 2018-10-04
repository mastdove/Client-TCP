using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Echo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        SimpleTcpClient client;
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            client.Connect(textBox1.Text, Convert.ToInt32(textBox2.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataResived;
        }

        private void Client_DataResived(object sender, SimpleTCP.Message e)
        {


            textBox3.Invoke((MethodInvoker)delegate ()
            {
                textBox4.Text += e.MessageString;
            });

           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply(textBox3.Text, TimeSpan.FromSeconds(3));

        }

    }
}