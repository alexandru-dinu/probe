#include <iostream>
#include <functional>
#include <algorithm>
#include <vector>
#include <random>
#include <chrono>

#include "functional.hpp"

using namespace func;

auto echo = [](int x) {std::cout << x << std::endl;};
auto inc = [](int x) {return x + 1;};
auto sub = [](int x, int y) {return x - y;};
auto even = [](int x) {return (x % 2 == 0);};


template <typename T>
std::vector<T> merge(std::vector<T> v1, std::vector<T> v2)
{
    if (empty(v1))
        return v2;
    if (empty(v2))
        return v1;

    T x1 = head(v1);
    T x2 = head(v2);

    if (x1 < x2)
        return cons_ms(x1, std::move(merge(tail_ms(v1), v2)));
    else
        return cons_ms(x2, std::move(merge(v1, tail_ms(v2))));
}

template <typename T>
std::vector<T> mergesort(std::vector<T> &&v)
{
    if (length(v) <= 1)
        return v;

    int mid = length(v) / 2;

    return merge(mergesort(std::move(take(mid, v))),
                 mergesort(std::move(drop(mid, v))));
}


int main(int argc, char const *argv[])
{
    int N = std::stoi(argv[1]);
    std::vector<int> v(N);

    for (int i = 0; i < N; i++)
        v[i] = N - i;

    auto begin = std::chrono::high_resolution_clock::now();

    std::vector<int> s = mergesort(std::move(v));

    auto end = std::chrono::high_resolution_clock::now();
    std::cout << std::chrono::duration_cast<std::chrono::nanoseconds>(end-begin).count() * 1e-6 << "ms" << std::endl;

    for (int i = 0; i < N - 1; i++) {
        if (s[i + 1] < s[i])
            return 1;
    }

    std::cout << "OK\n";

    return 0;
}
