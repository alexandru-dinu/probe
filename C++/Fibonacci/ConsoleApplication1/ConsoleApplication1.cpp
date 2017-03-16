// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <math.h>

using namespace std;

#define PHI (1+sqrt(5))/2
#define NrOfTerms 10

//Returns the n-th Fibonacci series term
int Fib(int n)
{
	return round((pow(PHI, n) / sqrt(5)));
}

//Returns the index of a specified Fibonacci term
int indexF(int F)
{
	return round((log(F*sqrt(5))) / (log(PHI)));
}

//Checks if a given number is a term of the Fibonacci series
bool checkF(int x)
{
	double val1 = sqrt(5 * pow(x, 2) + 4);
	double val2 = sqrt(5 * pow(x, 2) - 4);	

	if (val1 == (int)val1 || val2 == (int)val2)
		return true;
	else return false;
}

int _tmain(int argc, _TCHAR* argv[])
{

	cout << checkF(144) << " - " << indexF(144);

	cout << endl;
	system("PAUSE");
	return 0;
}

