#include <stdio.h>
#include <stdlib.h>

typedef enum {
	FALSE, TRUE
} bool;

bool parity(int n)
{
	if(!(n % 2))
		return TRUE;
	else
		return FALSE;
}

int main(void)
{
	int x;
	printf("x = ");
	scanf("%d", &x);

	parity(x) ? printf("%d is even.\n", x) : printf("%d is odd.\n", x);

	return 0;
}