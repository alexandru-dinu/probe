// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

struct fractie
{
	int numarator, numitor;
};

int _tmain(int argc, _TCHAR* argv[])
{
	fractie f1;
	int div = 1;

	int numarator_i, numitor_i;

	cout << "Numaratorul = "; cin >> f1.numarator;
	cout << "Numaratorul = "; cin >> f1.numitor;

	numarator_i = f1.numarator;
	numitor_i = f1.numitor;
	
	if (f1.numarator > f1.numitor)
	{
		for (int i = 1; i <= f1.numitor; i++)
		{
			if ((f1.numarator%i == 0) && (f1.numitor%i == 0))
			{
				div = i;
			}
		}
	}
	else if (f1.numarator < f1.numitor)
	{
		for (int i = 1; i <= f1.numarator; i++)
		{
			if ((f1.numarator%i == 0) && (f1.numitor%i == 0))
			{
				div = i;
			}
		}
	}
	if (numarator_i!=numitor_i)
		cout << "Fractia " << numarator_i << "/" << numitor_i << " se poate reduce prin " << div << ".";
	else
		cout << "Fractia " << numarator_i << "/" << numitor_i << " este egala cu 1, se reduce prin " << numarator_i<<".";

	cout << endl;
	system("PAUSE");
	return 0;
}

