namespace UI
{
    partial class AdminMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_dificulty = new System.Windows.Forms.ComboBox();
            this.b_loadQuestions = new System.Windows.Forms.Button();
            this.b_eraseQuestions = new System.Windows.Forms.Button();
            this.cb_category = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_set = new System.Windows.Forms.ComboBox();
            this.nud_amount = new System.Windows.Forms.NumericUpDown();
            this.b_LogOut = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_amount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dificulty:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount:";
            // 
            // cb_dificulty
            // 
            this.cb_dificulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dificulty.Enabled = false;
            this.cb_dificulty.FormattingEnabled = true;
            this.cb_dificulty.Location = new System.Drawing.Point(71, 120);
            this.cb_dificulty.Name = "cb_dificulty";
            this.cb_dificulty.Size = new System.Drawing.Size(154, 21);
            this.cb_dificulty.TabIndex = 3;
            // 
            // b_loadQuestions
            // 
            this.b_loadQuestions.Enabled = false;
            this.b_loadQuestions.Location = new System.Drawing.Point(67, 206);
            this.b_loadQuestions.Name = "b_loadQuestions";
            this.b_loadQuestions.Size = new System.Drawing.Size(76, 36);
            this.b_loadQuestions.TabIndex = 6;
            this.b_loadQuestions.Text = "Load Questions";
            this.b_loadQuestions.UseVisualStyleBackColor = true;
            this.b_loadQuestions.Click += new System.EventHandler(this.b_loadQuestions_Click);
            // 
            // b_eraseQuestions
            // 
            this.b_eraseQuestions.Enabled = false;
            this.b_eraseQuestions.Location = new System.Drawing.Point(149, 206);
            this.b_eraseQuestions.Name = "b_eraseQuestions";
            this.b_eraseQuestions.Size = new System.Drawing.Size(76, 36);
            this.b_eraseQuestions.TabIndex = 7;
            this.b_eraseQuestions.Text = "Erase Questions";
            this.b_eraseQuestions.UseVisualStyleBackColor = true;
            this.b_eraseQuestions.Click += new System.EventHandler(this.b_eraseQuestions_Click);
            // 
            // cb_category
            // 
            this.cb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_category.Enabled = false;
            this.cb_category.Location = new System.Drawing.Point(71, 88);
            this.cb_category.Name = "cb_category";
            this.cb_category.Size = new System.Drawing.Size(154, 21);
            this.cb_category.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Set:";
            // 
            // cb_set
            // 
            this.cb_set.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_set.FormattingEnabled = true;
            this.cb_set.Location = new System.Drawing.Point(71, 58);
            this.cb_set.Name = "cb_set";
            this.cb_set.Size = new System.Drawing.Size(154, 21);
            this.cb_set.TabIndex = 12;
            this.cb_set.SelectedIndexChanged += new System.EventHandler(this.cb_setChanged);
            // 
            // nud_amount
            // 
            this.nud_amount.Enabled = false;
            this.nud_amount.Location = new System.Drawing.Point(71, 153);
            this.nud_amount.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nud_amount.Name = "nud_amount";
            this.nud_amount.Size = new System.Drawing.Size(154, 20);
            this.nud_amount.TabIndex = 13;
            // 
            // b_LogOut
            // 
            this.b_LogOut.Location = new System.Drawing.Point(246, 17);
            this.b_LogOut.Name = "b_LogOut";
            this.b_LogOut.Size = new System.Drawing.Size(56, 23);
            this.b_LogOut.TabIndex = 14;
            this.b_LogOut.Text = "Log Out";
            this.b_LogOut.UseVisualStyleBackColor = true;
            this.b_LogOut.Click += new System.EventHandler(this.b_LogOut_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "Admin Control Panel";
            // 
            // AdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 271);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.b_LogOut);
            this.Controls.Add(this.nud_amount);
            this.Controls.Add(this.cb_set);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_category);
            this.Controls.Add(this.b_eraseQuestions);
            this.Controls.Add(this.b_loadQuestions);
            this.Controls.Add(this.cb_dificulty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdminMain";
            this.Text = "AdminMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nud_amount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_dificulty;
        private System.Windows.Forms.Button b_loadQuestions;
        private System.Windows.Forms.Button b_eraseQuestions;
        private System.Windows.Forms.ComboBox cb_category;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_set;
        private System.Windows.Forms.NumericUpDown nud_amount;
        private System.Windows.Forms.Button b_LogOut;
        private System.Windows.Forms.Label label5;
    }
}