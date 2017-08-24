#include <stdio.h>
#include <stdlib.h>

#define N 5

typedef struct
{
	int nr;
	int ap;
	int uniq;
}TOcc;

int compare(const void* a, const void* b) 
{
	int *x = (int*)a;
	int *y = (int*)b;

	return *x - *y;
}

TOcc *nrOfOcc(int *v)
{
	TOcc *T = calloc(N, sizeof(TOcc));

	int i, k = 0;
	T[k].nr = v[0];
	for(i = 0; i < N; i++)
	{
		if(T[k].nr == v[i])
		{
			T[k].ap++;
		}
		else
		{
			k++;
			T[k].nr = v[i];
			i--;
		}

	}
	T[0].uniq = k;

	return T;
}

int main(int argc, char const *argv[])
{
	int v[N] = {1, 1, 1, 1, 5};
	qsort(v, N, sizeof(int), compare);

	TOcc *T = nrOfOcc(v);
	int count = T[0].uniq + 1;

	int i;
	printf("Elem\tOcc\n");
	for(i = 0; i < count; i++)
	{
		printf("%d\t%d\n", T[i].nr, T[i].ap);
	}

	return 0;
}