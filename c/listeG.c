#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <ctype.h>
#include <limits.h>
#include <math.h>

#define ISVOID(L) ((L) == NULL)

typedef int (*TFCMP) (void *, void *);

typedef struct
{
	int x, y;
}TPct;

typedef struct celg
{
	struct celg *urm;
	void *info;
}TCelulaG, *TLG, **ALG;

//functie de comparare pentru punctele din plan
// < 0 : x's go first
// > 0 : y's go first
int fcmp(void *ae1, void *ae2)
{
	TPct p1 = *(TPct*) ae1;
	TPct p2 = *(TPct*) ae2;

	if(p1.x != p2.x)
		return p1.x - p2.x;
	else
		return p1.y - p2.y;
}

size_t LungimeLG(ALG a)      
{ 
	size_t elem = 0;
  	TLG p = *a;
  	for(; p != NULL; p = p->urm) 
  		elem++;  
  	return elem;
}

TLG GenerareLG(size_t N, size_t limInf, size_t limSup)
{
  TLG r = NULL, *u = &r, aux;
  TPct p;
  srand(time(NULL));
  for(; N > 0; N--)
  {
    p.x = rand() % (limSup-limInf+1) + limInf; 
    p.y = rand() % (limSup-limInf+1) + limInf;
    aux = (TLG)malloc(sizeof(TCelulaG));
    if(!aux) 
    	return r;

    aux->info = (TPct*)malloc(sizeof(TPct));

    if(!aux->info) 
    	{free(aux); return r;}

    memcpy(aux->info, &p, sizeof(TPct));
    aux->urm = NULL;

    if(r == NULL) 
    	r = aux;
    else 
    	*u = aux;
    u = &(*u)->urm;
  }
  return r;
}

int insInceput(ALG aL, void* ae, size_t d)
{
  TLG aux = malloc(sizeof(TCelulaG));
  if(!aux)
  	return 0;

  aux->info = malloc(d);

  if (!aux->info)          
  { 
  	free(aux); 
  	return 0;
  }

  memcpy(aux->info, ae, d);

  aux->urm = *aL;
  *aL = aux;

  return 1;
}

int insSfarsit(ALG aL, void* ae, size_t d)
{
	TLG L = *aL, ultim = NULL;

	for(; L != NULL; ultim = L, L = L->urm);

	TLG aux = malloc(sizeof(TCelulaG));
	if(!aux)
		return 0;

	aux->info = malloc(d);

	if (!aux->info)          
	{
		free(aux); 
	  	return 0;
	}

	memcpy(aux->info, ae, d);

	if(ultim)
		ultim->urm = aux;
	else
		*aL = aux;

	return 1;	  
}

int _elimDupl(ALG aL)
{
	TLG L = *aL;
	TLG aux;

	for(; L != NULL && L->urm != NULL; L = L->urm)
	{
		TPct p = *(TPct*)L->info;
		TPct q = *(TPct*)L->urm->info;
		if(p.x == q.x && p.y == q.y)
		{
			aux = *aL;
			*aL = (*aL)->urm;

			free(aux->info);
			free(aux);
		}
	}

	return 1;
}


void distrugeLG(ALG aL)
{
	TLG aux;

	while(*aL)
	{
		aux = *aL;
		*aL = (*aL)->urm;

		free(aux->info);
		free(aux);
	}
}

//----------
float dist(int a, int b)
{
	return sqrt(a*a + b*b);
}

//afisarea punctului din A a carui dist fata de origine este
//egala cu dist fata de origine a unui alt punct din B
int AfisareCond(TLG A, TLG B)
{
	int count = 0;
	for(; A != NULL; A = A->urm)
	{
		TPct pctA = *(TPct*) A->info; //punctul curent din A
		float distA = dist(pctA.x, pctA.y);

		TLG posInit = B;
		for(B = posInit; B != NULL; B = B->urm)
		{
			TPct pctB = *(TPct*) B->info; //punctul curent din B
			float distB = dist(pctB.x, pctB.y);

			if(distB == distA)
			{
				printf("[%d, %d]", pctA.x, pctA.y);
				count++;
				break;
			}
		}
	}
	return count;
}
//----------

TLG CopieElemAxe(TLG L, TFCMP fcmp, int *nr)
{
	int count = 0;
	TLG R = NULL;
	ALG u; //locul de inserare

	for(; L != NULL; L = L->urm)
	{
		TPct p = *(TPct*) L->info;
		if(p.x == 0 || p.y == 0) //punctul se afla pe una din axe
		{
			u = &R;
			while(*u != NULL)
			{
				if(fcmp(L->info, (*u)->info) < 0)
					break;

				u = &(*u)->urm;
			}
			insInceput(u, &p, sizeof(TPct));
			count++;
		}
	}

	*nr = count;
	return R;
}

TLG MutaElemAxe(ALG aL, TFCMP fcmp, int *nr)
{
	int count = 0;
	TLG R = NULL;
	ALG u;

	TLG aux;

	for(; *aL != NULL; )
	{
		TPct p = *(TPct*) (*aL)->info; 
		if(p.x == 0 || p.y == 0) //punctul care se afla pe una din axe
		{
			aux = *aL;
			u = &R;
			while(*u != NULL)
			{
				if(fcmp((*aL)->info, (*u)->info) < 0)
					break;

				u = &(*u)->urm;
			}
			//lasa lista initiala nemodificata
			//nu rupe legatura
			//aL = &aux->urm; 

			//modifica lista initiala
			//rupe legatura
			*aL = aux->urm;
			insInceput(u, &p, sizeof(TPct));
		}	
		else
		{
			aL = &(*aL)->urm;
		}
	}

	*nr = count;
	return R;
}

int main(int argc, char const *argv[])
{
	TLG A = GenerareLG(5, 0, 5);

	TLG pA;
	printf("Lista A initiala:\n");
	for(pA = A; pA != NULL; pA = pA->urm)
	{
		TPct p = *(TPct*) pA->info;
		printf("(%d, %d)\n", p.x, p.y);
	}

	_elimDupl(&A);

	printf("Lista A finala:\n");
	for(pA = A; pA != NULL; pA = pA->urm)
	{
		TPct p = *(TPct*) pA->info;
		printf("(%d, %d)\n", p.x, p.y);
	}
	
	distrugeLG(&A);
	return 0;
}