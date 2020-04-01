#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int main(int argc, char const *argv[])
{
    int x[2] = {1, 2};
    int y[2] = {3, 4};

    //pointer p is read-only
    int* const p = x;
    //illegal, p cannot point to something else
    //p = y;
    //perfectly legal
    p[0] = 10;

    //location pointed by q/w is read-only, but q/w can point to something else
    //both declarations are equivalent
    int const *q = x;
    const int *w = x;
    //illegal assignment of read-only location
    //q[0] = 10;
    //w[0] = 10;

    w = y;

    //value pointed by r cannot be changed
    //r cannot point to another location
    const int* const r = y;
    //r[0] = 10; //illegal
    //r = y; //illegal

    printf("%d,%d\n", w[0], w[1]);

    return 0;
}