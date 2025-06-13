using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Palavra : IComparable<Palavra>, IRegistro,
					  ICriterioDeSeparacao<Palavra>
{ 


    const int tamanhoPalavra = 30;
    string textoPalavra;

	bool[] acertou;



    public string TextoPalavra
    {
        get => textoPalavra;
        set
        {
            if (value != "")
                textoPalavra = value.PadRight(tamanhoPalavra, ' ').Substring(0, tamanhoPalavra);
            else
                throw new Exception("texto vazio é inválido.");
        }

    }

	public bool[] Acertou { get => acertou; set => acertou = value; }

	public Palavra(string textoPalavra)
	{
		TextoPalavra = textoPalavra;

		acertou = new bool[TextoPalavra.Length];
		for (int i = 0; i < TextoPalavra.Length; i++)
		{
			if (TextoPalavra[i] == ' ')
				acertou[i] = true; 
			else
				acertou[i] = false;
		}
	}


	public char[] separarPalavra()
	{
		string textoLimpo = textoPalavra.TrimEnd(' ');
		acertou = new bool[textoLimpo.Length];

		for (int i = 0; i < textoLimpo.Length; i++)
		{
			acertou[i] = textoLimpo[i] == ' ';
		}

		return textoLimpo.ToCharArray();
	}


	public Char[] separarPalavraSemEspacos()
	{
		string textoSemEspaco = textoPalavra.Replace(" ", "").TrimEnd();
		return textoSemEspaco.ToCharArray();
	}

	public char[] separarPalavraComEspacos()
	{
		return TextoPalavra.ToCharArray();
	}


	public bool DeveSeparar()
	{
		throw new NotImplementedException();
	}

	public int CompareTo(Palavra other)
	{
		throw new NotImplementedException();
	}

	public string FormatoDeArquivo()
	{
		throw new NotImplementedException();
	}
	public override string ToString()
	{
		return textoPalavra;
	}

	public void InicializarAcertou()
	{
		string textoLimpo = textoPalavra.TrimEnd(' ');
		acertou = new bool[textoLimpo.Length];
		for (int i = 0; i < textoLimpo.Length; i++)
			acertou[i] = textoLimpo[i] == ' '; // espaços já "acertados"
	}

	// Método para retornar o array de letras SEM modificar o Acertou
	public char[] GetLetras()
	{
		return textoPalavra.TrimEnd(' ').ToCharArray();
	}
}

	