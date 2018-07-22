#include <iostream>
#include <algorithm>
#include <vector>
#include <chrono>
#include <cmath>

bool pred(int x) {
	return std::sqrt(x * 2.317f - 0.178f / std::sqrt(x + 3.1f * x));
}

int main(int argc, char const *argv[])
{
    int N = std::stoi(argv[1]);
    std::vector<int> v(N);

    for (int i = 0; i < N; i++)
        v[i] = N - i;

    std::vector<int>::size_type sz = v.size();

    auto begin = std::chrono::high_resolution_clock::now();

   	// for (std::vector<int>::const_iterator iter = v.begin(); iter != v.end(); ++iter)
   	// 	pred(*iter);

   	for (int i = 0; i < sz; i++)
   		pred(v[i]);

    auto end = std::chrono::high_resolution_clock::now();
    std::cout << std::chrono::duration_cast<std::chrono::nanoseconds>(end-begin).count() * 1e-6 << " ms" << std::endl;

    return 0;
}
