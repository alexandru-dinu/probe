"""
Very simple solver for Calculator: The Game
https://play.google.com/store/apps/details?id=com.sm.calculateme&hl=en
"""

import sys


sign        = lambda x : (1, -1)[x < 0]
strip_sign  = lambda x : str(x)[1:] if x < 0 else str(x)


class Ops:
    def __init__(self, funcs):
        self.funcs = funcs

    def expand(self, x):
        return [(name, f(x)) for (name, f) in self.funcs.items()]

    def __len__(self):
        return len(self.funcs)


class Node:
    def __init__(self, value, name, kids, path):
        self.value = value
        self.name = name
        self.kids = kids
        self.path = path


def cons_tree(initial, target, moves, ops):
    root = Node(value=initial, name="ROOT", kids=[], path=[])

    queue = [root]
    num_nodes = sum(len(ops) ** i for i in range(1, moves + 1))

    while queue != [] and num_nodes >= 0:
        node = queue.pop(0)

        for (name, val) in ops.expand(node.value):
            kid = Node(value=val, name=name, kids=[], path=node.path + [name])
            queue += [kid]
            node.kids += [kid]
            num_nodes -= 1

    return root


def solve(tree, target):
    solutions = []

    if tree.value == target:
        return [" | ".join(tree.path)]

    for k in tree.kids:
        s = solve(k, target)
        solutions += s if s != [] else []

    return solutions


def print_tree(tree):
    print_tree_ex(tree, 0)


def print_tree_ex(tree, indent):
    ind = "".join([' ' for i in range(indent)])
    print(ind, tree.path, " -> ", str(tree.value))

    for k in tree.kids:
        print_tree_ex(k, indent + 8)


def main(initial, target, moves, ops):
    tree = cons_tree(initial, target, moves, ops)
    # print_tree(tree)

    solutions = solve(tree, target)

    for i, solution in enumerate(solutions):
        print(f"[{i}]: {solution}")


if __name__ == '__main__':
    lines = [l.strip() for l in open(sys.argv[1]).readlines()[1:]]

    initial = int(lines[0])
    target  = int(lines[1])
    moves   = int(lines[2])
    ops     = Ops(eval(" ".join([l for l in lines[3:] if len(l) > 0 and l[0] != '#'])))

    main(initial, target, moves, ops)
