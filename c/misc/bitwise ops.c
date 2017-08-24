#include <stdio.h>

//return the bit value of n on the p position
int seeBit(int n, unsigned int p)
{
	//n(2) = Bn/Bn-1/Bn-2/.../B2/B1/B0
	if(n & (1 << p))
		return 1;
	else return 0;
}

//sets the p bit on or off
void setBit(int *n, unsigned int p, unsigned int status)
{
	if(status)
		*n |= (1 << p);
	else
		*n &= ~(1 << p);
}

//negates the p bit
void invBit(int *n, unsigned int p)
{
	(*n) ^= (1 << p);
}

int main(void)
{
	int x = 3;
	int i = 0;
	int bit;

	if((x & (x-1)) == 0) //if x = 2^i
		{
			while((bit = x & (1 << i)) != x)
			{
				i++;
			}
			printf("%d\n", i); //show me i
		}
	else
		{
			setBit(&x, 2, 1);
			invBit(&x, 1);
			printf("%d\n", x);
		}

	return 0;
}