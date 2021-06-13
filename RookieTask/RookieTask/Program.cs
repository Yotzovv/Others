using RookieTask.Client.Controllers;
using RookieTask.Client.Interfaces;
using RookieTask.Client.Models;
using System;
using System.Text;

namespace RookieTask
{

    class Program
    {
        static void Main(string[] args)
        {
            ILogoController logoController = new LogoController();

            var logo = new Logo()
            {
                N = int.Parse(Console.ReadLine())
            };

            int dashesCount = 1;
            int starsCount = 2 * (logo.N - 1) + 1;

            for (int loop = 0; loop < logo.N + 1; loop++)
            {
                var middle = (logo.N + 1) / 2;
                var dashesRepetition = (logo.N - loop) > 0 ? (logo.N - loop) : 0;
                Console.WriteLine($"{dashesRepetition}, {middle}, {starsCount}, {dashesCount}, {logo.N}, {loop}");

                var row = logoController.ConstructRow(dashesRepetition, middle, ref starsCount, ref dashesCount, logo.N, loop);

                logo.Result += row;
            }

            Console.Write(logo.Result);
        }      
    }
}