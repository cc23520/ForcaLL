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

    }
	public Char[] separarPalavra()
	{
		acertou = new bool[textoPalavra.TrimEnd(' ').Length]; 
		int contadorDeTrue = 0;
		char[] letras = textoPalavra.Trim(' ').ToCharArray();
		return letras;
	}

	public Char[] separarPalavraSemEspacos()
	{
		char[] letras = textoPalavra.TrimEnd(' ').ToCharArray();
		return letras;
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
}

	