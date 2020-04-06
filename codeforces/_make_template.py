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

last = sorted([int(x.split('_')[0]) for x in glob.glob('*.cpp')])[-1]
name = '_'.join(map(lambda x: x.lower(), sys.argv[1:]))

out_name = f'{last+1}_{name}.cpp'
assert not os.path.exists(out_name)

with open(out_name, 'wt') as fp:
    fp.write(code)
