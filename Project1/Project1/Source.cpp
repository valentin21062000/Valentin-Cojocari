#include <iostream>
#include <fstream>
#include <vector>
using namespace std;
ifstream In("C:\\Users\\valen\\source\\repos\\Project1\\Project1\\in.txt");
ofstream Out("C:\\Users\\valen\\source\\repos\\Project1\\Project1\\out.txt");
int a, k=0, c=0, v[100], s[100], n, i, aux, t[100], tp;
void red(int a)
{
    for (i = a; i < n - 1; i++)
    {
        v[i] = v[i + 1];
        s[i] = s[i + 1];
    }
    
    
}


void minge(int aux, int m)
{
    for (i = 0; i < m; i++)
    {
        if (aux > v[i])
        {
            aux = v[i];
            a = i;

        }

    }
    tp = v[a] + s[a];
    aux = tp;
    c = c + 1;
    Out <<"Spectacolul "<<c<<" incepe la ora: "<< v[a] << "    Se termina la ora: " << tp << "\n";

}

int main()
{
    In >> n;
    Out << n << "\n";
   for (i = 0; i < n; i++)
        In >> v[i] >> s[i];
   for (i = 0; i < n; i++)
       Out << v[i] << " " << s[i] << "\n";
   Out << "\n";
   aux = v[0];
   k = n-1;
   while (k != 1)
   {
       minge(aux, k);
       red(a);
       k = k - 1;
       
   }
   Out.close();
       return 0;
}