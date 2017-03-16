// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <vector>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	vector<int> myVector(10);
	int pos = 0;
	int whatToDel;

	for (int i = 0; i < myVector.size(); i++)
	{
		cin >> myVector.at(i);
	}
	
	cout << "What element do you want to delete? "; cin >> whatToDel;

	while (pos < myVector.size())
	{
		if (myVector.at(pos) == whatToDel)
		{
			myVector.erase(myVector.begin() + pos);
		}
		else
		{
			pos++;
		}
	}

	cout << endl;
	for (int i = 0; i < myVector.size(); i++)
	{
		cout << myVector.at(i) << " ";
	}

	cout << endl;
	system("PAUSE");
	return 0;
}