using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace apListaLigada
{
  public partial class FrmAlunos : Form
  {
    ListaDupla<Forca> lista1 =  new ListaDupla<Forca>();



    public FrmAlunos()
    {
      InitializeComponent();
    }

    private void btnLerArquivo1_Click(object sender, EventArgs e)
    {


    }

    private void FazerLeitura(ref ListaDupla<Forca> qualLista)
    {
  
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                ListaDupla<Forca> novalista = new ListaDupla<Forca>();
                var arquivo = new StreamReader(dlgAbrir.FileName);
                while (!arquivo.EndOfStream)
                {
                    var linhaLida = arquivo.ReadLine();
                    var novoAluno = new Aluno(linhaLida);
                }
                arquivo.Close();
               // lista1.Listar(lsbUm);
            }

            // instanciar a lista de palavras e dicas
            // pedir ao usuário o nome do arquivo de entrada
            // abrir esse arquivo e lê-lo linha a linha
            
            // e inseri-0lo no final da lista duplamente ligada
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRA.Text) && !string.IsNullOrWhiteSpace(txtNome.Text))
            {
                var palavra = new Palavra(txtRA.Text.Trim());
                var dica = new Dica(txtNome.Text.Trim());

                var novaForca = new Forca(palavra, dica);
                if (!lista1.Existe(novaForca))
                {
                    lista1.InserirAposFim(novaForca);
                }
            }
        }



  private void btnBuscar_Click(object sender, EventArgs e)
  {
      // se a palavra digitada não é vazia:
      // criar um objeto da classe de Palavra e Dica para busca
      // se a palavra existe na lista1, posicionar o ponteiro atual nesse nó e exibir o registro atual
      // senão, avisar usuário que a palavra não existe
      // exibir o nó atual
      if (txtRA != null)
      {
                if (!lista1.Existe(new Forca(new Palavra(txtRA.Text), new Dica(txtNome.Text))))
                {
                    throw new Exception("não existe essa palavra");
                }
      } 
  }

    private void btnExcluir_Click(object sender, EventArgs e)
    {
            // para o nó atualmente visitado e exibido na tela:
            // perguntar ao usuário se realmente deseja excluir essa palavra e dica
            // se sim, remover o nó atual da lista duplamente ligada e exibir o próximo nó
            // se não, manter como está

            if (lista1.Atual != null)
            {
                    lista1.Atual.Info.Dica = new Dica(" ");
                lista1.Atual.Info.Palavra    = new Palavra(" ");

                MessageBox.Show("Dica excluida com sucesso!", "excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

		private void FrmAlunos_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (dlgSalvar.ShowDialog() == DialogResult.OK)
			{
				try
				{
					using (StreamWriter esc = new StreamWriter(dlgSalvar.FileName))
					{
						var atual = lista1.Primeiro;
						while (atual != null)
						{
							string palavra = atual.Info.Palavra.ToString().PadRight(30);
							string dica = atual.Info.Dica.ToString();

							esc.WriteLine(palavra + dica);
							atual = atual.Prox;
						}
					}
				}
				catch (Exception ex)
				{
                    throw new Exception("erro");
				}
			}
		}

		private void ExibirDados(ListaDupla<Forca> aLista, ListBox lsb, Direcao qualDirecao)
        {

          lsb.Items.Clear();
          var dadosDaLista = aLista.Listagem(qualDirecao);
          foreach (Forca forca in dadosDaLista)
            lsb.Items.Add(forca);
        }

    private void tabControl1_Enter(object sender, EventArgs e)
    {
      rbFrente.PerformClick();
    }

    private void rbFrente_Click(object sender, EventArgs e)
    {
      ExibirDados(lista1, lsbDados, Direcao.paraFrente);
    }

    private void rbTras_Click(object sender, EventArgs e)
    {
      ExibirDados(lista1, lsbDados, Direcao.paraTras);
    }

    private void FrmAlunos_Load(object sender, EventArgs e)
    {
            //fazer a leitura do arquivo escolhido pelo usuário e armazená-lo na lista1
            // posicionar o ponteiro atual no início da lista duplamente ligada
            // Exibir o Registro Atual;

			if (dlgAbrir.ShowDialog() == DialogResult.OK)  
			{
				using (StreamReader arquivo = new StreamReader(dlgAbrir.FileName))
				{
					string linha = "";

					while (!arquivo.EndOfStream)
					{
						var linhaLida = arquivo.ReadLine();

						if (!string.IsNullOrWhiteSpace(linhaLida))
						{
							string textoPalavra = linhaLida.Length >= 30 ? linhaLida.Substring(0, 30).Trim() : linhaLida.Trim();
							string textoDica = linhaLida.Length > 30 ? linhaLida.Substring(30).Trim() : ""; 

							var palavra = new Palavra(textoPalavra);
							var dica = new Dica(textoDica);
							var novaForca = new Forca(palavra, dica);
							lista1.InserirAposFim(novaForca);
						}
					}
                    if (lista1 != null)
                    {
                        lista1.PosicionarNoInicio();
                        txtRA.Text = lista1.Atual.Info.Palavra.ToString();
                        txtNome.Text = lista1.Atual.Info.Dica.ToString();
                    }
                }
			}

		}

    private void btnInicio_Click(object sender, EventArgs e)
    {
			// posicionar o ponteiro atual no início da lista duplamente ligada
			// Exibir o Registro Atual;
			if (lista1 != null)
			{
				lista1.PosicionarNoInicio();
                txtRA.Text = lista1.Atual.Info.Palavra.ToString();
				txtNome.Text = lista1.Atual.Info.Dica.ToString();    
			}
		}

    private void btnAnterior_Click(object sender, EventArgs e)
    {
			// Retroceder o ponteiro atual para o nó imediatamente anterior 
			// Exibir o Registro Atual;

			if (lista1 != null && lista1.Atual != null)
			{
				lista1.Retroceder(); 
				if (lista1.Atual != null)
				{
					txtRA.Text = lista1.Atual.Info.Palavra.ToString();
					txtNome.Text = lista1.Atual.Info.Dica.ToString();
				}

			}
		}

    private void btnProximo_Click(object sender, EventArgs e)
    {
            // Retroceder o ponteiro atual para o nó seguinte 
            // Exibir o Registro Atual;
            
			if (lista1 != null)
			{
				lista1.Avancar();
				txtRA.Text = lista1.Atual.Info.Palavra.ToString();
				txtNome.Text = lista1.Atual.Info.Dica.ToString();

			}
		}

    private void btnFim_Click(object sender, EventArgs e)
    {
			// posicionar o ponteiro atual no último nó da lista 
			// Exibir o Registro Atual;
			if (lista1 != null)
			{
				lista1.PosicionarNoFinal();
				txtRA.Text = lista1.Atual.Info.Palavra.ToString();
				txtNome.Text = lista1.Atual.Info.Dica.ToString();
			}
		}

    private void ExibirRegistroAtual()
    {
      // se a lista não está vazia:
      // acessar o nó atual e exibir seus campos em txtDica e txtPalavra
      // atualizar no status bar o número do registro atual / quantos nós na lista
      if (lista1 != null)
      {
			txtRA.Text = lista1.Atual.Info.Palavra.ToString();
	        txtNome.Text = lista1.Atual.Info.Dica.ToString();   
      }
    }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lista1.Atual != null)
            {
                string novaDica = txtNome.Text.Trim();

                if (!string.IsNullOrEmpty(novaDica))
                {
                    lista1.Atual.Info.Dica = new Dica(novaDica);
                }

            }
        }

    private void btnSair_Click(object sender, EventArgs e)
    {
			if (dlgSalvar.ShowDialog() == DialogResult.OK)
			{
				try
				{
					using (StreamWriter esc = new StreamWriter(dlgSalvar.FileName))
					{
						var atual = lista1.Primeiro;
						while (atual != null)
						{
							string palavra = atual.Info.Palavra.ToString().PadRight(30);
							string dica = atual.Info.Dica.ToString();

							esc.WriteLine(palavra + dica);
							atual = atual.Prox;
						}
					}
				}
				catch (Exception ex)
				{
					throw new Exception("erro");
				}
			}
            Close();
		}

    private void btnCancelar_Click(object sender, EventArgs e)
    {
            txtNome.Text = "";
            txtRA.Text = "";
    }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tpForca_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button40_Click(object sender, EventArgs e)
        {

        }
    }
}
