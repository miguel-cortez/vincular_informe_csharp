using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoInformes
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("Parametro1", "ALGO");
            parametros[1] = new ReportParameter("Parametro2", "ALGO 2");
            DataSet1 ds1 = new DataSet1();
            DataRow dr = ds1.DataTable1.NewRow();
            dr["Id"] = Convert.ToUInt64(100);
            dr["Nombre"] = "Miguel Ángel";
            dr["Apellido"] = "Cortez Vásquez";
            dr["Telefono"] = "79207226";
            dr["CorreoElectronico"] = "mcortez_vasquez@yahoo.com";
            ds1.DataTable1.Rows.Add(dr);


            dr = ds1.DataTable1.NewRow();
            dr["Id"] = Convert.ToUInt64(560);
            dr["Nombre"] = "Estela del Carmen";
            dr["Apellido"] = "Benitez Orellana";
            dr["Telefono"] = "74903687";
            dr["CorreoElectronico"] = "carmen_benitez@gmail.com";
            ds1.DataTable1.Rows.Add(dr);


            dr = ds1.DataTable1.NewRow();
            dr["Id"] = Convert.ToUInt64(856);
            dr["Nombre"] = "Felícito";
            dr["Apellido"] = "Reyes Hidalgo";
            dr["Telefono"] = "23459067";
            dr["CorreoElectronico"] = "reyes@outlook.com";
            ds1.DataTable1.Rows.Add(dr);


            this.reportViewer1.LocalReport.ReportPath = "Report2.rdlc";

            ReportDataSource dataSource = new ReportDataSource("DataSet1", ds1.Tables["DataTable1"]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);

            this.reportViewer1.LocalReport.SetParameters(parametros);

            this.reportViewer1.RefreshReport();
        }
    }
}
