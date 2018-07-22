#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#define CARD(m) (((m)->s - (m)->p) / (m)->d)
#define ISVOID(m) (m)->p == (m)->s
#define ISFULL(m) (m)->s == (m)->t

typedef int (*TFCMP) (const void *, const void *);

typedef struct {
	size_t d;
	void *p, *s, *t;
	TFCMP fid; //verifica egalitatea a 2 elem.
	TFCMP fcmp; //verifica ordinea a 2 elem.
}TMultime;

//initializeaza o multime vida de n elemente de timp d
//se asociaza cele 2 functii de baza
TMultime *init(size_t d, size_t n, TFCMP _id, TFCMP _cmp)
{
	TMultime *m = (TMultime*) calloc(1, sizeof(TMultime));
	if(!m)
	{
		return NULL;
	}

	m->p = calloc(n, d);
	if(!m->p)
	{
		free(m);
		return NULL;
	}

	m->d = d;
	m->s = m->p;

	char *sf = (char*) m->p + n * d;
	m->t = (void*) sf;

	m->fid = _id;
	m->fcmp = _cmp;

	return m;
}

void eliberare(TMultime **m)
{
	free((*m)->p);
	free(*m);
	*m = NULL;
}

int int_id (const void *a, const void *b)
{
	int xa = *(int*) a;
	int xb = *(int*) b;

	if(xa == xb)
		return 1;
	else 
		return 0;
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

//cauta elementul x in multimea m
int cauta(TMultime *m, void *x)
{
	char *pm = (char*) m->p;
	char *sf = (char*) m->s;

	for(; pm < sf; pm += m->d)
	{
		if(m->fid(x, (void*) pm) == 1)
			return 1;
	}
	return 0;
}

//adauga elementul x daca nu exista in m
//returneaza 1 daca elementul a fost introdus cu succes
//sau 0 altfel
int adauga(TMultime *m, void *x)
{
	char *sf = (char*) m->s;

	if(ISFULL(m))
		return 0;
	if(cauta(m, x))
		return 0;

	memcpy(m->s, x, m->d);
	sf += m->d;
	m->s = (void*) sf;

	return 1;
}

int int_afisare(TMultime *m, int pos)
{
	char *sf = (char*) m->s;

	if(ISVOID(m))
		return -1;

	char *loc = (char*) m->p + pos * (m->d);

	return *(int*) loc; 
}

//operatii cu multimi

//reuniune pe multimi nesortate
int reuniune_neord(TMultime *a, TMultime *b, TMultime *r)
{
	char *pa = (char*) a->p;
	char *sa = (char*) a->s;
	char *pb = (char*) b->p;
	char *sb = (char*) b->s;

	char *sr = (char*) r->s;

	//copiem continutul lui a in r
	for(; pa < sa; pa += r->d, sr += r->d)
	{
		memcpy(sr, pa, r->d);
	}

	r->s = (void*) sr;

	//adaugam restul elementelor din b in r (dif. de cele existente deja)
	for(; pb < sb; pb += b->d)
	{
		adauga(r, (void*) pb);
	}

	return 1;
}

int reuniune_ord(TMultime *a, TMultime *b, TMultime *r)
{
	char *pa = (char*) a->p;
	char *sa = (char*) a->s;
	char *pb = (char*) b->p;
	char *sb = (char*) b->s;

	char *sr = (char*) r->s;

	int rez;

	while(pa < sa && pb < sb)
	{
		rez = a->fcmp((void*) pa, (void*) pb);

		//a goes first
		if(rez < 0)
		{
			adauga(r, pa);
			pa += a->d;
			sr += a->d;
		}
		//b goes first
		else if(rez > 0)
		{
			adauga(r, pb);
			pb += b->d;
			sr += b->d;
		}
		//either one is good
		else
		{
			adauga(r, pa);
			pa += a->d;
			pb += b->d;
			sr += b->d;
		}
	}

	//there are still elements in a
	if(pa < sa)
	{
		int i;
		for(i = 0; i < sa - pa, pa < sa; i++, sr += (sa - pa), pa += a->d)
		{
			adauga(r, pa);
		}
	}
	//there are still elements in b
	if(pb < sb)
	{
		int i;
		for(i = 0; i < sb - pb, pb < sb; i++, sr += (sb - pb), pb += b->d)
		{
			adauga(r, pb);
		}
	}

	return 1;
}

int intersectie(TMultime *a, TMultime *b, TMultime *r)
{
	char *pa = (char*) a->p;
	char *sa = (char*) a->s;
	char *pb = (char*) b->p;
	char *sb = (char*) b->s;

	char *sr = (char*) r->s;

	for( ; pa < sa; pa += r->d)
	{
		for(pb = b->p ; pb < sb; pb += r->d)
		{
			if(a->fid((void*) pb, (void*) pa) == 1)
			{
				memcpy(r->s, (void*) pb, r->d);
				sr += r->d;
				r->s = (void*) sr;
			}
		}
	}

	return CARD(r);
}

int diferenta_ord(TMultime *a, TMultime *b, TMultime *r)
{
	char *pa = (char*) a->p;
	char *sa = (char*) a->s;
	char *pb = (char*) b->p;
	char *sb = (char*) b->s;

	char *sr = (char*) r->s;

	for( ; pa < sa; pa += r->d)
	{
		int count = 0;
		for(pb = b->p ; pb < sb; pb += r->d)
		{
			if(a->fid((void*) pb, (void*) pa) == 0)
			{
				count++;
			}
		}
		if(count == (int) CARD(b))
		{
			memcpy(r->s, (void*) pa, r->d);
			sr += r->d;
			r->s = (void*) sr;
		}
	}

	return CARD(r);
}

//A => A U B
int transforma(TMultime *a, TMultime *b)
{
	if(ISFULL(a))
		a->p = realloc(a->p, 2 * CARD(a));
	
	TMultime *dif = init(sizeof(int), (int) CARD(b), int_id, int_cmp);
	diferenta_ord(b, a, dif);

	char *p_dif = (char*) dif->p;
	char *s_dif = (char*) dif->s;
	
	int i;
	char *sa = (char*) a->s;
	memcpy(a->s, dif->p, ((int) CARD(dif)) * (dif->d));
	sa += ((int) CARD(dif)) * (dif->d);
	a->s = (void*) sa;
	
	return CARD(a);
}

//returneaza pozitia elementului x in m, daca acesta este gasit
int cauta_pos(TMultime *m, void *x)
{
	char *pm = (char*) m->p;
	char *sf = (char*) m->s;

	int i = 0;

	if(cauta(m, x) == 0)
		return -1;

	for(; pm < sf; pm += m->d)
	{
		if(m->fid(x, (void*) pm) == 0)
			i++;
		else
			break;
	}

	return i;
}

int elimina(TMultime *m, void *x)
{
	if(ISVOID(m))
		return -1;
	if(cauta(m, x) == 0)
		return -1;

	int loc = cauta_pos(m, x);
	
	if(loc == 0)
	{
		char *pm = (char*) m->p;
		pm += m->d;
		m->p = (void*) pm;
	}
	else
	{
		char *pm = (char*) m->p + loc * (m->d);
		char *sf = (char*) m->s;

		int N_shift = CARD(m) - loc - 1;

		while(N_shift)
		{
			*pm = *(pm + m->d);
			pm += m->d;

			N_shift--;
		}

		sf -= m->d;
		m->s = (void*) sf;
		}

	return 1;
}

int main(int argc, char const *argv[])
{
	int NA = 6;
	int NB = 7;

	TMultime *A = init(sizeof(int), NA, int_id, int_cmp);
	TMultime *B = init(sizeof(int), NB, int_id, int_cmp);

	int v1[6] = {-1, 23, 4, 6, -9, 10};
	int v2[7] = {2, 4, -9, 12, 10, 1, 11};

	char *sa = (char*) A->s;
	memcpy(A->s, v1, NA * (A->d));
	sa += NA * A->d;
	A->s = (void*) sa;

	char *sb = (char*) B->s;
	memcpy(B->s, v2, NB * (B->d));
	sb += NB * B->d;
	B->s = (void*) sb;

	TMultime *I = init(sizeof(int), NA + NB, int_id, int_cmp);
	intersectie(A, B, I);

	int i;
	printf("Intersectia:\n");
	for(i = 0; i < (int) CARD(I); i++)
	{
		printf("%d ", int_afisare(I, i));
	}
	printf("\n");

	qsort((int*)A->p, NA, A->d, A->fcmp);
	qsort((int*)B->p, NB, B->d, B->fcmp);

	TMultime *D = init(sizeof(int), NA, int_id, int_cmp);
	diferenta_ord(A, B, D);

	printf("Diferenta:\n");
	for(i = 0; i < (int) CARD(D); i++)
	{
		printf("%d ", int_afisare(D, i));
	}
	printf("\n");

	printf("Transforma:\n");
	transforma(A, B);
	qsort((int*)A->p, (int) CARD(A), A->d, A->fcmp);

	for(i = 0; i < CARD(A); i++)
	{
		printf("%d ", int_afisare(A, i));
	}
	printf("\n");

	int z = -1;
	elimina(D, &z);

	printf("[%d]\n", (int) CARD(D));
	for(i = 0; i < (int) CARD(D); i++)
	{
		printf("[%d]", int_afisare(D, i));
	}
	printf("\n");

	return 0;
}
