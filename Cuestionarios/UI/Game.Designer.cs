namespace UI
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.l_numQuestion = new System.Windows.Forms.Label();
            this.l_question = new System.Windows.Forms.Label();
            this.b_quit = new System.Windows.Forms.Button();
            this.b_opt1 = new System.Windows.Forms.Button();
            this.l_username = new System.Windows.Forms.Label();
            this.b_opt2 = new System.Windows.Forms.Button();
            this.b_opt3 = new System.Windows.Forms.Button();
            this.b_opt4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.l_time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(813, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(369, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Trivia Game";
            // 
            // l_numQuestion
            // 
            this.l_numQuestion.AutoSize = true;
            this.l_numQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_numQuestion.Location = new System.Drawing.Point(46, 92);
            this.l_numQuestion.Name = "l_numQuestion";
            this.l_numQuestion.Size = new System.Drawing.Size(112, 20);
            this.l_numQuestion.TabIndex = 3;
            this.l_numQuestion.Text = "Question 1/10:";
            // 
            // l_question
            // 
            this.l_question.AutoSize = true;
            this.l_question.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_question.Location = new System.Drawing.Point(164, 92);
            this.l_question.Name = "l_question";
            this.l_question.Size = new System.Drawing.Size(21, 20);
            this.l_question.TabIndex = 4;
            this.l_question.Text = "...";
            // 
            // b_quit
            // 
            this.b_quit.Location = new System.Drawing.Point(816, 355);
            this.b_quit.Name = "b_quit";
            this.b_quit.Size = new System.Drawing.Size(75, 23);
            this.b_quit.TabIndex = 10;
            this.b_quit.Text = "Quit";
            this.b_quit.UseVisualStyleBackColor = true;
            this.b_quit.Click += new System.EventHandler(this.b_quit_Click);
            // 
            // b_opt1
            // 
            this.b_opt1.Location = new System.Drawing.Point(279, 154);
            this.b_opt1.Name = "b_opt1";
            this.b_opt1.Size = new System.Drawing.Size(348, 38);
            this.b_opt1.TabIndex = 11;
            this.b_opt1.Text = "Option1";
            this.b_opt1.UseVisualStyleBackColor = true;
            this.b_opt1.Click += new System.EventHandler(this.b_opt1_Click);
            // 
            // l_username
            // 
            this.l_username.AutoSize = true;
            this.l_username.Location = new System.Drawing.Point(69, 24);
            this.l_username.Name = "l_username";
            this.l_username.Size = new System.Drawing.Size(22, 13);
            this.l_username.TabIndex = 12;
            this.l_username.Text = ".....";
            // 
            // b_opt2
            // 
            this.b_opt2.Location = new System.Drawing.Point(279, 198);
            this.b_opt2.Name = "b_opt2";
            this.b_opt2.Size = new System.Drawing.Size(348, 38);
            this.b_opt2.TabIndex = 13;
            this.b_opt2.Text = "Option2";
            this.b_opt2.UseVisualStyleBackColor = true;
            this.b_opt2.Click += new System.EventHandler(this.b_opt2_Click);
            // 
            // b_opt3
            // 
            this.b_opt3.Location = new System.Drawing.Point(279, 242);
            this.b_opt3.Name = "b_opt3";
            this.b_opt3.Size = new System.Drawing.Size(348, 38);
            this.b_opt3.TabIndex = 14;
            this.b_opt3.Text = "Option3";
            this.b_opt3.UseVisualStyleBackColor = true;
            this.b_opt3.Click += new System.EventHandler(this.b_opt3_Click);
            // 
            // b_opt4
            // 
            this.b_opt4.Location = new System.Drawing.Point(279, 286);
            this.b_opt4.Name = "b_opt4";
            this.b_opt4.Size = new System.Drawing.Size(348, 38);
            this.b_opt4.TabIndex = 15;
            this.b_opt4.Text = "Option4";
            this.b_opt4.UseVisualStyleBackColor = true;
            this.b_opt4.Click += new System.EventHandler(this.b_opt4_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // l_time
            // 
            this.l_time.AutoSize = true;
            this.l_time.Location = new System.Drawing.Point(842, 24);
            this.l_time.Name = "l_time";
            this.l_time.Size = new System.Drawing.Size(16, 13);
            this.l_time.TabIndex = 16;
            this.l_time.Text = "...";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 390);
            this.Controls.Add(this.l_time);
            this.Controls.Add(this.b_opt4);
            this.Controls.Add(this.b_opt3);
            this.Controls.Add(this.b_opt2);
            this.Controls.Add(this.l_username);
            this.Controls.Add(this.b_opt1);
            this.Controls.Add(this.b_quit);
            this.Controls.Add(this.l_question);
            this.Controls.Add(this.l_numQuestion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game";
            this.Text = "SuperTrivia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label l_numQuestion;
        private System.Windows.Forms.Label l_question;
        private System.Windows.Forms.Button b_quit;
        private System.Windows.Forms.Button b_opt1;
        private System.Windows.Forms.Label l_username;
        private System.Windows.Forms.Button b_opt2;
        private System.Windows.Forms.Button b_opt3;
        private System.Windows.Forms.Button b_opt4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label l_time;
    }
}