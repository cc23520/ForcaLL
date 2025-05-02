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
    public Palavra(string textoPalavra)
    {

        TextoPalavra = textoPalavra;

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
}

