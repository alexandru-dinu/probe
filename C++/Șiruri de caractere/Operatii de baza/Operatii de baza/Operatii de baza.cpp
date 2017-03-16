// Operatii de baza.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <string.h>

using namespace std;

int frecv_cif(char *sir, char c)
{
	int frecv = 0;
	char *p;
	p = strchr(sir, c);
	while (p)
	{
		frecv++;
		p++;
		p = strchr(p, c);
	}
	return frecv;
}

int _tmain(int argc, _TCHAR* argv[])
{
	int nr = 0;
	char sir[1024], c;

	cin.get(sir, 1024);
	cout << "Caracterul cautat: "; cin >> c;

	if (!frecv_cif(sir,c))
		cout << "Caracterul " << c << " nu apare in sirul dat.";
	else if (frecv_cif(sir, c)==1)
		cout << "Caracterul " << c << " apare o singura data in sirul dat.";
	else if (frecv_cif(sir, c) < 20)
		cout << "Caracterul " << c << " apare de " << frecv_cif(sir, c) << " ori in sirul dat.";
	else
		cout << "Caracterul " << c << " apare de " << frecv_cif(sir, c) << " de ori in sirul dat.";

	cout << endl;
	system("PAUSE");
	return 0;
}


