/*Gives details about the contents of a text file*/

#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <ctype.h>

int main(int argc, char* argv[])
{
	if(argc != 2)
		return -1;

	FILE *f;

	f = fopen(argv[1], "rt");
	if(!f) {
		return -1;
	}

	int count = 0;
	int blanks = 0;
	int newlines = 0;
	int digits = 0;
	int letters = 0;

	while(!feof(f)) 
	{
		char c = fgetc(f);

		//Implicit, un fisier text gol contine doar indicatorul EOF
		if(c != EOF && c != '\n') 
			count++;
		if(isdigit(c))
			digits++;
		if(isalpha(c))
			letters++;
		if(c == ' ')
			blanks++;
		if (c == '\n')
			newlines++;
	}

	printf("Chars (w/o EOF): %d\nBlanks: %d\nNewlines (w/o EOF): %d\nDigits: %d\nLetters: %d\nSpecial chars: %d\n", 
		count, blanks, newlines - 1, digits, letters, count - digits - letters);

	fclose(f);

	return 0;
}