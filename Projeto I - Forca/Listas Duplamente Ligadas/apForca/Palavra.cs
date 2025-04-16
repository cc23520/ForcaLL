using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Palavra
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


}

