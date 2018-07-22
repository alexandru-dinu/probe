#include <stdio.h>
#include <stdlib.h>
#include <limits.h>

typedef struct list {
	int element;
	struct list* next;
}Cell, *List;

// constructs a new cell
List new(int element) {
	List aux = calloc(1, sizeof(Cell));
	aux->element = element;
	aux->next = NULL;

	return aux;
}

// inserts the element e at the beginning of L
List cons(int e, List L) {
	List cell = new(e);
	cell->next = L;

	return L = cell;
}

// returns an empty list
List empty() {
	return NULL;
}

// returns the first element of the list
int head(List L) {
	return L->element;
}

// returns the list without its first element
List tail(List L) {
	return L->next;
}

// returns the size of the list
int size(List L) {
	return (L == NULL) ? (0) : (1 + size(tail(L)));
}

// checks whether the element e exists in the list
int contains(List L, int e) {
	if(L == empty())
		return 0;
	else return (head(L) == e) | contains(tail(L), e); 
}

// gets the i-th element of the list
int get(List L, int i) {
	if(i == 0)
		return head(L);
	else if(i > 0 && i < size(L))
		return get(tail(L), i - 1);
	else return INT_MIN;
}

// returns the position of the element e in the list
int pos(List L, int e) {
	return (contains(L, e)) ? (1 + pos(tail(L), e)) : (-1);
}

// inserts the element e on the position i
List ins(List L, int e, int i) {
	if(i == 0)
		return cons(e, L);
	else if(i > 0 && i <= size(L))
		return cons(head(L), ins(tail(L), e, i - 1));
	else return L;
}

// appends L2 to L1
List append(List L1, List L2) {
	return (L1 == empty()) ? (L2) : (cons(head(L1), append(tail(L1), L2)));
}

// reverses the list
List reverse(List L) {
	if(L == empty()) 
		return empty();
	else return append(reverse(tail(L)), cons(head(L), empty()));
}

// trims the first i elements from the list
List trim(List L, int i) {
	if(i > 0 && i <= size(L))
		return trim(tail(L), i - 1);
	else return L;
}

// drops the last i elements from the list
List drop(List L, int i) {
	return reverse(trim(reverse(L), i));
}

// checks whether the lists are identical
int eq(List L1, List L2) {
	if(L1 == empty() && L2 == empty())
		return 1;
	else return (head(L1) == head(L2)) & eq(tail(L1), tail(L2));
}

//	prints the list
void print(List L) {
	if(L == empty())
		printf("(empty)\n");
	else {
		for(; L; printf("%d ", head(L)), L = tail(L));
		printf("\n");
	}
}