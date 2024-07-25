namespace MinesweeperLayoutParser;

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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        toolStrip1 = new ToolStrip();
        toolStripLabel3 = new ToolStripLabel();
        toolStripLabel2 = new ToolStripLabel();
        toolStripLabel1 = new ToolStripLabel();
        toolStripButton1 = new ToolStripButton();
        toolStripButton2 = new ToolStripButton();
        toolStripButton3 = new ToolStripButton();
        panel1 = new Panel();
        button1 = new Button();
        toolStrip1.SuspendLayout();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // toolStrip1
        // 
        toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel3, toolStripLabel2, toolStripLabel1, toolStripButton1, toolStripButton2, toolStripButton3 });
        toolStrip1.Location = new Point(0, 0);
        toolStrip1.Name = "toolStrip1";
        toolStrip1.Size = new Size(800, 26);
        toolStrip1.TabIndex = 0;
        toolStrip1.Text = "toolStrip1";
        // 
        // toolStripLabel3
        // 
        toolStripLabel3.Alignment = ToolStripItemAlignment.Right;
        toolStripLabel3.Name = "toolStripLabel3";
        toolStripLabel3.Size = new Size(113, 23);
        toolStripLabel3.Text = "扫雷分析工具 v1.0";
        // 
        // toolStripLabel2
        // 
        toolStripLabel2.Alignment = ToolStripItemAlignment.Right;
        toolStripLabel2.Name = "toolStripLabel2";
        toolStripLabel2.Size = new Size(61, 23);
        toolStripLabel2.Text = "布局尺寸";
        // 
        // toolStripLabel1
        // 
        toolStripLabel1.Alignment = ToolStripItemAlignment.Right;
        toolStripLabel1.Name = "toolStripLabel1";
        toolStripLabel1.Size = new Size(35, 23);
        toolStripLabel1.Text = "雷数";
        // 
        // toolStripButton1
        // 
        toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
        toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
        toolStripButton1.ImageTransparentColor = Color.Magenta;
        toolStripButton1.Name = "toolStripButton1";
        toolStripButton1.Size = new Size(65, 23);
        toolStripButton1.Text = "新建布局";
        toolStripButton1.Click += toolStripButton1_Click;
        // 
        // toolStripButton2
        // 
        toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
        toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
        toolStripButton2.ImageTransparentColor = Color.Magenta;
        toolStripButton2.Name = "toolStripButton2";
        toolStripButton2.Size = new Size(65, 23);
        toolStripButton2.Text = "开始分析";
        toolStripButton2.Click += toolStripButton2_Click;
        // 
        // toolStripButton3
        // 
        toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
        toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
        toolStripButton3.ImageTransparentColor = Color.Magenta;
        toolStripButton3.Name = "toolStripButton3";
        toolStripButton3.Size = new Size(96, 23);
        toolStripButton3.Text = "显示/隐藏空白";
        toolStripButton3.Click += toolStripButton3_Click;
        // 
        // panel1
        // 
        panel1.AutoScroll = true;
        panel1.AutoSize = true;
        panel1.Controls.Add(button1);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(0, 26);
        panel1.Name = "panel1";
        panel1.Size = new Size(800, 424);
        panel1.TabIndex = 1;
        // 
        // button1
        // 
        button1.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        button1.Location = new Point(0, 0);
        button1.MinimumSize = new Size(32, 32);
        button1.Name = "button1";
        button1.Size = new Size(48, 48);
        button1.TabIndex = 0;
        button1.Text = "?";
        button1.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        AutoSize = true;
        ClientSize = new Size(800, 450);
        Controls.Add(panel1);
        Controls.Add(toolStrip1);
        Name = "Form1";
        Text = "扫雷分析工具 v1.0 by 茶红落叶";
        toolStrip1.ResumeLayout(false);
        toolStrip1.PerformLayout();
        panel1.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ToolStrip toolStrip1;
    private ToolStripLabel toolStripLabel1;
    private ToolStripLabel toolStripLabel2;
    private ToolStripLabel toolStripLabel3;
    private ToolStripButton toolStripButton1;
    private ToolStripButton toolStripButton2;
    private Panel panel1;
    private Button button1;
    private ToolStripButton toolStripButton3;
}
