using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string urlConsulta = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml";

            DataSet dsRetornaEndereco = new DataSet();
            dsRetornaEndereco.ReadXml(urlConsulta.Replace("@cep", txtCep.Text));

            string retorno = dsRetornaEndereco.Tables[0].Rows[0]["resultado"].ToString();

            if (retorno == "0")
            {
                MessageBox.Show("CEP INVALIDO");
            }
            else
            {
                txtbairro.Text = dsRetornaEndereco.Tables[0].Rows[0]["Bairro"].ToString();
                txtCidade.Text = dsRetornaEndereco.Tables[0].Rows[0]["cidade"].ToString();
                txtLogadouro.Text = dsRetornaEndereco.Tables[0].Rows[0]["logradouro"].ToString();
                txtTipoLogadouro.Text = dsRetornaEndereco.Tables[0].Rows[0]["tipo_logradouro"].ToString();
                txtUF.Text = dsRetornaEndereco.Tables[0].Rows[0]["uf"].ToString();
            }
        }
    }
}
