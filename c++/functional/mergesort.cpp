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

list merge(list l1, list l2)
{
    if (empty(l1))
        return l2;
    if (empty(l2))
        return l1;

    return (head(l1) < head(l2)) ?
            cons(head(l1), merge(tail(l1), l2)) :
            cons(head(l2), merge(l1, tail(l2)));
}

list mergesort(list l)
{
    int mid = length(l) / 2;

    switch(length(l)) {
        case 0:
        case 1:
            return l;
        default:
            return merge(mergesort(take(mid, l)),
                         mergesort(drop(mid, l)));
    }
}



int main() {

    list v1 = {10, 9, 8, 7, 7, 7, 5, 1, 2, 3};

    list v2(N);

    std::random_device rd;
    std::default_random_engine dre(rd());
    std::uniform_int_distribution<int> uid(0,1000);

    for (int i = 0; i < N; i++) {
        v2[i] = uid(dre);
    }

    auto begin = std::chrono::high_resolution_clock::now();

    mergesort(v2);

    auto end = std::chrono::high_resolution_clock::now();
    std::cout << std::chrono::duration_cast<std::chrono::nanoseconds>(end-begin).count() * 1e-6 << "ms" << std::endl;

    // foreach(echo, v2);

    return 0;
}
