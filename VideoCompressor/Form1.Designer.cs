
using System;
using System.Windows.Forms;

namespace VideoCompressor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListView = new System.Windows.Forms.ListView();
            this.Button_Execute = new System.Windows.Forms.Button();
            this.GroupBox_Codec = new System.Windows.Forms.GroupBox();
            this.RadioButton_H265 = new System.Windows.Forms.RadioButton();
            this.RadioButton_H264 = new System.Windows.Forms.RadioButton();
            this.Button_AllDelete = new System.Windows.Forms.Button();
            this.Button_Delete = new System.Windows.Forms.Button();
            this.Button_FileSelect = new System.Windows.Forms.Button();
            this.Button_FolderSelect = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.GroupBox_Codec.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListView
            // 
            this.ListView.AllowDrop = true;
            this.ListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView.HideSelection = false;
            this.ListView.Location = new System.Drawing.Point(14, 10);
            this.ListView.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(774, 332);
            this.ListView.TabIndex = 0;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_DragDrop);
            this.ListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_DragEnter);
            // 
            // Button_Execute
            // 
            this.Button_Execute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Execute.Location = new System.Drawing.Point(711, 415);
            this.Button_Execute.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.Button_Execute.Name = "Button_Execute";
            this.Button_Execute.Size = new System.Drawing.Size(77, 25);
            this.Button_Execute.TabIndex = 1;
            this.Button_Execute.Text = "実行";
            this.Button_Execute.UseVisualStyleBackColor = true;
            this.Button_Execute.Click += new System.EventHandler(this.Button_Execute_Click);
            // 
            // GroupBox_Codec
            // 
            this.GroupBox_Codec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupBox_Codec.Controls.Add(this.RadioButton_H265);
            this.GroupBox_Codec.Controls.Add(this.RadioButton_H264);
            this.GroupBox_Codec.Location = new System.Drawing.Point(14, 385);
            this.GroupBox_Codec.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.GroupBox_Codec.Name = "GroupBox_Codec";
            this.GroupBox_Codec.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.GroupBox_Codec.Size = new System.Drawing.Size(273, 55);
            this.GroupBox_Codec.TabIndex = 2;
            this.GroupBox_Codec.TabStop = false;
            this.GroupBox_Codec.Tag = "";
            this.GroupBox_Codec.Text = "コーデック";
            // 
            // RadioButton_H265
            // 
            this.RadioButton_H265.AutoSize = true;
            this.RadioButton_H265.Checked = true;
            this.RadioButton_H265.Location = new System.Drawing.Point(154, 25);
            this.RadioButton_H265.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.RadioButton_H265.Name = "RadioButton_H265";
            this.RadioButton_H265.Size = new System.Drawing.Size(95, 19);
            this.RadioButton_H265.TabIndex = 1;
            this.RadioButton_H265.TabStop = true;
            this.RadioButton_H265.Tag = "H265";
            this.RadioButton_H265.Text = "H.265 / HEVC";
            this.RadioButton_H265.UseVisualStyleBackColor = true;
            // 
            // RadioButton_H264
            // 
            this.RadioButton_H264.AutoSize = true;
            this.RadioButton_H264.Location = new System.Drawing.Point(21, 25);
            this.RadioButton_H264.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.RadioButton_H264.Name = "RadioButton_H264";
            this.RadioButton_H264.Size = new System.Drawing.Size(88, 19);
            this.RadioButton_H264.TabIndex = 0;
            this.RadioButton_H264.Tag = "H264";
            this.RadioButton_H264.Text = "H.264 / AVC";
            this.RadioButton_H264.UseVisualStyleBackColor = true;
            // 
            // Button_AllDelete
            // 
            this.Button_AllDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Button_AllDelete.Location = new System.Drawing.Point(488, 415);
            this.Button_AllDelete.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.Button_AllDelete.Name = "Button_AllDelete";
            this.Button_AllDelete.Size = new System.Drawing.Size(77, 25);
            this.Button_AllDelete.TabIndex = 3;
            this.Button_AllDelete.Text = "全削除";
            this.Button_AllDelete.UseVisualStyleBackColor = true;
            this.Button_AllDelete.Click += new System.EventHandler(this.Button_AllDelete_Click);
            // 
            // Button_Delete
            // 
            this.Button_Delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Button_Delete.Location = new System.Drawing.Point(574, 415);
            this.Button_Delete.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(77, 25);
            this.Button_Delete.TabIndex = 4;
            this.Button_Delete.Text = "削除";
            this.Button_Delete.UseVisualStyleBackColor = true;
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // Button_FileSelect
            // 
            this.Button_FileSelect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Button_FileSelect.Location = new System.Drawing.Point(401, 415);
            this.Button_FileSelect.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.Button_FileSelect.Name = "Button_FileSelect";
            this.Button_FileSelect.Size = new System.Drawing.Size(77, 25);
            this.Button_FileSelect.TabIndex = 5;
            this.Button_FileSelect.Text = "ファイル選択";
            this.Button_FileSelect.UseVisualStyleBackColor = true;
            this.Button_FileSelect.Click += new System.EventHandler(this.Button_FileSelect_Click);
            // 
            // Button_FolderSelect
            // 
            this.Button_FolderSelect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Button_FolderSelect.Location = new System.Drawing.Point(313, 415);
            this.Button_FolderSelect.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.Button_FolderSelect.Name = "Button_FolderSelect";
            this.Button_FolderSelect.Size = new System.Drawing.Size(77, 25);
            this.Button_FolderSelect.TabIndex = 6;
            this.Button_FolderSelect.Text = "フォルダ選択";
            this.Button_FolderSelect.UseVisualStyleBackColor = true;
            this.Button_FolderSelect.Click += new System.EventHandler(this.Button_FolderSelect_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(14, 354);
            this.ProgressBar.MarqueeAnimationSpeed = 10;
            this.ProgressBar.Maximum = 1000;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(774, 23);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.TabIndex = 7;
            this.ProgressBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.Button_FolderSelect);
            this.Controls.Add(this.Button_FileSelect);
            this.Controls.Add(this.Button_Delete);
            this.Controls.Add(this.Button_AllDelete);
            this.Controls.Add(this.GroupBox_Codec);
            this.Controls.Add(this.Button_Execute);
            this.Controls.Add(this.ListView);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Video Compressor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox_Codec.ResumeLayout(false);
            this.GroupBox_Codec.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListView;
        private Button Button_Execute;
        private GroupBox GroupBox_Codec;
        private RadioButton RadioButton_H265;
        private RadioButton RadioButton_H264;
        private Button Button_AllDelete;
        private Button Button_Delete;
        private Button Button_FileSelect;
        private Button Button_FolderSelect;
        private ProgressBar ProgressBar;
    }
}

