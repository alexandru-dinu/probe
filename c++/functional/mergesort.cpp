#include <iostream>
#include <functional>
#include <algorithm>
#include <vector>
#include <random>
#include <chrono>

#include "functional.hpp"

using namespace func;

typedef std::vector<int> list;

#define N 50000

auto echo = [](int x) {std::cout << x << std::endl;};
auto inc = [](int x) {return x + 1;};
auto sub = [](int x, int y) {return x - y;};
auto even = [](int x) {return (x % 2 == 0);};




int main() {

    list v1 = {3, 2, 1};


    // test with large vector
    list v2(N);

    std::random_device rd;
    std::default_random_engine dre(rd());
    std::uniform_int_distribution<int> uid(0,1000);

    for (int i = 0; i < N; i++)
        v2[i] = uid(dre);

    auto begin = std::chrono::high_resolution_clock::now();

    // TODO

    auto end = std::chrono::high_resolution_clock::now();
    std::cout <<
        std::chrono::duration_cast<std::chrono::nanoseconds>(end-begin).count() * 1e-6 <<
        "ms" << std::endl;

    return 0;
}
