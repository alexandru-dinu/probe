// Numere.cpp : main project file.

#include "stdafx.h"
#include <iostream>

using namespace std;

int nr(int n,int i)
{
	if(n<10)
		return i;
	else 
		return nr(n/10,i+1);
}

int nrp(int n,int i)
{
	if(n<10)
		return i;
	else if(n%2==0)
		return nrp(n/10, i+1);
	else
		return nrp(n/10, i);
}

int main()
{
    int n,gata;
	cout<<"n= ";cin>>n;
	cout<<"Numarul "<<n<<" are "<<nr(n,1)<<" cifre, dintre care "<<nrp(n,0)<<" pare si "<<nr(n,1)-nrp(n,0)<<" impare";
	cin>>gata;

    return 0;
}
