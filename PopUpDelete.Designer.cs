
namespace Form2
{
    partial class Form2
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
            this.label_Question = new System.Windows.Forms.Label();
            this.button_Ja = new System.Windows.Forms.Button();
            this.button_Nej = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label_Question.AutoSize = true;
            this.label_Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Question.Location = new System.Drawing.Point(43, 25);
            this.label_Question.Name = "label_Question";
            this.label_Question.Size = new System.Drawing.Size(190, 16);
            this.label_Question.TabIndex = 0;
            this.label_Question.Text = "Ta bort 99 fall från Databasen?";
            this.label_Question.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button_Ja.Location = new System.Drawing.Point(60, 81);
            this.button_Ja.Name = "button_Ja";
            this.button_Ja.Size = new System.Drawing.Size(44, 23);
            this.button_Ja.TabIndex = 1;
            this.button_Ja.Text = "Ja";
            this.button_Ja.UseVisualStyleBackColor = true;
            this.button_Ja.Click += new System.EventHandler(this.button_Ja_Click);
            // 
            // button2
            // 
            this.button_Nej.Location = new System.Drawing.Point(165, 81);
            this.button_Nej.Name = "button_Nej";
            this.button_Nej.Size = new System.Drawing.Size(44, 23);
            this.button_Nej.TabIndex = 2;
            this.button_Nej.Text = "Nej";
            this.button_Nej.UseVisualStyleBackColor = true;
            this.button_Nej.Click += new System.EventHandler(this.button_Nej_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 124);
            this.Controls.Add(this.button_Nej);
            this.Controls.Add(this.button_Ja);
            this.Controls.Add(this.label_Question);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ta bort?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Question;
        private System.Windows.Forms.Button button_Ja;
        private System.Windows.Forms.Button button_Nej;
    }
}