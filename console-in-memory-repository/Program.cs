using Console_in_memory_repository.Enums;
using Console_in_memory_repository.Helpers;
using Console_in_memory_repository.Screens;
using System;

namespace Console_in_memory_repository
{
    class Program
    {
        static void Main(string[] args)
        {
            EMenu opcao;
            do
            {
                opcao = MenuScreen.GetUserSelection();
                switch(opcao)
                {
                    case EMenu.GetAll:
                        SeriesScreen.GetAll();
                        break;
                    case EMenu.New:
                        SeriesScreen.Create();
                        break;
                    case EMenu.Detail:
                        SeriesScreen.Detail();
                        break;
                    case EMenu.Update:
                        SeriesScreen.Update();
                        break;
                    case EMenu.Delete:
                        SeriesScreen.Delete();
                        break;
                }
            } while (opcao != EMenu.Exit);
        }
    }
}
