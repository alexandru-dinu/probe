/*
Discretizarea problemei vitezei unui corp in cadere libera,
sub actiunea fortei de frecare cu aerul
*/

#include <stdio.h>
#include <math.h>
#include <stdlib.h>

#define g 9.80665
#define AIR_DENSITY 1.2754 
#define INITIAL_SPEED 0.0
#define ITERATIONS 10

int main(int argc, char const *argv[])
{
	float dragCoef, area;
	float mass;
	float alpha, c;
	float step;
	int i;

	printf("Enter drag coefficient: ");
	scanf("%f", &dragCoef);

	printf("Enter area: ");
	scanf("%f", &area);
	
	printf("Enter mass: ");
	scanf("%f", &mass);

	c = 0.5f * AIR_DENSITY * dragCoef * area;
	alpha = c / mass;

	// step = delta t = ti+1 -ti
	printf("Enter step: ");
	scanf("%f", &step);

	// velocity array
	float *v = calloc(10, sizeof(float));
	if(!v)
		exit(1);


	v[0] = INITIAL_SPEED;

	for(i = 1; i < ITERATIONS; i++)
		v[i] = v[i - 1] + step * (g - alpha * (v[i - 1] * v[i - 1]));	

	for(i = 0; i < ITERATIONS; i++)
		printf("V(t%d) = %f m/s\n", i, v[i]);

	return 0;
}
