// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <algorithm>
#include <vector>

using namespace std;

bool PalCheck(string s)
{
	transform(s.begin(), s.end(), s.begin(), tolower);

	if (s == string(s.rbegin(), s.rend()))
		return true;
	else return false;
}

int _tmain(int argc, _TCHAR* argv[])
{
	vector<string> myVector;
	string s;
	
	for (int i = 0; i < 5; i++)
	{
		cin >> s;
		myVector.push_back(s);
	}

	cout << "Your list of strings is characterised by: " << endl;

	for (int i = 0; i < myVector.size(); i++)
	{
		if (PalCheck(myVector.at(i)))
			cout << myVector.at(i) << " is a Palindrome." << endl;
		else
			cout << myVector.at(i) << " is not a Palindrome." << endl;
	}
	

	cout << endl;
	system("PAUSE");
	return 0;
}

