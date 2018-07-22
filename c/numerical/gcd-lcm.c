#include <stdio.h>

int gcd(int a, int b)
{
	while(a != b)
	{
		if(a > b)
			a = a - b;
		else
			b = b - a;
	}
	return b;
}

int main(void)
{
	int a,b;
	
	printf("Give me two numbers: ");
	scanf("%d %d", &a, &b);
	
	printf("GCD of %d and %d is: %d \n", a, b, gcd(a,b));
	printf("LCM of %d and %d is: %d \n", a, b, (a*b)/gcd(a,b));

	return 0;
}
