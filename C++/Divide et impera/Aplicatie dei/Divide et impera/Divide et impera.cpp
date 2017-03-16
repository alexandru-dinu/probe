// Divide et impera.cpp : main project file.

#include "stdafx.h"
#include <iostream>

using namespace std;

int n,i,v[10],sv=0,pv=1,pr=1,sp=1,nr=0,apnr,gata;

//Suma elementelor vectorului

int sumav(int li, int ls)
{
	int s1,s2,m;
	if(li==ls)
		return sv+v[ls];
	else
	{
		m=(li+ls)/2;
		s1=sumav(li,m);
		s2=sumav(m+1,ls);
		return s1+s2;
	}
} 

//Produsul elementelor vectorului

int produsv(int li, int ls)
{
	int s1,s2,m;
	if(li==ls)
		return pv*v[ls];
	else
	{
		m=(li+ls)/2;
		s1=produsv(li,m);
		s2=produsv(m+1,ls);
		return s1*s2;
	}
}

//Returneaza factorialul lui n

int factn(int li, int ls)
{
	int s1,s2,m;
	if(li==ls) return pr*ls;
	else if((ls-li)==1)
		return pr*ls*li;
	else
	{
		m=(li+ls)/2;
		s1=factn(li,m);
		s2=factn(m+1,ls);
		return s1*s2;
	}
}

//Calculeaza suma k!, k=1->n

int sumap(int li, int ls)
{
	int s1,s2,m;
	if(li==ls) return factn(1,ls);
	else if((ls-li)==1) 
		return factn(1,ls-1)+factn(1,ls);
	else
	{
		m=(li+ls)/2;
		s1=sumap(li,m);
		s2=sumap(m+1,ls);
		return s1+s2;
	}
}

//Returneaza numarul de elemente pare ale vectorului

int pare(int li, int ls)
{
	int s1,s2,m;
	if((li==ls)&&(v[ls]%2==0)) return nr+1;
	else if ((li==ls)&&(v[ls]%2!=0)) return nr;
	else
	{
		m=(li+ls)/2;
		s1=pare(li,m);
		s2=pare(m+1,ls);
		return s1+s2;
	}
}

//Returneaza numarul de elemente pozitive ale vectorului

int pozitive(int li, int ls)
{
	int s1,s2,m;
	if((li==ls)&&(v[ls]>0)) return nr+1;
	else if ((li==ls)&&(v[ls]<0)) return nr;
	else
	{
		m=(li+ls)/2;
		s1=pozitive(li,m);
		s2=pozitive(m+1,ls);
		return s1+s2;
	}
}

//Returneaza numarul de elemente negative ale vectorului

int negative(int li, int ls)
{
	int s1,s2,m;
	if((li==ls)&&(v[ls]<0)) return nr+1;
	else if ((li==ls)&&(v[ls]>0)) return nr;
	else
	{
		m=(li+ls)/2;
		s1=negative(li,m);
		s2=negative(m+1,ls);
		return s1+s2;
	}
}

//Returneaza cmmdc al elementelor vectorului

int cmmdc(int li, int ls)
{
	int s1,s2,m;
	if(ls==li) return v[ls];
	else
	{
		m=(li+ls)/2;
		s1=cmmdc(li,m);
		s2=cmmdc(m+1,ls);
		while(s1!=s2)
		{
			if(s1>s2)
				s1=s1-s2;
			else
				s2=s2-s1;
		}
		return s1;
	}

}

//Returneaza numar de aparitii a unui element cautat in vector

int ap(int li, int ls)
{
	int s1,s2,m;
	if((li==ls)&&(v[ls]==apnr)) return nr+1;
	else if((li==ls)&&(v[ls]!=apnr)) return nr;
	else
	{
		m=(li+ls)/2;
		s1=ap(li,m);
		s2=ap(m+1,ls);
		return s1+s2;
	}
}

//Returneaza pozitia pe care se afla un element cautat, cat timp elementele vectorului sunt ordonate crescator

