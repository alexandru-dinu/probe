#include <stdio.h>
#include <stdlib.h>
#include <limits.h>

typedef struct list_t {
    int val;
    struct list_t* next;
} cell_t, *list_t;


list_t new(int val) {
    list_t aux = calloc(1, sizeof(cell_t));
    aux->val = val;
    aux->next = NULL;
    return aux;
}

list_t cons(int e, list_t xs) {
    list_t cell = new(e);
    cell->next = xs;
    return xs = cell;
}

list_t empty() {
    return NULL;
}

int head(list_t xs) {
    return xs->val;
}

list_t tail(list_t xs) {
    return xs->next;
}

int size(list_t xs) {
    return (xs == NULL) ? 0 : (1 + size(tail(xs)));
}

int contains(list_t xs, int e) {
    if (xs == empty())
        return 0;

    if (head(xs) == e)
        return 1;

    return contains(tail(xs), e);
}

int get(list_t xs, int i) {
    return (i == 0) ? head(xs) : get(tail(xs), i-1);
}

int pos(list_t xs, int e) {
    return contains(xs, e) ? (1 + pos(tail(xs), e)) : (-1);
}

list_t ins(list_t xs, int e, int i) {
    return (i == 0) ? cons(e, xs) : cons(head(xs), ins(tail(xs), e, i - 1));
}

list_t append(list_t xs, list_t ys) {
    return (xs == empty()) ? ys : (cons(head(xs), append(tail(xs), ys)));
}

list_t reverse(list_t xs) {
    if (xs == empty())
        return empty();

    return append(reverse(tail(xs)), cons(head(xs), empty()));
}

list_t trim(list_t xs, int i) {
    if (xs == empty())
        return empty();

    return (i == 0) ? xs : trim(tail(xs), i - 1);
}

list_t drop(list_t xs, int i) {
    return reverse(trim(reverse(xs), i));
}

int eq(list_t xs, list_t ys) {
    if (xs == empty() && ys == empty())
        return 1;

    if ((xs == empty()) != (ys == empty()) || head(xs) != head(ys))
        return 0;

    return eq(tail(xs), tail(ys));
}

void show(list_t xs) {
    if(xs == empty()) {
        printf("()\n");
    }
    else {
        printf("%d -> ", head(xs));
        show(tail(xs));
    }
}
