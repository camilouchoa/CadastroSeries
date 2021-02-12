using System;

namespace CadastroSeries
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();

            while(opcaoUsuario.ToUpper () != "X")
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
                        AtualizarSerie();
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

                opcaoUsuario = obterOpcaoUsuario();
            }

            Console.WriteLine("Será sempre bem vindo em nosso serviço.");
            Console.ReadLine();
        }  


            private static string obterOpcaoUsuario ()
            {
                Console.WriteLine ();
                Console.WriteLine("Bem vindo ao Programa de cadastro de séries");
                Console.WriteLine("Informe uma das opções abaixo:");
                Console.WriteLine("1- Listar Séries");
                Console.WriteLine("2- Inserir nova série");
                Console.WriteLine("3- Atualizar Série");
                Console.WriteLine("4- Deletar Série");
                Console.WriteLine("5- Visualizar dados da Série");

                string opcao = Console.ReadLine();

                return opcao;
            }
            private static void InserirSerie()
            {
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }

                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Título da Série: " );
                string entradaTitulo= Console.ReadLine();

                Console.Write("Digite o Ano de Início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new Serie (id: repositorio.ProximoId(), 
                                                genero: (Genero)entradaGenero, 
                                                titulo: entradaTitulo, 
                                                ano: entradaAno, 
                                                descricao: entradaDescricao);

             repositorio.Inserir(novaSerie);   

            }
            private static void ListarSeries ()
            {

                Console.WriteLine ("Listar séries");

                var lista = repositorio.Lista();

                if (lista.Count == 0 ) 
                {

                    Console.WriteLine ("Nenhuma série encontrada");;
                    return;
                }

                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    
                     Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "'Excluido'" : "");
                }
                     

            }

            private static void AtualizarSerie ()
            {
                Console.WriteLine ("Digite o id da série" );

                int indiceSerie = int.Parse(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }

                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Título da Série: " );
                string entradaTitulo= Console.ReadLine();

                Console.Write("Digite o Ano de Início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie atualizaSerie = new Serie (id: indiceSerie, 
                                                genero: (Genero)entradaGenero, 
                                                titulo: entradaTitulo, 
                                                ano: entradaAno, 
                                                descricao: entradaDescricao);

                repositorio.Atualizar (indiceSerie, atualizaSerie);
            }

            private static void ExcluirSerie ()
            {
                Console.WriteLine("Digite o id da Série ");
                int indiceSerie = int.Parse(Console.ReadLine());

                repositorio.Excluir(indiceSerie);

            }

            private static void VisualizarSerie()
            {
                Console.WriteLine("Digite o id da Série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                var serie = repositorio.RetornoPorId(indiceSerie);

                Console.WriteLine(serie);
            }


        
    }
}
