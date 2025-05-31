using System;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using ProyectoFinal1;

namespace InvestigadorIA
{
    public partial class Form1 : Form
    {
      
        string cadenaConexion = "Data Source=LAPTOP-O90PA1AO\\SQLEXPRESS;Initial Catalog=InvestigadorIA;Integrated Security=True;TrustServerCertificate=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            
            string pregunta = textBoxPreguntas.Text;
            if (string.IsNullOrWhiteSpace(pregunta))
            {
                MessageBox.Show("Por favor, escribe una pregunta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EjecutarInvestigacion(pregunta);
        }

        private async void EjecutarInvestigacion(string pregunta)
        {

            try
            {

                IAService ia = new IAService("apy key");
                string prompt = "Por favor responde en español: " + pregunta;
                string respuesta = await ia.ObtenerRespuestaAsync( prompt);
                MostrarEnPantalla(respuesta);
                GuardarEnBaseDeDatos(pregunta, respuesta);
                GenerarDocumentos(pregunta, respuesta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error durante la investigación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void MostrarEnPantalla(string texto)
        {
            textBoxRespuesta.Text = texto;
        }

        private void GuardarEnBaseDeDatos(string pregunta, string respuesta)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string sql = "INSERT INTO Investigaciones (preguntas, Respuesta, Fecha) VALUES (@p, @r, @f)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@p", pregunta);
                    cmd.Parameters.AddWithValue("@r", respuesta);
                    cmd.Parameters.AddWithValue("@f", DateTime.Now);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos en la base de datos: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarDocumentos(string pregunta, string respuesta)
        {
            try
            {
                string carpeta = "C:\\Users\\VICTUS\\Music\\ProyectoFinal1\\Investigaciones\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                Directory.CreateDirectory(carpeta);

              
                string rutaWord = Path.Combine(carpeta, "Investigacion.docx");
                CrearWord(respuesta, rutaWord, pregunta);

               
                string rutaPPT = Path.Combine(carpeta, "Investigacion.pptx");
                CrearPPT(pregunta, respuesta, rutaPPT);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar los documentos: " + ex.Message, "Error de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearWord(string contenido, string ruta, string pregunta)
        {
            try
            {
                var wordApp = new Word.Application();
                var doc = wordApp.Documents.Add();

                var rango = doc.Content;
                rango.Text = pregunta + "\n\n"; 
                rango.Font.Size = 18;
                rango.Font.Bold = 1;

                var rangoContenido = doc.Content;
                rangoContenido.Start = rango.End;
                rangoContenido.Text = contenido;
                rangoContenido.Font.Size = 12;
                rangoContenido.Font.Bold = 0;

                doc.SaveAs2(ruta);

                doc.Close();
                wordApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el documento Word: " + ex.Message, "Error de Word", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CrearPPT(string titulo, string contenido, string ruta)
        {
            try
            {
                var pptApp = new PowerPoint.Application();
              

                var presentacion = pptApp.Presentations.Add();

                int maxChars = 300;  
                int inicio = 0;

                while (inicio < contenido.Length)
                {
                    int longitud = Math.Min(maxChars, contenido.Length - inicio);
                    string textoParte = contenido.Substring(inicio, longitud);

                    var slide = presentacion.Slides.Add(presentacion.Slides.Count + 1, PowerPoint.PpSlideLayout.ppLayoutText);

                    slide.Shapes[1].TextFrame.TextRange.Text = titulo;     
                    slide.Shapes[2].TextFrame.TextRange.Text = textoParte; 

                    inicio += longitud;
                }

                presentacion.SaveAs(ruta);

                 presentacion.Close();
                 pptApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la presentación de PowerPoint: " + ex.Message, "Error de PowerPoint", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
