// Stive.cpp : main project file.

//Stiva reprezinta un bloc ce contine elemente (noduri) ce functioneaza pe principiul LIFO - Last In First Out
//Stiva permite : adaugarea unui element ce va deveni varful stivei, eliminarea, consultarea sau modificarea ultimului element

#include "stdafx.h"
#include <iostream>

using namespace std;

struct nod
{
	int info;
	nod *back; //adresa elementului cu un nivel mai jos
}
*vf; //Varful stivei (ultimul element al acestuia)

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

	cout<<"Stiva creata este : "<<endl;

	afisare(vf);

	//se adauga nra elemente

	int nra;
	cout<<"Numarul de elemente care se adauga = ";cin>>nra;
	for(i=1;i<=nra;i++)
	{
		cout<<"Informatia din nodul nou adaugat "<<i<<" este = ";cin>>info;
		pune(vf,info); //se adauga elemente in continuare
	}

	n=n+nra; //noua dimensiune a stivei va fi n+nra

	//se elimina nre elemente

	int nre;
	cout<<"Numarul de elemente care se elimina = ";cin>>nre;
	for(i=1;i<=nre;i++)
	{
		eliminare(vf); //se elimina cele nre elemente din varful stivei
	}

	n=n-nre; //noua dimensiune a stivei va fi n-nre

	cout<<"Stiva finala creata este : "<<endl;

	afisare(vf);
	
	cin>>gata;
    return 0;
}
