#include <stdio.h>
#include <time.h>

int main(void)
{
	int contor = 3;
	int start;

	while(contor) {
		printf("%d\n",contor);
		contor--;
		start = clock();
		while(clock() < start + CLOCKS_PER_SEC);
	}

	printf("start\n");
}

// 1 secunda = start -> start + clocks_per_second
