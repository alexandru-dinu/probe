// Permutari recursiv.cpp : main project file.

#include "stdafx.h"
#include <iostream>

using namespace std;

int st[20], n, k, gata;
 
void init(int k)
{
	st[k]=0;
}

int succesor(int k)
{
	if(st[k]<n)
	{
		st[k]=st[k]+1;
		return 1;
	}
	else
	return 0;
}

int valid(int k)
{
	int i;
	for(i=1;i<k;i++)
	{
		if(st[k]==st[i])
		return 0;
	}
	return 1;
}

int solutie(int k)
{
	if(k==n) return 1;
	else return 0;
}

void tipar()
{
	for(int i=1;i<=n;i++)
	cout<<st[i]<<" ";
	cout<<endl;
}

void bt()
{
	k=1;init(k);
	while(k>0)
	{
		while(succesor(k))
		{
			if(valid(k))
			if(solutie(k))
			tipar();
			else
			{
				k++;
				init(k);
			}
		}
		k--;
	}
}

int main()
{
	cout<<"n = "; cin>>n;
	bt();

	cin>>gata;
	return 0;
}