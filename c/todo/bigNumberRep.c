#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX 100

/*
v1 = [Nd|d1.d2...dn|]
*/

//de verificat
int maxD(int a, int b)
{
	if (a > b)
		return a + 1;
	else return b + 1;
}

int sumBig(int *v1, int *v2)
{
	int i;
	int *rez;
	int carry = 0;

	int newD = maxD(v1[0], v2[0]);

	rez = (int*) malloc(newD * sizeof(int));
	rez[0] = newD;

	for (i = 1; i <= newD; i++)
	{
		int aux = v1[i] + v2[i];
		rez[i] = (carry + aux) % 10;

		if(aux + carry >= 10)
			carry = 1;
		else
			carry = 0;
	}

	if(rez[newD] == 0)
		{
			newD--;
			rez[0]--;
		}

	for(i = 0; i <= newD; i++)
	{
		printf("%d", rez[i]);
	}
	printf("\n");
}


int main(void)
{

	int *v1, *v2;
	int i;
	int digits1, digits2;

	char s1[MAX];
	char s2[MAX];

	fgets(s1, MAX, stdin);
	digits1 = strlen(s1) - 1;

	fgets(s2, MAX, stdin);
	digits2 = strlen(s2) - 1;

	v1 = (int*) malloc((digits1 + 1) * sizeof(int));
	v2 = (int*) malloc((digits2 + 1) * sizeof(int));

	v1[0] = digits1;
	v2[0] = digits2;

	//assign
	for(i = 1; i <= digits1; i++)
	{
		v1[i] = s1[digits1 - i] - '0';
	}
	for(i = 1; i <= digits2; i++)
	{
		v2[i] = s2[digits2 - i] - '0';
	}

	/* print the arrays
	for(i = 0; i <= digits1; i++)
	{
		printf("%d", v1[i]);
	}
	printf("\n");
	for (i = 0; i <= digits2; i++)
	{
		printf("%d", v2[i]);
	}
	printf("\n");
	*/

	sumBig(v1, v2);

	return 0;
}
