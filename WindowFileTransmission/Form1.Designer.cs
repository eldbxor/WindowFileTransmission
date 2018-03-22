namespace WindowFileTransmission
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
            this.ListView_FileList = new System.Windows.Forms.ListView();
            this.columnHeader_fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_fileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_filePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.연결ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Server = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Client = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Send = new System.Windows.Forms.Button();
            this.groupBox_mode = new System.Windows.Forms.GroupBox();
            this.RadioBtn_Receive = new System.Windows.Forms.RadioButton();
            this.RadioBtn_Send = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_send = new System.Windows.Forms.GroupBox();
            this.groupBox_receive = new System.Windows.Forms.GroupBox();
            this.Btn_ChangePath = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox_mode.SuspendLayout();
            this.groupBox_send.SuspendLayout();
            this.groupBox_receive.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListView_FileList
            // 
            this.ListView_FileList.AllowDrop = true;
            this.ListView_FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_fileName,
            this.columnHeader_fileSize,
            this.columnHeader_filePath});
            this.ListView_FileList.Location = new System.Drawing.Point(12, 57);
            this.ListView_FileList.Name = "ListView_FileList";
            this.ListView_FileList.Size = new System.Drawing.Size(299, 365);
            this.ListView_FileList.TabIndex = 0;
            this.ListView_FileList.UseCompatibleStateImageBehavior = false;
            this.ListView_FileList.View = System.Windows.Forms.View.Details;
            this.ListView_FileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_FileList_DragDrop);
            this.ListView_FileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_FileList_DragEnter);
            // 
            // columnHeader_fileName
            // 
            this.columnHeader_fileName.Text = "파일명";
            this.columnHeader_fileName.Width = 175;
            // 
            // columnHeader_fileSize
            // 
            this.columnHeader_fileSize.Text = "크기";
            // 
            // columnHeader_filePath
            // 
            this.columnHeader_filePath.Text = "진행도";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.연결ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(641, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 연결ToolStripMenuItem
            // 
            this.연결ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Server,
            this.MenuItem_Client});
            this.연결ToolStripMenuItem.Name = "연결ToolStripMenuItem";
            this.연결ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.연결ToolStripMenuItem.Text = "연결";
            // 
            // MenuItem_Server
            // 
            this.MenuItem_Server.Name = "MenuItem_Server";
            this.MenuItem_Server.Size = new System.Drawing.Size(134, 22);
            this.MenuItem_Server.Text = "서버";
            this.MenuItem_Server.Click += new System.EventHandler(this.MenuItem_Server_Click);
            // 
            // MenuItem_Client
            // 
            this.MenuItem_Client.Name = "MenuItem_Client";
            this.MenuItem_Client.Size = new System.Drawing.Size(134, 22);
            this.MenuItem_Client.Text = "클라이언트";
            this.MenuItem_Client.Click += new System.EventHandler(this.MenuItem_Client_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "파일 목록";
            // 
            // Btn_Send
            // 
            this.Btn_Send.Location = new System.Drawing.Point(11, 20);
            this.Btn_Send.Name = "Btn_Send";
            this.Btn_Send.Size = new System.Drawing.Size(177, 23);
            this.Btn_Send.TabIndex = 4;
            this.Btn_Send.Text = "전송";
            this.Btn_Send.UseVisualStyleBackColor = true;
            this.Btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // groupBox_mode
            // 
            this.groupBox_mode.Controls.Add(this.RadioBtn_Receive);
            this.groupBox_mode.Controls.Add(this.RadioBtn_Send);
            this.groupBox_mode.Location = new System.Drawing.Point(322, 57);
            this.groupBox_mode.Name = "groupBox_mode";
            this.groupBox_mode.Size = new System.Drawing.Size(200, 48);
            this.groupBox_mode.TabIndex = 5;
            this.groupBox_mode.TabStop = false;
            this.groupBox_mode.Text = "모드";
            // 
            // RadioBtn_Receive
            // 
            this.RadioBtn_Receive.AutoSize = true;
            this.RadioBtn_Receive.Location = new System.Drawing.Point(116, 20);
            this.RadioBtn_Receive.Name = "RadioBtn_Receive";
            this.RadioBtn_Receive.Size = new System.Drawing.Size(47, 16);
            this.RadioBtn_Receive.TabIndex = 1;
            this.RadioBtn_Receive.TabStop = true;
            this.RadioBtn_Receive.Text = "받기";
            this.RadioBtn_Receive.UseVisualStyleBackColor = true;
            // 
            // RadioBtn_Send
            // 
            this.RadioBtn_Send.AutoSize = true;
            this.RadioBtn_Send.Location = new System.Drawing.Point(27, 20);
            this.RadioBtn_Send.Name = "RadioBtn_Send";
            this.RadioBtn_Send.Size = new System.Drawing.Size(59, 16);
            this.RadioBtn_Send.TabIndex = 0;
            this.RadioBtn_Send.TabStop = true;
            this.RadioBtn_Send.Text = "보내기";
            this.RadioBtn_Send.UseVisualStyleBackColor = true;
            this.RadioBtn_Send.CheckedChanged += new System.EventHandler(this.RadioBtn_Send_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(295, 21);
            this.textBox1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "받을 위치";
            // 
            // groupBox_send
            // 
            this.groupBox_send.Controls.Add(this.Btn_Send);
            this.groupBox_send.Location = new System.Drawing.Point(322, 111);
            this.groupBox_send.Name = "groupBox_send";
            this.groupBox_send.Size = new System.Drawing.Size(200, 54);
            this.groupBox_send.TabIndex = 8;
            this.groupBox_send.TabStop = false;
            // 
            // groupBox_receive
            // 
            this.groupBox_receive.Controls.Add(this.Btn_ChangePath);
            this.groupBox_receive.Controls.Add(this.label2);
            this.groupBox_receive.Controls.Add(this.textBox1);
            this.groupBox_receive.Location = new System.Drawing.Point(322, 171);
            this.groupBox_receive.Name = "groupBox_receive";
            this.groupBox_receive.Size = new System.Drawing.Size(307, 90);
            this.groupBox_receive.TabIndex = 0;
            this.groupBox_receive.TabStop = false;
            // 
            // Btn_ChangePath
            // 
            this.Btn_ChangePath.Location = new System.Drawing.Point(226, 59);
            this.Btn_ChangePath.Name = "Btn_ChangePath";
            this.Btn_ChangePath.Size = new System.Drawing.Size(75, 23);
            this.Btn_ChangePath.TabIndex = 9;
            this.Btn_ChangePath.Text = "변경";
            this.Btn_ChangePath.UseVisualStyleBackColor = true;
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 12;
            this.listBoxLog.Location = new System.Drawing.Point(322, 262);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(307, 160);
            this.listBoxLog.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 434);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.groupBox_receive);
            this.Controls.Add(this.groupBox_send);
            this.Controls.Add(this.groupBox_mode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListView_FileList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "파일 전송 프로그램";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox_mode.ResumeLayout(false);
            this.groupBox_mode.PerformLayout();
            this.groupBox_send.ResumeLayout(false);
            this.groupBox_receive.ResumeLayout(false);
            this.groupBox_receive.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListView_FileList;
        private System.Windows.Forms.ColumnHeader columnHeader_fileName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 연결ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Server;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader_fileSize;
        private System.Windows.Forms.ColumnHeader columnHeader_filePath;
        private System.Windows.Forms.Button Btn_Send;
        private System.Windows.Forms.GroupBox groupBox_mode;
        private System.Windows.Forms.RadioButton RadioBtn_Receive;
        private System.Windows.Forms.RadioButton RadioBtn_Send;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox_send;
        private System.Windows.Forms.GroupBox groupBox_receive;
        private System.Windows.Forms.Button Btn_ChangePath;
        private System.Windows.Forms.ListBox listBoxLog;
    }
}

