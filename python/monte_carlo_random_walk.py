"""
What is the longest random walk you can take
so that on average you will end up 4 blocks or fewer from home (0, 0)
"""

import random

import matplotlib.pyplot as plt
from tqdm import tqdm

dist = lambda pos: abs(pos[0]) + abs(pos[1])


def random_walk(steps):
    x, y = 0, 0

    for i in range(steps):
        (dx, dy) = random.choice([(0, 1), (0, -1), (1, 0), (-1, 0)])

        x += dx
        y += dy

    return (x, y)


trials = 20000
num_steps = 51
steps_range = list(range(1, num_steps + 1))

percentage = [0] * num_steps

for steps in tqdm(steps_range):

    close = 0

    for trial in range(trials):
        pos = random_walk(steps)

        # end up close to home
        if dist(pos) <= 4:
            close += 1

    percentage[steps - 1] = float(close) / trials

    # print "steps = ", steps, "percentage of close to home = ", percentage[steps-1]

# print list(range(1, num_steps + 1))
# print percentage


plt.plot(steps_range, percentage, "ro")
plt.grid(True)
plt.show()