int cc(int li, int ls) 
{
	int m=(li+ls)/2;
	if(v[m]==apnr) return m;
	else if((li<ls)&&(apnr<v[m]))
		return cc(li,m-1);
	else
		return cc(m+1,ls);
}

//Verifica daca vectorul este ordonat crescator

int verifica(int li, int ls)
{
	int m=(li+ls)/2;
	if(li==ls)
		return 1;
	else if(v[m]>v[m+1])
		return 0;
	else
		return verifica(li,m)&verifica(m+1,ls);
}

//Ordoneaza vectorul crescator folosind metoda QuickSort

void schimb(int &a,int &b)
{
	int aux=a;
	a=b;
	b=aux;
}

void divizeaza(int s, int d, int &m)
{
	int i=s, j=d, pi=0,pj=1; //pi,j = parcurgerea pe i,j;
	while(i<j)
	{
		if(v[i]>v[j])
		{
			schimb(v[i],v[j]);
			schimb(pi,pj);
		}
		i=i+pi;
		j=j-pj;
	}
	m=i; //Pozitia pivotului va fi i
}

void quicksort(int s, int d) //s = parcurgerea vectorului de la stanga, d = parcurgerea vectorului de la dreapta
{
	int m; //Pivotul
	if(s<d) //Conditia ca vectorul sa aibe cel putin doua elemente, altfel se afiseaza asa cum este
	{
		divizeaza(s,d,m);
		quicksort(s,m-1);
		quicksort(m+1,d);
	}
}

int main()
{
	cout<<"Numarul de elemente al vectorului / n = ";cin>>n;

	for(i=1;i<=n;i++)
	{
		cout<<"v["<<i<<"]=";cin>>v[i];
	}

	cout<<"n! = "<<factn(1,n)<<endl;

	cout<<"Suma k! (k=1->n) = "<<sumap(1,n)<<endl;

	cout<<"Numarul elementelor pare din vector = "<<pare(1,n)<<endl;

	cout<<"Numarul elementelor impare din vector = "<<n-pare(1,n)<<endl;

	cout<<"Suma elementelor vectorului = "<<sumav(1,n)<<endl;

	cout<<"Produsul elementelor vectorului = "<<produsv(1,n)<<endl;

	if(pozitive(1,n)==n)
		cout<<"In vector sunt doar elemente pozitive = "<<n;
	else if(negative(1,n)==n)
		cout<<"In vector sunt doar elemente negative = "<<n;
	else if(pozitive(1,n)>negative(1,n))
		cout<<"Sunt mai multe elemente pozitive = "<<pozitive(1,n);
	else if(pozitive(1,n)<negative(1,n))
		cout<<"Sunt mai multe elemente negative = "<<negative(1,n);
	else if(pozitive(1,n)==negative(1,n))
		cout<<"Numarul elementelor pozitive este egal cu numarul elementelor negative = "<<n/2;
	
	cout<<endl;

	cout<<"Cmmdc a elementelor vectorului = "<<cmmdc(1,n)<<endl;

	cout<<"Elementul cautat = ";cin>>apnr;
	if(ap(1,n)==1)
		cout<<"Elementul "<<apnr<<" apare in vector o singura data.";
	else if(ap(1,n)>1)
		cout<<"Elementul "<<apnr<<" apare in vector de "<<ap(1,n)<<" ori.";
	else if(ap(1,n)==0)
		cout<<"Elementul "<<apnr<<" nu apare in vector.";
	cout<<endl;

	 if(verifica(1,n)==1)
	 {
		if(cc(1,n)==1)
			cout<<"Elementul "<<apnr<<" apare pe prima pozitie a vectorului.";
		else if(cc(1,n)==n)
			cout<<"Elementul "<<apnr<<" apare pe ultima pozitie a vectorului.";
		else 
			cout<<"Elementul "<<apnr<<" apare pe pozitia a-"<<cc(1,n)<<"-a.";
	 }

	 quicksort(1,n);

	 cout<<"Vectorul ordonat crescator este "<<endl;
	 for(i=1;i<=n;i++)
	 {
		 cout<<v[i]<<" ";
	 }

	cin>>gata;
	return 0;
}
