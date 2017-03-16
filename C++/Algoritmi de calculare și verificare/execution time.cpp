#include <time.h>
int main(void) {
    clock_t tStart = clock();

    /* Do your stuff here */

    printf("Time taken: %.4fs\n", (double)(clock() - tStart)/CLOCKS_PER_SEC);
    return 0;
}