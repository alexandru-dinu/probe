// P1.cpp : main project file.

//o stiva cu n numere intregi, sa se elimine toate numerele din varful stivei pana cand se intalneste un numar ale carui cifre au suma mai mare ca 10

#include "stdafx.h"
#include <iostream>

using namespace std;

int sc(int a)
{
	int s=0,v=a;
	while(v)
	{
		s=s+v%10;
		v=v/10;
	}
	if(s>10) return 1;
	else return 0;
}

struct nod
{
	int info;
	nod *back; //adresa elementului cu un nivel mai jos
}
*vf,*p; //Varful stivei (ultimul element al acestuia)

//adaugare element in stiva

void pune(nod *&prim, int x) //primul element din stiva, x=informatia
{
	nod *q; //pointerul cu care vom naviga pe nivelele stivei;
	if(prim==NULL) //daca stiva este goala
	{
		prim = new nod;
		prim->info=x; //informatia din primul element este x
		prim->back=NULL; //nu mai exista niciun element sub acesta
	}
	else //daca stiva nu este goala
	{
		q=new nod;
		q->back=prim; //i se spune lui q ca mai sunt elemente sub el
		q->info=x;
		prim=q; //acum primul element devine q;
	}
}

//afisarea elementelor din stiva

void afisare(nod *prim)
{
	nod *aux; //pointer auxiliar cu care vom parcurge stiva de sus in jos
	aux=prim; //prima valoare a lui aux este primul element al stivei, varful acesteia
	while(aux!=NULL) //se afiseaza lista pana cand aux = NULL
	{
		cout<<aux->info<<endl; //afisam elementul
		aux=aux->back; //se trece la nivelul inferior al stivei
	}
}

//eliminarea unui element din stiva

void eliminare(nod *&prim)
{
	nod *q; //pointer auxiliar cu care vom parcuge stiva
	if(prim==NULL) //daca stiva este goala
	{
		cout<<"Stiva este vida.";
	}
	else //daca stiva nu este goala
	{
		q=prim;
		prim=prim->back;
		delete q;
	}
}

int main()
{
    int n,i,info;
	int gata;
	cout<<"Numarul de noduri = ";cin>>n;
	for(i=1;i<=n;i++)
	{
		cout<<"Informatia din nodul "<<i<<" este = ";cin>>info;
		pune(vf,info);
	}

	p=vf;
	if(sc(p->info)==1)
	{
		afisare(p);
	}
	else
		do
		{
			eliminare(p);
		}
		while(sc(p->info)==0);

			afisare(p);

	cin>>gata;
	return 0;
}
