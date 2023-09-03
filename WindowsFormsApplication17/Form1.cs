using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication17
{
    public partial class Form1 : Form
    {
        private Dictionary<string, int> asistentesPorLocalidad = new Dictionary<string, int>();
        private Dictionary<string, decimal> montoPorLocalidad = new Dictionary<string, decimal>();

        public Form1()
        {
            InitializeComponent();
            InicializarDiccionarios();
        }

        private void InicializarDiccionarios()
        {
            // Inicializa los diccionarios con las localidades
            asistentesPorLocalidad["Sol Candente"] = 0;
            asistentesPorLocalidad["Sol Luminoso"] = 0;
            asistentesPorLocalidad["Sombrita"] = 0;
            asistentesPorLocalidad["Tribunita"] = 0;
            asistentesPorLocalidad["Silla Plástica"] = 0;

            montoPorLocalidad["Sol Candent"] = 0;
            montoPorLocalidad["Sol Luminoso"] = 0;
            montoPorLocalidad["Sombrita"] = 0;
            montoPorLocalidad["Tribunita"] = 0;
            montoPorLocalidad["Silla Plástica"] = 0;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string localidad = cmbLocalidades.Text;
            int cantidadEntradas;

            // Validar que la cantidad de entradas sea un número válido
            if (!int.TryParse(txtCantidad.Text, out cantidadEntradas))
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }

            // Validar que la localidad sea válida
            if (!asistentesPorLocalidad.ContainsKey(localidad))
            {
                MessageBox.Show("Seleccione una localidad válida.");
                return;
            }

            // Actualizar asistentes y montos por localidad
            asistentesPorLocalidad[localidad] += cantidadEntradas;
            montoPorLocalidad[localidad] += cantidadEntradas * ObtenerPrecioLocalidad(localidad);

            // Actualizar resultados
            MostrarResultados();
        }

        private decimal ObtenerPrecioLocalidad(string localidad)
        {
            // Definir los precios por localidad (ajusta estos valores según tus necesidades)
            switch (localidad)
            {
                case "Sol Candente":
                    return 3.0m;
                case "Sol Luminoso":
                    return 5.0m;
                case "Sombrita":
                    return 8.0m;
                case "Tribunita":
                    return 15.0m;
                case "Silla Plástica":
                    return 20.0m;
                default:
                    return 0.0m; // Si la localidad no se encuentra, regresa 0
            }
        }

        //este metodo  muestra los resultados de los datos ingresados
        private void MostrarResultados()
        {
            lstResultados.Items.Clear();

            int totalAsistentes = 0;
            decimal totalMonto = 0;

            foreach (var kvp in asistentesPorLocalidad)
            {
                string localidad = kvp.Key;
                int asistentes = kvp.Value;
                decimal monto = montoPorLocalidad[localidad];

                lstResultados.Items.Add($"{localidad}: {asistentes} asistentes - Monto: ${monto:F2}");

                totalAsistentes += asistentes;
                totalMonto += monto;
            }

            lblAsistentes.Text = $"Total Asistentes: {totalAsistentes}";
            lblMonto.Text = $"Total Monto: ${totalMonto:F2}";
        }

        //este evento limpia los datos y reposiciona en el cursor en txtcantidad

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cmbLocalidades.Text = "";
            txtCantidad.Text = "";
            txtCantidad.Focus();
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
