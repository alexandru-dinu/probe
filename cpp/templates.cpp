#include <iostream>

template <std::uint64_t N>
struct factorial {
    enum { v = N * factorial<N - 1>::v };
};

template <>
struct factorial<0> {
    enum { v = 1 };
};

// ---

template<std::uint64_t n>
struct fibonacci {
    enum { v = fibonacci<n-1>::v + fibonacci<n-2>::v };
};

template <>
struct fibonacci<0> {
    enum { v = 0 };
};

template <>
struct fibonacci<1> {
    enum { v = 1 };
};

int main(void) {
    constexpr std::uint64_t n = 10;

    std::cout << n << "! = " << factorial<n>::v << "\n";
    std::cout << "F" << n << " = " << fibonacci<n>::v << "\n";

    return 0;
}