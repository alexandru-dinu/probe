#include <stdio.h>
#include <math.h>

int prim(int x)
{
	int i;
	for(i = 2; i <= sqrt(x); i++)
	{
		if(x % i == 0)
		{
			return 0;
			break;
		}
	}
	return 1;
}

int main()
{
	int n, nrOfPrimes = 0;
	scanf("%d", &n);
	
	while(n > 0)
	{
		if(prim(n)) //Daca n este prim, afisam asta si incrementam nr total de nr prime
		{
			printf("PRIM \n");
			nrOfPrimes++;
			
			scanf("%d", &n);
		}
		else //Daca n nu este prim, afisam divizorii sai nebanali
		{
			int i;
			for(i = 2; i <= n/2; i++)
			{
				if(n % i == 0)
					printf("%d ", i);
			}
			printf("\n");
			
			scanf("%d", &n);
		}
		
	}
	
	printf("S-au gasit %d numere prime. \n", nrOfPrimes);
	
	return 0;
}
