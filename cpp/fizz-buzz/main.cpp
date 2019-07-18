#include <iostream>

#include "tags.h"

int main() {

	for (int i = 1; i <= 120; i++) {
		std::cout << get(i) << "\n";
	}

	return 0;
}