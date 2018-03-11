#include <iostream>
#include <fstream>
#include <assert.h>

using namespace std;

#define MAX(a, b) ((a > b) ? a : b)
#define FOR(i, a, b) for (i = a; i <= b; i++)
#define LMAX 1024

typedef int byte;

byte A[LMAX], B[LMAX], M[LMAX][LMAX]; 
byte RES[LMAX];

int main() {
	ifstream ifs;
	ofstream ofs;

	ifs.open("cmlsc.in");
	ofs.open("cmlsc.out");

	int m, n, i, j;
	ifs >> m >> n;

	assert(1 <= m && m <= 1024);
	assert(1 <= n && n <= 1024);


	FOR(i, 1, m)
		ifs >> A[i];

	FOR(i, 1, n)
		ifs >> B[i];

	//	populate
	FOR(i, 1, m) {
		FOR(j, 1, n) {
			if(A[i] == B[j])
				M[i][j] = 1 + M[i-1][j-1];
			else
				M[i][j] = MAX(M[i-1][j], M[i][j-1]);
		}
	}


	//	reconstruct
	int k = 0;
	for(i = m, j = n; i != 0, j != 0; ) {
		if(A[i] == B[j]) {
			RES[k++] = A[i];
			i--;
			j--;
		}
		else if(M[i-1][j] > M[i][j-1])
			i--;
		else
			j--;
	}

	ofs << k << "\n";

	for(int i = k-1; i >= 0; i--)
		ofs << RES[i] << " ";
	ofs << "\n";

	ifs.close();
	ofs.close();

	return 0;
}