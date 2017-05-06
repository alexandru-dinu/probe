#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(void)
{

	FILE *f, *g;

	f = fopen("in", "rt");
	if(!f)
	{
		printf("Fisierul nu s-a putut deschide!\n");
		exit(1);
	}

	g = fopen("tmp", "wt");
	if(!g)
	{
		printf("Fisierul nu s-a putut crea!\n");
		exit(1);
	}

	char nume1[30];
	char nume2[30];
	printf("Nume: ");
	scanf("%s", nume1);
	printf("Prenume: ");
	scanf("%s", nume2);
	

	float nota;
	printf("Nota dorita: ");
	scanf("%f", &nota);

	while(!feof(f))
	{
		char tmp_nume1[30];
		char tmp_nume2[30];
		float tmp_nota;

		fscanf(f, "%s%s%f", tmp_nume1, tmp_nume2, &tmp_nota);

		if(!feof(f))
		{
			fprintf(g, "%s ", tmp_nume1);
			fprintf(g, "%s ", tmp_nume2);
			if(!strcmp(tmp_nume1, nume1) && !strcmp(tmp_nume2, nume2))
				fprintf(g, "%.1f\n", nota);
			else
				fprintf(g, "%.1f\n", tmp_nota);
		}
	}

	fclose(f);
	fclose(g);
	rename("tmp", "in");
	return 0;
}
