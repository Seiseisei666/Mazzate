using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mazzate
{

    public enum TipoDanno
    {
        taglio,
        perforazione,
        impatto
    }

    public enum CategoriaArma
    {
        scudo = 0,
        manoSingola,
        manoDoppia,
        lunga,
        daLancio,
        daTiro,
    }

    public class Arma
    {
        public Arma(CategoriaArma tArma, TipoDanno tDanno, int vel, int fat)
        {
            tipoArma = tArma;
            tipoDanno = tDanno;
            velocita = vel;
            fatica = fat;
            //lunghezza =
            // Non ci serve: l'enum è già un numero! (deve essere castato esplicitamente però)

        }


        int velocita, fatica;

        public int Velocità { get { return velocita; } }
        public int Fatica { get { return fatica; } }
        public TipoDanno tipoDanno { get; protected set; }
        public CategoriaArma tipoArma { get; protected set; }
        public int lunghezza { get { return (int)tipoArma; } }
    }

}
