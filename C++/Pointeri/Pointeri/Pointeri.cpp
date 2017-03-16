// Pointeri.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int main()
{
	int *p,n,v;
	cout<<"Introduceti variabila : ";cin>>n;
	p=&n; //address of n
	cout<<"Adresa din memorie catre variabila "<<n<<" este "<<p<<"."<<endl;
	v=*p; //value pointed by p
	cout<<"Lui v i s-a atribuit valoarea "<<v<<"."<<endl;

	system("PAUSE");
	return 0;
}
