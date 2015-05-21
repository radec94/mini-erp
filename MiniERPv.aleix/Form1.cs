using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace MiniERP
{
    public partial class frmERP : Form
    {
        public const string CONNECTIONSTRING = "Driver={Microsoft Access Driver (*.mdb)};DBQ=minierp.mdb";

        private OdbcConnection cn;
        private OdbcDataAdapter da;
        DataSet ds;

        public frmERP()
        {
            cn = new OdbcConnection(CONNECTIONSTRING);
            cn.Open();
            InitializeComponent();
        }

        //ACCIONS
        private void frmERP_Load(object sender, EventArgs e)
        {

        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void valoracióStockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
         
        

        private void articlesToolStripMenuItem1_Click(object sender, EventArgs e)
        {        
            string connectionString;

            //Extreiem del XML:
            string codi = "";
            string descripcio = "";
            int preu = 0;
            int estoc = 0;

            //Validem XML
            ValidarXML("articles", "articles");

            //connectem amn la base de dades
            connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=minierp.mdb";

            OdbcConnection ConnexioMySQL = new OdbcConnection(connectionString);

            ConnexioMySQL.Open();

            //Seleccionem les dades

            XmlDocument xml = new XmlDocument();

            xml.Load("articles.xml");

            XmlNodeList xnList = xml.SelectNodes("/articles/article");

            foreach (XmlNode xn in xnList)

            {
                try
                {
                codi = xn["codi"].InnerText;

                descripcio = xn["descripcio"].InnerText;

                estoc = Convert.ToInt32(xn["estoc"].InnerText);

                preu = Convert.ToInt32(xn["preu"].InnerText);

                // PER FER UN INSERT O UPDATE
                
                OdbcCommand cmd = new OdbcCommand();

                cmd.Connection = ConnexioMySQL;

                cmd.CommandText = "INSERT INTO article VALUES ('" + codi + "','" + descripcio + "','" + estoc + "','" + preu + "');";

                cmd.ExecuteNonQuery();
                }
                catch (Exception g)
                {
                    AfegirError("L'ARTICLE AMB CODI: "+codi + " JA EXISTEIX A LA TAULA MESTRE D'ARTICLES", "IMPORTAR ARTICLES");

                }

            }

            ConnexioMySQL.Close();
            

        }
        //FALTA TREURE ELS ERRORS DEL SISTEMA PODRIA SER UNA FUNCIO PER PARAR EL PROGRAMA SI ES TRUE;
        private void ValidarXML(string xml, string xsd)
        {
            try
            {
                bool isValid = false;
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, xsd + ".xsd");
                settings.ValidationType = ValidationType.Schema;
                XmlDocument document = new XmlDocument();
                document.Load(xml + ".xml");
                XmlReader rdr = XmlReader.Create(new StringReader(document.InnerXml), settings);

                while (rdr.Read())
                {

                }
                isValid = true;
            }

            catch (Exception e)
            {
                MessageBox.Show("El fitxer XML no és correcte d'acord amb les normes del fitxer XSD", "ERROR");
                
            }

        }


        private void crearFitxerError()
        {
            StreamWriter arxiu = new StreamWriter("errors.xml", false);

            arxiu.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

            arxiu.WriteLine("<errors>");

            arxiu.WriteLine("</errors>");

            arxiu.Close();
        }

        //PREGUNTAR SI ES CORRECTE
        
        private void AfegirError(string descripcio, string proces)
        {

            try
            {
                //CARREGUEM EN MEMÒRIA EL FITXER D'ERRORS

                XmlDocument doc = new XmlDocument();

                doc.Load("errors.xml");

                //root representa l'arrel del document: <errors>

                XmlNode root = doc.DocumentElement;

                //CREEM UN NOU NODE D'ERROR  <error></error>

                XmlElement elem = doc.CreateElement("error");

                //CREEM SUBNODES FILL DE L'ERROR, TANTS COM NECESSITEM PER PRECISSAR 
                //DETALLS DE L'ERROR: DATA, PROCES QUE L'HA GENERAT, DESCRIPCIÓ ...

                XmlElement subElement1 = doc.CreateElement("descripcio");

                subElement1.InnerText = descripcio;

                XmlElement subElement2 = doc.CreateElement("proces");

                subElement2.InnerText = proces;

                //AFEGIM ELS SUBELEMENTS COM A FILLS DE l'ETIQUETA <error>

                elem.AppendChild(subElement1);

                elem.AppendChild(subElement2);

                //AFEGIM el nou error com a nou fill de l'arrel <errors>

                root.AppendChild(elem);

                //ACTUALITZEM EL DOCUMENT A DISC (FINS ARA TOT ES FEIA A MEMÒRIA)

                doc.Save("errors.xml");
            }
            catch (Exception h)
            {
                StreamWriter arxiu = new StreamWriter("errors.xml", false);

                arxiu.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

                arxiu.WriteLine("<errors>");

                arxiu.WriteLine("</errors>");

                arxiu.Close();
            }
        }
        
   }
}

