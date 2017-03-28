using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bzipprvsapr_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private UInt16[,] M = new UInt16[4,5]
           {{1,	6,	2,	7,	11},
            {2,	4,	3,	10,	2},
            {3,	2,	11,	7,	3},
            {4,	11,	2,	6,	3}};

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv.RowCount = 4;
            for (int i = 1; i < 5; ++i)
                dgv.Rows[i-1].HeaderCell.Value = "A" + i;

            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 5; ++j)
                    dgv.Rows[i].Cells[j].Value = M[i, j].ToString();

            UInt16[] MinFij = MethodMinMax.getMinArray(M);
            UInt16 MaxFir = MethodMinMax.getMaxValue(MinFij);
            for (int i = 0; i < 4; ++i)
                dgv.Rows[i].Cells[5].Value = MinFij[i].ToString();
            dgv.Rows[0].Cells[6].Value = MaxFir.ToString();
        }
    }
}
