#include "arraylist.h"

int main() {
	ArrayList A = new();

	int i;
	for(i = 0; i < 13; i++) {
		A = cons(A, i);
	}
	print(A);

	A = ins(A, -1, 10);
	A = cons(A, 11);
	A = ins(ins(A, 50, 2), -50, 2);

	print(A);

	printf("%d, %d\n", A->capacity, A->index);
	
	return 0;
}