/*
Solve AX = b, where A is a lower triungular matrix
*/

#include <stdio.h>
#include <stdlib.h>

//X[i] = (b[i] - sum) / A[i][i]

#define N 2

int main(void)
{

    int **A, *b;
    float *X;

    int lin = N;
    int col = 1;

    int i, j;
    float sum;

    A = (int**) malloc(lin * sizeof(int*));
    b = (int*) malloc(lin * sizeof(int));
    X = (float*) malloc(lin * sizeof(float));

    //read b
    for(i = 0; i < lin; i++) {
        printf("b[%d] = ", i);
        scanf("%d", &b[i]);
    }

    //construct the LT matrix
    for(i = 0; i < lin; i++) {
        A[i] = calloc(col, sizeof(int));

        for(j = 0; j < col; j++) {
            printf("A[%d][%d] = ", i, j);
            scanf("%d", &A[i][j]);
        }

        col++;
    }

    for(i = 0; i < lin; i++) {
        sum = 0;
        for(j = 0; j < i; j++) {
            sum += A[i][j] * X[j];
        }

        X[i] = (float) (b[i] - sum) / A[i][i];

        printf("X[%d] = %.2f\n", i, X[i]);
    }


    for(i = 0; i < lin; i++) {
        free(A[i]);
    }
    free(A);
    free(X);
    free(b);
    return 0;
}