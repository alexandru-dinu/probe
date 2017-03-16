#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define CARD(set) (((set)->p_tail - (set)->p_start) / (set)->data_type)
#define ISVOID(set) (set)->p_start == (set)->p_tail
#define ISFULL(set) (set)->p_tail == (set)->p_end

typedef int (*TFCMP) (const void *, const void *);

typedef struct {
	size_t data_type;
	void *p_start, *p_tail, *p_end;
	TFCMP id_funct, cmp_funct;
}TSet;

//Initializes a void set with nm elements of dt type
TSet *init(size_t dt, size_t nm, TFCMP _id, TFCMP _cmp)
{
	TSet *set = (TSet*) calloc(1, sizeof(TSet));
	if(!set)
		return NULL;

	set->p_start = calloc(nm, dt);
	if(!set->p_start)
	{
		free(set);
		return NULL;
	}

	set->data_type = dt;
	set->p_tail = set->p_start;

	char *_end = (char*) set->p_start + nm * dt;
	set->p_end = (void*) _end;

	set->id_funct = _id;
	set->cmp_funct = _cmp;

	return set;
}

//Frees the memory
void destroy(TSet **set)
{
	free((*set)->p_start);
	free(*set);
	*set = NULL;
}

/* Replace int data type with the one needed */
int int_id(const void *a, const void *b)
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

int int_getElem(TSet *set, int pos)
{
	if(ISVOID(set))
		exit(EXIT_FAILURE);

	char *location = (char*) set->p_start + pos * (set->data_type);

	return *(int*) location;
}

int int_addArray(TSet *set, int *arr, size_t nm)
{
	char *set_tail = (char*) set->p_tail;
	memcpy(set->p_tail, arr, nm * (set->data_type));
	set_tail += nm * (set->data_type);
	set->p_tail = (void*) set_tail;

	return 1;
}
/* ---------- */

//Searches elem in set
int search(TSet *set, void *elem)
{
	char *set_current = (char*) set->p_start;
	char *set_tail = (char*) set->p_tail;

	for(; set_current < set_tail; set_current += set->data_type)
		if(set->id_funct(elem, (void*) set_current))
			return 1;
	return 0;
}

//Inserts elem in set only if set is not full or already contains elem
int insert(TSet *set, void *elem)
{
	char *set_tail = (char*) set->p_tail;

	if(ISFULL(set))
		return 0;
	if(search(set, elem))
		return 0;

	memcpy(set->p_tail, elem, set->data_type);
	set_tail += set->data_type;
	set->p_tail = (void*) set_tail;

	return 1;
}

/* Operations */
int set_union(TSet *set1, TSet *set2, TSet *res)
{
	char *set1_current = (char*) set1->p_start;
	char *set1_tail = (char*) set1->p_tail;
	char *set2_current = (char*) set2->p_start;
	char *set2_tail = (char*) set2->p_tail;

	char *res_tail = (char*) res->p_tail;

	for(; set1_current < set1_tail; 
		set1_current += res->data_type, 
		res_tail += res->data_type)
		memcpy(res_tail, set1_current, res->data_type);

	res->p_tail = (void*) res_tail;

	for(; set2_current < set2_tail; set2_current += res->data_type)
		insert(res, (void*) set2_current);

	return 1;
}

int set_ounion(TSet *set1, TSet *set2, TSet *res)
{
	char *set1_current = (char*) set1->p_start;
	char *set1_tail = (char*) set1->p_tail;
	char *set2_current = (char*) set2->p_start;
	char *set2_tail = (char*) set2->p_tail;

	char *res_tail = (char*) res->p_tail;

	int val;

	while(set1_current < set1_tail && set2_current < set2_tail)
	{
		val = set1->cmp_funct((void*) set1_current, (void*) set2_current);

		if(val < 0)
		{
			insert(res, set1_current);
			set1_current += set1->data_type;
			res->p_tail += set1->data_type;
		}
		else if(val > 0)
		{
			insert(res, set2_current);
			set2_current += set2->data_type;
			res->p_tail += set2->data_type;
		}
		else
		{
			insert(res, set1_current);
			set1_current += set1->data_type;
			set2_current += set2->data_type;
			res_tail += res->data_type;
		}
	}

	return 1;
}

int set_intersect(TSet *set1, TSet *set2, TSet *res)
{
	char *set1_current = (char*) set1->p_start;
	char *set1_tail = (char*) set1->p_tail;
	char *set2_current = (char*) set2->p_start;
	char *set2_tail = (char*) set2->p_tail;

	char *res_tail = (char*) res->p_tail;

	for(; set1_current < set1_tail; set1_current += res->data_type)
	{
		for(set2_current = set2->p_start; set2_current < set2_tail; set2_current += res->data_type)
		{
			if(set1->id_funct((void*) set2_current, (void*) set1_current))
			{
				memcpy(res->p_tail, (void*) set2_current, res->data_type);
				res_tail += res->data_type;
				res->p_tail = (void*) res_tail;
			}
		}
	}
}

int set_odiff(TSet *set1, TSet *set2, TSet *res)
{
	char *set1_current = (char*) set1->p_start;
	char *set1_tail = (char*) set1->p_tail;
	char *set2_current = (char*) set2->p_start;
	char *set2_tail = (char*) set2->p_tail;

	char *res_tail = (char*) res->p_tail;

	for(; set1_current < set1_tail; set1 += res->data_type)
	{
		int count = 0;
		for(set2_current = set2->p_start; set2_current < set2_tail; set2_current += res->data_type)
		{
			if(!set1->id_funct((void*) set2_current, (void*) set1_current))
				count++;
		}
		if(count == (int) CARD(set2))
		{
			memcpy(res->p_tail, (void*) set1_current, res->data_type);
			res_tail += res->data_type;
			res->p_tail = (void*) res_tail;
		}
	}

	return 1;
}

int get_pos(TSet *set, void *elem)
{
	char *set_current = (char*) set->p_start;
	char *set_tail = (char*) set->p_tail;

	int i = 0;

	if(search(set, elem) == 0)
		return -1;

	for(; set_current < set_tail; set_current += set->data_type)
	{
		if(set->id_funct(elem, (void*) set_current) == 0)
			i++;
		else
			break;
	}

	return i;
}

int remove_elem(TSet *set, void *elem)
{
	if(ISVOID(set))
		return -1;
	if(search(set, elem) == 0)
		return -1;

	int loc = get_pos(set, elem);
	
	if(loc == 0)
	{
		char *set_current = (char*) set->p_start;
		set_current += set->data_type;
		set->p_start = (void*) set_current;
	}
	else
	{
		char *set_current = (char*) set->p_start + loc * (set->data_type);
		char *set_tail = (char*) set->p_tail;

		int N_shift = CARD(set) - loc - 1;

		while(N_shift)
		{
			*set_current = *(set_current + set->data_type);
			set_current += set->data_type;

			N_shift--;
		}

		set_tail -= set->data_type;
		set->p_tail = (void*) set_tail;
		}

	return 1;
}
/* ---------- */