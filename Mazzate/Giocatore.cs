using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mazzate
{

    public enum Colore
    {
        rosso,
        blu,
        giallo,
        verde
    }

    public class Giocatore
    {

        public Giocatore (Colore id, List<Guerriero> lGuerrieri) {
            colore = id;
            listaGuerrieri = lGuerrieri;
        }
        
        public void creaGuerrieri(int nGuerrieri)
        {
            for (int j = 0; j < nGuerrieri; j++)
            {
                listaGuerrieri.Add(new Guerriero(100, 100));
            }
            return;
        }

        public Colore colore { get; set; }
        List<Guerriero> listaGuerrieri = new List<Guerriero>();
    }



}
