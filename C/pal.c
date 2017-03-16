#include <stdio.h>

int pal(int param)
{
	int inv = 0;
	int param_c = param;
	
	while(param)
	{
		inv = inv*10 + param % 10;
		param /= 10;
	}
	
	if(inv == param_c)
		return 1;
	else return 0;
}

int main(void)
{
	int n;
	
	printf("Introdu n: \n");
	scanf("%d", &n);
	
	if(pal(n))
		printf("%d este palindrom. \n", n);
	else
		printf("%d nu este palindrom. \n", n);
	
	return 0;
}
