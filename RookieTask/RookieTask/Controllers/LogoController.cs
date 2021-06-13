using RookieTask.Client.Interfaces;
using System;

namespace RookieTask.Client.Controllers
{
    public class LogoController : ILogoController
    {
        public string ConstructRow(int dashesRepetition, int middle, ref int starsCount, ref int dashesCount, int n, int loop)
        {
            var row = new string('-', dashesRepetition);

            if (loop < middle)
            {
                if (loop >= 1)
                {
                    starsCount = n + 2 * loop;
                    dashesCount = n - 2 * loop;
                }
                else
                {
                    starsCount = n + loop;
                    dashesCount = n - loop;
                }

                row += new string('*', starsCount);
                row += new string('-', dashesCount);
                row += new string('*', starsCount);

            }
            else
            {
                row += new string('*', n);
                row += new string('-', dashesCount);
                dashesCount += 2;
                row += new string('*', starsCount);
                starsCount -= 2;
                row += (new string('-', dashesCount - 2) + new string('*', n));
            }

            row += new string('-', dashesRepetition);
            row += row + Environment.NewLine;

            return row;
        }
    }
}
