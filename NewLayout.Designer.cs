﻿namespace MinesweeperLayoutParser;

partial class NewLayout
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
        button1 = new Button();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        textBox3 = new TextBox();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(12, 102);
        button1.Name = "button1";
        button1.Size = new Size(208, 29);
        button1.TabIndex = 0;
        button1.Text = "确认";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(35, 19);
        label1.TabIndex = 1;
        label1.Text = "宽度";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 41);
        label2.Name = "label2";
        label2.Size = new Size(35, 19);
        label2.TabIndex = 3;
        label2.Text = "高度";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(12, 73);
        label3.Name = "label3";
        label3.Size = new Size(35, 19);
        label3.TabIndex = 5;
        label3.Text = "雷数";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(53, 6);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(167, 26);
        textBox1.TabIndex = 6;
        textBox1.Text = "9";
        // 
        // textBox2
        // 
        textBox2.Location = new Point(53, 41);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(167, 26);
        textBox2.TabIndex = 7;
        textBox2.Text = "9";
        // 
        // textBox3
        // 
        textBox3.Location = new Point(53, 73);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(167, 26);
        textBox3.TabIndex = 8;
        textBox3.Text = "10";
        // 
        // NewLayout
        // 
        AcceptButton = button1;
        AutoScaleDimensions = new SizeF(7F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(231, 140);
        Controls.Add(textBox3);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(button1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "NewLayout";
        StartPosition = FormStartPosition.CenterParent;
        Text = "创建新布局";
        Load += NewLayout_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
}