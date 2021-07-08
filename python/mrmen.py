import sys
from collections import Counter
from operator import itemgetter

import matplotlib.pyplot as plt
import numpy as np
import seaborn as sns
from tqdm import tqdm

sns.set()

rules = {
    # ladders
    2: 19,
    7: 27,
    17: 38,
    26: 46,
    40: 82,
    44: 76,
    50: 92,
    53: 88,
    75: 86,
    # snakes
    98: 43,
    94: 45,
    91: 52,
    84: 47,
    74: 4,
    69: 33,
    49: 9,
    39: 15,
}

num_trials = int(sys.argv[1])
count = Counter()
avgpath = 0


def play_game():
    pos = 0
    l = 0

    while pos < 100:
        pos += np.random.randint(1, 7)
        pos = rules.get(pos, pos)
        count[pos] += 1

        l += 1

    return l


path_lens = []
for _ in tqdm(range(num_trials)):
    path_lens.append(play_game())

print("avg path len = {}".format(sum(path_lens) / num_trials))
print("max path len = {}".format(max(path_lens)))
print("min path len = {}".format(min(path_lens)))
print("most common sq = {}".format(max(count.items(), key=itemgetter(1))[0]))

cells, passes = zip(*count.items())

plt.stem(cells, passes, use_line_collection=True)
plt.xticks(np.arange(0, max(cells) + 1, 2))
plt.show()
