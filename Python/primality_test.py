import math

def chkPrime(x):
	s = int(math.sqrt(x))
	if x % 2 == 0:
		return 0
	else:
		for i in range(3, s):
			if x % i == 0:
				return 0
	return 1

x = raw_input()
x = int(x)

if chkPrime(x) == 1:
	print x, "is prime."
else:
	print x, "is not prime."