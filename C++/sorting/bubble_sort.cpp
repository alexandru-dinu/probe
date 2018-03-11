// Bubble Sort.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

//ordoneaza vectorul crescator

void bubblesortCRESC(int *v, int n) 
{
	int i,j;
	for(i=1;i<=n;i++)
	{
		for(j=1;j<=i;j++)
		{
			int aux;
			if(v[i]<v[j])
			{
				aux=v[j];
				v[j]=v[i];
				v[i]=aux;
			}
		}
	}
}

//ordoneaza vectorul descrescator

void bubblesortDESCRESC(int *v, int n) 
{
	int i,j;
	for(i=1;i<=n;i++)
	{
		for(j=1;j<=i;j++)
		{
			int aux;
			if(v[i]>v[j])
			{
				aux=v[j];
				v[j]=v[i];
				v[i]=aux;
			}
		}
	}
}

void print(int *v, int n)
{
	int i;
	for(i=1;i<=n;i++)
	{
		cout<<v[i]<<" ";
	}
}

void main()
{
	int v[10],n,i;
	cout<<"Numarul de elemente din vector = ";cin>>n;
	for(i=1;i<=n;i++)
	{
		cout<<"v["<<i<<"]=";cin>>v[i];
	}
	bubblesortCRESC(v,n); //ordoneaza vectorul crescator
	cout<<"vectorul ordonat crescator este : ";
	print(v,n);

	cout<<endl;

	bubblesortDESCRESC(v,n); //ordoneaza vectorul descrescator
	cout<<"vectorul ordonat descrescator este : ";
	print(v,n);

	
	int gata;
	cin>>gata;
}