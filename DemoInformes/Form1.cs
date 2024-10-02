using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace DemoInformes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtParametro1.Text) || String.IsNullOrEmpty(txtParametro2.Text))
            {
                return;
            }
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("Parametro1", txtParametro1.Text.ToUpper());
            parametros[1] = new ReportParameter("Parametro2", txtParametro2.Text);
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


            this.reportViewer1.LocalReport.ReportPath = "Report1.rdlc";

            ReportDataSource dataSource = new ReportDataSource("DataSetCualquierNombre", ds1.Tables["DataTable1"]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);

            this.reportViewer1.LocalReport.SetParameters(parametros);

            this.reportViewer1.RefreshReport();
        }
    }
}
