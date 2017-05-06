/*This is a good example of accessing a structure from another structure
as well as manipulating data with them.*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

#define MAX 2
#define MAX_CHR 3

//length, width, height
typedef struct {
	float L, W, H;
} TDim;

//contains details for each geometrical form
typedef struct {
	char *id; // each geometrical form has a unique id
	float volume;
	TDim *dim;
} TForm;

TForm* FormAlloc()
{
	TForm *F = malloc(MAX * sizeof(TForm));

	int i;
	for(i = 0; i < MAX; i++)
	{
		F[i].id = malloc(MAX_CHR * sizeof(char));
		F[i].dim = malloc(MAX * sizeof(TDim));
	}

	return F;
}

float volume(int x, int y, int z)
{
	return x * y * z;
}

void append(char *s, char c)
{
	int len = strlen(s);
	s[len] = c;
	s[len + 1] = '\0';
}

int main()
{
	TForm *F = FormAlloc();

	int i;
	for(i = 0; i < 2; i++)
	{
		F[i].id = strdup("F");
		append(F[i].id, (char) i + 49);

		printf("%s:\n", F[i].id);

		printf("Length: ");
		scanf("%f", &F[i].dim->L);

		printf("Width: ");
		scanf("%f", &F[i].dim->W);

		printf("Height: ");
		scanf("%f", &F[i].dim->H);

		F[i].volume = volume(F[i].dim->L, F[i].dim->W, F[i].dim->H);
	}

	for(i = 0; i < MAX; i++)
	{
		printf("%s has volume %.2f.\n", F[i].id, F[i].volume);
	}
	

	return 0;
}