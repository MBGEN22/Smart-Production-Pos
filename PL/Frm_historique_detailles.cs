using Smart_Production_Pos.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Smart_Production_Pos.PL
{
    public partial class Frm_historique_detailles : Form
    {
        BL_STATE state_detaille = new BL_STATE();
        public string code_barre;
        public Frm_historique_detailles()
        {
            InitializeComponent();
        }
        private string GetMonthName(int month)
        {
            switch (month)
            {
                case 1: return "جانفي";
                case 2: return "فيفري";
                case 3: return "مارس";
                case 4: return "أفريل";
                case 5: return "ماي";
                case 6: return "جوان";
                case 7: return "جويلية";
                case 8: return "أوت";
                case 9: return "سبتمبر";
                case 10: return "أكتوبر";
                case 11: return "نوفمبر";
                case 12: return "ديسمبر";
                default: return "";
            }
        }
        private void Frm_historique_detailles_Load(object sender, EventArgs e)
        {
            LoadChartData();
            CustomizeChartFont();
            DataTable data = state_detaille.get_list_historique_vente_produit_par_mois(code_barre);
            //this.dataGridView1.DataSource = state_detaille.get_list_historique_vente_produit_par_mois(code_barre);

            //data.Columns["الشهر"].DataType = typeof(string);
            //foreach (DataRow row in data.Rows)
            //{
            //    int monthNumber = Convert.ToInt32(row["الشهر"]);
            //    row["الشهر"] = GetMonthName(monthNumber);
            //}

            this.dataGridView1.DataSource = data;
        }

        private void CustomizeChartFont()
        {
            // ضبط الخط لمحور X (التواريخ)
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);

            // ضبط الخط لمحور Y (القيم)
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);

            // ضبط الخط للعناوين
            chart1.Titles.Clear();
            Title chartTitle = new Title("المبيعات حسب الأشهر", Docking.Top, new Font("Times New Roman", 14, FontStyle.Bold), Color.Black);
            chart1.Titles.Add(chartTitle);

            // ضبط الخط في وسوم البيانات (Labels)
            foreach (var series in chart1.Series)
            {
                series.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            }
        }
        private void LoadChartData()
        {
            DataTable dt = state_detaille.get_list_historique_vente_produit_par_mois(code_barre);
            chart1.Series.Clear();
            Series series = new Series("المبيعات");
            series.ChartType = SeriesChartType.Column; // يمكنك تغييره إلى Line أو Bar
            chart1.Series.Add(series);

            foreach (DataRow row in dt.Rows)
            {
                string monthYear = $"{row["الشهر"]}/{row["السنة"]}";
                series.Points.AddXY(monthYear, Convert.ToInt32(row["الكمية المباعة"]));
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // التحقق من أن العمود هو "الشهر"
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "الشهر" && e.Value != null)
            {
                // تحويل رقم الشهر إلى اسمه
                int monthNumber;
                if (int.TryParse(e.Value.ToString(), out monthNumber))
                {
                    e.Value = GetMonthName(monthNumber);
                    e.FormattingApplied = true; // للإشارة إلى أن التنسيق تم بنجاح
                }
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // تأكد أن الخلية ليست فارغة لتفادي الأخطاء
                 
                row.Cells["الكمية المباعة"].Style.BackColor = Color.Yellow;
                 
            }
        }
    }
}
