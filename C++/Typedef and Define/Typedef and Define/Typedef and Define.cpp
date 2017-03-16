// Typedef and Define.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <stdio.h>

using namespace std;

typedef double kmh;
typedef double distanta_km;

#define PI 3.14;
#define end_of_program eof;

bool verif(int a, int b)
{
	if (b == 0)
		return false;
	else
		return true;

}

void main()
{
	kmh viteza = 100;
	distanta_km DBB = 80;
	double timp = 0;
	timp = DBB / viteza;

	double timp_minute = timp * 60;

	cout << viteza << " " << DBB << " " << "timp_ore = " << timp << " timp_minute = " << timp_minute << endl;

	cout << "Am folosit #define pentru a declara constanta PI ca fiind 3.14, PI = " << PI;

	cout << endl;

	if (verif(viteza, DBB) == true)
	{
		cout << "Da, merge.";
	}
	else
	{
		cout << "Tot merge.";
	}

	scanf_s("end_of_file %d", EOF);

}
