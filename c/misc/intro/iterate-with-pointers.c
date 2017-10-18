#include <stdio.h>

#define MAX 100

int strlength(char *s)
{
	int L = 0;
	char* p;

	for(p = s; *p != '\0'; p++)
		L++;

	return L;
}

void f1(int a[MAX][MAX], int m, int *rez)
{
	int *p, *w;

	for(p = a[0], w = a[0] + m - 1; 
		p < a[0] + m * MAX, w < a[0] + m * MAX; 
		p += MAX + 1, w += MAX - 1)
	{
		rez[0] += *p; //suma de pe Dp;
		rez[1] += *w;	//suma de pe Ds;
	}
}

int f2(int a[MAX][MAX], int m, int n, int *rez)
{
	int suma;

	int *p, *w;
	int count = 0;

	for(p = a[0]; p < a[0] + m * MAX; p += MAX)
	{
		suma = 0;

		for(w = p ; w < p + n; w++)
		{
			suma += *w;
		}	
		if(suma >= 0)
		{
			//printf("%d\n",suma);
			rez[count] = (p - a[0]) / MAX;
			count++;
		}
	}

	return count;
}

int main(void)
{
	//1.
	int x = 5;

	char *p = (char*) &x;

	if((*p) == 0)
		printf("Little endian\n");
	else
		printf("Big endian\n");

	printf("----------\n");
	//---

	//2.
	char c[3]={'a','b','c'};
	printf("Lungimea sirului c este %d\n",strlength(c));

	printf("----------\n");
	//---

	//3.
	int m1, a[MAX][MAX], rez1[2] = {0, 0};
	int i, j;

	printf("Introduceti dim. matricei: \n");
	scanf("%d", &m1);

	for(i = 0; i < m1; i++)
	{
		for(j = 0; j < m1; j++)
		{
			scanf("%d", &a[i][j]);
		}
	}

	f1(a, m1, rez1);

	printf("Suma Dp = %d, Ds = %d\n", rez1[0], rez1[1]);

	printf("----------\n");
	//---

	//4.
	int m2, n2, b[MAX][MAX], rez2[MAX];
	int k;

	printf("Introduceti m2, n2: ");
	scanf("%d%d", &m2, &n2);

	for(i = 0; i < m2; i++)
	{
		for(j = 0; j < n2; j++)
		{
			scanf("%d", &b[i][j]);
		}
	}

	int count = f2(b, m2, n2, rez2);

	printf("Indicii liniilor din matrice care au suma elementelor > 0: \n");
	for(k = 0; k < count; k++)
	{
		printf("%d\n", rez2[k]);
	}

	printf("----------\n");
	//---

	return 0;
}