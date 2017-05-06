#	largest collatz sequence for X <= 10^6
import math
from joblib import Parallel, delayed

def steps(x):
	if (x != 0 and ((int(x) & (int(x)-1)) == 0)):
		return 0, x

	elif (x % 2 == 0):
		new = x / 2
	else:
		new = 3 * x + 1

	fst, snd = steps(new)
	return (1 + fst), snd


def getMax(lim):
	r = ()
	max_st = -1

	for i in range(10,1,-1):
		fst, snd = steps(i)
		T = fst + math.log(snd, 2) + 1

		if(T > max_st):
			max_st = T
			r = (max_st, i)

	return r


parallel = Parallel(n_jobs=4)
m, x = parallel(delayed(getMax)(10))

