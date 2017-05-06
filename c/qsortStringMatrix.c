#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#define MAX 100

int ordCrescLen(const void* a, const void* b)
{
	char **x = (char**)a;
	char **y = (char**)b;

	if(strlen(*x) == strlen(*y))
		return (strcmp(*x,*y));
	else
		return strlen(*x) - strlen(*y);
}

int ordCrescAlph(const void* a, const void* b)
{
	char **x = (char**)a;
	char **y = (char**)b;

	return (strcmp(*x,*y));
}

int main(void)
{
	char **arr;
	char buffer[MAX];
	int n, i = 0;

	printf("n = ");
	scanf("%d", &n);
	getchar();

	arr = (char**) malloc((n + 1) * sizeof(char*));
	if(!arr)
	{
		printf("malloc err!\n");
		return -1;
	}

	while(i < n)
	{
		fgets(buffer, MAX, stdin);

		if(buffer[strlen(buffer) - 1] == '\n')
		{
			buffer[strlen(buffer) - 1] = '\0';
		}

		arr[i] = strdup(buffer);
		i++;
	}

	qsort(arr, n, sizeof(char*), ordCrescAlph);

	for(i = 0; i < n; i++)
	{
		puts(arr[i]);
	}

	return 0;
}
