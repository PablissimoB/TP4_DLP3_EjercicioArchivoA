using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public class Pagos
        {
            public int campoOrdenado { get; set; }
            public string campoString { get; set; }
            public int campoValor { get; set; }
            public Pagos(int a, string b, int c)
            {
                this.campoOrdenado = a;
                this.campoString = b;  
                this.campoValor = c;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = string.Empty;
                StreamReader streamReader = new StreamReader(Server.MapPath(".") + "/archivo.txt");
                string[] lines = (streamReader.ReadToEnd()).Split('\n');
                streamReader.Close();
                List<Pagos> list = new List<Pagos>();
                int lineCount = 0;
                foreach (string line in lines)
                {
                    lineCount++;
                    if (lineCount % 3 == 0)
                    {
                        Pagos pago = new Pagos(int.Parse(lines[lineCount - 3]), lines[lineCount - 2].ToString(), int.Parse(lines[lineCount - 1]));
                        list.Add(pago);
                    }
                }
                //Opcion lambda
                list.Sort((a, b) => b.campoOrdenado.CompareTo(a.campoOrdenado));

                //Opcion Metodo burbuja para ordenamiento
                //
                //for (int i = 0; i < list.Count; i++)
                //{
                //    for (int j = i + 1; j < list.Count; j++)
                //    {
                //        if (list[i].campoOrdenado < list[j].campoOrdenado)
                //        {
                //            Pagos temp = list[i];
                //            list[i] = list[j];
                //            list[j] = temp;
                //        }
                //    }
                //}
                foreach (Pagos pagos in list)
                {
                    Label1.Text += pagos.campoOrdenado.ToString();
                    Label1.Text += pagos.campoString.ToString();
                    Label1.Text += pagos.campoString.ToString() + "<br>";
                }
            }
        }
    }
}