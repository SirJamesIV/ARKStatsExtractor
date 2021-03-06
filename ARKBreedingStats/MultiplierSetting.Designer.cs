﻿namespace ARKBreedingStats
{
    partial class MultiplierSetting
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownWildLevel = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTameMult = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTameAdd = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDomLevel = new System.Windows.Forms.NumericUpDown();
            this.labelStatName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWildLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTameMult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTameAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDomLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownWildLevel
            // 
            this.numericUpDownWildLevel.DecimalPlaces = 2;
            this.numericUpDownWildLevel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownWildLevel.Location = new System.Drawing.Point(185, 3);
            this.numericUpDownWildLevel.Name = "numericUpDownWildLevel";
            this.numericUpDownWildLevel.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownWildLevel.TabIndex = 2;
            this.numericUpDownWildLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWildLevel.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // numericUpDownTameMult
            // 
            this.numericUpDownTameMult.DecimalPlaces = 2;
            this.numericUpDownTameMult.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTameMult.Location = new System.Drawing.Point(125, 3);
            this.numericUpDownTameMult.Name = "numericUpDownTameMult";
            this.numericUpDownTameMult.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownTameMult.TabIndex = 1;
            this.numericUpDownTameMult.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTameMult.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // numericUpDownTameAdd
            // 
            this.numericUpDownTameAdd.DecimalPlaces = 2;
            this.numericUpDownTameAdd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTameAdd.Location = new System.Drawing.Point(65, 3);
            this.numericUpDownTameAdd.Name = "numericUpDownTameAdd";
            this.numericUpDownTameAdd.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownTameAdd.TabIndex = 0;
            this.numericUpDownTameAdd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTameAdd.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // numericUpDownDomLevel
            // 
            this.numericUpDownDomLevel.DecimalPlaces = 2;
            this.numericUpDownDomLevel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownDomLevel.Location = new System.Drawing.Point(245, 3);
            this.numericUpDownDomLevel.Name = "numericUpDownDomLevel";
            this.numericUpDownDomLevel.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownDomLevel.TabIndex = 3;
            this.numericUpDownDomLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDomLevel.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // labelStatName
            // 
            this.labelStatName.AutoSize = true;
            this.labelStatName.Location = new System.Drawing.Point(3, 5);
            this.labelStatName.Name = "labelStatName";
            this.labelStatName.Size = new System.Drawing.Size(26, 13);
            this.labelStatName.TabIndex = 4;
            this.labelStatName.Text = "Stat";
            // 
            // MultiplierSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelStatName);
            this.Controls.Add(this.numericUpDownWildLevel);
            this.Controls.Add(this.numericUpDownDomLevel);
            this.Controls.Add(this.numericUpDownTameMult);
            this.Controls.Add(this.numericUpDownTameAdd);
            this.Name = "MultiplierSetting";
            this.Size = new System.Drawing.Size(302, 26);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWildLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTameMult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTameAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDomLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownWildLevel;
        private System.Windows.Forms.NumericUpDown numericUpDownTameMult;
        private System.Windows.Forms.NumericUpDown numericUpDownTameAdd;
        private System.Windows.Forms.NumericUpDown numericUpDownDomLevel;
        private System.Windows.Forms.Label labelStatName;
    }
}
