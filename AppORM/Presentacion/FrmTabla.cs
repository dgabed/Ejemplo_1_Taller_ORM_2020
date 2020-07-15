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

namespace AppORM.Presentacion
{
    public partial class FrmTabla : Form
    {
        private int id;
        private bool editar;
        tabla objPersona;

        public FrmTabla(int id, bool editar)
        {
            InitializeComponent();

            this.editar = editar;
            this.id = id;

            if (this.editar)
                this.cargarDatos();
        }

        private void cargarDatos()
        {
            using (TallerORM_Ejemplo_1Entities db = new TallerORM_Ejemplo_1Entities())
            {
                this.objPersona = db.tabla.Find(this.id);

                txtNombre.Text = objPersona.nombre;
                txtDireccion.Text = objPersona.direccion;
                txtEmail.Text = objPersona.email;
                dtpFecha.Value = objPersona.fecha_nacimiento.Value;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            using (TallerORM_Ejemplo_1Entities db = new TallerORM_Ejemplo_1Entities())
            {

                if(!editar)
                    this.objPersona = new tabla();

                objPersona.nombre = txtNombre.Text;
                objPersona.direccion = txtDireccion.Text;
                objPersona.email = txtEmail.Text;
                objPersona.fecha_nacimiento = dtpFecha.Value;

                if (editar)
                {
                    db.Entry(objPersona).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    db.tabla.Add(objPersona); //Solo lo agrega al modelo edmx    
                }

                db.SaveChanges(); //Persiste en la base de datos según el caso (modificar o agregar)
                this.Close();
            }
        }
    }
}
