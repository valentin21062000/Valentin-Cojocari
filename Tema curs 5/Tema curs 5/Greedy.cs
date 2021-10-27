using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tema_curs_5
{
    public class Greedy
    {
        public List<Orase> Solve(List<Orase> cities)
        {
            var finalRoute = new List<Orase>();
            List<int> unvisitedCities = new List<int>();//cities not visited in a single trial
            List<int> allCities = new List<int>();//all cities for resetting the unvisited cities list
            for (int i = 0; i < cities.Count; i++)
            {
                unvisitedCities.Add(i);
                allCities.Add(i);
            }
            bool notDone = true;
            int startPosition = 0;
            while (notDone)
            {
                notDone = false;
                int currentPosition = startPosition;
                finalRoute.Add(cities[currentPosition]);
                unvisitedCities.Remove(currentPosition);

                for (int i = 0; i < cities.Count - 1; i++)
                {
                    int minPathIndex = -1;
                    double minPathDistance = double.PositiveInfinity;
                    for (int j = 0; j < unvisitedCities.Count; j++)
                    {
                        double currentDistance = math.GetDistance(cities[currentPosition], cities[unvisitedCities[j]]);
                        if (currentDistance < minPathDistance)
                        {
                            minPathDistance = currentDistance;
                            minPathIndex = unvisitedCities[j];
                        }
                    }
                    if (minPathDistance == double.PositiveInfinity)
                    {
                        finalRoute.Clear();
                        unvisitedCities = new List<int>(allCities);
                        startPosition++;
                        notDone = true;
                        break;
                    }
                    else // Start again with the minPathIndex
                    {
                        unvisitedCities.Remove(minPathIndex);
                        currentPosition = minPathIndex;
                        finalRoute.Add(cities[currentPosition]);
                    }
                }
                if (math.GetDistance(cities[currentPosition], cities[startPosition]) == double.PositiveInfinity)
                {
                    finalRoute.Clear();
                    unvisitedCities = new List<int>(allCities);
                    startPosition++;
                    notDone = true;
                }
            }
            return finalRoute;
        }

        public List<Orase> SolveSimpler(List<Orase> cities)
        {
            var finalRoute = new List<Orase>();
            var currentCityIndex = 0;
            var firstCity = cities[currentCityIndex];
            finalRoute.Add(firstCity);
            while (finalRoute.Count != cities.Count)
            {
                var currentCity = cities[currentCityIndex];
                var minDistance = double.PositiveInfinity;
                var minDistanceCity = new Orase();
                for (int nextCityIndex = 0; nextCityIndex < cities.Count; nextCityIndex++)
                {
                    if (currentCityIndex != nextCityIndex)
                    {
                        var nextCity = cities[nextCityIndex];
                        var foundCity = finalRoute.Find(c => c.Numarul_de_orase == nextCity.Numarul_de_orase);
                        if (foundCity == null)
                        {
                            var distance = math.GetDistance(currentCity, nextCity);
                            if (distance < minDistance)
                            {
                                minDistance = distance;
                                minDistanceCity = nextCity;
                            }
                        }
                    }
                }

                if (minDistance != double.PositiveInfinity)
                {
                    finalRoute.Add(minDistanceCity);
                    currentCityIndex = minDistanceCity.Numarul_de_orase - 1;
                }
            }

            return finalRoute;
        }
    }
}