#include <stdlib.h>
#include <stdio.h>
#include <stdarg.h>
#include <string.h>
#include <time.h>

#define ISVOID(p) (p)->urm == p

typedef int (*TFCMP)(void*, void*);

typedef struct celulaD
{
	struct celulaD *pre, *urm;
	void *info;
} TCelulaD, *TLDI;

typedef struct 
{
	char *nume;
	int nota;
} TStudent;

TLDI InitLDI()
{
	TLDI aux = malloc(sizeof(TCelulaD));
	if(aux)
	{
		aux->pre = aux->urm = aux;
		aux->info = NULL;
	}
	return aux;
}

int lungimeLDI(TLDI L)
{
	TLDI p = L->urm;
	int n = 0;

	while(p != L)
	{
		n++;
		p = p->urm;
	}

	return n;
}

int InsDupa(TLDI L, void *data)
{
	TLDI aux = (TLDI) malloc(sizeof(TCelulaD));
	if(!aux)
		return 0;

	aux->info = data;

	aux->urm = L->urm;
	L->urm->pre = aux;

	aux->pre = L;
	L->urm = aux;

	return 1;
}

int InserareINT(TLDI L, int elem)
{
	int *dataAux;
	TLDI aux;

	dataAux = (int*) malloc(sizeof(int));
	if(!dataAux)
		return 0;

	*dataAux = elem;

	//1. ins dupa un anumit element p
	//2. ins la inceput = ins dupa santinela s
	//3. ins la sf de lista = ins dupa s->pre
	InsDupa(L, dataAux);
}

int InserareSTUD(TLDI L, TStudent stud)
{
	TStudent *studAux = (TStudent*) malloc(sizeof(TStudent));
	if(!studAux)
		return 0;

	*studAux = stud;
	InsDupa(L->pre, studAux);

	return 1;
}

void AfisareLDI(TLDI L)
{
	TLDI p;

	if(p->urm == p)
	{
		printf("Lista este vida!\n");
		return;
	}

	for(p = L->urm; p != L; p = p->urm)
	{
		int data = *((int*)(p->info));
		printf("[ %d ]\n", data);
	}
}

//afiseaza al pos-elea element din lista
void AfisareElem(TLDI L, int pos)
{
	//se sare peste santinela, 
	//L->urm fiind primul element din lista care contine informatie utila
	TLDI p = L->urm; 

	if(p->urm == p)
	{
		printf("Lista este vida!\n");
		return;
	}

	int i;
	for(i = 1; i < pos; i++)
		p = p->urm;

	int data = *((int*)(p->info));
	printf("[[ %d ]]\n", data);
}

void AfisareSTUD(TLDI L)
{
	TLDI p;

	if(p->urm == p)
	{
		printf("Lista este vida!\n");
		return;
	}

	for(p = L->urm; p != L; p = p->urm)
	{
		TStudent stud = *((TStudent*)(p->info));
		printf("[%s, %d]\n", stud.nume, stud.nota);
	}
}

void ResetLDI(TLDI L)
{
	TLDI p = L->urm;
	TLDI aux;

	while(p != L)
	{
		aux = p;
		p = p->urm;
		free(aux->info);
		free(aux);
	}
	L->urm = L->pre = L;
}

void DistrLDI(TLDI *as)
{
	ResetLDI(*as);
	free(*as);
	*as = NULL;
}

/* ---------- */
TLDI MutaImpare(TLDI L)
{
	TLDI R = InitLDI();
	TLDI p = L->urm;

	int len = lungimeLDI(L);
	int i;
	for(i = 1; i <= len; i++)
	{
		if(i & 1 == 1)
		{
			int data = *((int*)(p->info));
			InserareINT(R->pre, data);
			p = p->urm;
		}
		else
			p = p->urm;
	}

	return R;
}

int _fcmp(void *a, void *b)
{
	int xa = *(int*) a;
	int xb = *(int*) b;

	if(xa == xb)
		return 1;
	else
		return 0;
}

int _ford(void *a, void *b)
{
	TStudent xa = *(TStudent*) a;
	TStudent xb = *(TStudent*) b;

	if (xa.nota > xb.nota)
		return -1;
	else 
		return 1;
}

//elimina din lista elementul de la adresa ae
void EliminaElem(TLDI L, void *ae, TFCMP _fcmp)
{
	TLDI p = L->urm;

	TLDI aux = InitLDI();

	int len = lungimeLDI(L);
	int i;

	for(i = 0; i < len; i++)
	{
		int data = *((int*)(p->info));

		if(_fcmp(p->info, ae) == 1)
		{
			aux = p;
			p->pre->urm = p->urm;
			p->urm->pre = p->pre;
		}

		p = p->urm;
		free(aux->info);
		free(aux);	
	}
}

//elimina elementele din lista care sunt simetrice fata de santinela
int EliminaSim(TLDI s, TFCMP _fcmp)
{
	int count = 0;

	TLDI f = s->urm;
	TLDI p = s->pre;

	TLDI aux1 = InitLDI();
	TLDI aux2 = InitLDI();

	int i;
	int len = lungimeLDI(s);
	for(i = 0; i < len / 2; i++)
	{
		if(_fcmp(f->info, p->info) == 1)
		{
			aux1 = p;
			aux2 = f;

			f->pre->urm = f->urm;
			f->urm->pre = f->pre;

			p->pre->urm = p->urm;
			p->urm->pre = p->pre;

			f = f->urm, p = p->pre;

			free(aux1->info);
			free(aux1);
			free(aux2->info);
			free(aux2);

			count++;
		}
		else
			f = f->urm, p = p->pre;
	}

	return count;
}

TLDI MutaSTUD(TLDI s, int *n, TFCMP _ford)
{
	*n = 0;

	TLDI R = InitLDI();
	TLDI p = s->urm;

	TLDI aux = InitLDI();

	for(; p != s;)
	{
		TStudent stud = *(TStudent*)p->info;

		if(stud.nota >= 5.0)
		{
			aux = R->urm;
			while(aux != R)
			{
				if(_ford(p->info, aux->info) < 0)
					break;

				aux = aux->urm;
			}

			InserareSTUD(aux, stud);

			p->pre->urm = p->urm;
			p->urm->pre = p->pre;
		
			p = p->urm;

			(*n)++;
		}
		else
			p = p->urm;
	}
	return R;
}

void EliminaDupl(TLDI A, TFCMP _fcmp)
{
	
}
/* ---------- */


int main(int argc, char const *argv[])
{
	int N1 = 4;
	int N2 = 2;
	int i;

	srand(time(NULL));

	TLDI A = InitLDI();
	for(i = 0; i < N1; i++)
	{
		int x = rand() % 10 + 1;
		InserareINT(A, x);
	}

	TLDI B = InitLDI();
	for(i = 0; i < N2; i++)
	{
		int x = rand() % 10 + 1;
		InserareINT(B, x);
	}

	printf("Lista A:\n");
	AfisareLDI(A);
	printf("\n");

	printf("Lista B:\n");
	AfisareLDI(B);
	printf("\n");

	EliminaDupl(A, _fcmp);

	printf("Lista A (intersectia):\n");
	AfisareLDI(A);
	printf("\n");

	return 0;
}