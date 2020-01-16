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
            this.tb_amount = new System.Windows.Forms.TextBox();
            this.b_loadQuestions = new System.Windows.Forms.Button();
            this.b_eraseQuestions = new System.Windows.Forms.Button();
            this.b_saveQuestions = new System.Windows.Forms.Button();
            this.tabla = new System.Windows.Forms.ListView();
            this.cb_category = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_set = new System.Windows.Forms.ComboBox();
            this.b_addSet = new System.Windows.Forms.Button();
            this.b_deleteSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dificulty:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount:";
            // 
            // cb_dificulty
            // 
            this.cb_dificulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dificulty.FormattingEnabled = true;
            this.cb_dificulty.Location = new System.Drawing.Point(88, 89);
            this.cb_dificulty.Name = "cb_dificulty";
            this.cb_dificulty.Size = new System.Drawing.Size(154, 21);
            this.cb_dificulty.TabIndex = 3;
            // 
            // tb_amount
            // 
            this.tb_amount.Location = new System.Drawing.Point(88, 121);
            this.tb_amount.Name = "tb_amount";
            this.tb_amount.Size = new System.Drawing.Size(154, 20);
            this.tb_amount.TabIndex = 5;
            // 
            // b_loadQuestions
            // 
            this.b_loadQuestions.Location = new System.Drawing.Point(67, 164);
            this.b_loadQuestions.Name = "b_loadQuestions";
            this.b_loadQuestions.Size = new System.Drawing.Size(76, 36);
            this.b_loadQuestions.TabIndex = 6;
            this.b_loadQuestions.Text = "Load Questions";
            this.b_loadQuestions.UseVisualStyleBackColor = true;
            this.b_loadQuestions.Click += new System.EventHandler(this.b_loadQuestions_Click);
            // 
            // b_eraseQuestions
            // 
            this.b_eraseQuestions.Location = new System.Drawing.Point(270, 164);
            this.b_eraseQuestions.Name = "b_eraseQuestions";
            this.b_eraseQuestions.Size = new System.Drawing.Size(76, 36);
            this.b_eraseQuestions.TabIndex = 7;
            this.b_eraseQuestions.Text = "Erase Questions";
            this.b_eraseQuestions.UseVisualStyleBackColor = true;
            this.b_eraseQuestions.Click += new System.EventHandler(this.b_eraseQuestions_Click);
            // 
            // b_saveQuestions
            // 
            this.b_saveQuestions.Location = new System.Drawing.Point(166, 164);
            this.b_saveQuestions.Name = "b_saveQuestions";
            this.b_saveQuestions.Size = new System.Drawing.Size(76, 36);
            this.b_saveQuestions.TabIndex = 8;
            this.b_saveQuestions.Text = "Save Questions";
            this.b_saveQuestions.UseVisualStyleBackColor = true;
            this.b_saveQuestions.Click += new System.EventHandler(this.b_saveQuestions_Click);
            // 
            // tabla
            // 
            this.tabla.HideSelection = false;
            this.tabla.Location = new System.Drawing.Point(384, 57);
            this.tabla.Name = "tabla";
            this.tabla.Size = new System.Drawing.Size(310, 236);
            this.tabla.TabIndex = 9;
            this.tabla.UseCompatibleStateImageBehavior = false;
            // 
            // cb_category
            // 
            this.cb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_category.Location = new System.Drawing.Point(88, 57);
            this.cb_category.Name = "cb_category";
            this.cb_category.Size = new System.Drawing.Size(154, 21);
            this.cb_category.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Set:";
            // 
            // cb_set
            // 
            this.cb_set.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_set.FormattingEnabled = true;
            this.cb_set.Location = new System.Drawing.Point(88, 27);
            this.cb_set.Name = "cb_set";
            this.cb_set.Size = new System.Drawing.Size(154, 21);
            this.cb_set.TabIndex = 12;
            // 
            // b_addSet
            // 
            this.b_addSet.Location = new System.Drawing.Point(372, 25);
            this.b_addSet.Name = "b_addSet";
            this.b_addSet.Size = new System.Drawing.Size(75, 23);
            this.b_addSet.TabIndex = 13;
            this.b_addSet.Text = "Add Set";
            this.b_addSet.UseVisualStyleBackColor = true;
            // 
            // b_deleteSet
            // 
            this.b_deleteSet.Location = new System.Drawing.Point(271, 25);
            this.b_deleteSet.Name = "b_deleteSet";
            this.b_deleteSet.Size = new System.Drawing.Size(75, 23);
            this.b_deleteSet.TabIndex = 14;
            this.b_deleteSet.Text = "Delete Set";
            this.b_deleteSet.UseVisualStyleBackColor = true;
            // 
            // AdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 307);
            this.Controls.Add(this.b_deleteSet);
            this.Controls.Add(this.b_addSet);
            this.Controls.Add(this.cb_set);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_category);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.b_saveQuestions);
            this.Controls.Add(this.b_eraseQuestions);
            this.Controls.Add(this.b_loadQuestions);
            this.Controls.Add(this.tb_amount);
            this.Controls.Add(this.cb_dificulty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdminMain";
            this.Text = "AdminMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_dificulty;
        private System.Windows.Forms.TextBox tb_amount;
        private System.Windows.Forms.Button b_loadQuestions;
        private System.Windows.Forms.Button b_eraseQuestions;
        private System.Windows.Forms.Button b_saveQuestions;
        private System.Windows.Forms.ListView tabla;
        private System.Windows.Forms.ComboBox cb_category;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_set;
        private System.Windows.Forms.Button b_addSet;
        private System.Windows.Forms.Button b_deleteSet;
    }
}