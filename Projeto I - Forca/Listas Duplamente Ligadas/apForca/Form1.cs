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
                    // para cada linha, criar um objeto da classe de Palavra e Dica
                    //lista1.InserirAposFim(novoAluno);
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
      // se o usuário digitou palavra e dica:
      // criar objeto da classe Palavra e Dica para busca
      // tentar incluir em ordem esse objeto na lista1
      // se não incluiu (já existe) avisar o usuário
      if (!lista1.Existe(new Forca(new Palavra(txtRA.Text), new Dica(txtNome.Text)))) 
      {
                lista1.InserirEmOrdem(new Forca(new Palavra(txtRA.Text), new Dica(txtNome.Text)));
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
            } // tem que fazer o compare das classes
      }
    }

    private void btnExcluir_Click(object sender, EventArgs e)
    {
      // para o nó atualmente visitado e exibido na tela:
      // perguntar ao usuário se realmente deseja excluir essa palavra e dica
      // se sim, remover o nó atual da lista duplamente ligada e exibir o próximo nó
      // se não, manter como está
    }

    private void FrmAlunos_FormClosing(object sender, FormClosingEventArgs e)
    {
      // solicitar ao usuário que escolha o arquivo de saída
      // percorrer a lista ligada e gravar seus dados no arquivo de saída
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
				lista1.Retroceder(); // Retrocede para o nó anterior

				// Verifica se o ponteiro "atual" não é nulo
				if (lista1.Atual != null)
				{
					// Exibe os dados do nó atual
					txtRA.Text = lista1.Atual.Info.Palavra.ToString();
					txtNome.Text = lista1.Atual.Info.Dica.ToString();
				}
				else
				{
					MessageBox.Show("Você chegou ao início da lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // alterar a dica e guardar seu novo valor no nó exibido
            if (lista1.Atual != null)
            {
                // Obtém o valor digitado no campo da dica
                string novaDica = txtNome.Text.Trim();

                if (!string.IsNullOrEmpty(novaDica))
                {
                    // Altera a dica do objeto Forca armazenado no nó atual
                    lista1.Atual.Info.Dica = new Dica(novaDica);

                    MessageBox.Show("Dica atualizada com sucesso!", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

    private void btnSair_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {

    }

		
	}
}
