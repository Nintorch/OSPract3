namespace OSPract3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Button_Connect = new Button();
            Label_Status = new Label();
            TextBox_Message = new TextBox();
            Button_Send = new Button();
            SuspendLayout();
            // 
            // Button_Connect
            // 
            Button_Connect.Location = new Point(20, 24);
            Button_Connect.Name = "Button_Connect";
            Button_Connect.Size = new Size(150, 29);
            Button_Connect.TabIndex = 0;
            Button_Connect.Text = "Подключиться";
            Button_Connect.UseVisualStyleBackColor = true;
            Button_Connect.Click += Button_Connect_Click;
            // 
            // Label_Status
            // 
            Label_Status.AutoSize = true;
            Label_Status.Location = new Point(12, 421);
            Label_Status.Name = "Label_Status";
            Label_Status.Size = new Size(50, 20);
            Label_Status.TabIndex = 1;
            Label_Status.Text = "label1";
            // 
            // TextBox_Message
            // 
            TextBox_Message.Location = new Point(20, 82);
            TextBox_Message.Name = "TextBox_Message";
            TextBox_Message.Size = new Size(125, 27);
            TextBox_Message.TabIndex = 2;
            // 
            // Button_Send
            // 
            Button_Send.Location = new Point(20, 115);
            Button_Send.Name = "Button_Send";
            Button_Send.Size = new Size(94, 29);
            Button_Send.TabIndex = 3;
            Button_Send.Text = "Отправить";
            Button_Send.UseVisualStyleBackColor = true;
            Button_Send.Click += Button_Send_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Button_Send);
            Controls.Add(TextBox_Message);
            Controls.Add(Label_Status);
            Controls.Add(Button_Connect);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Button_Connect;
        private Label Label_Status;
        private TextBox TextBox_Message;
        private Button Button_Send;
    }
}
