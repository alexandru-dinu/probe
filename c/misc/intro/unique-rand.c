#include <stdlib.h>
#include <stdio.h>
#include <time.h>

#define MOD 10
#define n 10

int main(void)
{
	srand(time(NULL));

	int *v;
	int i, j = 0;
	int r;

	v = malloc(n * sizeof(int));

	v[0] = rand() % MOD;

	for(i = 1; i < n; i++)
	{
		init: r = rand() % MOD;

		for(j = 0; j < i; j++)
		{
			if(v[j] == r)
				goto init;
		}

		v[i] = r;
	}

	for (i = 0; i < n; i++)
	{
		printf("%d\n", v[i]);
	}
	printf("\n");

	return 0;
}