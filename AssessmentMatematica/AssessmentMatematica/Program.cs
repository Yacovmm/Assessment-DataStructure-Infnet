using System;
using System.Collections.Generic;

namespace AssessmentMatematica
{
    static class Program
    {
        static void Main(string[] args)
        {
            var init = "[1] Inserir ponto de entrega;" +
                        "\n[2] Inserir item de entrega;" +
                        "\n[3] Inserir caminhão;" +
                        "\n[4] Associar item a ponto de entrega; " +
                        "\n[5] Associar ponto de entrega a caminhão;" +
                        "\n[6] Realizar entregas;" +
                        "\n[0] Sair.";

            

            var status = true;
            
            while (status)
            {
                Console.WriteLine(init);
                var input = Console.ReadLine();
                switch (input.ToString())
                {
                    case "1":
                        var local = new Local();
                        Console.WriteLine("Entre com o nomedo local: ");
                        local.Nome = Console.ReadLine();
                        Console.WriteLine("Entre com o identificador: ");
                        local.Identificador = Console.ReadLine();
                        Util.CriarLocal(local);
                        break;
                    case "2":
                        var item = new ItemEntrega();
                        Console.WriteLine("Entre com o nome do Item: ");
                        item.Nome = Console.ReadLine();
                        Util.CriarItemEntrega(item);
                        break;
                    case "3":
                        Util.CriarCaminhao(new Caminhao());
                        break;
                    case "4":
                        Util.ListarPontosDeEntregas();                        
                        Console.WriteLine("Entre com o id do local: ");
                        var idLocal = Console.ReadLine();

                        Util.ListarItens();
                        Console.WriteLine("Entre com o id do Item: ");
                        var idItem = Console.ReadLine();

                        Util.AssociarItemAoLocal(idItem, idLocal);
                        break;
                    case "5":
                        Util.ListarCaminhao();
                        Console.WriteLine("Entre com o Id do caminhao: ");
                        var idCaminhao = Console.ReadLine();

                        Util.ListarPontosDeEntregas();
                        Console.WriteLine("Entre com o Id do Local: ");
                        var idLocal1 = Console.ReadLine();
                        Util.AssociarLocalAoCaminhao(idLocal1, idCaminhao);
                        break;
                    case "6":
                        Util.RealizaEntregas();
                        break;
                    case "0":
                        status = false;
                        break;
                }
            }
        }
    }

    static class Util
    {
        public static Stack<object> Volumes = new Stack<object>();

        public static IDictionary<int, Caminhao> ConjuntoCaminhoes = new Dictionary<int, Caminhao>();

        public static IDictionary<int, Local> PontosDeEntrega = new Dictionary<int, Local>();

        public static IDictionary<int, ItemEntrega> Itens = new Dictionary<int, ItemEntrega>();

        public static void ListarCaminhao()
        {
            if(ConjuntoCaminhoes.Count == 0)
            {
                Console.WriteLine("Nao ha caminhoes");
                return;
            }
            for (int i = 1;i <=ConjuntoCaminhoes.Count; i++)
            {
                Console.WriteLine("Id Caminhao: " + ConjuntoCaminhoes[i]);
                Console.WriteLine("Placa do Caminhao " + "-> " + ConjuntoCaminhoes[i].Placa);
                Console.WriteLine("Quantidade de Itens na caçamba " + "-> " + ConjuntoCaminhoes[i].ItemnsCacamba.Count);
            }
        }

        public static void ListarPontosDeEntregas()
        {
            foreach(Local l in PontosDeEntrega.Values)
            {
                Console.WriteLine("Nome do Lugar " + "-> " + l.Nome);
                Console.WriteLine("Identificador do Lugar " + "-> " + l.Identificador);
            }
        }

        public static void ListarItens()
        {
            foreach (ItemEntrega i in Itens.Values)
            {
                Console.WriteLine("Nome do Item " + "-> " + i.Nome);
                Console.WriteLine("Identificador do Item " + "-> " + i.Identificador);
            }
        }

        internal static void AssociarItemAoLocal(string idItem, string idLocal)
        {
            PontosDeEntrega[int.Parse(idLocal)].ItensParaSerEntregues.Enqueue(Itens[int.Parse(idItem)]);
        }

        internal static void AssociarLocalAoCaminhao(string idLocal, string idCaminhao)
        {
            if(ConjuntoCaminhoes.Count == 0)
            {
                Console.WriteLine("Sem Caminhoes");
                return;
            }
            ConjuntoCaminhoes[int.Parse(idCaminhao)].PontosDeEntrega.Enqueue(PontosDeEntrega[int.Parse(idLocal)]);            
        }

        internal static void CriarCaminhao(Caminhao c)
        {
            ConjuntoCaminhoes.Add((ConjuntoCaminhoes.Count + 1), c);
        }

        internal static void CriarItemEntrega(ItemEntrega item)
        {
            item.Identificador = (Itens.Count + 1).ToString();
            Itens.Add((Itens.Count + 1), item);
        }

        internal static void CriarLocal(Local l)
        {
            l.Identificador = (PontosDeEntrega.Count + 1).ToString();
            PontosDeEntrega.Add((PontosDeEntrega.Count + 1), l);            
        }

        internal static void RealizaEntregas()
        {
            if(ConjuntoCaminhoes.Count <= 1)
            {
                // Co
            }

        }

        //public static IEnumerable<int> PontosEntregaSemCaminhaoAssociado()
        //{
            
        //}

        internal static bool PontosDeEntregaSemCaminhao(int idPontoDeEntrega, int idPontoEntregaCaminhao)
        {
            return idPontoDeEntrega != idPontoEntregaCaminhao;
        }
    }
}
