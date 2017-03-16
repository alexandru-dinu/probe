// Vector divide et impera.cpp : main project file.

#include "stdafx.h"
#include <iostream>

using namespace std;

int x[256]; //Vectorul de numere intregi
int n,i;
int nrn=0,nrp=0; //Numarul de elemente negative / numarul de elemente pare
int par=0; //Verifica paritatea elementelor
int cresc=0; //Verifica daca elementele din vector sunt ordonate crescator
int gata;

//Returneaza numarul de elemente negative

int f(int li,int ls)
{
	int m=(li+ls)/2;
	if((li==ls)&&(x[ls]<0)) return nrn+1;
	else if((li==ls)&&(x[ls]>0)) return nrn;
	else return f(li,m)+f(m+1,ls);	
}

//Returneaza numarul de elemente pare

int p(int li,int ls)
{
	int m=(li+ls)/2;
	if((li==ls)&&(x[ls]%2==0)) return nrp+1;
	else if ((li==ls)&&(x[ls]%2!=0)) return nrp;
	else return p(li,m)+p(m+1,ls);
}

//Verifica daca exista cel putin un element par in vector

int v(int li,int ls)
{
	int m=(li+ls)/2;
	if((li==ls)&&(x[ls]%2==0)) return par+2;
	else if((li==ls)&&(x[ls]%2!=0)) return par+1;
	else return v(li,m)&v(m+1,ls);
}

//Verifica daca elementele din vector sunt ordonate crescator

int verifica(int li, int ls)
{
	int m=(li+ls)/2;
	if(li==ls)
		return 1;
	else if(x[m]>x[m+1])
		return 0;
	else
		return verifica(li,m)&verifica(m+1,ls);
}

int main()
{
    cout<<"Numarul de elemente ale vectorului = ";cin>>n;
	for(i=1;i<=n;i++)
	{
		cout<<"x["<<i<<"]=";cin>>x[i];
	}

	//Verifica tipul numerelor din vector : pozitive/negative

	if(f(1,n)==1)
		cout<<"Este un singur element negativ in vector."<<endl;
	else if(f(1,n)==n)
		cout<<"Toate elementele vectorului sunt negative."<<endl;
	else if(f(1,n)==0)
		cout<<"Nu exista elemente negative in vector."<<endl;
	else
		cout<<"Sunt "<<f(1,n)<<" elemente negative in vector."<<endl;

	//Verifica paritatea elementelor din vector

	if(p(1,n)==1)
		cout<<"Este un singur element par in vector."<<endl;
	else if(p(1,n)==n)
		cout<<"Toate elementele vectorului sunt pare."<<endl;
	else if(p(1,n)==0)
		cout<<"Nu exista elemente pare in vector."<<endl;
	else
		cout<<"Sunt "<<p(1,n)<<" elemente pare in vector."<<endl;

	//Verifica daca exista cel putin un element par in vector

	if(v(1,n)%2==0)
		cout<<"Vectorul contine cel putin un element par."<<endl;
	else
		cout<<"Vectorul nu contine niciun element par."<<endl;

	//Verifica daca elementele din vector sunt ordonate crescator

	if(verifica(1,n)==1)
		cout<<"Elementele vectorului sunt ordonate crescator";
	else 
		cout<<"Elementele vectorului nu sunt ordonate crescator";

	cin>>gata;
    return 0;
}
