using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SistemaExpedientes_LimaNorte
{
    public partial class Form1 : Form
    {
        string ruta = "Expedientes.txt";
        public Form1(){ InitializeComponent(); }
        
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validacion datos obligatorios
            if(txtCodigo.Text==""||txtDNI.Text==""||txtNombres.Text==""){
                MessageBox.Show("Faltan datos obligatorios");
                return;
            }
            // Validacion DNI 8 digitos
            if(txtDNI.Text.Length!=8||!txtDNI.Text.All(char.IsDigit)){
                MessageBox.Show("DNI debe tener 8 digitos numericos");
                return;
            }
            // Busqueda secuencial codigo duplicado
            if(File.Exists(ruta)){
                foreach(var linea in File.ReadAllLines(ruta)){
                    if(linea.Split('|')[0]==txtCodigo.Text){
                        MessageBox.Show("Codigo duplicado - busqueda secuencial");
                        return;
                    }
                }
            }
            string reg = $"{txtCodigo.Text}|{txtDNI.Text}|{txtNombres.Text}|{txtTipo.Text}|{txtAsunto.Text}|{dtpFecha.Value}";
            File.AppendAllText(ruta, reg + Environment.NewLine);
            MessageBox.Show("Expediente registrado - Municipalidad Lima Norte");
        }
    }
}
