using Console_in_memory_repository.Data;
using Console_in_memory_repository.Entities;
using Console_in_memory_repository.Enums;
using Console_in_memory_repository.Helpers;
using System;

namespace Console_in_memory_repository.Screens
{
    public static class SeriesScreen
    {
        public static void GetAll()
        {
            Console.Clear();
            Console.WriteLine("Lista das séries cadastradas");
            Console.WriteLine("============================");
            Console.WriteLine();
            var list = SeriesRepository.GetInstance().getAll();
            if (list.Count > 0)
            {
                foreach(var serie in list)
                {
                    Console.WriteLine(serie.ToListString());
                }
            }
            else
            {
                Console.WriteLine("************** Nenhum série foi encontrada cadastrada **************");
            }
            Console.WriteLine();
            Console.WriteLine("Pressiona qualquer tecla para voltar ao menu principal");
            Console.ReadLine();
        }

        public static void Create()
        {
            Console.Clear();
            Console.WriteLine("Cadastrar uma nova série");
            Console.WriteLine("============================");
            Console.WriteLine();

            var name = InputHelpers.GetRequiredValue("Informe um nome para a série: ");
            var category = InputHelpers.GetValidEnumValue<ECategories>("Categorias disponíveis", "Informe o código da categoria desejada: ", 1, 13);

            var repository = SeriesRepository.GetInstance();
            var id = repository.GetNextId();
            var serie = new Series(id, name, category, true);
            repository.Save(serie);

            Console.WriteLine();
            Console.WriteLine("Pressiona qualquer tecla para voltar ao menu principal");
            Console.ReadLine();
        }

        public static void Delete()
        {
            var repository = SeriesRepository.GetInstance();
            Console.Clear();
            Console.WriteLine("Exclusão de uma série");
            Console.WriteLine("============================");
            Console.WriteLine();
            var id = InputHelpers.GetIntegerValue("Qual o id da série para excluir: ", 1, repository.GetNextId() - 1);
            var serie = repository.getById(id);

            Console.Clear();
            Console.WriteLine("Exclusão de uma série");
            Console.WriteLine("============================");
            Console.WriteLine();
            
            if (serie.Active)
            {
                Console.WriteLine(serie.ToString());
                Console.WriteLine();

                if (InputHelpers.GetBooleanValue("Confirma a exclusão dessa série?"))
                {
                    repository.Delete(id);
                    Console.WriteLine();
                    Console.WriteLine("Séria excluída com sucesso!");
                }
            } 
            else
            {
                Console.WriteLine("Séria já está excluída!");
            }

            Console.WriteLine();
            Console.WriteLine("Pressiona qualquer tecla para voltar ao menu principal");
            Console.ReadLine();
        }

        public static void Detail()
        {
            var repository = SeriesRepository.GetInstance();
            Console.Clear();
            var id = InputHelpers.GetIntegerValue("Qual o id da série para detalhar: ", 1, repository.GetNextId() - 1);

            var serie = repository.getById(id);

            Console.Clear();
            Console.WriteLine("Detalhamento de uma série");
            Console.WriteLine("============================");
            Console.WriteLine();
            Console.WriteLine(serie.ToString());

            Console.WriteLine();
            Console.WriteLine("Pressiona qualquer tecla para voltar ao menu principal");
            Console.ReadLine();
        }

        public static void Update()
        {
            var repository = SeriesRepository.GetInstance();
            Console.Clear();
            Console.WriteLine("Atualizar uma série");
            Console.WriteLine("============================");
            Console.WriteLine();
            var id = InputHelpers.GetIntegerValue("Qual o id da série para alterar: ", 1, repository.GetNextId() - 1);
            var oldSerie = repository.getById(id);

            if (oldSerie.Active)
            {
                Console.Clear();
                Console.WriteLine("Atualizar uma série");
                Console.WriteLine("============================");
                Console.WriteLine();
                Console.WriteLine(oldSerie.ToString());
                Console.WriteLine();

                var name = InputHelpers.GetRequiredValue($"Informe um novo nome para a série: ");
                var category = InputHelpers.GetValidEnumValue<ECategories>("Categorias disponíveis", "Informe o código da categoria desejada: ", 1, 13);

                var newSerie = new Series(id, name, category, true);
                repository.Update(id, newSerie);
            }
            else
            {
                Console.WriteLine("Séria já está excluída!");
            }

            Console.WriteLine();
            Console.WriteLine("Pressiona qualquer tecla para voltar ao menu principal");
            Console.ReadLine();
        }

    }
}
