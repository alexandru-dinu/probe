#include<stdio.h>
#include<time.h>

int main(void)
{
	int x = 0;

	srand(time(NULL)); //generam un seed (x0)

	int i;

	for(i = 1; i<=6; i++)
	{
		x = (rand()%48) + 1; //x e in [1,49]
		printf("%d\n", x); //afisam x
	}

return 0;
}

//random in [a,b] -> rand()%(b-a) + a
