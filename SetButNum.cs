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
public partial class SetButNum : Form
{
    public int Num = 1;
    public SetButNum()
    {
        InitializeComponent();
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        Num = (int)numericUpDown1.Value;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
