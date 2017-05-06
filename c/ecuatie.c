#include<stdio.h>
#include<math.h>
int main(void)
{
float a,b,c;
float delta;

printf("Introduceti coeficientii ecuatiei:\n");
scanf("%f %f %f", &a, &b, &c);

if(a == 0 && b == 0 && c != 0)
	printf("Nu ati introdus o ecuatie valida.\n");
else if(a == 0 && b == 0 && c == 0)
	printf("Ati obtinut 0 = 0.\n");
else if (a == 0 && b != 0)
	printf("Ati obtinut o ecuatie de gradul 1, cu solutia x = %f", -c/b);
else if (a != 0)
	{
	delta = b * b - 4 * a * c;
		if(delta < 0)
			printf("Ecuatia nu are solutii reale.\n");
		else if(delta == 0)
			printf("Ecuatia are radacina dubla x = %f\n", -b/(2*a));
		else 
			printf("Ecuatia are doua solutii reale, x1 = %f si x2 = %f\n",(-b+sqrt(delta))/(2*a),(-b-sqrt(delta))/(2*a));
	}
return 0; 
}
