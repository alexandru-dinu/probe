//put a matrix in the heap

#include <stdio.h>
#include <stdlib.h>

#define ROWS 3
#define COLS 3

int** allocMat(int rows, int cols)
{
	int **mat;
	int i, j;

	mat = (int**) malloc(rows * sizeof(int*));
	//!err
	if(!mat)
		return NULL;
	//!--

	for(i = 0; i < rows; i++)
	{
		mat[i] = (int*) malloc(cols * sizeof(int));
		//!err
		if(!mat[i])
		{
			for(j = 0; j < i; j++)
			{
				free(mat[j]);
				mat[j] = NULL;
			}
			free(mat);
			return NULL;
		}
		//!--
	}
	return mat;
}

int main(void)
{
	int **mat;
	int i, j;

	mat = allocMat(ROWS, COLS);

	//read
	for(i = 0; i < ROWS; i++)
	{
		for(j = 0; j < COLS; j++)
		{
			scanf("%d", &mat[i][j]);
		}
	}

	//write
	for(i = 0; i < ROWS; i++)
	{
		for(j = 0; j < COLS; j++)
		{
			printf("%d ", mat[i][j]);
		}
		printf("\n");
	}

	return 0;
}
