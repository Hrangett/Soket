using System;
using System.IO;    //Stream 사용
using System.Windows.Forms;
using System.Net.Sockets;   //Tcp Listner client, server
using System.Threading;     //쓰레드 사용
using Microsoft.Win32;  //레지스트리 클래스 사용. 별칭 등의 간단한 정보를 저장 및 재사용
using System.Net;       //IP Address

namespace Messenger2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TcpListener Server;     //Tcp 통신시 클라이언트의 연결을 수신
        private TcpClient SerClient;    //서버측의 클라이언트
        private TcpClient client;       //서버에 접속하려는 클라이언트
        private NetworkStream myStream; //네트워크 스트림(데잍터 전솜 및 수신 통로)
        private StreamReader myRead;    //읽기 스트림
        private StreamWriter myWriter;  //쓰기 스트림

        private Boolean Start = false;      //서버 기동
        private Boolean ClientCon = false;  //클라이언트 기동

        private int myPort;         //포트번호
        private string myName;      //별칭
        private Thread myReader;    //전송된 데이터의 읽기 쓰레드
        private Thread myServer;    //서버대기 쓰레드

        private RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETFramework",true);

        // 전송된 데이터를 출력하는 대리자 작성
        private delegate void AddTextDelegate(string strText);
        private AddTextDelegate AddText = null;


        private void Form1_Load(object sender, EventArgs e)
        {
            //레지스트리에 별칭이 등록되지 않았는지?
            if((string)key.GetValue("Message_name") == "")
            {
                this.myName = this.txtId.Text;
                this.myPort = 62000;
            }
            else
            {// 등록됨?
                try
                {
                    this.myName = (string)key.GetValue("Message_name");
                    this.myPort = 62000;

                }
                catch (Exception)
                {

                    
                }
            }
        }

        private void 설정ToolStringMenuItem_Click(object sender, EventArgs e)
        {
            this.설정toolStringMenuItem.Enabled = false;
            this.plOption.Visible = true;
            this.txtId.Focus();
            this.txtId.Text = (string)key.GetValue("Message_name");
            this.txtPort.Text = "62001";    //포트번호
        }

        private void 닫기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ServerStop();
                Disconnection();
            }
            catch
            {

                return;
            }
        }

        private void tsbtnConn_Click(object sender, EventArgs e)
        {

            AddText = new AddTextDelegate(MessageView);
            //  서버용 기동인지 클라이언트 기동인지 구분
            if (this.cbServer.Checked == true)   //서버로 기동
            {
                var addr = new IPAddress(0);
                try
                {
                    this.myName = (string)key.GetValue("Message_name");
                }
                catch (Exception)
                {

                    this.myName = this.txtId.Text;
                    this.myPort = Convert.ToInt32(this.txtPort.Text);

                }

                if(!(this.Start))
                {
                    try
                    {
                        Server = new TcpListener(addr, this.myPort);
                        Server.Start();

                        //서버상태 flag를 기동상태로 변경
                        this.Start = true;

                        //화면 컨트롤 제어
                        this.txtMessage.Enabled = true;
                        this.btnSend.Enabled = true;
                        this.txtMessage.Focus();
                        this.tsbtnConn.Enabled = false;
                        this.tsbtnDisconn.Enabled = true;
                        this.cbServer.Enabled = false;

                        //  서버에 접속하는 크라이언트를 대기  => 쓰레드!!
                        myServer = new Thread(ServerStart);
                        myServer.Start();

                        this.설정toolStringMenuItem.Enabled = false;

                    }
                    catch (Exception)
                    {
                        //접속에서 MEssage처리
                        Invoke(AddText, "서버를 실행할 수 없습니다");
                        throw;
                    }
                }
                else
                {
                    //서버 종료

                }
            }
            else   //클라이언트로 기동
            {
                if (!(this.ClientCon))
                {
                    //클라이어ㄴ트가 기동이 되지 않았는지=> 기동시킴
                    ClientConnection();
                }
                else
                {
                    this.txtMessage.Enabled = false;
                    this.btnSend.Enabled = false;
                }
            }

        }

        private void ClientConnection()
        {
            try
            {
                //클라이언트가 서버에 접속
                client = new TcpClient(this.txtIp.Text, this.myPort);

                Invoke(AddText, "서버에 접속했습니다");

                //서버와 연결된 통신통로(스트림) 획득
                myStream = client.GetStream();

                myRead = new StreamReader(myStream);
                myWriter = new StreamWriter(myStream);

                // 컨트롤제어
                this.ClientCon = true;
                this.tsbtnConn.Enabled = false;
                this.tsbtnDisconn.Enabled = true;
                this.txtMessage.Enabled = true;
                this.btnSend.Enabled = true;
                this.txtMessage.Focus();

                //수신 쓰레드 생성
                myReader = new Thread(Receive);     //Receive는 서버, 클라이언ㅌ 겸용
                myReader.Start();
            }   
            catch(Exception ex)
            {
                //서버에 접속 못한 상태를 상태Flage에 반영 후 메세지로 처리
                this.ClientCon = false;
                Invoke(AddText, "서버에 접속하지 못했습니다");
                Invoke(AddText,$"Err : {ex.Message}");
            }
        }

        private void MessageView(string strText)
        {
            //메세지 추가
            this.rtbText.AppendText(strText + "\n");
            this.rtbText.Focus();

            //마지막 위치로 이동
            this.rtbText.ScrollToCaret();
            this.txtMessage.Focus();
        }

        //서버 종료 및 자원 래제 처리
        private void ServerStop()
        {
            this.Start = false;

            // 컨트롤 제어
            this.txtMessage.Enabled = false;
            this.txtMessage.Clear();
            this.btnSend.Enabled = false;
            this.tsbtnConn.Enabled = true;
            this.tsbtnDisconn.Enabled = false;
            this.cbServer.Enabled = true;

            // 클라이언트의 접속 상태 flg도 false 로 변경.
            this.ClientCon = false;

            // 각종 자원 해제
            // StreadReader 해제
            if (!(myRead == null))
            {
                myRead.Close();
            }
            // StreamWriter 해제
            if (!(myWriter == null))
            {
                myWriter.Close();
            }
            // Network stream 해제
            if (!(myStream == null))
            {
                myStream.Close();
            }
            // TcpClinet 해제
            if (!(SerClient == null))
            {
                SerClient.Close();
            }
            // TcpListner 해제
            if (!(Server == null))
            {
                Server.Stop();
            }
            // 수신 쓰레드 해제
            // 클라이언트 접속 담당 쓰레드 해제
            if (!(myReader == null))
            {
                myReader.Join();
            }

            // 서버와 종료된 상황을 메세지로 알려줌
            if (!(AddText == null))
            {
                Invoke(AddText, "서버와 접속이 끊겼습니다.");
            }
        }

        //서버 및 클라이언트가 상대방에게 보내는 메세지를 전송함
        private void Msg_send()
        {
            try
            {
                //전송시가정보획득
                var dt = Convert.ToString(DateTime.Now);

                myWriter.WriteLine(this.myName + "&" + this.txtMessage.Text + "&" + dt);
                myWriter.Flush();

                //리치텍스트 박스에 전송 메세지 추가
                MessageView(this.myName + ":" + this.txtMessage.Text);
                this.txtMessage.Clear();

            }
            catch (Exception)
            {
                Invoke(AddText, "데이터 전송에 문제가 발생했습니다.");
                this.txtMessage.Clear();
            }
        }

        private void Disconnection()
        {
            //클라이언트 접속 ㅎㅐ제 처리
            this.ClientCon = false;
            try
            {
                if(!(myRead == null))
                {
                    myRead.Close();
                }

                //스트림 해제
                if (myWriter != null)
                {
                    myWriter.Close();
                }

                //네트워크 스트림ㄴ 해제
                if (!(myStream == null))
                {
                    myStream.Close();
                }

                //TCP Client 해제
                if(client != null)
                {
                    client.Close();
                }

                //쓰레드 종료,
                if (myReader != null)
                {
                    myReader.Join();
                }

            }
            catch 
            {

                return;
            }
        }

        private void ServerStart()
        {
            Invoke(AddText, "서버실행 : 클라이언트의 접속을 기다립니다.");
            while(Start)
            {
                try
                {
                    //서버에 접속된 클라이언트
                    SerClient = Server.AcceptTcpClient();

                    Invoke(AddText, "클라이언트가 접속되었습니다.");


                    myStream = SerClient.GetStream();

                    myRead = new StreamReader(myStream);
                    myWriter = new StreamWriter(myStream);

                    this.ClientCon = true;

                    //client가 보내온 데이터를 수신하는 쓰레드
                    myReader = new Thread(Receive);
                    myReader.Start();
                }
                catch (Exception)
                {

                }
                
            }

            

        }

        private void Receive()
        {

            try
            {
                // 클라이언트가 접속 되어 있는 동안
                while (this.ClientCon)
                {
                    // 스트림으로 부터 읽을 데이터가 있는지?
                    if(myStream.CanRead)
                    {
                        var msg = myRead.ReadLine();
                        var Smsg = msg.Split('&');

                        if(Smsg[0] == "S001")
                        {
                            //전송시각처리이지만, 생랴ㅐㄱ
                        }
                        else
                        {
                            if(msg.Length>0)
                            {
                                Invoke(AddText, Smsg[0] + " : " + Smsg[1]);
                            }
                        }
                        //수신 데이터 처리
                    }
                   
                }

            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
                
            }
        }

        private void tsbtnDisconn_Click(object sender, EventArgs e)
        {

            try
            {
                //클라이언트로 기동했느냐 서버로 기동했느냐
                if(this.cbServer.Checked)
                {
                    if (this.SerClient.Connected)
                    {
                        var dt = Convert.ToString(DateTime.Now);
                        // 클라이언트에게 서버가 종료됨을 알림
                        myWriter.WriteLine(this.myName + "&" + "채팅App가 종료되었습니다." + "&" + dt);
                        myWriter.Flush();
                    }
                }
                else
                {
                    if(this.client.Connected)
                    {
                        var dt = Convert.ToString(DateTime.Now);
                        // 서버에게 클라이언트가 종료됨을 알림
                        myWriter.WriteLine(this.myName + "&" + "채팅App가 종료되었습니다." + "&" + dt);
                        myWriter.Flush();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}");
            }
            ServerStop();
            this.설정toolStringMenuItem.Enabled = true;
        }

        private void cbServer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbServer.Checked)
            {
                //서버 기동시 IP는 내부적으로 사용 => 입력막음
                this.txtIp.Enabled = false;
            }
            else
            {
                // 클라이언트로 기동시 접속할 IP를 입력받음
                this.txtIp.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.설정toolStringMenuItem.Enabled = Capture;
            this.plOption.Visible = false;
            this.txtMessage.Focus();
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //엔터키가 입력된 경우
            if (e.KeyChar == (char)13)
            {
                if (this.txtMessage.Text == "")
                {
                    this.txtMessage.Focus();
                }
                else
                {
                    Msg_send();
                }
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cbServer.Checked == true)  //서버용으로 사용
            {
                //입ㄹㅕㄱ된 정보 레지스트리에 등록
                ControllCheck();
                //
            }
            else   //클라이언트용으로 사용
            {
                if (this.txtIp.Text == "")
                {
                    this.txtIp.Focus();
                }
                else
                {
                    ControllCheck();
                }
            }
        }

        private void ControllCheck()
        {
            if(this.txtId.Text == "")
            {
                this.txtId.Focus();
            }
            else if(this.txtPort.Text == "")
            {
                this.txtPort.Focus();
            }
            else
            {
                //입력된 정보를 레지스트리에 저장
                try
                {
                    // 레지스트리에 별칭 및 포트저어장

                    var name = this.txtId.Text;
                    var port = this.txtPort.Text;
                    key.SetValue("Message_name", name);
                    key.SetValue("Message_port", port);

                    //컨트롤 제어
                    this.plOption.Visible = false;
                    this.설정toolStringMenuItem.Enabled = true;
                    this.tsbtnConn.Enabled = true;

                }
                catch (Exception)
                {
                    MessageBox.Show("설정 정보가 저장되지 않았습니다", "에러", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(this.txtMessage.Text == "")
            {
                txtMessage.Focus();
            }
            else
            {
                Msg_send();

            }
        }


    }
}
