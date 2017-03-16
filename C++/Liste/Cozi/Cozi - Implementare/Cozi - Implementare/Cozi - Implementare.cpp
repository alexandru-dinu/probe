// Cozi.cpp : main project file.

#include "stdafx.h"
#include <iostream>

using namespace std;

struct nod
{
	int info;
	nod *urm;
}

*vf,*ultim;

//se completeaza lista

void pune(nod *&prim, nod *& sfarsit, int x) //varful o sa devina primul element din coada, iar ultim, sfarsitul cozii
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

	cout<<"Coada creata este : ";

	afisare(vf);

	cout<<endl;

	//adaugarea a nra elemente

	int nra;

	cout<<"Numarul de elemente care se adauga = ";cin>>nra;

	for(i=1;i<=nra;i++)
	{
		cout<<"Informatia din nodul "<<n+i<<" este = ";cin>>info;
		pune(vf,ultim,info);
	}

	n=n+nra;

	//eliminarea a nre elemente

	int nre;

	cout<<"Numarul de elemente care se elimina = ";cin>>nre;

	for(i=1;i<=nre;i++)
	{
		eliminare(vf);
	}

	n=n-nre;

	cout<<"Coada in varianta finala este : ";

	afisare(vf);

	cout<<endl;

	cin>>gata;
    return 0;
}
