// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <math.h>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	int calc_nr;
	cout << "Number of calculations: "; cin >> calc_nr;

	cout << endl;

	for (int i = 1; i <= calc_nr; i++)
	{
		cout << "----------Calculation " << i << ":" << endl;

		int nr1, nr2, select;
		double sol;

		cout << "Number 1: "; cin >> nr1;
		cout << "Number 2: "; cin >> nr2;

		cout << endl;

		cout << "Select an option: " << endl;
		cout << "1 - addition" << endl;
		cout << "2 - subtraction" << endl;
		cout << "3 - multiplication" << endl;
		cout << "4 - division" << endl;
		cout << "5 - power" << endl;
		cout << "6 - square root" << endl;

		cout << endl;

		cout << "Your choice: "; cin >> select;

		if (nr2 == 0 && select == 4)
			cout << "DivisionByZeroException" << endl;
		else
		{

			cout << endl;

			switch (select)
			{
			case 1:
			{
					  sol = nr1 + nr2;
					  cout << "Addition is: " << nr1 << " + " << nr2 << " = " << sol << endl;
			} break;
			case 2:
			{
					  sol = nr1 - nr2;
					  cout << "Subtraction is: " << nr1 << " - " << nr2 << " = " << sol << endl;
			} break;
			case 3:
			{
					  sol = nr1*nr2;
					  cout << "Multiplication is: " << nr1 << " * " << nr2 << " = " << sol << endl;
			} break;
			case 4:
			{
					  sol = double(nr1) / double(nr2);
					  cout << "Division is: " << nr1 << " / " << nr2 << " = " << sol << endl;
			} break;
			case 5:
			{
					  sol = pow(double(nr1), double(nr2));
					  cout << nr1 << " to the power of " << nr2 << " is: " << sol;
			} break;
			case 6:
			{
					  double sol1, sol2;
					  sol1 = sqrt(abs(nr1));
					  sol2 = sqrt(abs(nr2));
					  if (nr1 < 0)
					  {
						  cout << "Square root of " << nr1 << " is: " << sol1 << "i." << endl;
						  cout << "Square root of " << nr2 << " is: " << sol2 << endl;
					  }
					  else if (nr2 < 0)
					  {
						  cout << "Square root of " << nr1 << " is: " << sol1 << endl;
						  cout << "Square root of " << nr2 << " is: " << sol2 << "i." << endl;
					  }
					  else if (nr1 < 0 && nr2 < 0)
					  {
						  cout << "Square root of " << nr1 << " is: " << sol1 << "i." << endl;
						  cout << "Square root of " << nr2 << " is: " << sol2 << "i." << endl;
					  }
					  else
					  {
						  cout << "Square root of " << nr1 << " is: " << sol1 << endl;
						  cout << "Square root of " << nr2 << " is: " << sol2 << endl;
					  }
			} break;
			default:
			{
					   cout << "Option not available. Choose one from 1 - 6." << endl;
			}
				break;
			}
			cout << endl;
		}
	}

	cout << endl;
	system("PAUSE");
	return EXIT_SUCCESS;
}

