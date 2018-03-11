// Quick Sort.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int n, i, v[256];

void schimb(int &a,int &b)
{
	int aux=a;
	a=b;
	b=aux;
}

void divizeaza(int s, int d, int &m)
{
	int i=s, j=d, pi=0,pj=1; //pi,pj = parcurgerea pe i,j;
	while(i<j)
	{
		if(v[i]>v[j])
		{
			schimb(v[i],v[j]);
			schimb(pi,pj);
		}
		i=i+pi;
		j=j-pj;
	}
	m=i; //Pozitia pivotului va fi i
}

void quicksort(int s, int d) //s = parcurgerea vectorului de la stanga, d = parcurgerea vectorului de la dreapta
{
	int m; //Pivotul
	if(s<d) //Conditia ca vectorul sa aibe cel putin doua elemente, altfel se afiseaza asa cum este
	{
		divizeaza(s,d,m);
		quicksort(s,m-1);
		quicksort(m+1,d);
	}
}

int main()
{
	cout<<"Numarul de elemente ale vectorului = ";cin>>n;
	for(i=1;i<=n;i++)
	{
		cout<<"v["<<i<<"]=";cin>>v[i];
	}

	quicksort(1,n);

	for(i=1;i<=n;i++)
	{
		cout<<v[i]<<" ";
	}

	cout<<endl;
	system("PAUSE");
	return 0;
}

