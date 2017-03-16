#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <time.h>

#define MAX 2 * 1024 * 1024 //2MB

#define CHK(assertion) \
	if(assertion) \
		{ \
			fprintf(stderr, "error!\n"); \
			exit(1); \
		} \

char *strdup(const char *s);

char *createString(FILE *f)
{
	char *aux = malloc(MAX * sizeof(char));
	CHK(!aux);

	int i = 0;
	while((aux[i++] = fgetc(f)) != EOF);
	aux[i] = '\0';

	char *str = realloc(aux, (i + 1) * sizeof(char));
	aux = NULL;

	return str;
}

void rmChar(char *str, char c)
{
	char *src, *dest;

	// both pointers point to the first char of input
	src = dest = str;    
	// exit loop when null terminator reached
	while(*src != '\0')   
	{
		// if source is not a 'c' char and it is printable
    	if (*src != c && isprint(*src)) 
   		{
   			// copy the char at source to destination
        	*dest = *src;
        	// increment destination pointer
        	dest++;       
    	}
    	// increment source pointer
    	src++;
	}
	// terminate string with null terminator 
	*dest = '\0';          
}

void rmSpaceSel(char *str)
{
	int qt = 0;
	char *src, *dest;

	src = dest = str;   
	while(*src != '\0')   
	{
    	if (*src == '"')  
        	qt++;    

    	if((qt % 2 == 1) || 
    		(qt % 2 == 0 && (isdigit(*src) || !isblank(*src))))
    	{
    		*dest = *src;
    		dest++;
    	}
    	src++;        
	}
	*dest = '\0';          
}

void removeGarbage(char *str, char* garbage)
{
	int i; 
	int len = strlen(garbage);

	for(i = 0; i < len; i++)
	{
		rmChar(str, garbage[i]);
	}
}

int main(int argc, char const *argv[])
{
	clock_t start, end;
	start = clock();
//--
	if (argc != 3)
	{
		printf("usage: ./cvt input output\n");
	}

	FILE *input = fopen(argv[1], "rt");
	CHK(!input);

	FILE *output = fopen(argv[2], "wt");
	CHK(!output);

	char *str = createString(input);

	removeGarbage(str, "{}[]:,\n");
	rmSpaceSel(str);

	int nrEntries = 0;

	char **arr = malloc((strlen(str) + 1) * sizeof(char*));
	CHK(!arr);
	
	int i = 0;

	char *p = strtok(str, "\"");
	char *firstField = (char*) strdup(p);

	while(p)
	{
		arr[i++] = (char*) strdup(p);

		if(!strcmp(firstField, p) && (i % 2 == 1)) //egale
			nrEntries++;

		p = strtok(NULL, "\"");
	}

	int dist = i / nrEntries; //distance between equal fields
	int nrFields = dist / 2;

	int j, k;

	//insert first line / fields names
	for(j = 0; j < nrFields; j++)
	{
		fprintf(output, "%s,", arr[2 * j]);
	}
	fprintf(output, "\n");

	//insert corresponding values
	for(j = 0; j < nrEntries; j++)
	{
		for(k = 0; k < nrFields; k++)
		{	
			fprintf(output, "%s,", arr[j * dist + 2 * k + 1]);
		}
		if (j != nrEntries - 1)
		{
			fprintf(output, "\n");
		}
	}	
//--
	free(str);
	for(j = 0; j < i; j++)
	{
		free(arr[j]);
	}
	free(arr);
	free(firstField);
	fclose(input);
	fclose(output);
	
	end = clock();
	printf("%f\n", (double) (end - start) / CLOCKS_PER_SEC);
	return 0;
}