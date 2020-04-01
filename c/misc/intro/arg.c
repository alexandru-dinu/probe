#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>

int prime(int a)
{
    int i;
    float s = sqrt(a);

    if (a % 2 == 0)
        return 0;
    else {
        for(i = 3; i < sqrt(a); i += 2) {
            if(a % i == 0) {
                return 0;
            }
        }
    }
    return 1;
}

void tower(double *x)
{
    *x = pow(*x, *x);
}

int main(int argc, char *argv[])
{
    if(argc == 1) {
        printf("No number given!\n");
        return -1;
    }

    int nr = atoi(argv[1]);
    prime(nr) ? printf("%d is prime.\n", nr) : printf("%d is not prime.\n", nr);

    double x = atof(argv[2]);
    printf("%.1lf ", x);
    tower(&x);
    printf("%.1lf\n", x);

    return 0;
}