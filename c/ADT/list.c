#include "list.h"

int main() {
	List L1 = cons(1, cons(2, cons(3, empty())));

	print(L1);

	return 0;
}
