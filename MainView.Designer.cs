
namespace Form
{
    partial class MainView
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
			this.listView_QueryResult = new System.Windows.Forms.ListView();
			this.button_Sök = new System.Windows.Forms.Button();
			this.label_Kategori = new System.Windows.Forms.Label();
			this.label_Subkategori = new System.Windows.Forms.Label();
			this.comboBox_Kategori = new System.Windows.Forms.ComboBox();
			this.comboBox_SubKategori = new System.Windows.Forms.ComboBox();
			this.label_AriaUser = new System.Windows.Forms.Label();
			this.textBox_AriaUser = new System.Windows.Forms.TextBox();
			this.textBox_Kommentar = new System.Windows.Forms.TextBox();
			this.label_Kommentar = new System.Windows.Forms.Label();
			this.button_Hämta_PatId = new System.Windows.Forms.Button();
			this.label_PatientId = new System.Windows.Forms.Label();
			this.button_TaBort = new System.Windows.Forms.Button();
			this.button_AriaJag = new System.Windows.Forms.Button();
			this.button_Reset_Filter = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listView_QueryResult
			// 
			this.listView_QueryResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listView_QueryResult.FullRowSelect = true;
			this.listView_QueryResult.Location = new System.Drawing.Point(35, 92);
			this.listView_QueryResult.Name = "listView_QueryResult";
			this.listView_QueryResult.Size = new System.Drawing.Size(1200, 775);
			this.listView_QueryResult.TabIndex = 0;
			this.listView_QueryResult.UseCompatibleStateImageBehavior = false;
			this.listView_QueryResult.View = System.Windows.Forms.View.Details;
			this.listView_QueryResult.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_QueryResult_ColumnClick);
			this.listView_QueryResult.SelectedIndexChanged += new System.EventHandler(this.listView_QueryResult_SelectedIndexChanged);
			// 
			// button_Sök
			// 
			this.button_Sök.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_Sök.Location = new System.Drawing.Point(940, 15);
			this.button_Sök.Name = "button_Sök";
			this.button_Sök.Size = new System.Drawing.Size(139, 52);
			this.button_Sök.TabIndex = 1;
			this.button_Sök.Text = "Sök";
			this.button_Sök.UseVisualStyleBackColor = true;
			this.button_Sök.Click += new System.EventHandler(this.button_Sök_Click);
			// 
			// label_Kategori
			// 
			this.label_Kategori.AutoSize = true;
			this.label_Kategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Kategori.Location = new System.Drawing.Point(35, 16);
			this.label_Kategori.Name = "label_Kategori";
			this.label_Kategori.Size = new System.Drawing.Size(61, 16);
			this.label_Kategori.TabIndex = 3;
			this.label_Kategori.Text = "Kategori:";
			// 
			// label_Subkategori
			// 
			this.label_Subkategori.AutoSize = true;
			this.label_Subkategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Subkategori.Location = new System.Drawing.Point(270, 16);
			this.label_Subkategori.Name = "label_Subkategori";
			this.label_Subkategori.Size = new System.Drawing.Size(88, 16);
			this.label_Subkategori.TabIndex = 4;
			this.label_Subkategori.Text = "Sub-kategori:";
			// 
			// comboBox_Kategori
			// 
			this.comboBox_Kategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Kategori.FormattingEnabled = true;
			this.comboBox_Kategori.Location = new System.Drawing.Point(102, 16);
			this.comboBox_Kategori.Name = "comboBox_Kategori";
			this.comboBox_Kategori.Size = new System.Drawing.Size(121, 21);
			this.comboBox_Kategori.TabIndex = 5;
			// 
			// comboBox_SubKategori
			// 
			this.comboBox_SubKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_SubKategori.FormattingEnabled = true;
			this.comboBox_SubKategori.Location = new System.Drawing.Point(364, 15);
			this.comboBox_SubKategori.Name = "comboBox_SubKategori";
			this.comboBox_SubKategori.Size = new System.Drawing.Size(121, 21);
			this.comboBox_SubKategori.TabIndex = 6;
			// 
			// label_AriaUser
			// 
			this.label_AriaUser.AutoSize = true;
			this.label_AriaUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_AriaUser.Location = new System.Drawing.Point(554, 16);
			this.label_AriaUser.Name = "label_AriaUser";
			this.label_AriaUser.Size = new System.Drawing.Size(67, 16);
			this.label_AriaUser.TabIndex = 7;
			this.label_AriaUser.Text = "Aria User:";
			// 
			// textBox_AriaUser
			// 
			this.textBox_AriaUser.Location = new System.Drawing.Point(627, 15);
			this.textBox_AriaUser.Name = "textBox_AriaUser";
			this.textBox_AriaUser.Size = new System.Drawing.Size(100, 20);
			this.textBox_AriaUser.TabIndex = 8;
			// 
			// textBox_Kommentar
			// 
			this.textBox_Kommentar.Location = new System.Drawing.Point(181, 55);
			this.textBox_Kommentar.Name = "textBox_Kommentar";
			this.textBox_Kommentar.Size = new System.Drawing.Size(304, 20);
			this.textBox_Kommentar.TabIndex = 9;
			// 
			// label_Kommentar
			// 
			this.label_Kommentar.AutoSize = true;
			this.label_Kommentar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Kommentar.Location = new System.Drawing.Point(35, 56);
			this.label_Kommentar.Name = "label_Kommentar";
			this.label_Kommentar.Size = new System.Drawing.Size(140, 16);
			this.label_Kommentar.TabIndex = 10;
			this.label_Kommentar.Text = "Keyword i Kommentar:";
			// 
			// button_Hämta_PatId
			// 
			this.button_Hämta_PatId.Enabled = false;
			this.button_Hämta_PatId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_Hämta_PatId.Location = new System.Drawing.Point(1097, 16);
			this.button_Hämta_PatId.Name = "button_Hämta_PatId";
			this.button_Hämta_PatId.Size = new System.Drawing.Size(139, 52);
			this.button_Hämta_PatId.TabIndex = 11;
			this.button_Hämta_PatId.Text = "Få Patient ID";
			this.button_Hämta_PatId.UseVisualStyleBackColor = true;
			this.button_Hämta_PatId.Click += new System.EventHandler(this.button_Hämta_Click);
			// 
			// label_PatientId
			// 
			this.label_PatientId.AutoSize = true;
			this.label_PatientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_PatientId.Location = new System.Drawing.Point(32, 884);
			this.label_PatientId.Name = "label_PatientId";
			this.label_PatientId.Size = new System.Drawing.Size(0, 16);
			this.label_PatientId.TabIndex = 12;
			// 
			// button_TaBort
			// 
			this.button_TaBort.Enabled = false;
			this.button_TaBort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_TaBort.Location = new System.Drawing.Point(1077, 881);
			this.button_TaBort.Name = "button_TaBort";
			this.button_TaBort.Size = new System.Drawing.Size(158, 23);
			this.button_TaBort.TabIndex = 13;
			this.button_TaBort.Text = "Ta bort från Databasen";
			this.button_TaBort.UseVisualStyleBackColor = true;
			this.button_TaBort.Click += new System.EventHandler(this.button_TaBort_Click);
			// 
			// button_AriaJag
			// 
			this.button_AriaJag.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button_AriaJag.Location = new System.Drawing.Point(745, 14);
			this.button_AriaJag.Name = "button_AriaJag";
			this.button_AriaJag.Size = new System.Drawing.Size(39, 23);
			this.button_AriaJag.TabIndex = 14;
			this.button_AriaJag.Text = "Jag";
			this.button_AriaJag.UseVisualStyleBackColor = true;
			this.button_AriaJag.Click += new System.EventHandler(this.button_AriaJag_Click);
			// 
			// button_Reset_Filter
			// 
			this.button_Reset_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_Reset_Filter.Location = new System.Drawing.Point(557, 52);
			this.button_Reset_Filter.Name = "button_Reset_Filter";
			this.button_Reset_Filter.Size = new System.Drawing.Size(117, 23);
			this.button_Reset_Filter.TabIndex = 15;
			this.button_Reset_Filter.Text = "Återställ filter";
			this.button_Reset_Filter.UseVisualStyleBackColor = true;
			this.button_Reset_Filter.Click += new System.EventHandler(this.button_Återställ_Click);
			// 
			// MainView
			// 
			this.AcceptButton = this.button_Sök;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 923);
			this.Controls.Add(this.button_Reset_Filter);
			this.Controls.Add(this.button_AriaJag);
			this.Controls.Add(this.button_TaBort);
			this.Controls.Add(this.label_PatientId);
			this.Controls.Add(this.button_Hämta_PatId);
			this.Controls.Add(this.textBox_Kommentar);
			this.Controls.Add(this.label_Kommentar);
			this.Controls.Add(this.textBox_AriaUser);
			this.Controls.Add(this.label_AriaUser);
			this.Controls.Add(this.comboBox_SubKategori);
			this.Controls.Add(this.comboBox_Kategori);
			this.Controls.Add(this.label_Subkategori);
			this.Controls.Add(this.label_Kategori);
			this.Controls.Add(this.button_Sök);
			this.Controls.Add(this.listView_QueryResult);
			this.Name = "MainView";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Hämta fall från databas";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_QueryResult;
        private System.Windows.Forms.Button button_Sök;
        private System.Windows.Forms.Label label_Kategori;
        private System.Windows.Forms.Label label_Subkategori;
        private System.Windows.Forms.ComboBox comboBox_Kategori;
        private System.Windows.Forms.ComboBox comboBox_SubKategori;
        private System.Windows.Forms.Label label_AriaUser;
        private System.Windows.Forms.TextBox textBox_Kommentar;
        private System.Windows.Forms.Label label_Kommentar;
        private System.Windows.Forms.Button button_Hämta_PatId;
        private System.Windows.Forms.Label label_PatientId;
        private System.Windows.Forms.Button button_TaBort;
        private System.Windows.Forms.TextBox textBox_AriaUser;
        private System.Windows.Forms.Button button_AriaJag;
        private System.Windows.Forms.Button button_Reset_Filter;
    }
}