// Combinari recursiv.cpp : main project file.

#include "stdafx.h"
#include <iostream>

using namespace std;

int st[20], n, m, k, gata;
 
void init(int k)
{
	if(k==1) st[k]=0;
	else st[k]=st[k-1];
}

int succesor(int k)
{
	if(st[k]<n-m+k)
	{
		st[k]=st[k]+1;
		return 1;
	}
	else
	return 0;
}

int valid(int k)
{
	return 1;
}

int solutie(int k)
{
	if(k==m) return 1;
	else return 0;
}

void tipar()
{
	for(int i=1;i<=m;i++)
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
	cout<<"Combinari de "; cin>>n;
	cout<<"luate cate ";cin>>m;

	bt();

	cin>>gata;
	return 0;
}