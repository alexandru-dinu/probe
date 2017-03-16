#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
#include <math.h>

typedef struct {
	int* v;
	int index, capacity;
}TArrayList, *ArrayList;

// constructs a new arraylist
ArrayList new() {
	ArrayList aux = calloc(1, sizeof(TArrayList));
	aux->index = 0;
	aux->capacity = 1;
	aux->v = calloc(aux->capacity, sizeof(int));

	return aux;
}

// auxiliary resize function for cons
int* resize(int* v, int oldcapacity){
	int* aux = calloc(2 * oldcapacity, sizeof(int));
	int i;
	for(i = 0; i < oldcapacity; aux[i] = v[i], i++);

	return aux;
}

// inserts the element e at the end of A
ArrayList cons(ArrayList A, int e) {
	if(A->index == A->capacity) {
		A->v = resize(A->v, A->capacity);
		A->capacity *= 2;
	}

	A->v[(A->index)++] = e;

	return A;
}

// returns an empty arraylist
ArrayList empty() {
	return NULL;
}

// returns the size of the arraylist
int size(ArrayList A) {
	return A->index;
}

// returns the first element of the arraylist
int head(ArrayList A) {
	return (A != empty()) ? (A->v[0]) : (INT_MIN);
}

// returns the arraylist without its first element
ArrayList tail(ArrayList A) {
	int* aux = calloc(size(A) - 1, sizeof(int));
	int i;
	for(i = 1; i < A->index; aux[i-1] = A->v[i], i++);

	(A->index)--;
	A->v = aux;
	
	return A;
}

// checks whether the element e exists in the arraylist
int contains(ArrayList A, int e) {
	if(A == empty() || size(A) == 0)
		return 0;
	else {
		int i;
		for(i = 0; i < size(A); i++) {
			if(A->v[i] == e)
				return 1;
		}
		return 0;
	}
}

// gets the i-th element of the arraylist
int get(ArrayList A, int i) {
	if(A == empty() || i < 0 || i > size(A) - 1)
		return INT_MIN;
	else return A->v[i];
}

// returns the position of the element e in the arraylist
int pos(ArrayList A, int e) {
	return (contains(A, e)) ? (1 + pos(tail(A), e)) : (-1);
}

// inserts the element e on the position i
ArrayList ins(ArrayList A, int e, int i) {
	if(i == size(A))
		return cons(A, e); 
	else if (i >= 0 && i < size(A)) {
		int k;
		A = cons(A, A->v[A->index - 1]);
		for(k = A->index - 3; k >= i; A->v[k+1] = A->v[k], k--);
		A->v[i] = e;

		return A;
	}
	else return A;
}

// appends A2 to A1
ArrayList append(ArrayList A1, ArrayList A2) {
	ArrayList res = A1;

	int i;
	for(i = 0; i < size(A2); cons(res, A2->v[i++]));

	return res;
}

// reverses the arraylist
ArrayList reverse(ArrayList A) {
	int i, n = size(A), mid = (int) ceil(n / 2);
	for(i = 0; i < mid; i++) {
		A->v[i] ^= A->v[n-1-i];
		A->v[n-1-i] ^= A->v[i];
		A->v[i] ^= A->v[n-1-i];
	}

	return A;
}

// trims the first i elements from the arraylist
ArrayList trim(ArrayList A, int i) {
	int* aux = calloc(size(A) - i, sizeof(int));

	int k;
	for(k = i; k < size(A); aux[k-i] = A->v[k], k++);

	A->index -= i;
	A->v = aux;

	return A;
}

// drops the last i elements from the arraylist
ArrayList drop(ArrayList A, int i) {
	return reverse(trim(reverse(A), i));
}

// checks whether the lists are identical
int eq(ArrayList A1, ArrayList A2) {
	if(A1 == empty() && A2 == empty())
		return 1;
	else if(size(A1) == size(A2)) {
		int i;
		for(i = 0; i < size(A1); i++) {
			if(A1->v[i] != A2->v[i])
				return 0;
		}
		return 1;
	}
	else return 0;
}

//	prints the arraylist
void print(ArrayList A) {
	if(A == empty() || A->index == 0)
		printf("(empty)\n");
	else {
		int i;
		for(i = 0; i < A->index; printf("%d ", A->v[i]), i++);
		printf("\n");
	}
}