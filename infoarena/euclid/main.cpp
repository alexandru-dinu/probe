#include <iostream>
#include <fstream>

using namespace std;

int func(int a, int b) {
	if(b == 0)
		return a;
	else return func(b, a % b);
}

int main() {
	ifstream ifs;
	ofstream ofs;

	ifs.open("euclid2.in");
	ofs.open("euclid2.out");

	int n;
	ifs >> n;

	for(int i = 0; i < n; i++) {
		int a, b;

		ifs >> a >> b;

		ofs << func(a, b) << "\n";
	}

	ifs.close();
	ofs.close();
}