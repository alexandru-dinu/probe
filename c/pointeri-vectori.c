#include <stdio.h>
#include <time.h>

#define MIN 10
#define MAX 100

//genereaza aleator n elemente si le punte in v, intre min si max
void genVect(int *v, int n, int min, int max)
{
	int i;

	srand(time(NULL));
	
	for(i = 0; i < n; i++)
	{
		v[i] = rand() % (max - min) + min;
	}
}

//calculeaza si afiseaza valoarea maxima si pozitia acesteia din v
void pozMax(int *v, int n)
{
	int max = v[0];
	int i;
	int poz;

	for(i = 0; i < n; i++)
	{
		if(v[i] > max)
		{
			max = v[i];
			poz = i;
		}
	}

	printf("Valoarea maxima din v este %d si apare pe pozitia %d.\n", max, poz);
}

//returneaza media aritmetica a elementelor vectorului
float medAritmetica(int *v, int n)
{
	int sum = 0;
	int i;

	for(i = 0; i < n; i++)
	{
		sum += v[i];
	}

	return (float)sum / n;
}

//returneaza numarul elementelor mai mari decat media aritmetica a vectorului
int elGTmed(int *v, int n)
{
	int i;
	int nrE = 0;

	int med = medAritmetica(v, n);

	for(i = 0; i < n; i++)
	{
		if(v[i] > med)
			nrE++;
	}

	return nrE;
}

void shiftLeft(int *v, int n, int pos)
{
	int k;

	for(k = pos; k < n; k++)
	{
		v[k] = v[k + 1];
	}
}

//elimina elementele din v1 care apar si in v2
//intoarce numarul de elemente ramase
int elimDuplicate(int *v1, int n1, int *v2, int n2)
{
	int i, j;
	int count = 0;

	for(i = 0; i < n1; i++)
	{
		for (j = 0; j < n2; j++)
		{
			if(v1[i] == v2[j])
			{
				shiftLeft(v1, n1, i);
				i--;
				n1--;
				count++;
				break;
			}
		}
	}

	return count;
}

int main(void)
{
	int n, v[100];
	int i;

	printf("dim(v): ");
	scanf("%d", &n);

	//p0
	genVect(v, n, MIN, MAX);

	printf("----------\n");

	for(i = 0; i < n; i++)
	{
		printf("v[%d] = %d \n", i, v[i]);
	}

	printf("----------\n");

	//p1
	pozMax(v,n);

	//p2
	printf("Media aritmetica a elementelor vectorului este %.3f.\n", medAritmetica(v, n));

	//p3
	printf("Numarul elementelor mai mari decat media aritmetica este %d.\n", elGTmed(v, n));

	printf("----------\n");

	//p4
	int v1[100] = {4, 6, 6, 6, 7, 10, 9, 1}; 
	int v2[100] = {6, 8, 9, 5};

	int NEl = 8 - elimDuplicate(v1, 8, v2, 4);
	printf("Numarul de elemente ramase in v1 este %d:\n", NEl);

	int w;
	for(w = 0; w < NEl; w++)
	{
		printf("v1[%d] = %d\n", w, v1[w]);
	}

	return 0;
}