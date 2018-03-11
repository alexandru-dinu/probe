#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int main()
{
	char *s1 = strdup("alexandru");
	FILE *f = fopen("bin", "wb");

	fwrite(s1, sizeof(char), strlen(s1), f);
	fclose(f);

	f = fopen("bin", "rb");

	char c;
	int test;

	while(test = (int)fread(&c, sizeof(char), 1, f))
	{
		//putc(c, stdout);
		printf("%d\n", test);
	}
	printf("%d\n", test);

	return 0;
}