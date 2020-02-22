namespace UI
{
    partial class HighScores
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
            this.dgw_HighScores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_HighScores)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(209, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "High Scores";
            // 
            // dgw_HighScores
            // 
            this.dgw_HighScores.AllowUserToAddRows = false;
            this.dgw_HighScores.AllowUserToDeleteRows = false;
            this.dgw_HighScores.AllowUserToResizeColumns = false;
            this.dgw_HighScores.AllowUserToResizeRows = false;
            this.dgw_HighScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_HighScores.Location = new System.Drawing.Point(81, 89);
            this.dgw_HighScores.Name = "dgw_HighScores";
            this.dgw_HighScores.ReadOnly = true;
            this.dgw_HighScores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgw_HighScores.Size = new System.Drawing.Size(485, 304);
            this.dgw_HighScores.StandardTab = true;
            this.dgw_HighScores.TabIndex = 1;
            // 
            // HighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 421);
            this.Controls.Add(this.dgw_HighScores);
            this.Controls.Add(this.label1);
            this.Name = "HighScores";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgw_HighScores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgw_HighScores;
    }
}