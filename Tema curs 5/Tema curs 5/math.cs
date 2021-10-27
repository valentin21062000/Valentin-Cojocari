using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_curs_5
{      public class math
        {
            public static double GetDistance(Orase oras1, Orase oras2)
            {
                return Math.Sqrt(Math.Pow(oras2.x - oras1.x, 2) + Math.Pow(oras2.y - oras1.y, 2));
            }
        }  }
