#include <stdio.h>
#include <math.h>

#define MAX_CONVERSION_SIZE 1024
typedef unsigned int MAX_TYPE_SIZE;

//Algoritm de conversie B10 in oricare baza < 10
//----------
MAX_TYPE_SIZE base_convert(long long param, short base)
{
	MAX_TYPE_SIZE vector[MAX_CONVERSION_SIZE];
	MAX_TYPE_SIZE pTb = 0; 
	MAX_TYPE_SIZE i = 0;
	MAX_TYPE_SIZE j;

	while (param)
	{
		vector[i] = abs(param % base);
		param /= base;
		i++;
	}

	for (j = 0; j < i; j++)
	{
		pTb = pTb * 10 + vector[i - 1 - j];
	}

	return pTb;
}
//----------

//Algoritm de conversie B2 in B10
//----------
MAX_TYPE_SIZE binaryTOdec(long long param)
{
	MAX_TYPE_SIZE vector[MAX_CONVERSION_SIZE];
	MAX_TYPE_SIZE i, j;
	MAX_TYPE_SIZE dec = 0;
	int bits = log10(param) + 1; //calculeaza nr de biti din secventa
	
	for(i = 0; i < bits; i++)
	{
		int aux = param % 10;
		vector[i] = aux;
		param /= 10;
		dec = dec  + aux * pow(2, i);
	}
	
	return dec;
}
//----------

int main(void)
{
	unsigned int numarB2, numarB10;
	
	printf("Introduceti un numar in B10, urmat de un altul in B2: \n");
	scanf("%d %d", &numarB10, &numarB2);

	printf("%d din B10 in B2: %d \n", numarB10, base_convert(numarB10, 2));
	printf("%d din B2 in B10: %d \n", numarB2, binaryTOdec(numarB2));
	return 0;
}
