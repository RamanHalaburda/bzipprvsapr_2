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
            // fill dgv
            dgv.RowCount = 5;
            for (int i = 1; i < 5; ++i)
                dgv.Rows[i-1].HeaderCell.Value = "A" + i;            

            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 5; ++j)
                    dgv.Rows[i].Cells[j].Value = string.Format("{0:0.##}", M[i, j]);

            dgv.Rows[4].HeaderCell.Value = "Q";
            for (int j = 0; j < 5; ++j)
                dgv.Rows[4].Cells[j].Value = string.Format("{0:0.##}", Q[j]);

            // fill dgv_s
            dgv_s.RowCount = 4;
            for (int i = 1; i < 5; ++i)
                dgv_s.Rows[i - 1].HeaderCell.Value = "C" + i;
            
            // fill dgv_result
            dgv_result.RowCount = 1;
            for (int i = 1; i <= 4; ++i)
            {
                dgv_result.Columns[i - 1].HeaderCell.Value = "A" + i;
                dgv_result.Rows[0].Cells[i - 1].Value = "0";
            }
            
            // MinMax
            UInt16[] MM_SumFij = MethodMinMax.getMinArray(M);
            UInt16 MM_MaxFir = MethodMinMax.getMaxValue(MM_SumFij);
            for (int i = 0; i < 4; ++i)
            {
                dgv.Rows[i].Cells[5].Value = string.Format("{0:0.##}", MM_SumFij[i]);
                if (MM_MaxFir == MM_SumFij[i])
                {
                    dgv.Rows[i].Cells[6].Value = string.Format("{0:0.##}", MM_MaxFir);
                    incrementValueCellOfDataGridView(dgv_result.Rows[0].Cells[i]);
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = Color.Aqua;
                    dgv.Rows[i].Cells[6].Style = style;
                }
            }

            // Bajes-Laplas
            Double[] BL_MinFij = MethodBajesLaplas.getMinArray(M, Q);
            Double BL_MaxFir = MethodBajesLaplas.getMaxValue(BL_MinFij);
            for (int i = 0; i < 4; ++i)
            {
                dgv.Rows[i].Cells[7].Value = string.Format("{0:0.##}", BL_MinFij[i]);
                if (BL_MaxFir == BL_MinFij[i])
                {                    
                    dgv.Rows[i].Cells[8].Value = string.Format("{0:0.##}", BL_MaxFir);
                    incrementValueCellOfDataGridView(dgv_result.Rows[0].Cells[i]);
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = Color.Aqua;
                    dgv.Rows[i].Cells[8].Style = style;
                }
            }

            //Savage
            Int16[,] S_Fij_MinFij = MethodSavage.getMatrixCoefficient(M);
            Int16 S_MaxFir = MethodSavage.getMaxValue(S_Fij_MinFij);
            for (int i = 0; i < S_Fij_MinFij.GetLength(0); ++i)
                for (int j = 0; j < S_Fij_MinFij.GetLength(1); ++j)
                {
                    dgv_s.Rows[i].Cells[j].Value = Convert.ToString(S_Fij_MinFij[i, j]);
                    if ((j == 5) && (S_MaxFir == S_Fij_MinFij[i, j]))
                    {
                        dgv_s.Rows[i].Cells[6].Value = Convert.ToString(S_MaxFir);
                        incrementValueCellOfDataGridView(dgv_result.Rows[0].Cells[i]);
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Aqua;
                        dgv_s.Rows[i].Cells[5].Style = style;
                    }
                }         

            // search most useful method
            searchMostUsefulWay(dgv_result);
        }

        private void incrementValueCellOfDataGridView(DataGridViewCell _dgvc)
        {
            _dgvc.Value = Convert.ToString(Convert.ToDouble(_dgvc.Value) + 1);
        }

        private void searchMostUsefulWay(DataGridView _dgv)
        { 
            // search MAX counter
            UInt16 max = Convert.ToUInt16(_dgv.Rows[0].Cells[0].Value);
            UInt16 index = 0;
            for (int i = 1; i < _dgv.ColumnCount; ++i)
                if (Convert.ToUInt16(_dgv.Rows[0].Cells[i].Value) > max)
                {
                    max = Convert.ToUInt16(_dgv.Rows[0].Cells[i].Value);
                    index = (UInt16)i;
                }

            // check by repeating similar counters
            UInt16 c = 0;
            for (int i = 0; i < _dgv.ColumnCount; ++i)
                if (Convert.ToUInt16(_dgv.Rows[0].Cells[i].Value) == max)
                {
                    ++c;
                    if (c == 2)
                    {
                        MessageBox.Show("Exist similar results!");
                        return;
                    }
                }

            // final check
            if (c == 1)
            {                
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.BlueViolet;
                _dgv.Rows[0].Cells[index].Style = style;
                MessageBox.Show("Success! A" + Convert.ToString(++index) + " is most useful way.");
            }
            else
            {
                MessageBox.Show("Search without success!");
                return;
            }
        }
    }
}
