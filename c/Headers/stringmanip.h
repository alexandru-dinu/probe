/*Useful header for basic string manipulations*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

//replace cnk1 with cnk2 in str
void replaceChunks(char *str, char *cnk1, char *cnk2)
{
    char *pos;
    int clen1 = strlen(cnk1), clen2 = strlen(cnk2);

    pos = strstr(str, cnk1);
    while(pos)
    {
        memmove(pos + clen2, pos + clen1, strlen(pos) - clen1 + 1);
        memcpy(pos, cnk2, clen2);
        pos = strstr(str, cnk1);
    }
}

//converts a string into integer, ignoring other characters
int _atoi(char *s)
{
	int len = strlen(s);
	int number = 0;
	int i;

	for(i = 0; i < len; i++)
	{
		if(s[i] >= '0' && s[i] <= '9')
			number = number * 10 + s[i] - '0';
	}

	return number;
}

//lowercases a string
void lwrCase(char *str)
{
	int i;
	for(i = 0; i < strlen(str); i++)
	{
		str[i] = tolower(str[i]);
	}
}

//uppercases a string
void uprCase(char *str)
{
	int i;
	for(i = 0; i < strlen(str); i++)
	{
		str[i] = toupper(str[i]);
	}
}

//returns an index from where str1 and str2 start to differ
int differPoint(char *str1, char *str2)
{
	int point = 0;
	int i = 0;

	while(tolower(str1[i]) == str2[i])
	{
		point++;
		i++;
	}

	if(point == strlen(str2))
		return point;
	else return 0;
}

//appends c to s
void append(char* s, char c)
{
        int len = strlen(s);
        s[len] = c;
        s[len+1] = '\0';
}

//returns the number of occurences of needle in haystack
//traditional name for the strings :)
int countMatch(char *haystack, char *needle) 
{
    int needleLen = strlen(needle);
    char *searchStr, *haystack_copy = haystack;
    int count = 0;

    while(haystack_copy)
    {
        searchStr = strstr(haystack_copy, needle);

        if(searchStr == NULL)
            break;

        if((searchStr == haystack) || 
        	(searchStr != haystack && !isalpha(searchStr[-1]) && !isalpha(searchStr[needleLen])))
            {
            	count++;
            }

        haystack_copy = searchStr + needleLen;
    }

    return count;
}

//returns the number of words in a string
int wordCount(char *str)
{
	char *strDuplicate = malloc((strlen(str) + 1) * sizeof(char));
	strcpy(strDuplicate, str);

	int wc = 0;
	char *p = strtok(strDuplicate, " ");

	while(p)
	{
		wc++;
		p = strtok(NULL, " ");
	}

	free(strDuplicate);
	return wc;
}
