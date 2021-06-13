using System;
using System.Collections.Generic;
using System.Text;

namespace RookieTask.Client.Models
{    public class Logo
    {
        private static int n;

        public int N
        {
            get => n;

            set
            {
                if (value <= 2 || 10000 <= value)
                {
                    throw new Exception("Number must be between 2 and 10,000!");
                }

                n = value;
            }
        }

        public string Result { get; set; }
    }
}
