// Produs cartezian.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int n,i,k,st[512],v[512],nr_elem=1;

void init(int k)
{
	st[k]=0;
}

int succesor(int k)
{
	if(st[k]<v[k])
	{
		st[k]+=1;
		return 1;
	}
	else
		return 0;
}

int valid()
{
	return 1;
}

int solutie(int k)
{
	if(k==n)
		return 1;
	else
		return 0;
}

void tipar()
{
	for(i=1;i<=n;i++)
	{
		cout<<st[i]<<" ";
	}
			cout<<endl;
}

void bt(int k)
{
	init(k);
	while(succesor(k))
	{
		if(valid())
		{
			if(solutie(k))
				tipar();
			else bt(k+1);
		}
	}
}

int main()
{
	cout<<"Numarul de multimi = ";cin>>n;
	for(i=1;i<=n;i++)
	{
		cout<<"Cardinalul multimii "<<i<<" = ";cin>>v[i];
		nr_elem*=v[i];
	}

	bt(1);

	cout<<endl;

	cout<<"card(P_C) = "<<nr_elem<<endl;

	system("PAUSE");
	return 0;
}

