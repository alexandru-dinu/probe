#include <stdio.h>

int maxSubsetSum(int *v, int n)
{
    int i;

    int sumC = 0;
    int sumM;

    for(i = 0; i < n; i++) {
        sumC = (sumC + v[i]) > 0 ? (sumC + v[i]) : 0;
        sumM = sumM > sumC ? sumM : sumC;
    }

    return sumM;
}

int main(void)
{
    int v[9] = {2, -3, 1, 4, -2, 3, -9, 2, -1};

    printf("S = %d\n", maxSubsetSum(v, 9));
    return 0;
}