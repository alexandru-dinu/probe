#include <stdio.h>

int main(void)

{
	int A[3][4]; //matricea coef.
	int elem; //elementul curent citit
	int i, j; //contorii necesari parcurgerii matricei

	float x, y, z; //solutiile sistemului

	int z_numarator, z_numitor;
	float y_fractie1, y_fractie2;

	int fin;

	//completeaza matricea
	for(i = 0; i < 3; i++) {
		for(j = 0; j < 4; j++)
		{
			printf("Pos %d%d : ",i,j);
			scanf("%d", &elem);
			A[i][j] = elem;
		}
	}

	//calculeaza  z
	z_numarator = 
	A[0][0]*A[0][1]*A[1][3]*A[2][0] - 
	A[1][0]*A[0][0]*A[0][1]*A[2][3] - 
	A[0][0]*A[0][3]*A[1][1]*A[2][0] +
	A[1][0]*A[0][0]*A[0][3]*A[2][1] +
	A[1][1]*A[2][3]*A[0][0]*A[0][0] -
	A[1][3]*A[2][1]*A[0][0]*A[0][0];

	z_numitor = 
	A[0][0]*A[0][1]*A[1][2]*A[2][0] - 
	A[1][0]*A[0][0]*A[0][1]*A[2][2] -
	A[0][0]*A[0][2]*A[1][1]*A[2][0] +
	A[1][0]*A[0][0]*A[0][2]*A[2][1] +
	A[1][1]*A[2][2]*A[0][0]*A[0][0] -
	A[1][2]*A[2][1]*A[0][0]*A[0][0];

	z = z_numarator / z_numitor;

	//calculeaza y
	y =
	(A[0][0]*A[1][3] - A[1][0] * A[0][3] - 
	z * (A[0][0]*A[1][2] - A[0][2]*A[1][0])) /
	(A[0][0]*A[1][1] - A[0][1]*A[1][0]);

	x = (A[0][3] - z * A[0][2] - y * A[0][1]) / A[0][0];

	//afisarea solutiilor
	printf("(x,y,z): %.2f %.2f %.2f", x,y,z);

	scanf("%d",&fin);

	return 0;
}
