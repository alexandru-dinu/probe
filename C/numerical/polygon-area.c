#include <stdio.h>
#include <math.h>

int main(void)
{
	float x0 = 1, y0 = 2;
	float xC, yC;
	float xP, yP;

	float suma = 0;	
	int i;

	int vertices = 4;

	xP = x0;
	yP = y0;

	for(i = 1; i < vertices; i++)
	{
		printf("xC, yC\n");
		scanf("%f%f", &xC, &yC);

		suma += xP*yC - yP*xC;

		xP = xC;
		yP = yC; 
	}

	suma += xC*y0 - yC*x0;

	printf("Aria este %f\n", fabs(suma)/2);

	return 0;
}


