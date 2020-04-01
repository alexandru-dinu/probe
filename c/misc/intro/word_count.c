//varianta mai faina cu strdup
//s[i] = strdup(s)

#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#define MAX 100

int main(void)
{
    char *s;
    char *s_aux = malloc(MAX * sizeof(char));

    char sep[8] = {' ', ',', '.', '!', '?', ';', ':'};

    int count = 0;

    if(!s_aux) {
        printf("malloc err!\n");
        return -1;
    }

    fgets(s_aux, MAX, stdin);

    if(s_aux[strlen(s_aux) - 1] == '\n') {
        s_aux[strlen(s_aux) - 1] = '\0';
        s = realloc(s_aux, strlen(s_aux) * sizeof(char));
    }
    else {
        s = realloc(s_aux, (strlen(s_aux) + 1) * sizeof(char));
    }

    if(!s) {
        printf("realloc err!\n");
        return -1;
    }
    s_aux = NULL;

    char *p = strtok(s, sep);
    while(p) {
        puts(p);
        count++;
        p = strtok(NULL, sep);
    }

    printf("Sunt %d cuvinte.\n", count);

    free(s);
    return 0;
}