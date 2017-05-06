// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int org_array[10] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

int binary_search(int lB, int uB, int nrToSch)
{
	if (lB == uB && nrToSch == org_array[lB])
		return lB;
	else if (uB - lB == 1)
	{
		if (nrToSch == org_array[lB])
			return lB;
		else if (nrToSch == org_array[uB])
			return uB;
	}
	else
	{
		int m = (lB + uB) / 2;
		if (nrToSch == org_array[m])
			return m;
		else if (nrToSch > org_array[m])
			return binary_search(m, uB, nrToSch);
		else
			return binary_search(lB, m, nrToSch);
	}
}

int _tmain(int argc, _TCHAR* argv[])
{
	cout << binary_search(0, 9, 5) + 1 << endl;

	system("PAUSE");
	return 0;
}

