#define MAX_CONVERSION_SIZE 1024 
typedef unsigned long long MAX_TYPE_SIZE;

MAX_TYPE_SIZE base_convert(long long param, short base)
{
	MAX_TYPE_SIZE vector[MAX_CONVERSION_SIZE];
	MAX_TYPE_SIZE pTb = 0; 
	MAX_TYPE_SIZE i = 0;

	while (param)
	{
		vector[i] = abs(param % base);
		param /= base;
		i++;
	}

	for (int j = 0; j < i; j++)
	{
		pTb = pTb * 10 + vector[i - 1 - j];
	}

	return pTb;
}