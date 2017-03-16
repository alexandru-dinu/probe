#include <stdio.h>
#include <math.h>

int main()
{
    int j;
    float i;
    double (*fp[3]) (double) = {sin, cos, log};

    for (i = 2.718; i < 2.719; i += 0.000001) {
	for (j = 0; j < 3; j++) {
	    printf("fp%d(%f) = %lf\n", j, i, fp[j] (i));
	}
	printf("\n");
    }
    return 0;
}
