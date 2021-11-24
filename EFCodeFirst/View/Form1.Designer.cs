namespace EFCodeFirst.View
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
            this.dgData = new System.Windows.Forms.DataGridView();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.buttonTables = new System.Windows.Forms.Button();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.buttonTablesId = new System.Windows.Forms.Button();
            this.buttonSportsmanCountry = new System.Windows.Forms.Button();
            this.buttonSportCountry = new System.Windows.Forms.Button();
            this.buttonTopCountry = new System.Windows.Forms.Button();
            this.buttonTopSport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgData
            // 
            this.dgData.Location = new System.Drawing.Point(17, 20);
            this.dgData.Name = "dgData";
            this.dgData.Size = new System.Drawing.Size(444, 335);
            this.dgData.TabIndex = 0;
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Items.AddRange(new object[] {
            "Sportsmen",
            "Sports",
            "Countries"});
            this.comboBoxTables.Location = new System.Drawing.Point(467, 20);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(123, 23);
            this.comboBoxTables.TabIndex = 1;
            // 
            // buttonTables
            // 
            this.buttonTables.Location = new System.Drawing.Point(467, 49);
            this.buttonTables.Name = "buttonTables";
            this.buttonTables.Size = new System.Drawing.Size(123, 23);
            this.buttonTables.TabIndex = 2;
            this.buttonTables.Text = "Info";
            this.buttonTables.UseVisualStyleBackColor = true;
            this.buttonTables.Click += new System.EventHandler(this.buttonTables_Click);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(594, 20);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(102, 23);
            this.textBoxId.TabIndex = 3;
            // 
            // buttonTablesId
            // 
            this.buttonTablesId.Location = new System.Drawing.Point(594, 49);
            this.buttonTablesId.Name = "buttonTablesId";
            this.buttonTablesId.Size = new System.Drawing.Size(102, 23);
            this.buttonTablesId.TabIndex = 4;
            this.buttonTablesId.Text = "Info by id";
            this.buttonTablesId.UseVisualStyleBackColor = true;
            this.buttonTablesId.Click += new System.EventHandler(this.buttonTablesId_Click);
            // 
            // buttonSportsmanCountry
            // 
            this.buttonSportsmanCountry.Location = new System.Drawing.Point(467, 136);
            this.buttonSportsmanCountry.Name = "buttonSportsmanCountry";
            this.buttonSportsmanCountry.Size = new System.Drawing.Size(229, 23);
            this.buttonSportsmanCountry.TabIndex = 5;
            this.buttonSportsmanCountry.Text = "Top sportsmen by countries";
            this.buttonSportsmanCountry.UseVisualStyleBackColor = true;
            this.buttonSportsmanCountry.Click += new System.EventHandler(this.buttonSportsmanCountry_Click);
            // 
            // buttonSportCountry
            // 
            this.buttonSportCountry.Location = new System.Drawing.Point(467, 165);
            this.buttonSportCountry.Name = "buttonSportCountry";
            this.buttonSportCountry.Size = new System.Drawing.Size(229, 23);
            this.buttonSportCountry.TabIndex = 6;
            this.buttonSportCountry.Text = "Top sports by countries";
            this.buttonSportCountry.UseVisualStyleBackColor = true;
            this.buttonSportCountry.Click += new System.EventHandler(this.buttonSportCountry_Click);
            // 
            // buttonTopCountry
            // 
            this.buttonTopCountry.Location = new System.Drawing.Point(467, 78);
            this.buttonTopCountry.Name = "buttonTopCountry";
            this.buttonTopCountry.Size = new System.Drawing.Size(229, 23);
            this.buttonTopCountry.TabIndex = 7;
            this.buttonTopCountry.Text = "Top countries";
            this.buttonTopCountry.UseVisualStyleBackColor = true;
            this.buttonTopCountry.Click += new System.EventHandler(this.buttonTopCountry_Click);
            // 
            // buttonTopSport
            // 
            this.buttonTopSport.Location = new System.Drawing.Point(467, 107);
            this.buttonTopSport.Name = "buttonTopSport";
            this.buttonTopSport.Size = new System.Drawing.Size(229, 23);
            this.buttonTopSport.TabIndex = 8;
            this.buttonTopSport.Text = "Top sports";
            this.buttonTopSport.UseVisualStyleBackColor = true;
            this.buttonTopSport.Click += new System.EventHandler(this.buttonTopSport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 367);
            this.Controls.Add(this.buttonTopSport);
            this.Controls.Add(this.buttonTopCountry);
            this.Controls.Add(this.buttonSportCountry);
            this.Controls.Add(this.buttonSportsmanCountry);
            this.Controls.Add(this.buttonTablesId);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.buttonTables);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.dgData);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgData;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.Button buttonTables;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Button buttonTablesId;
        private System.Windows.Forms.Button buttonSportsmanCountry;
        private System.Windows.Forms.Button buttonSportCountry;
        private System.Windows.Forms.Button buttonTopCountry;
        private System.Windows.Forms.Button buttonTopSport;
    }
}