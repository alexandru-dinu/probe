/*
Discretizarea problemei vitezei unui corp in cadere libera,
sub actiunea fortei de frecare cu aerul
*/

#include <stdio.h>
#include <math.h>
#include <stdlib.h>

#define g 9.80665
#define AIRD 1.2754 
#define INITSP 0.0
#define ITERATIONS 10

int main(int argc, char const *argv[])
{
	float dragCoef, area;

	printf("Enter drag coefficient and area: ");
	scanf("%f%f", &dragCoef, &area);

	float c = 0.5 * AIRD * dragCoef * area;

	float mass;
	printf("Enter mass: ");
	scanf("%f", &mass);

	float alpha = c / mass;

	float step; //step = delta t = ti+1 -ti
	printf("Enter step: ");
	scanf("%f", &step);

	float *v = malloc(10 * sizeof(float*));
	if(!v) {exit(1);}
	v[0] = INITSP;


	int i;
	for(i = 1; i < ITERATIONS; i++)
	{
		v[i] = v[i - 1] + step * (g - alpha * pow(v[i - 1], 2));	
	}

	for(i = 0; i < ITERATIONS; i++)
	{
		printf("V(t%d) = %f m/s\n", i, v[i]);
	}

	return 0;
}
