using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_curs_5
{
   public class Recursive
    {
        public List<Orase> Solve(List<Orase> orase)
        {
            var finalRoute = new List<Orase>();

            var currentCityIndex = 0;
            var firstCity = orase[currentCityIndex];
            finalRoute.Add(firstCity);

            finalRoute = SolveRecursive(orase, finalRoute, currentCityIndex);

            return finalRoute;
        }
        public List<Orase> SolveRecursive(List<Orase> orase, List<Orase> finalRoute, int currentCityIndex)
        {
            if (finalRoute.Count == orase.Count)
            {
                return finalRoute;
            }
            else
            {
                var currentCity = orase[currentCityIndex];

                var minDistance = double.PositiveInfinity;
                var minDistanceCity = new Orase();

                for (int nextCityIndex = 0; nextCityIndex < orase.Count; nextCityIndex++)
            {
                    if (currentCityIndex != nextCityIndex)
                    {
                        var nextCity = orase[nextCityIndex];
                        var foundCity = finalRoute.Find(c => c.Numarul_de_orase == nextCity.Numarul_de_orase);
                        if (foundCity == null)
                        {
                            var distance = math.GetDistance(currentCity, nextCity);
                            if (distance < minDistance)
                            {
                                minDistance = distance;
                                minDistanceCity = nextCity;
                            }}}
 }
                if (minDistance != double.PositiveInfinity)
                {
                    finalRoute.Add(minDistanceCity);
                    currentCityIndex = minDistanceCity.Numarul_de_orase - 1;
                    return SolveRecursive(orase, finalRoute, currentCityIndex);
                }
            }

            return finalRoute;
        }
    }
}
