#include <stdio.h>

int sumaDivN(int param)
{
	int i;
	int sdn = 0;
	for(i = 2; i <= param/2; i++)
	{
		if(param % i == 0)
			sdn += i;
	}
	
	return sdn;
}

int main(void)
{
	int N;
	printf("Introdu n: \n");
	scanf("%d", &N);
	
	if(N < 2)
		printf("N invalid");
	else
	{
		int i;
		int max = sumaDivN(N);
		int indice = N;
		for(i = N - 1; i >= 2; i--)
		{
			if(sumaDivN(i) > max)
			{
				max = sumaDivN(i);
				indice = i;
			}
		}
	
		printf("%d are suma %d \n", indice, max);
	}
	
	return 0;
}
