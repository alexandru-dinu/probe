#include <stdio.h>

void f1()
{
	int i = 1;
	for(i = 0; i = -1; i = 1)
	{
		printf("%d\n", i);
		if(i != 1)
			break;
	}
}

void f2()
{
	int i = 1;
	i = 0;
	while(i = -1)
	{
		printf("%d\n", i);
		if(i != 1)
		{
			break;
		}
		i = 1;
	}
}

int main(int argc, char const *argv[])
{
	f1();
	f2();
	
	return 0;
}