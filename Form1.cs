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
        // �ȴ�����
        newLayout.width = mineParser.width;
        newLayout.height = mineParser.height;
        newLayout.mines = mineParser.mines;

        // �򿪶Ի���
        newLayout.ShowDialog();

        // ��������
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
                    // ��ʼ����ť

                    Button button = new Button();

                    button.Size = new Size(butSize, butSize);
                    button.Location = new Point(w * butSize, h * butSize);
                    button.Tag = $"{Buttons.Count}";
                    button.Text = "-";

                    // ��������

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

                    // �Ҽ��˵�

                    var cms = new ContextMenuStrip();
                    var ��������mi = new ToolStripMenuItem();
                    var ����Ϊ��mi = new ToolStripMenuItem();

                    ��������mi.Text = "��������";
                    ����Ϊ��mi.Text = "����Ϊ��";
                    ��������mi.Click += (sender, e) =>
                    {
                        var w = new SetButNum();
                        w.ShowDialog();
                        button.ForeColor = Color.Black;
                        button.Text = w.Num.ToString();

                    };
                    ����Ϊ��mi.Click += (sender, e) =>
                    {
                        button.ForeColor = Color.Red;
                        button.Text = "��";
                    };

                    cms.Items.AddRange(new ToolStripItem[] { ��������mi, ����Ϊ��mi });

                    button.ContextMenuStrip = cms;

                    //�����ʾ

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
                if (btn.Text == "��")
                {
                    verify_mines++;
                }
            }
            MineNum.Text = $"����: {mines} (����֤: {verify_mines})";
            LayerSize.Text = $"���ֳߴ� H:{height} W:{width}";
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
            // ����ÿ����ť
            foreach (var button in Buttons)
            {
                if (!int.TryParse(button.Text, out int num)) continue; // �����ť�ϵ��ı��������֣�������

                // ��ȡ��ť���к�������
                int row = button.Location.Y / butSize;
                int col = button.Location.X / butSize;

                // ��ȡ��ť��Χ8������İ�ť
                var neighbors = GetNeighbors(row, col);

                // ͳ����Χ���Ϊ"��"������
                int markedCount = 0;
                foreach (var neighbor in neighbors)
                {
                    if (neighbor.Text == "��")
                    {
                        markedCount++;
                    }
                }

                // ��δ���Ϊ"��"�İ�ť�����ڵ�ǰ��ť����ʱ������Χδ��ǵİ�ť����"?"���
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
            bool changed; // ���ڱ���Ƿ��а�ť�ı����ı�
            do
            {
                changed = false;
                foreach (var btn in Buttons)
                {
                    if (int.TryParse(btn.Text, out int num)) // �����ť�ϵ��ı������֣�������ƶ�
                    {
                        // ��ȡ��ť���к�������
                        int row = btn.Location.Y / butSize;
                        int col = btn.Location.X / butSize;

                        // ��ȡ��ť��Χ8������İ�ť
                        var neighbors = GetNeighbors(row, col);

                        // ͳ����Χδ���Ϊ"��"�Ŀհ׸�������
                        int blankCount = neighbors.Count(neigh => neigh.Text == "-" || neigh.Text == "?");

                        // ͳ����Χ���Ϊ"��"������
                        int markedCount = 0;
                        foreach (var neighbor in neighbors)
                        {
                            if (neighbor.Text == "��")
                            {
                                markedCount++;
                            }
                        }

                        if (blankCount > 0 && num - markedCount == blankCount) // ���ʣ��հ׸������������������򽫿հ׸��ӱ��Ϊ"��"
                        {
                            foreach (var neighbor in neighbors)
                            {
                                if (neighbor.Text == "-" || neighbor.Text == "?")
                                {
                                    neighbor.Text = "��";
                                    changed = true;
                                }
                            }
                        }

                        // ͳ����Χδ֪��ť������
                        int unknownCount = neighbors.Count(neigh => neigh.Text == "-");

                        if (unknownCount > 0 && num - markedCount == unknownCount) // ���ʣ��δ֪��ť������������δ֪��ť����Ϊ"��"
                        {
                            foreach (var neighbor in neighbors)
                            {
                                if (neighbor.Text == "-" || neighbor.Text == "?")
                                {
                                    neighbor.Text = "��";
                                    verify_mines++;
                                    changed = true;
                                }
                            }
                        }
                        else if (markedCount == num) // ������Ϊ"��"�������������֣���ʣ��δ֪��ť����Ϊ����
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
                    case "��":
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
