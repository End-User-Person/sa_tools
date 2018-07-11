﻿namespace SonicRetro.SAModel.SAEditorCommon
{
    partial class ManualBuildWindow
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
            this.assemblyItemTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.IniExportButton = new System.Windows.Forms.Button();
            this.CPPExportButton = new System.Windows.Forms.Button();
            this.CheckAllButton = new System.Windows.Forms.Button();
            this.UncheckAllButton = new System.Windows.Forms.Button();
            this.CheckModifiedButton = new System.Windows.Forms.Button();
            this.assemblyItemTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // assemblyItemTabs
            // 
            this.assemblyItemTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.assemblyItemTabs.Controls.Add(this.tabPage1);
            this.assemblyItemTabs.Location = new System.Drawing.Point(12, 12);
            this.assemblyItemTabs.Name = "assemblyItemTabs";
            this.assemblyItemTabs.SelectedIndex = 0;
            this.assemblyItemTabs.Size = new System.Drawing.Size(776, 368);
            this.assemblyItemTabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 342);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // IniExportButton
            // 
            this.IniExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.IniExportButton.Location = new System.Drawing.Point(462, 415);
            this.IniExportButton.Name = "IniExportButton";
            this.IniExportButton.Size = new System.Drawing.Size(152, 23);
            this.IniExportButton.TabIndex = 1;
            this.IniExportButton.Text = "ExportINI";
            this.IniExportButton.UseVisualStyleBackColor = true;
            this.IniExportButton.Click += new System.EventHandler(this.IniExportButton_Click);
            // 
            // CPPExportButton
            // 
            this.CPPExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CPPExportButton.Location = new System.Drawing.Point(636, 415);
            this.CPPExportButton.Name = "CPPExportButton";
            this.CPPExportButton.Size = new System.Drawing.Size(152, 23);
            this.CPPExportButton.TabIndex = 2;
            this.CPPExportButton.Text = "Export C++";
            this.CPPExportButton.UseVisualStyleBackColor = true;
            this.CPPExportButton.Click += new System.EventHandler(this.CPPExportButton_Click);
            // 
            // CheckAllButton
            // 
            this.CheckAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckAllButton.Location = new System.Drawing.Point(12, 386);
            this.CheckAllButton.Name = "CheckAllButton";
            this.CheckAllButton.Size = new System.Drawing.Size(115, 23);
            this.CheckAllButton.TabIndex = 3;
            this.CheckAllButton.Text = "Check All This Tab";
            this.CheckAllButton.UseVisualStyleBackColor = true;
            this.CheckAllButton.Click += new System.EventHandler(this.CheckAllButton_Click);
            // 
            // UncheckAllButton
            // 
            this.UncheckAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UncheckAllButton.Location = new System.Drawing.Point(133, 386);
            this.UncheckAllButton.Name = "UncheckAllButton";
            this.UncheckAllButton.Size = new System.Drawing.Size(127, 23);
            this.UncheckAllButton.TabIndex = 4;
            this.UncheckAllButton.Text = "Uncheck All This Tab";
            this.UncheckAllButton.UseVisualStyleBackColor = true;
            this.UncheckAllButton.Click += new System.EventHandler(this.UncheckAllButton_Click);
            // 
            // CheckModifiedButton
            // 
            this.CheckModifiedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckModifiedButton.Location = new System.Drawing.Point(266, 386);
            this.CheckModifiedButton.Name = "CheckModifiedButton";
            this.CheckModifiedButton.Size = new System.Drawing.Size(147, 23);
            this.CheckModifiedButton.TabIndex = 5;
            this.CheckModifiedButton.Text = "Check Modified This Tab";
            this.CheckModifiedButton.UseVisualStyleBackColor = true;
            this.CheckModifiedButton.Click += new System.EventHandler(this.CheckModifiedButton_Click);
            // 
            // ManualBuildWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CheckModifiedButton);
            this.Controls.Add(this.UncheckAllButton);
            this.Controls.Add(this.CheckAllButton);
            this.Controls.Add(this.CPPExportButton);
            this.Controls.Add(this.IniExportButton);
            this.Controls.Add(this.assemblyItemTabs);
            this.Name = "ManualBuildWindow";
            this.Text = "ManualBuildWindow";
            this.assemblyItemTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl assemblyItemTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button IniExportButton;
        private System.Windows.Forms.Button CPPExportButton;
        private System.Windows.Forms.Button CheckAllButton;
        private System.Windows.Forms.Button UncheckAllButton;
        private System.Windows.Forms.Button CheckModifiedButton;
    }
}