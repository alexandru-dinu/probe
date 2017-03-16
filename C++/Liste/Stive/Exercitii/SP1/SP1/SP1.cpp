// Operatii cu stive.cpp : main project file.

//Intr-o stiva ce memoreaza numere, valoarea x poate fi adaugata numai daca in varful stivei se afla un element strict mai mare decat x
//In caz contrar sunt eliminate toate elementele care nu indeplinesc aceasta conditie si apoi se adauga valoarea x
//Daca stiva este initial vida, care este numarul elementelor aflate in aceasta stiva, dupa adaugare, respectand contitiile de mai sus, in ordine numerele 20, 5, 16, 9, 3, 7, 5, 4, 8

#include "stdafx.h"
#include <iostream>

using namespace std;

int n;

struct nod
{
	int info;
	nod *back;
}
*vf;

void pune(nod *&prim, int x)
{
	nod *q;
	if(prim==NULL)
	{
		prim = new nod;
		prim->info=x;
		prim->back=NULL;
	}
	else
	{
		q = new nod;
		q->back=prim;
		q->info=x;
		prim=q;
	}
}

void afisare(nod *prim)
{
	nod *aux;
	aux=prim;
	while(aux!=NULL)
	{
		cout<<aux->info<<endl;
		aux=aux->back;
	}
}

void eliminare(nod *&prim)
{
	nod *q;
	if(prim==NULL)
	{
		cout<<"Stiva este vida";
	}
	else
	{
		q=prim;
		prim=prim->back;
		delete q;
	}
}

//Verifica daca valoarea pe care dorim sa o adaugam respecta conditiile

void verificare(nod *&prim, int v)
{
	nod *q;
	q=prim;
	while(q!=NULL)
	{
		if(v<q->info)
		{
			pune(vf,v);
			n=n+1;
		}
		else
		{
			eliminare(vf);
			n=n-1;
		}	
		q=q->back;
	}
}

int main()
{
    int i,info,val;
	int gata;

	cout<<"Numarul de noduri = ";cin>>n;
	for(i=1;i<=n;i++)
	{
		cout<<"Informatia din nodul "<<i<<" este = ";cin>>info;
		pune(vf, info);
	}

	cout<<"Valoarea care se adauga = ";cin>>val;

	verificare(vf,val);

	afisare(vf);

	n=n+1;

	cin>>gata;
    return 0;
}
