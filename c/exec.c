#include <stdio.h>
#include <time.h>
#include <math.h>

int prime(int N)
{
	int i;
	
	for (i = 2; i <= sqrt(N); i += 1)
	{
		if(N % i == 0)
		{
			return 0;
			break;
		}
	}
	return 1;
}

int main(void)
{
	float start, end;
	
	int n = 10000;
	int k = 2;
	
	start = clock();
	{ //Code you want to see how long it takes to process
		while(n)
		{
			if(prime(k))
			{
				//printf("%d \n", k);
				k++;
				n--;
			}
			else
			{
				k++;
			}
		}
	}
	end = clock();
	
	printf("This took %f seconds. \n", (end - start) / CLOCKS_PER_SEC);
	return 0;
}
