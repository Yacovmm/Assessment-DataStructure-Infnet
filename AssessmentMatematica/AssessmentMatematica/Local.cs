using System.Collections.Generic;

namespace AssessmentMatematica
{
    public class Local
    {
        public Local()
        {
            ItensParaSerEntregues = new Queue<ItemEntrega>();
        }

        public string Identificador { get; set; }

        public string Nome { get; set; }

        public Queue<ItemEntrega> ItensParaSerEntregues { get; set; }

    }
}