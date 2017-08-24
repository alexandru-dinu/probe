#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <ctype.h>
#include <limits.h>

#define ISVOID(L) ((L) == NULL)

/* definire tipuri de date */
typedef int TELEM, *ADRELEM;
typedef struct CelLista {
	TELEM info;
	struct CelLista *urm;
} TCel, *TLista, **ALista;
/* TLista *L = ALista L */

/* functii de baza */
TLista AlocaCel(TELEM *elem)
{
	TLista aux = (TLista) malloc(sizeof(TCel));
	if(aux)
	{
		aux->info = *elem; //se completeaza informatia utila
		aux->urm = NULL;
	}

	return aux; //adresa noii celule sau NULL
}

TLista CitesteL(int *lg)
{
	TLista L = NULL, u, aux;
  	TELEM x;
  	char ch;
  	for(*lg = 0; scanf("%i", &x) == 1; )  
  	{ 
	    aux = AlocaCel(&x);           
	    if(!aux) 
	    	return L;              
	    if(L == NULL) 
	    	L = aux;
	    else 
	    	u->urm = aux;
	    u = aux;

	    (*lg)++;
  }
  
  while((ch=getchar()) != EOF && ch != '\n');
  return L;                     
}

size_t LungimeL(TLista L)
{
	size_t lungime;
	TLista p = L;

	for(lungime = 0; p != NULL; p = p->urm, lungime++);

	return lungime;
}

size_t LungimeL_rec(TLista L)
{
	if(L == NULL)
		return 0;
	return 1 + LungimeL_rec(L->urm);
}

void AfisareL(TLista L)
{
	printf("[ ");
	for(; L != NULL; L = L->urm)
	{
		printf("%d ", L->info);
	}	
	printf("]\n");
}

void AfisareL_inv(TLista L)
{
	if(L == NULL)
		return;
	AfisareL_inv(L->urm);
	printf("%d ", L->info);
}
/* ---------- */

//L != NULL; L = L->urm; -> analiza iterativa
//L != NULL && L->urm != NULL -> analiza perechi de elemente

/* cautare in lista */
//cautare in lista: prima aparitie a celulei care respecta conditia
TLista CautaP(TLista L)
{
	for(; L != NULL; L = L->urm)
	{
		if(L->info % 2) //caut primul element impar
			return L;
	}

	return NULL; //nu s-a gasit nicio celula care respecta conditia
}

//cautare in lista: ultima aparitie a celulei care respecta conditia
TLista CautaU(TLista L)
{
	TLista ultim = NULL;

	for(; L != NULL; L = L->urm)
		if(L->info % 2)
			ultim = L;

	return ultim; //ultima celula sau NULL
}
/* ---------- */

/* inserare in lista */
//1. inserare la inceputul listei
int insInceput(TLista *L, TELEM *elem)
{
	TLista aux = AlocaCel(elem);
	if(!aux)
		return 0;

	aux->urm = *L;
	*L = aux;

	return 1;
}

//2. inserare la sfarsitul listei
int insSfarsit(TLista *adrL, TELEM *elem)
{
	TLista L = *adrL;
	TLista ultim = NULL, aux;

	for(; L != NULL; ultim = L, L = L->urm);

	aux = AlocaCel(elem);
	if(!aux) 
		return 0;
	if(ultim)
		ultim->urm = aux;
	else
		*adrL = aux;

	return 1;
}

//3a. inserare dupa un anumit element p
int insDupa(TLista L, TELEM *elem)
{
	TLista p = NULL, aux;

	//determinare p
	for(; L != NULL; L = L->urm)
		if(L->info % 2)
		{
			p = L;
			break;
		}

	if(!p)
		return 0; //elementul nu a fost gasit

	aux = AlocaCel(elem);
	if(!aux)
		return 0;

	aux->urm = p->urm;
	p->urm = aux;

	return 1;
}

//3b. inserare inaintea unui element p
int insInainte(TLista *adrL, TELEM *elem)
{
	TLista L = *adrL;
	TLista anterior = NULL, aux;
	TLista p;

	for(p = NULL; L != NULL; anterior = L, L = L->urm)
		if(L->info % 2)
		{
			p = L;
			break;
		}

	if(anterior == NULL)
	{
		insInceput(adrL, elem);
		return 1;
	}
	if(p == NULL)
		return 0;

	aux = AlocaCel(elem);
	if(!aux)
		return 0;

	anterior->urm = aux;
	aux->urm = p;

	return 1;
}
/* ---------- */

/* eliminare & distrugere */
int Eliminare(TLista *adrL, TELEM *elem)
{
	TLista L = *adrL;
	TLista p = NULL, anterior = NULL;

	for(; L != NULL; anterior = L, L = L->urm)
		if(L->info == *elem)
		{
			p = L;
			break;
		}

	if(p == NULL)
		return 0;
	else
	{
		if(anterior == NULL)
			*adrL = p->urm;
		else
			anterior->urm = p->urm;

		free(p);
	}	

	return 1;
}

void DistrugeL(TLista *L)
{
	TLista aux, p = *L;

	while(p)
	{
		aux = p;
		p = p->urm;
		free(aux);
	}

	*L = NULL;
}
/* ---------- */

