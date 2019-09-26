using System;
using System.Collections.Generic;
using System.Text;

namespace AssessmentMatematica
{
    public class Caminhao
    {
        public Caminhao()
        {
            Placa = new Guid();
            ItemnsCacamba = new Stack<ItemEntrega>();
            PontosDeEntrega = new Queue<Local>();
        }

        public Guid Placa { get; set; }

        public Queue<Local> PontosDeEntrega { get; set; }

        public Stack<ItemEntrega> ItemnsCacamba { get; set; }

        public string ReturnString()
        {
            string resul = "";
            foreach(Local a in PontosDeEntrega)
            {
                foreach(ItemEntrega item in ItemnsCacamba)
                {
                    resul = $"Visitado ponto de entrega {a.Nome}. Foram entregues os itens: \n" +
                        $"{item.Nome} . \n";

                }
            }
            return resul;
        }
    }
}
