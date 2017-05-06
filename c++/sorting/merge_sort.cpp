// Merge Sort.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int n,x[256];
int gata;

void divizeaza (int s, int d, int &m)
{
	m=(s+d)/2;
}

void interclaseaza (int s, int d, int m)
{
	int i=s, j=m+1,k=1,v[256];
	while(i<=m && j<=d)
	{
		if(x[i]<x[j])
		{
			v[k]=x[i]; i++;
		}
		else
		{
			v[k]=x[j]; j++;
		}
		k++;
	}
	if(i<=m) 
		while(i<=m)
		{
			v[k]=x[i];
			i++;
			k++;
		}
	else
		while(j<=d)
		{
			v[k]=x[j]; j++; k++;
		}
		for(k=1, i=s; i<=d; k++, i++)
		{
			x[i]=v[k];
		}
}

void mergesort (int s,int d)
{
	int m;
	if(s<d)
	{
		divizeaza(s,d,m);
		mergesort(s,m);
		mergesort(m+1,d);
		interclaseaza(s,d,m);
	}
}

int main()
{	
	int i;

	cout<<"Numarul de elemente ale vectorului = ";cin>>n;

	for(i=1;i<=n;i++)
	{
		cout<<"x["<<i<<"]=";cin>>x[i];
	}

	mergesort(1,n);

	cout<<"Vectorul ordonat este "<<endl;

	for(i=1;i<=n;i++)
	{
		cout<<x[i]<<" ";
	}

    cin>>gata;
    return 0;
}