//afisarea perechilor cu aceeasi paritate
int Perechi(TLista L)
{
	int nrPerechi = 0;

	int poz = 1;

	for(; L != NULL && L->urm != NULL; L = L->urm)
	{
		if(L->info % 2 == L->urm->info % 2)
		{
			printf("(%d: %d, %d)\n", poz, L->info, L->urm->info);
			nrPerechi++;
		}
		poz++;
	}

	return nrPerechi;
}

//verifica daca lista are jumatati identice
int Identice(TLista L)
{
	int len = LungimeL_rec(L);

	if(len % 2)
		return 0;
	
	TLista p = L;
	TLista q = L;

	int i;

	for(i = 0; i < len / 2; i++, L = L->urm)
		q = L->urm;

	i = 0;
	while(q)
	{
		if(p->info == q->info)
			i++;
		p = p->urm;
		q = q->urm;
	}

	if(i == len / 2)
		return 1;
	else
		return 0;
}

//determina indicii de inceput si de sfarsit 
//corespunzatori ultimei secvente de lungime minim 2,
//ordonata crescator
int Secventa(TLista L, int *ai, int *as)
{
	int lungSecv = 0;

	int i = 0;
	int count = 0;
	while(L != NULL && L->urm != NULL)
	{
		count++;
		if(L->urm->info - L->info > 0)
		{
			lungSecv++;
		}
		else
		{
			i = count;
			lungSecv = 0;
		}

		L = L->urm;
	}

	*ai = i;
	*as = *ai + lungSecv;

	if (lungSecv == 0)
	{
		*ai = -1;
		*as = -1;
	}

	return lungSecv;
}

int InsSelectiv(TLista *adrL)
{
	TLista L = *adrL;

	int nr_ins = 0;

	for(; L != NULL; L = L->urm)
	{
		int elem = L->info;

		if(elem % 2)
		{
			TLista aux = AlocaCel(&elem);
			if(!aux)
				return -1;

			aux->urm = L->urm;
			L->urm = aux;

			L = L->urm;

			nr_ins++;
		}
	}

	return nr_ins;
}

//elimina toate elementele din intervalul (a,b)
int _elimina(ALista aL, int a, int b, int *numRamase)
{
	TLista aux = NULL;


	int count = 0;
	int len = LungimeL_rec(*aL);

	while(*aL)
	{
		if((*aL)->info > a && (*aL)->info < b)
		{
			aux = *aL;
			*aL = aux->urm;
			free(aux);

			count++;
		}
		else
		{
			aL = &(*aL)->urm;
		}
	}
	*numRamase = len - count;
	return count;
}

//elimina duplicatele din lista
int _elimDupl(ALista aL)
{
	TLista L = *aL;

	for(; L != NULL && L->urm != NULL; L = L->urm)
	{
		if(L->urm->info == L->info)
			Eliminare(aL, &L->info);
	}

	return 1;
}

//creeaza o noua lista cu elementele lui L, inversate
TLista Invers(TLista L, int *result)
{
	TLista R = NULL;
	TLista aux;

	*result = LungimeL_rec(L);

	for(; L != NULL; L = L->urm)
	{
		aux = AlocaCel(&L->info);
		if(!aux)
			return NULL;

		if(R == NULL)
		{
			R = aux;
			R->urm = NULL;
		}
		else
		{
			aux->urm = R;
			R = aux;
		}
	}

	return R;
}

//D = A - B
TLista Diferenta(TLista A, TLista B, int *result)
{
	TLista D = NULL;
	TLista w;
	TLista aux;

	int count = 0;

	for(; A != NULL && B != NULL; )
	{
		if(A->info < B->info)
		{
			aux = AlocaCel(&A->info);
			if(!aux)
				return NULL;

			if(D == NULL)
			{
				D = aux;
				w = D;
			}
			else
			{
				w->urm = aux;
				w = aux;
			}

			A = A->urm;
			count++;
		}
		else if(A->info > B->info)
		{
			B = B->urm;
		}
		else if(A->info == B->info)
		{
			A = A->urm;
			B = B->urm;
		}
	}

	for(; A != NULL; )
	{
		aux = AlocaCel(&A->info);
		if(!aux)
			return NULL;

		if(D == NULL)
		{
			D = aux;
			w = D;
		}
		else
		{
			w->urm = aux;
			w = aux;
		}

		A = A->urm;
		count++;
	}

	*result = count; 

	return D;
}

//D' = A - B, fara duplicate
TLista DiferentaND(TLista A, TLista B, int *result)
{
  TLista D = NULL;
  TLista w;
  TLista aux;
 
  int count = 0;
  int lastValue = INT_MIN;
 
  for(; A != NULL && B != NULL;)
  {
    if(A->info < B->info)
    {                  
      if(A->info != lastValue)
      {
        aux = AlocaCel(&A->info);
        if(!aux) { return NULL; }
 
        if(D == NULL)
        {
          D = aux;
          w = D;
        }
        else
        {
          w->urm = aux;
          w = aux;
        }
        lastValue = A->info;
        count++;
      }
      A = A->urm;
    }
    else if(A->info > B->info)
    {
      B = B->urm;
    }
    else if(A->info == B->info)
    {
      A = A->urm;
      B = B->urm;        
    }
  }

  return D;
}

int main(int argc, char const *argv[])
{
	TLista A, B;

	int N1 = 0;
	int N2 = 0;
	int x;

	A = CitesteL(&N1);
	B = CitesteL(&N2);

	TLista D = DiferentaND(A, B, &x);

	AfisareL(A);
	AfisareL(B);
	AfisareL(D);
	return 0;
}