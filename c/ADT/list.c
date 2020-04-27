#include "list.h"

void print(const char* name, list_t xs) {
    printf("%s: ", name);
    show(xs);
}

int main() {
    list_t xs = cons(1, cons(2, cons(3, empty())));
    print("xs", xs);

    printf("size(xs): %d\n", size(xs));
    printf("head(xs): %d\n", head(xs));
    print("tail(xs)", tail(xs));
    print("trim(xs, 1)", trim(xs, 1));
    print("drop(xs, 2)", drop(xs, 2));

    for (int i = -5; i <= 5; i++)
        printf("%2d in xs: %d\n", i, contains(xs, i));

    for (int i = 0; i < size(xs); i++)
        printf("xs[%2d] = %d\n", i, get(xs, i));

    for (int i = -5; i <= 5; i++)
        printf("pos of %2d = %d\n", i, pos(xs, i));

    list_t ys = ins(append(xs, reverse(xs)), 4, 3);
    print("ys", ys);
    printf("palindrome(ys): %d\n", eq(ys, reverse(ys)));

    printf("(xs == ys): %d\n", eq(xs, ys));

    return 0;
}
