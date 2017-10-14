"""
Very simple solver for Calculator: The Game
https://play.google.com/store/apps/details?id=com.sm.calculateme&hl=en
"""

sign = lambda x: (1, -1)[x < 0]
strip_sign = lambda x : x[1:] if x[0] == '-' else x

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
    [val, fname, kids, path] = tree

    if val == target:
        print " | ".join(path[:])

    for k in kids:
        solve(k, target)


"""
Game parameters
"""
initial = 1001
target = 210
moves = 5
ops = {
    # "*2" : lambda x : x  * 2,
    # "10" : lambda x : int(str(x) + ('10')),
    # "^3" : lambda x : int(x ** 3),
    # "10->1" : lambda x : int(str(x).replace('10', '1')),
    # "SUM" : lambda x : sign(x) * sum([int(c) for c in strip_sign(str(x))])

    # "-9" : lambda x : x - 9,
    # "*3" : lambda x : x * 3,
    # "+4" : lambda x : x + 4,
    # "+/-" : lambda x : (-1) * x,
    # "Rev" : lambda x : sign(x) * int(strip_sign(str(x))[::-1])

    # "<<" : lambda x : 0 if len(strip_sign(str(x))) == 1 else int(str(x)[:-1]),
    # "+6" : lambda x : x + 6,
    # "-3" : lambda x : x - 3,

    # "1" : lambda x : int(str(x) + ('1')),
    # "*3" : lambda x : x * 3,
    # "Rev" : lambda x : sign(x) * int(strip_sign(str(x))[::-1])

    "+2" : lambda x : x + 2,
    "12->0" : lambda x : int(str(x).replace('12', '0')),
    #"S<" : lambda x : sign(x) * int(strip_sign(str(x))[1:] + strip_sign(str(x))[0]),
    "S>" : lambda x : int(strip_sign(str(x))[len(strip_sign(str(x)))-1] + strip_sign(str(x))[0:len(strip_sign(str(x)))-1])   
}


if __name__ == '__main__':

    tree = cons_tree(initial, target, moves)
    #print_tree(tree)
    solve(tree, target)