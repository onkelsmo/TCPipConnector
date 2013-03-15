using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace testTCPip
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        tcpIP.TCP_ip tcp = new tcpIP.TCP_ip();


        //Create Host
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = tcp.InitializeDirectPlay(true);

        }


        //Connect
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = tcp.InitializeDirectPlay(false);
        }


        //Send Text to All
        private void button3_Click(object sender, EventArgs e)
        {
            tcp.SendText(textBox2.Text);
        }


        //Send text 2 player
        private void button4_Click(object sender, EventArgs e)
        {
            tcp.SendText2Player(textBox2.Text, int.Parse(textBox1.Text));
        }


        #region EventFunctionen
        private void onTextRecive(string text, string id)
        {
            textBox2.Text = ("Message von: " + id + ":   " + text);

        }
        private void onFindHost(int currentPlayerID, int MaxPlayers)
        {


        }
        private void onMigrate(string info)
        {


        }
        private void ConnectComlite(int PlayerID, string idUserContext)
        {


        }
        private void OnDataReceiveEXBinary(byte[] bArray, string PlayerID)
        {


        }
        #endregion



        private void Form1_Load(object sender, EventArgs e)
        {
            tcpIP.TCP_ip.DataReceive += new tcpIP.TCP_ip.DataReceiveEventHandler(onTextRecive);
            tcpIP.TCP_ip.FindHost += new tcpIP.TCP_ip.FindHostEventHandler(onFindHost);
            tcpIP.TCP_ip.Migrate += new tcpIP.TCP_ip.MigrateEventHandler(onMigrate);
            tcpIP.TCP_ip.onConnectComlite += new tcpIP.TCP_ip.onConnectComliteEventHandler(ConnectComlite);
            tcpIP.TCP_ip.OnDataReceiveEXBinary += new tcpIP.TCP_ip.OnDataReceiveEXBinaryEventHandler(OnDataReceiveEXBinary);


        }


    }
}
