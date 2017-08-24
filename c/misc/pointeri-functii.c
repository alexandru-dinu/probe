#include <stdio.h>
#include <time.h>

#define MAX 100
#define lowerB 1
#define upperB 100

void generare(int *v, int n)
{
	int i;

	srand(time(NULL));

	for(i = 0; i < n; i++)
		*(v+i) = rand()%(upperB - lowerB) + lowerB;
}

/*
int* generare2(int n)
{
	int i, v[MAX];

	for(i = 0; i < n; i++)
		*(v+i) = rand()%(upperB - lowerB) + lowerB;

	return v;
}
// in main:
	v = generare2(MAX);
*/

void afisare(int *v, int n)
{
	int i;

	for(i = 0; i < n; i++)
	{
		printf("v[%d] = %d\n", i, *v + i);
	}
}

int min(int *v, int n)
{
	int *s, *e; //s = start, e = end
	int min;

	for(s = v, e = v + n, min = *v; s < e; s++)
	{
		if(*p < min)
			min = *p;
	}

	return min;
}

int main(void)
{
	int v[MAX] = {1,2,6,4,1,2,5,8,-1,10};

	printf("Min = %d\n", min(v,10));

	return 0;
}