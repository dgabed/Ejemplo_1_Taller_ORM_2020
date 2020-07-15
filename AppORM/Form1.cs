using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppORM.Models;

namespace AppORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cargarGrilla();
        }

        private void cargarGrilla()
        {
            using (TallerORM_Ejemplo_1Entities db = new TallerORM_Ejemplo_1Entities())
            {
                var lst = from d in db.tabla
                          select d;

                dgvPersona.DataSource = lst.ToList();

            }
        }

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            Presentacion.FrmTabla objFrmTabla = new Presentacion.FrmTabla(0, false);
            objFrmTabla.ShowDialog();

            this.cargarGrilla();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
           
            if (dgvPersona.Rows.Count>0)
            {
                int id = int.Parse(dgvPersona.Rows[dgvPersona.CurrentRow.Index].Cells[0].Value.ToString());
                Presentacion.FrmTabla objFrmTabla = new Presentacion.FrmTabla(id, true);
                objFrmTabla.ShowDialog();

                this.cargarGrilla();
            }

        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPersona.Rows.Count > 0)
            {
                int id = int.Parse(dgvPersona.Rows[dgvPersona.CurrentRow.Index].Cells[0].Value.ToString());
                
                using(TallerORM_Ejemplo_1Entities db = new TallerORM_Ejemplo_1Entities())
                {
                    tabla objPersona = db.tabla.Find(id);
                    db.tabla.Remove(objPersona);

                    db.SaveChanges();
                }

                this.cargarGrilla();
            }
        }
    }
}
