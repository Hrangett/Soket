
namespace Messenger2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsddbtnOption = new System.Windows.Forms.ToolStripDropDownButton();
            this.설정toolStringMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.닫기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnConn = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDisconn = new System.Windows.Forms.ToolStripButton();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.plOption = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbServer = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.plOption.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbtnOption,
            this.tsbtnConn,
            this.tsbtnDisconn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(522, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsddbtnOption
            // 
            this.tsddbtnOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddbtnOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.설정toolStringMenuItem,
            this.toolStripSeparator1,
            this.닫기ToolStripMenuItem});
            this.tsddbtnOption.Image = ((System.Drawing.Image)(resources.GetObject("tsddbtnOption.Image")));
            this.tsddbtnOption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbtnOption.Name = "tsddbtnOption";
            this.tsddbtnOption.Size = new System.Drawing.Size(29, 22);
            this.tsddbtnOption.Text = "환경설정";
            // 
            // 설정toolStringMenuItem
            // 
            this.설정toolStringMenuItem.Name = "설정toolStringMenuItem";
            this.설정toolStringMenuItem.Size = new System.Drawing.Size(110, 22);
            this.설정toolStringMenuItem.Text = "설   정";
            this.설정toolStringMenuItem.Click += new System.EventHandler(this.설정ToolStringMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(107, 6);
            // 
            // 닫기ToolStripMenuItem
            // 
            this.닫기ToolStripMenuItem.Name = "닫기ToolStripMenuItem";
            this.닫기ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.닫기ToolStripMenuItem.Text = "닫   기";
            this.닫기ToolStripMenuItem.Click += new System.EventHandler(this.닫기ToolStripMenuItem_Click);
            // 
            // tsbtnConn
            // 
            this.tsbtnConn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnConn.Enabled = false;
            this.tsbtnConn.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnConn.Image")));
            this.tsbtnConn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnConn.Name = "tsbtnConn";
            this.tsbtnConn.Size = new System.Drawing.Size(23, 22);
            this.tsbtnConn.Text = "연결";
            this.tsbtnConn.ToolTipText = "연결";
            this.tsbtnConn.Click += new System.EventHandler(this.tsbtnConn_Click);
            // 
            // tsbtnDisconn
            // 
            this.tsbtnDisconn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDisconn.Enabled = false;
            this.tsbtnDisconn.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDisconn.Image")));
            this.tsbtnDisconn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDisconn.Name = "tsbtnDisconn";
            this.tsbtnDisconn.Size = new System.Drawing.Size(23, 22);
            this.tsbtnDisconn.Text = "끊기";
            this.tsbtnDisconn.ToolTipText = "끊기";
            this.tsbtnDisconn.Click += new System.EventHandler(this.tsbtnDisconn_Click);
            // 
            // rtbText
            // 
            this.rtbText.Location = new System.Drawing.Point(0, 28);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(522, 335);
            this.rtbText.TabIndex = 1;
            this.rtbText.Text = "";
            // 
            // plOption
            // 
            this.plOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plOption.Controls.Add(this.btnClose);
            this.plOption.Controls.Add(this.btnSave);
            this.plOption.Controls.Add(this.cbServer);
            this.plOption.Controls.Add(this.txtPort);
            this.plOption.Controls.Add(this.txtId);
            this.plOption.Controls.Add(this.txtIp);
            this.plOption.Controls.Add(this.label3);
            this.plOption.Controls.Add(this.label2);
            this.plOption.Controls.Add(this.label1);
            this.plOption.Location = new System.Drawing.Point(0, 28);
            this.plOption.Name = "plOption";
            this.plOption.Size = new System.Drawing.Size(215, 202);
            this.plOption.TabIndex = 2;
            this.plOption.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(119, 150);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "설정";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbServer
            // 
            this.cbServer.AutoSize = true;
            this.cbServer.Location = new System.Drawing.Point(16, 115);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(76, 16);
            this.cbServer.TabIndex = 8;
            this.cbServer.Text = "서버 실행";
            this.cbServer.UseVisualStyleBackColor = true;
            this.cbServer.CheckedChanged += new System.EventHandler(this.cbServer_CheckedChanged);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(57, 84);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 7;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(57, 48);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 21);
            this.txtId.TabIndex = 6;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(57, 17);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(100, 21);
            this.txtIp.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "PORT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnSend);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 363);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(522, 90);
            this.panel2.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(435, 19);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 50);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "보내기";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtMessage);
            this.panel3.Location = new System.Drawing.Point(12, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(417, 50);
            this.panel3.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Location = new System.Drawing.Point(3, 15);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(411, 14);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 453);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.plOption);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "1:1 ㅊㅐㅌㅣㅇ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.plOption.ResumeLayout(false);
            this.plOption.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tsddbtnOption;
        private System.Windows.Forms.ToolStripMenuItem 설정toolStringMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 닫기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbtnConn;
        private System.Windows.Forms.ToolStripButton tsbtnDisconn;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.Panel plOption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbServer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
    }
}

