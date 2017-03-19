// Turnurile din Hanoi.cpp : main project file.

#include "stdafx.h"
#include <iostream>

using namespace std;

float n; //Numarul de discuri
char a='a',b='b',c='c'; //Tijele
long double nr=0; //Numarul de pasi = (2^n)-1 , o functie exponentiala cu baza supraunitara
int gata;

void hanoi(int n, char a, char b, char c)
{
	if(n==1) 
	{
		cout<<"Mutarea: "<<a<<"->"<<b<<endl; 
		nr=nr+1;
	}
	else
	{
		hanoi(n-1,a,c,b); //b=aux
		cout<<"Mutarea: "<<a<<"->"<<b<<endl; //afisare indiferent de apelarea subprogramelor
		nr=nr+1;
		hanoi(n-1,c,b,a); //a=aux
	}	
}	

int main()
{
    cout<<"Numarul de discuri = ";cin>>n;

	//Verficare daca n este intreg sau zecimal

	if(n!=ceil(n)) // verificare daca n este zecimal
		cout<<"Imposibil."<<endl;

	else

	//Conditii de existenta pentru rezolvare daca n este intreg

	if(n<0)
		cout<<"Imposibil."<<endl;
	else if(n==0)
		cout<<"Nu exista discuri pentru rezolvare."<<endl;

	//Rezolvarea propriu-zisa

	else if(n>0)
	{
		if(n==1)
			{
				cout<<"Pasul pentru rezolvare este : "<<endl;
				hanoi(n,a,b,c);
			}
		else if(n>1)
			{
				cout<<"Pasii pentru rezolvare sunt :"<<endl;
				hanoi(n,a,b,c);
			}

	//Discutarea numarului de pasi

	if(n==1)
		cout<<"Pentru rezolvarea Turnurilor din Hanoi cu un disc este necesar un pas.";
	else
		cout<<"Pentru rezolvarea Turnurilor din Hanoi cu "<<n<<" discuri sunt necesari "<<nr<<" pasi.";
	}

	cin>>gata;

    return 0;
}
