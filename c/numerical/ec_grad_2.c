#include <stdio.h>
#include <math.h>

float a, b, c;

float f(float x) //returneaza valoarea functiei in punctul x
{
	return a * x * x + b * x + c;
}

int main(void)
{
	float u, v;
	float min, max;
	
	printf("a: b: c: u: v:");
	scanf("%f%f%f%f%f", &a, &b, &c, &u, &v);
	
	
	float delta;
	float xV, yV;
	
	float sol1, sol2;
	
	delta = b * b - 4 * a * c;
	
	sol1 = (-b + sqrt(delta)) / (2 * a);
	sol2 = (-b - sqrt(delta)) / (2 * a);
	
	xV = -b / (2 * a);
	yV = -delta / (4 * a);
	
	
	//xV in [u,v]
	if(u < xV && xV < v)
	{
		if(a > 0)
		{
			min = yV;
			max = f(u) > f(v) ? f(u) : f(v);
		}
		else if(a < 0)
		{
			max = yV;
			min = f(u) < f(v) ? f(u) : f(v);
		}
	}
	//----------
	
	//xV in afara [u,v]
	else
	{
		min = f(u) < f(v) ? f(u) : f(v);
		max = f(u) > f(v) ? f(u) : f(v);
	}
	//----------
	
	//afisare radacini in [u,v]
	if((u < sol1 && sol1 < v) && (u < sol2 && sol2 < v)) //ambele in [u,v]
	{
		printf("s1, s2: %f %f \n", sol1, sol2);
	}
	else if((u < sol1 && sol1 < v) && (u > sol2 || sol2 > v))
	{
		printf("s1: %f \n", sol1);
	}
	else 
	{
		printf("s2: %f \n", sol2);
	}
	//----------
	
	printf("min: %f, max: %f \n", min, max);
	
	return 0;
}
