namespace Datos_empleado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private bool ValidarCampos()
        {
            if (textID.Text == "" ||
                textNombre.Text == "" ||
                textApellido.Text == "" ||
                textDireccion.Text == "" ||
                textTelefono.Text == "" ||
                textEmail.Text == "" ||
                textCargo.Text == "" ||
                textSalario.Text == "" ||
                comboBoxGenero.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Todos los campos son obligatorios",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivo de texto (*.txt)|*.txt";
            guardar.Title = "Guardar archivo de empleados";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(guardar.FileName))
                {
                    writer.WriteLine("ID\tNombre\tApellido\tDirección\tTeléfono\tEmail\tCargo\tSalario\tFecha Ingreso\tGénero");
                    writer.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");

                    writer.WriteLine(
                        $"{textID.Text}\t{textNombre.Text}\t{textApellido.Text}\t{textDireccion.Text}\t{textTelefono.Text}\t{textEmail.Text}\t{textCargo.Text}\t{textSalario.Text}\t{dateTimePickerFecha.Value.ToShortDateString()}\t{comboBoxGenero.Text}"
                    );
                }

                MessageBox.Show(
                    "Archivo guardado correctamente",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxGenero.Items.Add("Masculino");
            comboBoxGenero.Items.Add("Femenino");
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Archivo de texto (*.txt)|*.txt";

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("notepad.exe", abrir.FileName);
            }
            
        
           
        
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea salir de la aplicación?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
