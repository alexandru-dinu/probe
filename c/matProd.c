#include <stdio.h>
#include <stdlib.h>

#define MAX 100

//A x B = C
int inmultireMatrice(int A[MAX][MAX], int m1, int n1, int B[MAX][MAX], int m2, int n2, int C[MAX][MAX])
{
	int i, j, k;

	int sumaC = 0; //suma curenta de produse

	if(n1 != m2)
	{
		printf("!err\n");
		return -1;
	}

	for(i = 0; i < m1; i++)
	{
		for(j = 0; j < n2; j++)
		{
			sumaC = 0;

			for(k = 0; k < m2; k++)
			{
				sumaC += A[i][k] * B[k][j];
			}

			C[i][j] = sumaC;
		}
	}

}

int main(void)
{

	int m1, n1, m2, n2;

	scanf("%d", &m1);
	scanf("%d", &n1);
	scanf("%d", &m2);
	scanf("%d", &n2);

	int A[MAX][MAX], B[MAX][MAX], C[MAX][MAX];

	int i, j;

	for(i = 0; i < m1; i++)
	{
		for(j = 0; j < n1; j++)
		{
			scanf("%d", &A[i][j]);
		}
	}

	for(i = 0; i < m2; i++)
	{
		for(j = 0; j < n2; j++)
		{
			scanf("%d", &B[i][j]);
		}
	}

	inmultireMatrice(A, m1, n1, B, m2, n2, C);

	printf("----------\n");

	for(i = 0; i < m1; i++)
	{
		for(j = 0; j < n2; j++)
		{
			printf("%d ", C[i][j]);
		}
		printf("\n");
	}
	return 0;
}
