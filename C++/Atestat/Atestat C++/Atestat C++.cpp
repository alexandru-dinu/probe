// Atestat C++.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
#include <fstream>

using namespace std;

#define MAX_SIZE 50
#define MIN_GRADE 5
#define MAX_GRADE 10

ofstream _out_file("out.txt");

int _tmain(int argc, _TCHAR* argv[])
{
	vector<string> vecName;
	vector<float> vecAvg;

	bool _isOk_continue = true;

	int size; 
	cout << "How many students? "; cin >> size;
	if (size >= MAX_SIZE) 
	{
		cout << "Too many students.";
	}
	
	else 
	{
		string name_temp;
		float avg_temp;

		for (int i = 0; i < size; i++) 
		{
			cout << "[" << i + 1 << "] -> ";
			cout << "Student's name: "; cin >> name_temp;
			cout << "Student's average: "; cin >> avg_temp;

			if (avg_temp >= MIN_GRADE && avg_temp <= MAX_GRADE) 
			{
				vecName.push_back(name_temp);
				vecAvg.push_back(avg_temp);
			}
			else 
			{
				cout << "Grade too low / high.";
				_isOk_continue = false;
				break;
			}
		}

		if (_isOk_continue)
		{
			for (int i = 0; i < size; i++)
				for (int j = 0; j <= i; j++)
				{
					if (vecAvg.at(i)>vecAvg.at(j))
					{
						swap(vecAvg.at(i), vecAvg.at(j));
						swap(vecName.at(i), vecName.at(j));
					}
				}

			cout << "The list of students ordered by their average is: " << endl;

			for (int i = 0; i < size; i++)
			{
				cout << i + 1 << ". " << vecName.at(i) << " -> " << vecAvg.at(i) << endl;
			}
		}
			
	}
	
	cout << endl;
	system("PAUSE");
	return 0;
}

