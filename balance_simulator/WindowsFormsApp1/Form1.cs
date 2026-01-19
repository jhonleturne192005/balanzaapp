using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        decimal peso_plato = 2.5M; //en kg
        decimal peso_actual = 0.0M;
        decimal peso_bruto = 0.0M;
        decimal peso_tara = 0.0M;

        decimal peso_aumentar = 0.10M;
        csWebSocket csWebSocketclass;
        JSONConfig joc;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnPonerPlato.Enabled = true;
            btnQuitarPlato.Enabled = false;
            txtPeso.Enabled = false;
            csWebSocketclass = new csWebSocket();
            joc = new JSONConfig();
            csWebSocketclass.init();
            //csWebSocket.dataUser = joc.createJson(peso_actual.ToString(), peso_bruto.ToString(), peso_tara.ToString());
            csAPI csapi = new csAPI(Aumentar,Disminuir,Tara);
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            /*if (txtPeso.Text.Trim().Equals(""))
            {
                lblPeso.Text = "0 KG";
                return;
            }

            lblPeso.Text=txtPeso.Text.Trim()+" KG";
            float peso= float.Parse(txtPeso.Text.Trim());
            peso_actual+= peso;
            peso_bruto+= peso;
            peso_tara+= peso;*/
        }

        private void btnPonerPlato_Click(object sender, EventArgs e)
        {
            decimal peso = peso_plato + peso_actual;
            btnPonerPlato.Enabled = false;
            btnQuitarPlato.Enabled = true;
            lblPeso.Text = peso+" KG";
            peso_actual+= peso_plato;
            peso_bruto+= peso_plato;
            peso_tara+= peso_plato;
            txtPeso.Text = peso_bruto.ToString();
            Dat();
        }

        private void btnQuitarPlato_Click(object sender, EventArgs e)
        {
            btnPonerPlato.Enabled = true;
            btnQuitarPlato.Enabled = false;
            lblPeso.Text = (peso_bruto - peso_plato).ToString() + " KG";
            //
            peso_actual = peso_bruto-peso_plato;
            peso_bruto -= peso_plato;
            peso_tara -= peso_plato;

            txtPeso.Text = peso_bruto.ToString();
            Dat();
        }

        private void btnTara_Click(object sender, EventArgs e)
        {
            Tara();
        }

        private void btn_aumentar_Click(object sender, EventArgs e)
        {
            Aumentar();
        }

        private void btn_disminuir_Click(object sender, EventArgs e)
        {
            Disminuir();
        }

        private void Dat()
        {
            //MessageBox.Show(peso_actual.ToString("0.00") +"");
            lblPesoDat.Text = peso_actual+" KG";
            lblPesoBrutoDat.Text = peso_bruto+" KG";
            lblPesoTaraDat.Text = peso_tara+ " KG";

            Task.Run(() => csWebSocket.sendMessageSocket(joc.createJson(peso_actual.ToString(), peso_bruto.ToString(), peso_tara.ToString())));
        }


        private void Aumentar()
        {
            if(txtPeso.InvokeRequired)
            {
                Console.WriteLine("Estamos en el subproceso");

                //ejecuta en el proceso principal
                Invoke(new Action(() =>
                {
                    txtPeso.Text = (peso_bruto + peso_aumentar).ToString();
                    lblPeso.Text = (peso_actual + peso_aumentar).ToString();
                    //
                    peso_actual = peso_actual + peso_aumentar;
                    peso_bruto = peso_bruto + peso_aumentar;
                    peso_tara = peso_tara + peso_aumentar;
                    Dat();
                }));
                return;
            }
            
            txtPeso.Text = (peso_bruto + peso_aumentar).ToString();
            lblPeso.Text = (peso_actual + peso_aumentar).ToString();
            //
            peso_actual = peso_actual + peso_aumentar;
            peso_bruto = peso_bruto + peso_aumentar;
            peso_tara = peso_tara + peso_aumentar;
            Dat();
        }

        private void Disminuir()
        {
            if (txtPeso.InvokeRequired)
            {
                Console.WriteLine("Estamos en el subproceso");

                //ejecuta en el proceso principal
                Invoke(new Action(() =>
                {
                    if (peso_bruto == 0 || peso_actual == 0)
                    {
                        Dat();
                        return;
                    }
                    else
                    {
                        txtPeso.Text = (peso_bruto - peso_aumentar).ToString();
                        lblPeso.Text = (peso_actual - peso_aumentar).ToString();
                        //
                        peso_actual = peso_actual - peso_aumentar;
                        peso_bruto = peso_bruto - peso_aumentar;
                        peso_tara = peso_tara - peso_aumentar;
                        Dat();
                    }
                }));
                return;
            }


            if (peso_bruto == 0 || peso_actual == 0)
            {
                Dat();
                return;
            }
            else
            {
                txtPeso.Text = (peso_bruto - peso_aumentar).ToString();
                lblPeso.Text = (peso_actual - peso_aumentar).ToString();
                //
                peso_actual = peso_actual - peso_aumentar;
                peso_bruto = peso_bruto - peso_aumentar;
                peso_tara = peso_tara - peso_aumentar;
                Dat();
            }
        }


        private void Tara()
        {
            if (txtPeso.InvokeRequired)
            {
                Console.WriteLine("Estamos en el subproceso");

                //ejecuta en el proceso principal
                Invoke(new Action(() =>
                {
                    decimal pesot = peso_bruto - peso_tara;
                    lblPeso.Text = pesot + " KG";
                    peso_actual = pesot;
                    Dat();
                }));
                return;
            }

            decimal peso = peso_bruto - peso_tara;
            lblPeso.Text = peso + " KG";
            peso_actual = peso;
            Dat();
        }



    }
}
