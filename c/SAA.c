#include<stdio.h>
#include<time.h>
#include<math.h>

float rec(float p)
{
	return 1/p;
}

int main(void)
{
	unsigned int n;
	int i;
	
	float start, end;
	
	printf("How many terms?\n");
	scanf("%d",&n);
	
	double sum = 0;

	start = clock();
	{
		for(i = 1; i <= n; i++)
		{
			sum += (pow((-1), i - 1) * rec(i));
		}
	}
	end = clock();

	printf("Sum: %f \n", sum);
	printf("Au trecut %f secunde.\n", (end - start) / CLOCKS_PER_SEC);

	return 0;
}
