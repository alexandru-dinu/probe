#include <stdio.h>

int f(int *n, int *k)
{
	n = k;

	return *n;
}

int main(void)
{
	int n = 10;
	int k = 18;

	printf("%d\n", f(&n, &k));
	return 0;
}