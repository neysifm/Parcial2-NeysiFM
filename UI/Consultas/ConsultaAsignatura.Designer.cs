namespace Parcial2_NeysiFM.UI.Consultas
{
    partial class ConsultaAsignatura
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
            this.CriteriometroTextBox = new MetroFramework.Controls.MetroTextBox();
            this.FiltrometroComboBox = new MetroFramework.Controls.MetroComboBox();
            this.BuscarmetroButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.ConsultadataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CriteriometroTextBox
            // 
            // 
            // 
            // 
            this.CriteriometroTextBox.CustomButton.Image = null;
            this.CriteriometroTextBox.CustomButton.Location = new System.Drawing.Point(214, 1);
            this.CriteriometroTextBox.CustomButton.Name = "";
            this.CriteriometroTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CriteriometroTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CriteriometroTextBox.CustomButton.TabIndex = 1;
            this.CriteriometroTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CriteriometroTextBox.CustomButton.UseSelectable = true;
            this.CriteriometroTextBox.CustomButton.Visible = false;
            this.CriteriometroTextBox.Lines = new string[0];
            this.CriteriometroTextBox.Location = new System.Drawing.Point(422, 73);
            this.CriteriometroTextBox.MaxLength = 32767;
            this.CriteriometroTextBox.Name = "CriteriometroTextBox";
            this.CriteriometroTextBox.PasswordChar = '\0';
            this.CriteriometroTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CriteriometroTextBox.SelectedText = "";
            this.CriteriometroTextBox.SelectionLength = 0;
            this.CriteriometroTextBox.SelectionStart = 0;
            this.CriteriometroTextBox.ShortcutsEnabled = true;
            this.CriteriometroTextBox.Size = new System.Drawing.Size(236, 23);
            this.CriteriometroTextBox.TabIndex = 19;
            this.CriteriometroTextBox.UseSelectable = true;
            this.CriteriometroTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CriteriometroTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // FiltrometroComboBox
            // 
            this.FiltrometroComboBox.FormattingEnabled = true;
            this.FiltrometroComboBox.ItemHeight = 23;
            this.FiltrometroComboBox.Items.AddRange(new object[] {
            "Todos Los Registros",
            "Por ID",
            "Por Descripcion"});
            this.FiltrometroComboBox.Location = new System.Drawing.Point(115, 67);
            this.FiltrometroComboBox.Name = "FiltrometroComboBox";
            this.FiltrometroComboBox.Size = new System.Drawing.Size(215, 29);
            this.FiltrometroComboBox.TabIndex = 18;
            this.FiltrometroComboBox.UseSelectable = true;
            // 
            // BuscarmetroButton
            // 
            this.BuscarmetroButton.Location = new System.Drawing.Point(664, 73);
            this.BuscarmetroButton.Name = "BuscarmetroButton";
            this.BuscarmetroButton.Size = new System.Drawing.Size(75, 23);
            this.BuscarmetroButton.TabIndex = 17;
            this.BuscarmetroButton.Text = "Buscar";
            this.BuscarmetroButton.UseSelectable = true;
            this.BuscarmetroButton.Click += new System.EventHandler(this.BuscarmetroButton_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(360, 77);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(56, 19);
            this.metroLabel4.TabIndex = 14;
            this.metroLabel4.Text = "Criterio:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(67, 77);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(42, 19);
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "Filtro:";
            // 
            // ConsultadataGridView
            // 
            this.ConsultadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsultadataGridView.Location = new System.Drawing.Point(67, 114);
            this.ConsultadataGridView.Name = "ConsultadataGridView";
            this.ConsultadataGridView.Size = new System.Drawing.Size(672, 367);
            this.ConsultadataGridView.TabIndex = 10;
            // 
            // ConsultaAsignatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 507);
            this.Controls.Add(this.CriteriometroTextBox);
            this.Controls.Add(this.FiltrometroComboBox);
            this.Controls.Add(this.BuscarmetroButton);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.ConsultadataGridView);
            this.Name = "ConsultaAsignatura";
            this.Text = "Consulta Asignaturas";
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox CriteriometroTextBox;
        private MetroFramework.Controls.MetroComboBox FiltrometroComboBox;
        private MetroFramework.Controls.MetroButton BuscarmetroButton;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DataGridView ConsultadataGridView;
    }
}