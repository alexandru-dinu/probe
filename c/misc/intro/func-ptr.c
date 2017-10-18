#include <stdio.h>
#include <stdlib.h>

int foo(int a) {
    return a+1;
}

int goo(int a, int b) {
    return a + b;
}

int hoo(int* a, int* b, int c, int d) {
    return a[c] + b[d];
}

int *qoo(int *a, int b) {
    return a + b;
}

int main(void) {
    int (*f)(int);
    int (*g)(int, int);
    int (*h)(int*, int*, int, int);
    int* (*q)(int*, int);

    int eax = ((int(*)())("\xc3 <- This returns the value of the EAX register"))();
    printf("eax = [%d]\n", eax);


    int *v1 = calloc(10, sizeof(int));
    v1[0] = 1337;
    
    int *v2 = calloc(20, sizeof(int));
    v2[1] = 779;

    q = qoo;

    int *x = (int*)((*q)(v2, 1));

    printf("[%d]\n", x[0]);

    free(v1);
    free(v2);

    return 0;
}
