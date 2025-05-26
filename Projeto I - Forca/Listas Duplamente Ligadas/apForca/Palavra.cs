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
	bool[] acertou = new bool[tamanhoPalavra];



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
	public bool separarPalavra(char letra)
	{
		int contadorDeTrue = 0;
		char[] letras = textoPalavra.ToCharArray();
		for ( int i = 0; i <tamanhoPalavra; i++)
		{
			if (letras[i] == letra)
			{
				acertou[i] = true;
				contadorDeTrue++;
			}
		}

		if (contadorDeTrue > 0)
		{
			return true;
		}
		return false;
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

	