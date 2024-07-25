using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperLayoutParser;
public partial class NewLayout : Form
{
    // Width, height, number of mines
    public int width = 9;
    public int height = 9;
    public int mines = 10;

    public NewLayout()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        width = int.Parse(textBox1.Text);
        height = int.Parse(textBox2.Text);
        mines = int.Parse(textBox3.Text);
        this.Close();
    }

    private void NewLayout_Load(object sender, EventArgs e)
    {
        textBox1.Text = width.ToString();
        textBox2.Text = height.ToString();
        textBox3.Text = mines.ToString();
    }
}
