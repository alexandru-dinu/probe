#include <stdio.h>
#include <stdlib.h>

int copyFile(FILE *dest, FILE *source)
{
	fseek(source, 0L, SEEK_END);
	int source_elem = ftell(source) / sizeof(int);
	rewind(source);

	int i;
	for(i = 0; i< source_elem; i++)
	{
		int x;
		fread(&x, sizeof(int), 1, source);
		fwrite(&x, sizeof(int), 1, dest);
	}
	
	return 0;
}

int main(int argc, char const *argv[])
{
	if (argc != 3)
	{
		printf("usage: ./a.out source_file dest_file\n");
		exit(1);
	}
	
	FILE *source = fopen(argv[1], "rb");
	FILE *dest = fopen(argv[2], "wb");

	copyFile(dest, source);

	fclose(source);
	fclose(dest);

	return 0;
}