using Console_in_memory_repository.Enums;
using Console_in_memory_repository.Helpers;
using System;

namespace Console_in_memory_repository.Screens
{
    public static class MenuScreen
    {
        public static EMenu GetUserSelection()
        {
            Console.Clear();
            Console.WriteLine("Selecione a opção desejada");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1 - Listar as séries");
            Console.WriteLine("2 - Incluir uma série");
            Console.WriteLine("3 - Alterar uma série");
            Console.WriteLine("4 - Excluir uma série");
            Console.WriteLine("5 - Detalhar uma série");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();

            return EnumHelpers.GetByValue<EMenu>(InputHelpers.GetIntegerValue("Infome a opção: ", 0, 5));
        }
    }
}
