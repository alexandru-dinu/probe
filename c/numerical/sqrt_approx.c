#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#define EPS 0.000001

float sqrtG(float x, float guess)
{
    if(fabs(x - pow(guess, 2)) <= EPS)
        return guess;
    else
        return sqrtG(x, (guess + (x / guess)) / 2);
}

int main(void)
{
    float x;
    int G;

    printf("x = ");
    scanf("%f", &x);
    printf("G = ");
    scanf("%d", &G);

    float res = sqrtG(x, G);

    printf("sqrt(%f) = %f\n", x, res);
    printf("err = %f\n", res - sqrt(x));

    return 0;
}
