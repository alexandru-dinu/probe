// Operatii cu cozi.cpp : main project file.

//n numere intregi, sa se stearga elementele neprime pana se intalneste un element prim

#include "stdafx.h"
#include <iostream>

using namespace std;

int verifprim(int a)
{
	int i,s=0,v;
	v=a;
	for(i=1;i<=v;i++)
	{
		if(v%i==0)
		{
			s=s+1;
		}
	}
	if(s==2)
		return 1;
	else
		return 0;
}

struct nod
{
	int info;
	nod *urm;
}

*vf,*ultim,*p;

//se completeaza lista

void pune(nod *&prim, nod *&sfarsit, int x) //varful o sa devina primul element din coada, iar ultim, sfarsitul cozii
{
	nod *q; //pointer-ul auxiliar ce ne permite sa navigam pe nivelele cozii
	if(prim==NULL)
	{
		prim = new nod; //se aloca spatiu in memorie pentru primul nod al cozii
		prim->info=x; //i se atribuie nodului campul cu informatia utila
		prim->urm=NULL; //nu mai exista niciun alt element in coada
		sfarsit=prim; //este decat un singur element in coada
	}
	else
	{
		q = new nod; //se aloca spatiu in memorie pentru un nou nod al cozii
		sfarsit->urm=q; //i se spune cozii ca se mai adauga un nod dupa ultimul element deja existent
		q->info=x; //i se atribuie nodului campul cu informatia utila
		sfarsit=q; //acum sfarsitul cozii este q
		sfarsit->urm=NULL; //nu mai exista niciun alt element in coada
	}
}

//se afiseaza continutul stivei

void afisare(nod *prim)
{
	nod *aux; //pointer-ul auxiliar ce ne permite sa navigam pe nivelele cozii
	aux=prim; //aux ia valoarea primului element din coada
		while(aux!=NULL)
		{
			cout<<aux->info<<" ";
			aux=aux->urm; //se trece la urmatorul element al cozii
		}
}

//se elimina un element din coada

void eliminare(nod *&prim)
{
	nod *q; //pointer-ul auxiliar ce ne permite sa navigam pe nivelele cozii
	if(prim==NULL)
	{
		cout<<"Coada este vida.";
	}
	else
	{
		q=prim;
		prim=prim->urm;
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
		pune(vf,ultim,info);
	}
	
	p=vf;
	if(verifprim(p->info)==1) //daca deja primul element al cozii este prim, se realizeaza direct afisarea acesteia
	{
		afisare(vf);
	}
	else //altfel, se elimina toate elementele care nu sunt pana la intalnirea unuia prim
		do
		{
			eliminare(p);
		}
		while(verifprim(p->info)==0);

			afisare(p);

	cin>>gata;
	return 0;
}