// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <vector>

using namespace std;

long long factorial(int x)
{
	if (x == 0)
		return 1;
	else if (x == 1)
		return 1;
	else return x*factorial(x - 1);
}

int comb(int n, int k)
{
	return (factorial(n)) / (factorial(n - k)*factorial(k));
}

void _generatePascalRow(int x) // x = power + 1
{
	for (int i = 0; i <= x; i++)
	{
		cout << comb(x, i) << " ";
	}
}

int _tmain(int argc, _TCHAR* argv[])
{
	int nrOfLines;
	cout << "Lines: "; cin >> nrOfLines;

	if (nrOfLines <= 0)
		cout << "Impossible";
	else
	{
		for (int i = 0; i < nrOfLines; i++)
		{
			cout << "power <" << i << ">: ";
			_generatePascalRow(i);
			cout << endl;
		}
	}

	cout << endl;
	system("PAUSE");
	return 0;
}

