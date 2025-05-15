namespace Car_List
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.carInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.mileageTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.makeTextBox = new System.Windows.Forms.TextBox();
            this.mileagePromptLabel = new System.Windows.Forms.Label();
            this.yearPromptLabel = new System.Windows.Forms.Label();
            this.makePromptLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.carListBox = new System.Windows.Forms.ListBox();
            this.displayButton = new System.Windows.Forms.Button();
            this.carInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // carInfoGroupBox
            // 
            this.carInfoGroupBox.Controls.Add(this.mileageTextBox);
            this.carInfoGroupBox.Controls.Add(this.yearTextBox);
            this.carInfoGroupBox.Controls.Add(this.makeTextBox);
            this.carInfoGroupBox.Controls.Add(this.mileagePromptLabel);
            this.carInfoGroupBox.Controls.Add(this.yearPromptLabel);
            this.carInfoGroupBox.Controls.Add(this.makePromptLabel);
            this.carInfoGroupBox.Location = new System.Drawing.Point(12, 16);
            this.carInfoGroupBox.Name = "carInfoGroupBox";
            this.carInfoGroupBox.Size = new System.Drawing.Size(200, 97);
            this.carInfoGroupBox.TabIndex = 0;
            this.carInfoGroupBox.TabStop = false;
            this.carInfoGroupBox.Text = "汽車資訊";
            this.carInfoGroupBox.Enter += new System.EventHandler(this.carInfoGroupBox_Enter);
            // 
            // mileageTextBox
            // 
            this.mileageTextBox.Location = new System.Drawing.Point(81, 66);
            this.mileageTextBox.Name = "mileageTextBox";
            this.mileageTextBox.Size = new System.Drawing.Size(100, 22);
            this.mileageTextBox.TabIndex = 5;
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(81, 42);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(100, 22);
            this.yearTextBox.TabIndex = 4;
            // 
            // makeTextBox
            // 
            this.makeTextBox.Location = new System.Drawing.Point(81, 18);
            this.makeTextBox.Name = "makeTextBox";
            this.makeTextBox.Size = new System.Drawing.Size(100, 22);
            this.makeTextBox.TabIndex = 3;
            // 
            // mileagePromptLabel
            // 
            this.mileagePromptLabel.AutoSize = true;
            this.mileagePromptLabel.Location = new System.Drawing.Point(19, 68);
            this.mileagePromptLabel.Name = "mileagePromptLabel";
            this.mileagePromptLabel.Size = new System.Drawing.Size(44, 12);
            this.mileagePromptLabel.TabIndex = 2;
            this.mileagePromptLabel.Text = "里程數:";
            // 
            // yearPromptLabel
            // 
            this.yearPromptLabel.AutoSize = true;
            this.yearPromptLabel.Location = new System.Drawing.Point(34, 44);
            this.yearPromptLabel.Name = "yearPromptLabel";
            this.yearPromptLabel.Size = new System.Drawing.Size(32, 12);
            this.yearPromptLabel.TabIndex = 1;
            this.yearPromptLabel.Text = "年份:";
            // 
            // makePromptLabel
            // 
            this.makePromptLabel.AutoSize = true;
            this.makePromptLabel.Location = new System.Drawing.Point(34, 20);
            this.makePromptLabel.Name = "makePromptLabel";
            this.makePromptLabel.Size = new System.Drawing.Size(32, 12);
            this.makePromptLabel.TabIndex = 0;
            this.makePromptLabel.Text = "廠牌:";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(75, 131);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 32);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "加入清單";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // carListBox
            // 
            this.carListBox.FormattingEnabled = true;
            this.carListBox.ItemHeight = 12;
            this.carListBox.Location = new System.Drawing.Point(238, 25);
            this.carListBox.Name = "carListBox";
            this.carListBox.Size = new System.Drawing.Size(207, 88);
            this.carListBox.TabIndex = 2;
            // 
            // displayButton
            // 
            this.displayButton.Location = new System.Drawing.Point(304, 131);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(75, 32);
            this.displayButton.TabIndex = 3;
            this.displayButton.Text = "顯示清單";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 179);
            this.Controls.Add(this.displayButton);
            this.Controls.Add(this.carListBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.carInfoGroupBox);
            this.Name = "Form1";
            this.Text = "汽車清單";
            this.carInfoGroupBox.ResumeLayout(false);
            this.carInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox carInfoGroupBox;
        private System.Windows.Forms.TextBox mileageTextBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox makeTextBox;
        private System.Windows.Forms.Label mileagePromptLabel;
        private System.Windows.Forms.Label yearPromptLabel;
        private System.Windows.Forms.Label makePromptLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox carListBox;
        private System.Windows.Forms.Button displayButton;
    }
}

