namespace UI
{
    partial class CreateGame
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
            this.nud_amount = new System.Windows.Forms.NumericUpDown();
            this.cb_set = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_category = new System.Windows.Forms.ComboBox();
            this.cb_dificulty = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_amount)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_amount
            // 
            this.nud_amount.Enabled = false;
            this.nud_amount.Location = new System.Drawing.Point(94, 131);
            this.nud_amount.Name = "nud_amount";
            this.nud_amount.Size = new System.Drawing.Size(154, 20);
            this.nud_amount.TabIndex = 21;
            // 
            // cb_set
            // 
            this.cb_set.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_set.FormattingEnabled = true;
            this.cb_set.Location = new System.Drawing.Point(94, 36);
            this.cb_set.Name = "cb_set";
            this.cb_set.Size = new System.Drawing.Size(154, 21);
            this.cb_set.TabIndex = 20;
            this.cb_set.SelectedIndexChanged += new System.EventHandler(this.Cb_set_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Set:";
            // 
            // cb_category
            // 
            this.cb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_category.Enabled = false;
            this.cb_category.Location = new System.Drawing.Point(94, 66);
            this.cb_category.Name = "cb_category";
            this.cb_category.Size = new System.Drawing.Size(154, 21);
            this.cb_category.TabIndex = 18;
            // 
            // cb_dificulty
            // 
            this.cb_dificulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dificulty.Enabled = false;
            this.cb_dificulty.FormattingEnabled = true;
            this.cb_dificulty.Location = new System.Drawing.Point(94, 98);
            this.cb_dificulty.Name = "cb_dificulty";
            this.cb_dificulty.Size = new System.Drawing.Size(154, 21);
            this.cb_dificulty.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Dificulty:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Category:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "New game";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CreateGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 285);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nud_amount);
            this.Controls.Add(this.cb_set);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_category);
            this.Controls.Add(this.cb_dificulty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateGame";
            this.Text = "CreateGame";
            this.Load += new System.EventHandler(this.CreateGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_amount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_amount;
        private System.Windows.Forms.ComboBox cb_set;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_category;
        private System.Windows.Forms.ComboBox cb_dificulty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}