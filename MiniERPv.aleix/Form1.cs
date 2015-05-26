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
using Microsoft.VisualBasic;

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
            //Validem XML
            ValidarXML("articles", "articles");
            //Importem articles
            ImportarArticles();

        } //ImportarArticles

        private void ImportarArticles()
        {
            string connectionString;

            //Extreiem del XML:
            string codi = "";
            string descripcio = "";
            int preu = 0;
            int estoc = 0;

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
                    AfegirError("L'ARTICLE AMB CODI: " + codi + " JA EXISTEIX A LA TAULA MESTRE D'ARTICLES", "IMPORTAR ARTICLES");

                }

            }

            ConnexioMySQL.Close();
            
        }

        private void ImportarProveidors()
        {
            string connectionString;

            //Extreiem del XML:
            string codi = "";
            string nom = "";
            string adreca = "";
            string poblacio = "";
            int cp = 0;
            //connectem amn la base de dades
            connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=minierp.mdb";

            OdbcConnection ConnexioMySQL = new OdbcConnection(connectionString);

            ConnexioMySQL.Open();

            //Seleccionem les dades

            XmlDocument xml = new XmlDocument();

            xml.Load("proveidors.xml");

            XmlNodeList xnList = xml.SelectNodes("/proveidors/proveidor");

            foreach (XmlNode xn in xnList)
            {
                try
                {
                    codi = xn["codi"].InnerText;

                    nom = xn["nom"].InnerText;

                    adreca = xn["adreca"].InnerText;

                    poblacio = xn["poblacio"].InnerText;

                    cp = Convert.ToInt32(xn["cp"].InnerText);

                    // PER FER UN INSERT O UPDATE

                    OdbcCommand cmd = new OdbcCommand();

                    cmd.Connection = ConnexioMySQL;

                    cmd.CommandText = "INSERT INTO proveidor VALUES ('" + codi + "','" + nom + "','" + adreca + "','" + poblacio + "','" + cp + "');";

                    cmd.ExecuteNonQuery();
                }
                catch (Exception )
                {
                    AfegirError("EL PROVEIDOR AMB CODI: " + codi + " JA EXISTEIX A LA TAULA MESTRE DE PROVEIDORS", "IMPORTAR PROVEIDOR");
                    //nO REGISTRE EL MPRIMER CODI
                }

            }

            ConnexioMySQL.Close();

        }

        //Falta implementar lo de demanar el url del fitxer
        private void ImportarCapçaleraComanda()
        {
            string connectionString;

            //Extreiem del XML:
            string codiProveidor = "";
            string data = "";

            //connectem amb la base de dades

            connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=minierp.mdb";

            OdbcConnection ConnexioMySQL = new OdbcConnection(connectionString);

            ConnexioMySQL.Open();

            //Seleccionem les dades

            XmlDocument xml = new XmlDocument();

            xml.Load("comanda1.xml");//Nom de la variable que assigna el nom de la comanda----------------------------------

            XmlNodeList xnList = xml.SelectNodes("/comanda");

            foreach (XmlNode xn in xnList)
            {
                try
                {
                    codiProveidor = xn["codiProveidor"].InnerText;

                    data = xn["data"].InnerText;

                    // PER FER UN INSERT O UPDATE

                    OdbcCommand cmd = new OdbcCommand();

                    cmd.Connection = ConnexioMySQL;

                    cmd.CommandText = "INSERT INTO ccomanda (codiproveidor,data) VALUES ('" + codiProveidor + "','" + data + "');";

                    cmd.ExecuteNonQuery();


                }
                catch (Exception)//Proveïdor inexistent a la taula PROVEIDOR. Genera error sobre fitxer XML
                {
                    AfegirError("Proveïdor inexistent a la taula PROVEIDOR "+ codiProveidor, "INCORPORAR COMANDA");
                    //nO REGISTRE EL MPRIMER CODI
                }

            }

            ConnexioMySQL.Close();
        }
        //Falta implementar lo de demanar el url del fitxer
        private void ImportarDetallComanda()
        {
            string connectionString;

            //Extreiem del XML:
            ulong codiComanda = 0;
            string codiArticle = "";
            ulong quantitat = 0;
            int preu = 0;
            string rebuttext = "";
            bool rebut = false;
            int fila;

            //connectem amb la base de dades

            connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=minierp.mdb";

            OdbcConnection ConnexioMySQL = new OdbcConnection(connectionString);

            ConnexioMySQL.Open();

            //Seleccionem les dades
            //PER SELECCIONAR DADES

            //crea el datadapter. No cal si el que volem son inserts

            OdbcDataAdapter da;

            da = new OdbcDataAdapter("Select codi, codiproveidor ,data  from ccomanda", ConnexioMySQL);

            //omples el dataset amb les dades del da. No cal si e lque volem son inserts

            DataSet ds = new DataSet();

            da.Fill(ds);

            //ds.Tables[0].Rows.Count número de fila

            //Rows té tantes files com registres el select i tantes columnes com camps
       
            XmlDocument xml = new XmlDocument();

            xml.Load("comanda1.xml");//Nom de la variable que assigna el nom de la comanda----------------------------------

            XmlNodeList xnList = xml.SelectNodes("/comanda/articles/article");

            foreach (XmlNode xn in xnList)
            {
                try
                {
                    fila = ds.Tables[0].Rows.Count-1;

                    codiComanda = Convert.ToUInt64(ds.Tables[0].Rows[fila][0].ToString());

                    codiArticle = xn["codiArticle"].InnerText;

                    quantitat = Convert.ToUInt64(xn["quantitat"].InnerText);

                    preu = Convert.ToInt32(xn["preu"].InnerText);

                    rebuttext = xn["rebut"].InnerText;

                    if (rebuttext[0] == 'S' || rebuttext[1] == 'i') rebut = true;
                    else rebut = false;
                    
                    // PER FER UN INSERT O UPDATE

                    OdbcCommand cmd = new OdbcCommand();

                    cmd.Connection = ConnexioMySQL;
                    
                    cmd.CommandText = "INSERT INTO dcomanda VALUES (" + codiComanda + ",'" + codiArticle + "'," + quantitat + "," + preu + "," + rebut + ");";
                    cmd.ExecuteNonQuery();


                }
                catch (Exception)//Proveïdor inexistent a la taula PROVEIDOR. Genera error sobre fitxer XML
                {
                    AfegirError("Article inexistent a la taula ARTICLES " + codiArticle, "INCORPORAR COMANDA");
                   //nO REGISTRE EL MPRIMER CODI
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

        //Falta que es crei el fitxer si no existeix i si existeix fer que lompli
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

        private void proveïdorsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ValidarXML("proveidors", "proveidors");
            ImportarProveidors();
        }

        private void incorporarComandaToolStripMenuItem_Click(object sender, EventArgs e)
        {


            ImportarCapçaleraComanda();

            ImportarDetallComanda();
        }
        
   }
}

