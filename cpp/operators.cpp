#include <iostream>

struct s {
    
    int x;

    s() {}

    int operator+(const struct s& x) {
        return 42;
    }
};

template <typename X, typename Y>
auto add(X x, Y y) -> decltype(x + y) {
    return x + y;
}

int main(void)
{
    struct s x{}, y{};

    std::cout << x + y << std::endl;

    return 0;
}
