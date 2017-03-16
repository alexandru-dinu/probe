import math
import sys

def next(a, c, m, val):
	return (a * val + c) % m

a = int(sys.argv[1])
c = int(sys.argv[2])
m = int(sys.argv[3])
val = int(sys.argv[4])

arr = (next(a, c, m, val), )

for i in range (1, 10):
	arr = arr + (next (a, c, m, arr[i-1]), )

print arr