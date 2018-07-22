#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <ctype.h>

#define ISVOID(L) ((L) == NULL)

typedef int (*TFCMP) (const void*, const void*);

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

void _AfisareL(ALista aL)
{
	TLista p = *aL;

	while(p)
	{
		printf("[%d] ", p->info);
		p = p->urm;
	}
}

void AfisareL_inv(TLista L)
{
	if(L == NULL)
		return;
	AfisareL_inv(L->urm);
	printf("%d ", L->info);
}

int int_cmp(const void *a, const void *b)
{
	int xa = *(int*) a;
	int xb = *(int*) b;

	if(xa < xb)
		return -1;
	else if(xa > xb)
		return 1;
	return 0;
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

int _insOrd(ALista aL, ADRELEM ae, TFCMP ord)
{
	int rez;

	while(*aL)
	{
		rez = ord(&(*aL)->info, ae);
		if(rez > 0)
			return 0;
		else
			aL = &(*aL)->urm;
	}
	return 1;
}

int _insSfarsit(ALista adrL, TELEM *elem)
{
	TLista aux;

	while(*adrL)
		adrL = &(*adrL)->urm;

	aux = AlocaCel(elem);
	if(!aux)
		return 0;
	
	*adrL = aux;

	return 1;
}

int _insInceput(ALista adrL, TELEM *elem)
{
	TLista aux = AlocaCel(elem);
	if(!aux)
		return 0;

	if (ISVOID(*adrL))
		*adrL = aux;
	else
	{
		aux->urm = *adrL;
		*adrL = aux;
	}

	return 1;
}

ALista AdrLeg(ALista adrL, ADRELEM elem)
{
	for(; *adrL != NULL; adrL = &(*adrL)->urm)
		if((*adrL)->info == *elem)
			return adrL;
	return NULL;
}

int main(int argc, char const *argv[])
{
	TLista L;

	int N = 3;
	int i = 0;
	int x;

	for(i = 0; i < N; i++)
	{
		printf("[%d]: ", i);
		scanf("%d", &x);
		_insSfarsit(&L, &x);
	}

	_AfisareL(&L);
	printf("\n");


	//_AfisareL(&L);
	DistrugeL(&L);
	return 0;
}