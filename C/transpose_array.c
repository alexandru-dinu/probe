#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define LIN 3
#define COL 4

void printArr(int** arr, int lin, int col)
{
	int i, j;
	for(i = 0; i < lin; i++)
	{
		for(j = 0; j < col; j++)
		{
			printf("%d\t", arr[i][j]);
		}
		printf("\n");
	}
}

int** transpose(int** arr, int lin, int col)
{
	int i, j;

	//just print the transpose
	/*
	for(i = 0; i < col; i++)
	{
		for(j = 0; j < lin; j++)
		{
			printf("%d\t", arr[j][i]);
		}
		printf("\n");
	}
	*/

	int **trArr;
	trArr = malloc(col * sizeof(int));

	for(i = 0; i < col; i++)
	{
		trArr[i] = malloc(lin * sizeof(int));
	}

	for(i = 0; i < col; i++)
	{
		for(j = 0; j < lin; j++)
		{
			trArr[i][j] = arr[j][i];
		}
	}

	return trArr;
}

void freeMem(int **arr, int pos)
{
	int i;
	for(i = 0; i < pos; i++)
	{
		free(arr[i]);
	}
	free(arr);
}

int main(int argc, char const *argv[])
{
	int** arr;
	arr = malloc(LIN * sizeof(int));
	if(!arr)
	{
		perror("malloc");
		exit(1);
	}

	int i, j;
	for(i = 0; i < LIN; i++)
	{
		arr[i] = malloc(COL * sizeof(int));
		if(!arr[i])
		{
			perror("malloc");
			freeMem(arr, i);
			exit(1);
		}
	}

//fill array
	srand(time(NULL));
	for(i = 0; i < LIN; i++)
	{
		for(j = 0; j < COL; j++)
		{
			arr[i][j] = rand() % 100 + 1;
		}
	}

	printf("Matrix is:\n");
	printArr(arr, LIN, COL);

	printf("Transposed matrix is:\n");
	int** trArr = transpose(arr, LIN, COL);
	printArr(trArr, COL, LIN);

	//freeMem(arr, LIN);
	return 0;
}