// Liste.cpp : main project file.

#include "stdafx.h"
#include <iostream>

using namespace std;

//Verifica elementele prime din lista

int f(int x)
{
	int nrp;
	for(int i=1;i<=x;i++)
	{
		if(x%i==0)
			nrp++;
	}
	if(nrp==2) 
		return 1;
	else 
		return 0;
}

//Verifica elementele palindrom din lista

int g(int x)
{
	int inv=0,aux;
	aux=x; //Este nevoie de o variabila auxiliara care retine valoarea pe care o testam
	while(x)
	{
		inv=inv*10+x%10;
		x=x/10;
	}
	if(inv==aux)
		return 1;
	else
		return 0;
}

struct nod
{
	int info;
	nod *urm;
}

*prim, *ultim, *p, *q;

int gata;

int main()
{
    int n,i,info;
	cout<<"Numarul de noduri = ";cin>>n;

	//Citirea si completarea primului nod

	prim = new nod; //Se aloca spatiu in memorie pentru primul nod
	cout<<"Informatia din primul nod = "; 
	cin>>info;prim->info=info; //Se completeaza primul nod cu informatia utila
	prim->urm=NULL; //Urmatorul element este nul
	ultim=prim; //Avem doar un singur element, deci prim=ultim;

	//Citirea celorlalte n-1 noduri

	for(i=2;i<=n;i++)
	{
		p = new nod; //Se aloca spatiu in memorie pentru urmatorul nod
		cout<<"Informatia din al "<<i<<"-lea nod = ";
		cin>>info;p->info=info; //Se completeaza al i-lea nod cu informatia utila
		p->urm=NULL; //Urmatorul element este, deocamdata, nul
		ultim->urm=p; //Se continua ca urmatorul element este egal cu p
		ultim=p; //Ultimul element este p
	}

	
	//Afisarea listei

	cout<<"Lista creata este : ";

	q=prim; //q este un pointer intermediar care va parcurge lista de la prim la ultim
	while(q!=NULL) //Cat timp lista contine elemente
	{
		cout<<q->info<<" "; //Afisarea informatiei utile
		q=q->urm; //Trecerea la urmatorul nod
	}

	cout<<endl;

	//Afisarea elementelor prime din lista

	cout<<"Elementele prime din lista sunt : ";

	q=prim;
	while(q!=NULL)
	{
		int verpr=f(q->info); //verpr retine valoarea q->info la momentul rularii buclei while
			if(verpr) //Daca se gaseste un element prim
			{
				cout<<q->info<<" "; //Afisarea elementului prim
				q=q->urm; //Trecerea la urmatorul element
			}
			else
				q=q->urm; //Daca nu se gaseste un element prim, se trece la urmatorul element
	}

	cout<<endl;

	//Afisarea elementelor palindrom din lista

	cout<<"Elementele palindrom din lista sunt : ";
	
	q=prim;
	while(q!=NULL)
	{
		int verpal=g(q->info); //verpal retine valoarea q->info la momentul rularii buclei while
			if(verpal) //Daca se gaseste un element palindrom
			{
				cout<<q->info<<" "; //Afisarea elementului palindrom
				q=q->urm; //Trecerea la urmatorul element
			}
			else
				q=q->urm; //Daca nu se gaseste un element palindrom, se trece la urmatorul element
	}

	cout<<endl;
	
	cin>>gata;
	return 0;
}