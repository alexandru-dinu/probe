#!/usr/bin/env python

import os
import sys
import glob

assert len(sys.argv) > 1

code = """
#include <iostream>
#include <bits/stdc++.h>

using namespace std;

#define ll long long

int main() {
    ios::sync_with_stdio(0);
    cin.tie(NULL);

    ;

    return 0;
}
""".strip()

directory = sys.argv[1]
name = os.path.join(directory, '_'.join(map(lambda x: x.lower(), sys.argv[2:])) + ".cpp")
assert not os.path.exists(name)

with open(name, 'wt') as fp:
    fp.write(code)
