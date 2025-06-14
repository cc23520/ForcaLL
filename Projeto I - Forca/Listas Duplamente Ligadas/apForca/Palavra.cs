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
		string txtL = textoPalavra.TrimEnd(' ');
		acertou = new bool[txtL.Length];

		for (int i = 0; i < txtL.Length; i++)
		{
			acertou[i] = txtL[i] == ' ';
		}

		return txtL.ToCharArray();
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

	public void IniciaAcertos()
	{
		string txtL = textoPalavra.TrimEnd(' ');
		acertou = new bool[txtL.Length];
		for (int i = 0; i < txtL.Length; i++)
			acertou[i] = txtL[i] == ' ';
	}

	public char[] GetLetras()
	{
		return textoPalavra.TrimEnd(' ').ToCharArray();
	}
}

	