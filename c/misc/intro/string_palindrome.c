#include <stdio.h>
#include <string.h>

#define MAX 100

int main(void)
{
    char s[MAX];
    int i;
    int count = 0;
    char s_fin[MAX];
    s_fin[0] = '\0';

    char sep[8] = {' ', ',', '.', '!', '?', ';', ':'};

    fgets(s, MAX, stdin);

    if((s[strlen(s) - 1]) == '\n') {
        s[strlen(s) - 1] = '\0';
    }

    char *p = strtok(s, sep);
    while(p) {
        strcat(s_fin, p);
        p = strtok(NULL, sep);
    }

    for(i = 0; i < strlen(s_fin) / 2; i++) {
        if(s_fin[i] != ' ') {
            if(s_fin[i] == s_fin[strlen(s_fin) - 1 - i])
                count++;
        }
    }

    if(count == (strlen(s_fin) / 2))
        printf("Palindrom\n");
    else
        printf("%d\n", count);

    return 0;
}