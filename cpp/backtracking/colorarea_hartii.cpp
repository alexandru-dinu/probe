// Colorarea hartii.cpp : main project file.

#include "stdafx.h"
#include <iostream>
#include <conio.h>
#include <math.h>

using namespace std;

int st[20],a[10][10],n,k,c,gata;

void init()
{st[k]=0;}

int succesor()
{if (st[k]<c)
{st[k]++;
return 1;
}
else return 0;}

int valid()
{for(int i=1;i<k;i++)
if(st[i]==st[k] && a[i][k]==1) return 0;
return 1;}

int sol()
{return (k==n);}

void tipar()
{for(int i=1;i<=n;i++) cout<<"Tara numarul "<<i<<" culoarea "<<st[i]<<endl;
cout<<endl;
}

void bt()
{int as;k=1;
init();
while(k>0)
{
do {} while ((as=succesor()) && !valid());
if (as)
if (sol()) tipar();
else {k++;init();}
else k--;
}
}

int main()
{
	cout<<"Numarul de tari = ";cin>>n;
	cout<<"Numarul de culori = ";cin>>c;
	for(int i=1;i<=n;i++)
	for(int j=1;j<=n;j++) 
	{
	cout<<"a["<<i<<"]["<<j<<"]=";cin>>a[i][j];
	}
	bt();

	cin>>gata;
	return 0;
}