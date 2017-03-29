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

        private Double[] Q = new Double[5] { 0.2F, 0.1F, 0.5F, 0.05F, 0.15F };

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv.RowCount = 5;
            for (int i = 1; i < 5; ++i)
                dgv.Rows[i-1].HeaderCell.Value = "A" + i;            

            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 5; ++j)
                    dgv.Rows[i].Cells[j].Value = string.Format("{0:0.##}", M[i, j]);

            dgv.Rows[4].HeaderCell.Value = "Q";
            for (int j = 0; j < 5; ++j)
                dgv.Rows[4].Cells[j].Value = string.Format("{0:0.##}", Q[j]);

            // MinMax
            UInt16[] MM_SumFij = MethodMinMax.getMinArray(M);
            UInt16 MM_MaxFir = MethodMinMax.getMaxValue(MM_SumFij);
            for (int i = 0; i < 4; ++i)
                dgv.Rows[i].Cells[5].Value = string.Format("{0:0.##}", MM_SumFij[i]);
            dgv.Rows[0].Cells[6].Value = string.Format("{0:0.##}", MM_MaxFir);
            

            // Bajes-Laplas
            Double[] BL_MinFij = MethodBajesLaplas.getMinArray(M, Q);
            Double BL_MaxFir = MethodBajesLaplas.getMaxValue(BL_MinFij);
            for (int i = 0; i < 4; ++i)
                dgv.Rows[i].Cells[7].Value = string.Format("{0:0.##}", BL_MinFij[i]);
            dgv.Rows[0].Cells[8].Value = string.Format("{0:0.##}", BL_MaxFir);

            //Savage
            Int16[] MM_MinFij = MethodSavage.getMatrixCoefficient(M);
            UInt16 MM_MaxFir = MethodSavage.getMaxValue(MM_MinFij);
            for (int i = 0; i < 4; ++i)
                dgv.Rows[i].Cells[5].Value = string.Format("{0:0.##}", MM_MinFij[i]);
            dgv.Rows[0].Cells[6].Value = string.Format("{0:0.##}", MM_MaxFir);
        }
    }
}
