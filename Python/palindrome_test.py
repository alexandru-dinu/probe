# it needs to be adapted for strings, as well :)

import math


def getNrDigits(param):
    param = int((math.log(param) / math.log(10))) + 1
    return param


def chkPal(param):
    s = str(param)
    l = getNrDigits(param)
    count = 0

    for i in range(0, l):
        if s[i] == s[l - i - 1]:
            count += 1

    if count == l:
        print(param, "is palindrome.")
    else:
        print(param, "is not palindrome.")

x = input()

flag = 0
try:
    x = int(x)
except ValueError:
    flag = 1

if flag == 1:
    print("Incorrect input!")
elif int(x) <= 0:
    print("Incorrect input!")
else:
    chkPal(int(x))
