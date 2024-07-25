using System.Collections;
namespace MinesweeperLayoutParser;

public partial class Form1 : Form
{
    NewLayout newLayout = new();
    MineParser mineParser = new(13, 10, 18);
    bool isHideBlank = false;
    public Form1()
    {
        InitializeComponent();
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        // 先传给它
        newLayout.width = mineParser.width;
        newLayout.height = mineParser.height;
        newLayout.mines = mineParser.mines;

        // 打开对话框
        newLayout.ShowDialog();

        // 调整数据
        mineParser.width = newLayout.width;
        mineParser.height = newLayout.height;
        mineParser.mines = newLayout.mines;
        mineParser.verify_mines = 0;
        mineParser.newGeneratedGrid(panel1);
        mineParser.SetMineMessage(toolStripLabel1, toolStripLabel2);
        mineParser.UpdateMineMessage();
    }

    public class MineParser
    {
        public int width;
        public int height;
        public int mines;
        public int butSize = 48;
        public int verify_mines = 0;
        public List<Button> Buttons = new();

        public ToolStripLabel MineNum = new();
        public ToolStripLabel LayerSize = new();


        public MineParser(int width, int height, int mines)
        {
            this.width = width;
            this.height = height;
            this.mines = mines;
        }
        public void newGeneratedGrid(Panel panel)
        {
            panel.Controls.Clear();
            Buttons.Clear();

            for (var h = 0; h < height; h++)
            {
                for (var w = 0; w < width; w++)
                {
                    // 初始化按钮

                    Button button = new Button();

                    button.Size = new Size(butSize, butSize);
                    button.Location = new Point(w * butSize, h * butSize);
                    button.Tag = $"{Buttons.Count}";
                    button.Text = "-";

                    // 互动处理

                    button.Click += (sender, e) =>
                    {
                        button.Text = string.Empty;
                    };

                    button.KeyPress += (sender, e) =>
                    {
                        if (char.IsDigit(e.KeyChar) && e.KeyChar >= '1' && e.KeyChar <= '9')
                        {
                            button.Text = e.KeyChar.ToString();
                        }
                        else
                        {
                            button.ForeColor = Color.Black;
                            button.Text = "-";
                        }
                    };

                    // 右键菜单

                    var cms = new ContextMenuStrip();
                    var 设置数字mi = new ToolStripMenuItem();
                    var 设置为雷mi = new ToolStripMenuItem();

                    设置数字mi.Text = "设置数字";
                    设置为雷mi.Text = "设置为雷";
                    设置数字mi.Click += (sender, e) =>
                    {
                        var w = new SetButNum();
                        w.ShowDialog();
                        button.ForeColor = Color.Black;
                        button.Text = w.Num.ToString();

                    };
                    设置为雷mi.Click += (sender, e) =>
                    {
                        button.ForeColor = Color.Red;
                        button.Text = "雷";
                    };

                    cms.Items.AddRange(new ToolStripItem[] { 设置数字mi, 设置为雷mi });

                    button.ContextMenuStrip = cms;

                    //添加显示

                    Buttons.Add(button);
                    panel.Controls.Add(button);
                }
            }

        }
        public void SetMineMessage(ToolStripLabel MineNum, ToolStripLabel LayerSize)
        {
            this.MineNum = MineNum;
            this.LayerSize = LayerSize;
        }
        public void UpdateMineMessage()
        {
            verify_mines = 0;
            foreach (var btn in Buttons)
            {
                if (btn.Text == "雷")
                {
                    verify_mines++;
                }
            }
            MineNum.Text = $"雷数: {mines} (已验证: {verify_mines})";
            LayerSize.Text = $"布局尺寸 H:{height} W:{width}";
        }
        public void startParser()
        {
            verify_mines = 0;
            MarkPossibleMines();
            AutoCheckMines();
            UpdateMineMessage();
            UpdateButtonColor();
        }
        private List<Button> GetNeighbors(int row, int col)
        {
            List<Button> neighbors = new List<Button>();

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < height && j >= 0 && j < width && !(i == row && j == col))
                    {
                        neighbors.Add(Buttons[i * width + j]);
                    }
                }
            }

            return neighbors;
        }
        public void MarkPossibleMines()
        {
            // 遍历每个按钮
            foreach (var button in Buttons)
            {
                if (!int.TryParse(button.Text, out int num)) continue; // 如果按钮上的文本不是数字，则跳过

                // 获取按钮的行和列索引
                int row = button.Location.Y / butSize;
                int col = button.Location.X / butSize;

                // 获取按钮周围8个方向的按钮
                var neighbors = GetNeighbors(row, col);

                // 统计周围标记为"雷"的数量
                int markedCount = 0;
                foreach (var neighbor in neighbors)
                {
                    if (neighbor.Text == "雷")
                    {
                        markedCount++;
                    }
                }

                // 当未标记为"雷"的按钮数等于当前按钮数字时，将周围未标记的按钮打上"?"标记
                if (num - markedCount > 0)
                {
                    foreach (var neighbor in neighbors)
                    {
                        if (neighbor.Text == "-")
                        {
                            neighbor.Text = "?";
                        }
                    }
                }
            }
        }
        public void AutoCheckMines()
        {
            bool changed; // 用于标记是否有按钮文本被改变
            do
            {
                changed = false;
                foreach (var btn in Buttons)
                {
                    if (int.TryParse(btn.Text, out int num)) // 如果按钮上的文本是数字，则进行推断
                    {
                        // 获取按钮的行和列索引
                        int row = btn.Location.Y / butSize;
                        int col = btn.Location.X / butSize;

                        // 获取按钮周围8个方向的按钮
                        var neighbors = GetNeighbors(row, col);

                        // 统计周围未标记为"雷"的空白格子数量
                        int blankCount = neighbors.Count(neigh => neigh.Text == "-" || neigh.Text == "?");

                        // 统计周围标记为"雷"的数量
                        int markedCount = 0;
                        foreach (var neighbor in neighbors)
                        {
                            if (neighbor.Text == "雷")
                            {
                                markedCount++;
                            }
                        }

                        if (blankCount > 0 && num - markedCount == blankCount) // 如果剩余空白格子数量等于雷数，则将空白格子标记为"雷"
                        {
                            foreach (var neighbor in neighbors)
                            {
                                if (neighbor.Text == "-" || neighbor.Text == "?")
                                {
                                    neighbor.Text = "雷";
                                    changed = true;
                                }
                            }
                        }

                        // 统计周围未知按钮的数量
                        int unknownCount = neighbors.Count(neigh => neigh.Text == "-");

                        if (unknownCount > 0 && num - markedCount == unknownCount) // 如果剩余未知按钮等于雷数，则将未知按钮设置为"雷"
                        {
                            foreach (var neighbor in neighbors)
                            {
                                if (neighbor.Text == "-" || neighbor.Text == "?")
                                {
                                    neighbor.Text = "雷";
                                    verify_mines++;
                                    changed = true;
                                }
                            }
                        }
                        else if (markedCount == num) // 如果标记为"雷"的数量等于数字，则将剩余未知按钮设置为非雷
                        {
                            foreach (var neighbor in neighbors)
                            {
                                if (neighbor.Text == "-" || neighbor.Text == "?")
                                {
                                    neighbor.Text = "";
                                    changed = true;
                                }
                            }
                        }
                    }
                }
            } while (changed);
        }
        public void UpdateButtonColor()
        {
            foreach (var btn in Buttons)
            {
                switch (btn.Text)
                {
                    case "-":
                        btn.ForeColor = Color.Gray;
                        break;
                    case "?":
                        btn.ForeColor = Color.Blue;
                        break;
                    case "雷":
                        btn.ForeColor = Color.Red;
                        break;
                    default:
                        btn.ForeColor = Color.Black;
                        break;
                }
            }
        }
        public void HideBlanks(bool isHideBlank)
        {
            if (isHideBlank)
            {
                foreach(var btn in Buttons)
                {
                    if (string.IsNullOrEmpty(btn.Text))
                    {
                        btn.Hide();
                    }
                }
            }
            else
            {
                foreach (var btn in Buttons)
                {
                    if (string.IsNullOrEmpty(btn.Text))
                    {
                        btn.Show();
                    }
                }
            }
        }
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
        mineParser.startParser();
    }

    private void toolStripButton3_Click(object sender, EventArgs e)
    {
        if (isHideBlank)
        {
            isHideBlank = false;
        }
        else
        {
            isHideBlank = true;
        }
        mineParser.HideBlanks(isHideBlank);
    }
}
