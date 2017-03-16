#include<stdlib.h>

int integer_length(int value) //returns the length of a specified integer
{
	int check = abs(value);
	int length = 0;
	while (check)
	{
		length++;
		check = check / 10;
	}
	return length;
}

int integer_reverse(int value) //returns the reverse integer
{
	int check = abs(value);
	int inv = 0;
	while (check)
	{
		inv = inv * 10 + check % 10;
		check = check / 10;
	}
	return inv;
}