#include <stdio.h>
#include <math.h>

float power(int base, int exp) //raises base to power exp
{
	if (exp == 0 && base != 0)
		return 1;
	else return base * power(base, exp - 1);
}

int nrOfDigits(int param) //returns the number of digits of param
{	
	int n = 1;

	if (param < 10)
		return n;
	else return n + nrOfDigits(param / 10);
}

int reverseDigits(int param) //reverses the order of digits
{
	if (param < 10)
		return param;
	else return 
		(param % 10) * 
		power(10, nrOfDigits(param) - 1) + 
		reverseDigits(param / 10);
}

int nextPalindrome(int param) //returns the closest bigger palindrome to param
{
	if(param == reverseDigits(param))
		return param;
	else return nextPalindrome(param + 1);
}

int chkPrime(int param) //checks if a number is prime
{
	int i;

	for(i = 2; i <= sqrt(param); i++)
	{
		if(param % i == 0)
		{
			return 0;
			break;
		}
	}

	return 1;
}

int closestPrime(int param) //return the closest prime to param
{
	if(chkPrime(param))
		return param;
	else return closestPrime(param + 1);
}

int main(void)
{
	//
	printf("Power, 7^3 = %.2f\n", power(7,3));

	//
	printf("Nr of digits, 2533  = %d\n", nrOfDigits(2533));

	//
	printf("Reverted digits, 2533 = %d\n", reverseDigits(2533));

	//
	int givenNumber;
	printf("Give me a number, so I can give you a palindrome: ");
	scanf("%d", &givenNumber);

	printf("Closest palindrome to %d is %d.\n", 
		givenNumber, nextPalindrome(givenNumber));

	//
	int nr;
	printf("Give me another number: ");
	scanf("%d", &nr);

	while(nr > 0)
	{
		if(chkPrime(nr))
		{
			printf("\n");
			
			printf("Give me another number: ");
			scanf("%d", &nr);
		}
		else 
		{
			int k = 1;
			int upper = nr + k;
			int lower = nr - k;

			while(chkPrime(upper) == 0 && chkPrime(lower) == 0)
			{
				k++;
				upper = nr + k;
				lower = nr - k;
			}

			if(chkPrime(lower) && chkPrime(upper))
				printf("%d, %d \n", lower, upper);
			else if(chkPrime(upper))
				printf("%d\n", upper);
			else if(chkPrime(lower))
				printf("%d\n", lower);

			printf("Give me another number: ");
			scanf("%d", &nr);
		} 
	}




	return 0;
}