using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace WindowFileTransmission
{
    public partial class Form1 : Form
    {
        NetworkState mNetworkState;
        Socket socket;

        public Form1()
        {
            InitializeComponent();
            groupBox_mode.Enabled = false;
            groupBox_send.Enabled = false;
            groupBox_receive.Enabled = false;
        }

        enum NetworkState
        {
            NOT_CONNECTED,
            CONNECTED_AS_SERVER,
            CONNECTED_AS_CLIENT
        }

        private void SetGroupBoxPermission(NetworkState state)
        {
            PutLog(state.ToString());
            switch (state)
            {
                case NetworkState.NOT_CONNECTED:
                    groupBox_mode.Enabled = false;
                    groupBox_send.Enabled = false;
                    groupBox_receive.Enabled = false;
                    break;
                case NetworkState.CONNECTED_AS_SERVER:
                    groupBox_mode.Enabled = true;
                    groupBox_send.Enabled = true;
                    groupBox_receive.Enabled = false;
                    break;
                case NetworkState.CONNECTED_AS_CLIENT:
                    groupBox_mode.Enabled = false;
                    groupBox_send.Enabled = false;
                    groupBox_receive.Enabled = true;
                    break;
            }
        }

        private void SetGroupBoxPermission(bool isRadioBtnSendChecked)
        {
            switch (isRadioBtnSendChecked)
            {
                case true:
                    groupBox_send.Enabled = true;
                    groupBox_receive.Enabled = false;
                    break;
                case false:
                    groupBox_send.Enabled = false;
                    groupBox_receive.Enabled = true;
                    break;
            }
        }


        private void ListView_FileList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void ListView_FileList_DragDrop(object sender, DragEventArgs e)
        {
            String[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) ListView_FileList.Items.Add(file);
        }

        private void MenuItem_Server_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(CreateServer)).Start();
        }

        private void CreateServer()
        {
            bool isAvailableAsServer = GetPublicIp() == GetMyIp() ? true : false;
            PutLog(isAvailableAsServer ? "서버 개설 가능" + "(현재 아이피: " + GetMyIp() + ")" : "서버 개설 불가" + "(현재 아이피: " + GetMyIp() + ")");
            if (!isAvailableAsServer) return;

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint point = new IPEndPoint(IPAddress.Loopback, 8192);

            socket.Bind(point);
            socket.Listen(1);
            socket = socket.Accept();

            SetGroupBoxPermission(mNetworkState = NetworkState.CONNECTED_AS_SERVER);
            RadioBtn_Send.Checked = true;
        }

        private void MenuItem_Client_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(ConnectToServer)).Start();
        }

        private void ConnectToServer()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(IPAddress.Loopback, 8192);

            SetGroupBoxPermission(mNetworkState = NetworkState.CONNECTED_AS_CLIENT);
            RadioBtn_Receive.Checked = true;
        }

        // 공인 아이피 가져오기
        private string GetPublicIp()
        {
            string ip = new WebClient().DownloadString(@"http://ipinfo.io/ip");
            return Regex.Replace(ip, @"\t|\n|\r", String.Empty);
        }

        // 현재 아이피 가져오기
        private string GetMyIp()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string ClientIp = string.Empty;
            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    ClientIp = host.AddressList[i].ToString();
            }
            return ClientIp;
        }

        private void PutLog(string msg)
        {
            Console.WriteLine(msg);

            if (listBoxLog.InvokeRequired)
                listBoxLog.BeginInvoke(new Action(() => listBoxLog.SelectedIndex = listBoxLog.Items.Add(msg)));
            else
                listBoxLog.SelectedIndex = listBoxLog.Items.Add(msg);
        }

        private void RadioBtn_Send_CheckedChanged(object sender, EventArgs e)
        {
            SetGroupBoxPermission(RadioBtn_Send.Checked);
            if (mNetworkState == NetworkState.CONNECTED_AS_SERVER)
            {
                SetGroupBoxPermission(RadioBtn_Send.Checked);
            }
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socket != null)
                socket.Close();
        }
    }
}
