//This is a good example of
//malloc, calloc, qsort, binarySearch

#include <stdio.h>
#include <stdlib.h>

#define MAX 100 //maximum elements of the vectors
#define VAL -25 //value to be searched in v1

//for v1
int compareA(const void* a, const void* b) 
{
	int *x = (int*)a;
	int *y = (int*)b;

	return *x - *y;
}

//for v2
int compareD(const void* a, const void* b)
{
	int *x = (int*)a;
	int *y = (int*)b;

	return *y - *x;
}

int binarySearch(int *v, int lowerB, int upperB, int value)
{
	int mid;

	if(upperB < lowerB)
		return -1;
	else
	{
		mid = (lowerB + upperB) / 2;

		if(*(v+mid) > value)
			return binarySearch(v, lowerB, mid - 1, value);
		else if(*(v+mid) < value)
			return binarySearch(v, mid + 1, upperB, value);
		else if(*(v+mid) == value)
			return mid;
	}
}

int main(void)
{
	int *v1, *v2;

	int i, j;

	//allocate MAX elements of 'int' size, and return me the address
	v1 = (int*) malloc(MAX * sizeof(int));
	//allocate MAX elements of 'double' size, 
	//initialize the zone with 0's, and return me the address
	v2 = (int*) calloc(MAX, sizeof(int));
	//if the allocation was not successful
	if(!v1 || !v2)
	{
		printf("err!\n");
		return -1;
	}
	//else, do the following operations with vectors

	//read vector v1
	for(i = 0; i < MAX; i++)
	{
		scanf("%d", &(*(v1 + i)));
	}

	//read vector v2
	for(j = 0; j < MAX; j++)
	{
		scanf("%d", &(*(v2 + j)));
	}

	//sort v1 in ascending order
	//so I can search for VAL in it
	qsort(v1, MAX, sizeof(int), compareA);

	//sort v2 in descending order
	qsort(v2, MAX, sizeof(int), compareD);

	//print out the results
	printf("v1:\n");
	for(i = 0; i < MAX; i++)
	{
		printf("%d.\t%d\n", i, *(v1 + i));
	}

	printf("\n----------\n");

	printf("v2:\n");
	for(j = 0; j < MAX; j++)
	{
		printf("%d.\t%d\n", j, *(v2 + j));
	}

	int searchResult = binarySearch(v1, 0, MAX, VAL);

	if(searchResult >= 0)
		printf("I found %d at the position %d in v1!\n", VAL, searchResult);
	else
		printf("Nothing has been found!\n");

	return 0;
}