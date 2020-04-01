//Removes all duplicate entries from the array and sorts it

#include <stdio.h>
#include <stdlib.h>

#define MAX 10

void shiftLeft(int *v, int n, int pos)
{
    int k;

    for(k = pos; k < n; k++) {
        v[k] = v[k + 1];
    }
}

int elimDuplicate(int *v, int n)
{
    int i, j;
    int count = 0;

    for(i = 0; i < n; i++) {
        for (j = 0; j < i; j++) {
            if(v[i] == v[j]) {
                shiftLeft(v, n, i);
                count++;
                i--;
                n--;
                break;
            }
        }
    }
    return count;
}

int compare(const void* a, const void* b)
{
    int *x = (int*)a;
    int *y = (int*)b;

    return *x - *y;
}

int main(void)
{
    int i;
    int v[MAX];

    for(i = 0; i < MAX; i++) {
        scanf("%d", &v[i]);
    }

    int n = elimDuplicate(v, MAX);
    int _n = MAX - n;

    qsort(v, _n, sizeof(int), compare);

    for(i = 0; i < MAX - n ; i++) {
        printf("%d ", v[i]);
    }
    printf("\n");


    return 0;
}