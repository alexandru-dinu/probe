import numpy as np
import matplotlib.pyplot as plt
import sys
from operator import itemgetter

rules = {
    # ladders
    2 : 19,
    7 : 27,
    17 : 38,
    26 : 46,
    40 : 82,
    44 : 76,
    50 : 92,
    53 : 88,
    75 : 86,
    # snakes
    98 : 43,
    94 : 45,
    91 : 52,
    84 : 47,
    74 : 4,
    69 : 33,
    49 : 9,
    39 : 15
}

count = int(sys.argv[1])
history = {i : 0 for i in range(1, 106)}
avgpath = 0

def play_game():
    pos = 0
    l = 0

    while pos < 100:
        dice = np.random.randint(1, 7)

        pos += dice

        history[pos] += 1

        if pos in rules:
            pos = rules[pos]

        l += 1

    return l


pl = []
for _ in range(count):
    pl.append(play_game())

print("avg path len = {}".format(sum(pl) / count))
print("max path len = {}".format(max(pl)))
print("min path len = {}".format(min(pl)))
print("most common sq = {}".format(max(history.items(), key=itemgetter(1))[0]))

cells = list(history.keys())
passes = list(history.values())

plt.stem(cells, passes)
plt.grid()
plt.show()
