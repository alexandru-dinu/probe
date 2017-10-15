"""
Very simple solver for Calculator: The Game
https://play.google.com/store/apps/details?id=com.sm.calculateme&hl=en
"""

sign = lambda x: (1, -1)[x < 0]
strip_sign = lambda x : x[1:] if x[0] == '-' else x

ss = lambda x : strip_sign(str(x))

expand = lambda x : [(name, f(x)) for (name, f) in ops.iteritems()]

VALUE = 0
NAME = 1
KIDS = 2
PATH = 3


# node = [value, function_name, kids, path]
def cons_tree(initial, target, moves):
    root = [initial, "ROOT", [], []]

    queue = [root]

    num_nodes = sum(len(ops) ** i for i in range(1, moves + 1))

    while queue != [] and num_nodes >= 0:
        [nval, nname, nkids, npath] = queue.pop(0)

        for (name, val) in expand(nval):
            kid = [val, name, [], npath + [name]]
            queue.append(kid)
            nkids.append(kid)
            num_nodes -= 1
        
    return root


def print_tree(tree):
    print_tree_ex(tree, 0)

def print_tree_ex(tree, indent):
    [val, name, kids, path] = tree

    ind = "".join([' ' for i in range(indent)])
    print ind, path, " -> ", str(val)

    for k in kids:
        print_tree_ex(k, indent + 8)


def solve(tree, target):
    solutions = []
    [val, fname, kids, path] = tree

    if val == target:
        return [" | ".join(path)]

    for k in kids:
        s = solve(k, target)
        solutions += s if s != [] else []

    return solutions


"""
Game parameters
"""
initial = 9
target = 30
moves = 4
ops = {
    # "*2" : lambda x : x  * 2
    # "^3" : lambda x : int(x ** 3)

    # "0" : lambda x : int(str(x) + ('0'))
    # "10->1" : lambda x : int(str(x).replace('10', '1'))

    # "SUM" : lambda x : sign(x) * sum([int(c) for c in ss(x))]),
    # "Rev" : lambda x : sign(x) * int(ss(x)[::-1])

    # "<<" : lambda x : 0 if len(ss(x))) == 1 else int(str(x)[:-1])
    # "S<" : lambda x : sign(x) * int(ss(x)[1:] + ss(x)[0]) 
    # "S>" : lambda x : int(ss(x)[len(ss(x)))-1] + ss(x)[0:len(ss(x))-1])   

    "-5" : lambda x : x - 5,
    "*-6" : lambda x : x * (-6),
    "+/-" : lambda x : x * (-1),
    "SUM" : lambda x : sign(x) * sum([int(c) for c in ss(x)])
}


if __name__ == '__main__':

    tree = cons_tree(initial, target, moves)
    #print_tree(tree)

    for solution in solve(tree, target):
        print solution