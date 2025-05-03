using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Forca : IComparable<Forca>, IRegistro,
					  ICriterioDeSeparacao<Forca>
{
	private Dica dica;
	private Palavra palavra;

	public Forca(Palavra palavra,Dica dica)
	{
		this.palavra = palavra;
		this.dica = dica;
	}

	public Dica Dica { get => dica; set => dica = value; }
	public Palavra Palavra { get => palavra; set => palavra = value; }

	public int CompareTo(Forca other)
	{
		throw new NotImplementedException();
	}

	public bool DeveSeparar()
	{
		throw new NotImplementedException();
	}

	public string FormatoDeArquivo()
	{
		throw new NotImplementedException();
	}

	public override string ToString()
	{
		return $"Palavra: {palavra.ToString()}, Dica: {dica.ToString()}";
	}
}

