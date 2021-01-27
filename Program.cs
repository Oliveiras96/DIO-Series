using System;

namespace DIO.Series
{
    class Program
    {
        
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":

                        ListarSeries();
                        break;
                    
                    case "2":

                        InserirSerie();
                        break;
                    
                    case "3":

                        AtualizaSerie();
                        break;
                    
                    case "4":

                        ExcluirSerie();
                        break;
                    
                    case "5":

                        VisualizarSerie();
                        break;
                    
                    case "C":

                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario(); 
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();    
        }


        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
            }

            // Lista série:
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2} ", serie.retornaId(), serie.retornaTitulo(), (excluido ? "(*Excluido*)" : ""));
            }

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            Serie novaSerie = criaSerie(repositorio.ProximoId());           
            repositorio.Insere(novaSerie);
        }

        private static void AtualizaSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Serie atualizaSerie = criaSerie(indiceSerie);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie.ToString());
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!!!");
            
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualiza série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        // Método para criar uma nova série com base em um Id passado:
        public static Serie criaSerie(int serieId)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();


            // Cria um novo objeto série para armazenar no repositório;
            Serie serie = new Serie(id: serieId,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            return serie;
        }
    }
}

