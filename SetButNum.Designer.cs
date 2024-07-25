namespace MinesweeperLayoutParser;

partial class SetButNum
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
        numericUpDown1 = new NumericUpDown();
        button1 = new Button();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        SuspendLayout();
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new Point(12, 12);
        numericUpDown1.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
        numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new Size(86, 26);
        numericUpDown1.TabIndex = 1;
        numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
        numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
        // 
        // button1
        // 
        button1.Location = new Point(12, 44);
        button1.Name = "button1";
        button1.Size = new Size(86, 26);
        button1.TabIndex = 2;
        button1.Text = "确认";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // SetButNum
        // 
        AcceptButton = button1;
        AutoScaleDimensions = new SizeF(7F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(111, 79);
        Controls.Add(button1);
        Controls.Add(numericUpDown1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        MaximumSize = new Size(127, 119);
        Name = "SetButNum";
        StartPosition = FormStartPosition.CenterParent;
        Text = "设置该区数字";
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private NumericUpDown numericUpDown1;
    private Button button1;
}