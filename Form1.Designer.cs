using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace wfsql
{
    partial class DataChanger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataChanger));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.submitButton = new System.Windows.Forms.Button();
            this.saveData = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.areaFrom = new System.Windows.Forms.NumericUpDown();
            this.enabledFilterByArea = new System.Windows.Forms.CheckBox();
            this.enabledFilterByName = new System.Windows.Forms.CheckBox();
            this.areaTo = new System.Windows.Forms.NumericUpDown();
            this.lastName = new System.Windows.Forms.TextBox();
            this.strictSearchByName = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaTo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 76);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(693, 348);
            this.dataGridView1.TabIndex = 0;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.submitButton.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.submitButton.ForeColor = System.Drawing.Color.White;
            this.submitButton.Location = new System.Drawing.Point(441, 514);
            this.submitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(281, 92);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Оновити";
            this.submitButton.UseVisualStyleBackColor = false;
            // 
            // saveData
            // 
            this.saveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveData.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveData.ForeColor = System.Drawing.Color.White;
            this.saveData.Location = new System.Drawing.Point(29, 514);
            this.saveData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveData.Name = "saveData";
            this.saveData.Size = new System.Drawing.Size(281, 92);
            this.saveData.TabIndex = 3;
            this.saveData.Text = "Зберегти";
            this.saveData.UseVisualStyleBackColor = false;
            this.saveData.Click += new System.EventHandler(this.saveData_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CreatePrompt = true;
            this.saveFileDialog1.DefaultExt = "docx";
            this.saveFileDialog1.Filter = "MS Word|*.docx|MS Word 2003|*.doc";
            this.saveFileDialog1.InitialDirectory = "Desktop";
            // 
            // areaFrom
            // 
            this.areaFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.areaFrom.DecimalPlaces = 2;
            this.areaFrom.ForeColor = System.Drawing.Color.White;
            this.areaFrom.Location = new System.Drawing.Point(357, 433);
            this.areaFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.areaFrom.Maximum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            0});
            this.areaFrom.Name = "areaFrom";
            this.areaFrom.Size = new System.Drawing.Size(117, 22);
            this.areaFrom.TabIndex = 4;
            // 
            // enabledFilterByArea
            // 
            this.enabledFilterByArea.AutoSize = true;
            this.enabledFilterByArea.ForeColor = System.Drawing.Color.White;
            this.enabledFilterByArea.Location = new System.Drawing.Point(68, 433);
            this.enabledFilterByArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.enabledFilterByArea.Name = "enabledFilterByArea";
            this.enabledFilterByArea.Size = new System.Drawing.Size(152, 21);
            this.enabledFilterByArea.TabIndex = 5;
            this.enabledFilterByArea.Text = "Фільтр за площею";
            this.enabledFilterByArea.UseVisualStyleBackColor = true;
            // 
            // enabledFilterByName
            // 
            this.enabledFilterByName.AutoSize = true;
            this.enabledFilterByName.ForeColor = System.Drawing.Color.White;
            this.enabledFilterByName.Location = new System.Drawing.Point(68, 465);
            this.enabledFilterByName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.enabledFilterByName.Name = "enabledFilterByName";
            this.enabledFilterByName.Size = new System.Drawing.Size(173, 21);
            this.enabledFilterByName.TabIndex = 6;
            this.enabledFilterByName.Text = "Фильтр за прізвищем";
            this.enabledFilterByName.UseVisualStyleBackColor = true;
            // 
            // areaTo
            // 
            this.areaTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.areaTo.DecimalPlaces = 2;
            this.areaTo.ForeColor = System.Drawing.Color.White;
            this.areaTo.Location = new System.Drawing.Point(565, 432);
            this.areaTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.areaTo.Maximum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            0});
            this.areaTo.Name = "areaTo";
            this.areaTo.Size = new System.Drawing.Size(117, 22);
            this.areaTo.TabIndex = 7;
            // 
            // lastName
            // 
            this.lastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lastName.ForeColor = System.Drawing.Color.White;
            this.lastName.Location = new System.Drawing.Point(565, 462);
            this.lastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(117, 22);
            this.lastName.TabIndex = 8;
            // 
            // strictSearchByName
            // 
            this.strictSearchByName.AutoSize = true;
            this.strictSearchByName.ForeColor = System.Drawing.Color.White;
            this.strictSearchByName.Location = new System.Drawing.Point(357, 465);
            this.strictSearchByName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.strictSearchByName.Name = "strictSearchByName";
            this.strictSearchByName.Size = new System.Drawing.Size(83, 21);
            this.strictSearchByName.TabIndex = 9;
            this.strictSearchByName.Text = "Строгий";
            this.strictSearchByName.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(535, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "до";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(325, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "від";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(688, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "м^2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(480, 438);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "м^2";
            // 
            // DataChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 634);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.strictSearchByName);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.areaTo);
            this.Controls.Add(this.enabledFilterByName);
            this.Controls.Add(this.enabledFilterByArea);
            this.Controls.Add(this.areaFrom);
            this.Controls.Add(this.saveData);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DataChanger";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Data Changer";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button saveData;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.NumericUpDown areaFrom;
        private System.Windows.Forms.CheckBox enabledFilterByArea;
        private System.Windows.Forms.CheckBox enabledFilterByName;
        private System.Windows.Forms.NumericUpDown areaTo;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.CheckBox strictSearchByName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}

