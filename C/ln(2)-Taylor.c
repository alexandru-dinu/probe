#include <stdio.h>
#include <math.h>

#define N 10001

double rec(int p)
{
	return 1 / (double)p;
}

int main()
{
	int i;
	double s = 0;

	for(i = 1; i <= N; i++)
	{
		s += pow(-1, i + 1) * rec(i);
	}

	printf("ln(2) ~ %lf\n", s);
	printf("Err = %lf\n", fabs(log(2) - s));

	return 0;
}