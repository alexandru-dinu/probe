// ConsoleApplication2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	vector<string> myVector;
	vector<int> wordLen;

	string s;

	int size; 
	cout << "size: "; cin >> size;

	for (int i = 0; i < size; i++)
	{
		cin >> s;
		myVector.push_back(s);
		wordLen.push_back(s.size());
	}

	int maxWord = *max_element(wordLen.begin(), wordLen.end());
	int minWord = *min_element(wordLen.begin(), wordLen.end());

	for (int i = 0; i < myVector.size(); i++)
	{
		if (string(myVector.at(i)).size() == maxWord)
		{
			cout << "Max_word is: " << myVector.at(i) << endl;
		}
		else if (string(myVector.at(i)).size() == minWord)
		{
			cout << "Min_word is: " << myVector.at(i) << endl;
		}
		else
			continue;
	}


	cout << endl;
	system("PAUSE");
	return 0;
}

