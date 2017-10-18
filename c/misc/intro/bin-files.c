/*
Generati un fisier binar care sa contina un numar n de numere intregi. 
n se va citi de la tastatura si cele n numere se vor genera random. 
In fisierul de output afisati doar cele n numere intregi generate. 
Numele fisierului generat se va citi de asemenea de la tastatura.
*/

#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int main(void)
{
	FILE *f, *g;

	srand(time(NULL));

	f = fopen("bin", "wb");
	if(!f)
	{
		printf("Fisierul nu a putut fi deschis!\n");
		exit(1);
	}

	int n;
	printf("n = ");
	scanf("%d", &n);

	while(n)
	{
		int rnd = rand() % 26 + 97;
		fwrite(&rnd, sizeof(int), 1, f);	

		n--;
	}

	fclose(f);

	g = fopen("bin", "rb");
	fseek(g, 0, SEEK_END);
	int tell = ftell(g);

	tell = tell / sizeof(int);
	rewind(g);

	int i;
	int x;
	for(i = 0; i < tell; i++)
	{
		fread(&x, sizeof(int), 1, g);
		printf("%d ", x);
	}
	printf("\n");

	return 0;
}