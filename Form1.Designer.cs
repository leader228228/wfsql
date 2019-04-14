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
            this.dataGridView1.Location = new System.Drawing.Point(22, 62);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(520, 283);
            this.dataGridView1.TabIndex = 0;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.submitButton.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.submitButton.ForeColor = System.Drawing.Color.White;
            this.submitButton.Location = new System.Drawing.Point(331, 418);
            this.submitButton.Margin = new System.Windows.Forms.Padding(2);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(211, 75);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Обновить";
            this.submitButton.UseVisualStyleBackColor = false;
            // 
            // saveData
            // 
            this.saveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveData.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveData.ForeColor = System.Drawing.Color.White;
            this.saveData.Location = new System.Drawing.Point(22, 418);
            this.saveData.Margin = new System.Windows.Forms.Padding(2);
            this.saveData.Name = "saveData";
            this.saveData.Size = new System.Drawing.Size(211, 75);
            this.saveData.TabIndex = 3;
            this.saveData.Text = "Сохранить";
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
            this.areaFrom.Location = new System.Drawing.Point(268, 352);
            this.areaFrom.Margin = new System.Windows.Forms.Padding(2);
            this.areaFrom.Maximum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            0});
            this.areaFrom.Name = "areaFrom";
            this.areaFrom.Size = new System.Drawing.Size(88, 20);
            this.areaFrom.TabIndex = 4;
            // 
            // enabledFilterByArea
            // 
            this.enabledFilterByArea.AutoSize = true;
            this.enabledFilterByArea.ForeColor = System.Drawing.Color.White;
            this.enabledFilterByArea.Location = new System.Drawing.Point(51, 352);
            this.enabledFilterByArea.Margin = new System.Windows.Forms.Padding(2);
            this.enabledFilterByArea.Name = "enabledFilterByArea";
            this.enabledFilterByArea.Size = new System.Drawing.Size(125, 17);
            this.enabledFilterByArea.TabIndex = 5;
            this.enabledFilterByArea.Text = "Фильтр по области";
            this.enabledFilterByArea.UseVisualStyleBackColor = true;
            this.enabledFilterByArea.CheckedChanged += new System.EventHandler(this.enabledFilterByArea_CheckedChanged);
            // 
            // enabledFilterByName
            // 
            this.enabledFilterByName.AutoSize = true;
            this.enabledFilterByName.ForeColor = System.Drawing.Color.White;
            this.enabledFilterByName.Location = new System.Drawing.Point(51, 378);
            this.enabledFilterByName.Margin = new System.Windows.Forms.Padding(2);
            this.enabledFilterByName.Name = "enabledFilterByName";
            this.enabledFilterByName.Size = new System.Drawing.Size(116, 17);
            this.enabledFilterByName.TabIndex = 6;
            this.enabledFilterByName.Text = "Фильтр по имени";
            this.enabledFilterByName.UseVisualStyleBackColor = true;
            // 
            // areaTo
            // 
            this.areaTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.areaTo.DecimalPlaces = 2;
            this.areaTo.ForeColor = System.Drawing.Color.White;
            this.areaTo.Location = new System.Drawing.Point(424, 351);
            this.areaTo.Margin = new System.Windows.Forms.Padding(2);
            this.areaTo.Name = "areaTo";
            this.areaTo.Size = new System.Drawing.Size(88, 20);
            this.areaTo.TabIndex = 7;
            // 
            // lastName
            // 
            this.lastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lastName.ForeColor = System.Drawing.Color.White;
            this.lastName.Location = new System.Drawing.Point(424, 375);
            this.lastName.Margin = new System.Windows.Forms.Padding(2);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(89, 20);
            this.lastName.TabIndex = 8;
            // 
            // strictSearchByName
            // 
            this.strictSearchByName.AutoSize = true;
            this.strictSearchByName.ForeColor = System.Drawing.Color.White;
            this.strictSearchByName.Location = new System.Drawing.Point(268, 378);
            this.strictSearchByName.Margin = new System.Windows.Forms.Padding(2);
            this.strictSearchByName.Name = "strictSearchByName";
            this.strictSearchByName.Size = new System.Drawing.Size(67, 17);
            this.strictSearchByName.TabIndex = 9;
            this.strictSearchByName.Text = "Строгий";
            this.strictSearchByName.UseVisualStyleBackColor = true;
            // 
            // DataChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 515);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DataChanger";
            this.Text = "Data Changer";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load_1);
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
    }
}

