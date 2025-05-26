using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dica   : IComparable<Dica>, IRegistro,
					  ICriterioDeSeparacao<Dica>

{
    const int tamanhoTexto = 32767;
    string textoDica;





    public string Texto
    {
        get => textoDica;
        set
        {
            if (value != "")
                textoDica = value.PadRight(tamanhoTexto, ' ').Substring(0, tamanhoTexto);
            else
                throw new Exception("texto vazio é inválido.");
        }
    }

    public Dica( string textoDica)
    {
       
        Texto = textoDica;
        
    }

	public int CompareTo(Dica other)
	{
		throw new NotImplementedException();
	}

	public string FormatoDeArquivo()
	{
		throw new NotImplementedException();
	}

	public bool DeveSeparar()
	{
		throw new NotImplementedException();
	}
	public override string ToString()
	{
		return Texto;
	}
}

