#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
	int *p = malloc(10 * sizeof(int));
	if(p)
		printf("malloc success!\n");
	else
		exit(1);

	int *q = realloc(p, 20 * sizeof(int));
	if(q)
	{
		printf("malloc success!\n");
		p = q;
		free(q);
		q = NULL;
	}	
	else
		exit(1);

	int i;
	srand(time(NULL));
	for(i = 0; i < 20; i++)
	{
		p[i] = rand() % 100;
		printf("%d\n", p[i]);
	}

	return 0;
}
