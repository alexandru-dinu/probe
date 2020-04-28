#include <iostream>
#include <bits/stdc++.h>

using namespace std;

const vector<pair<int, string>> tags = {
    {3, "Fizz"}, {5, "Buzz"}, {7, "Bazz"}
};

string fizz_buzz(int x) {
    string out = "";

    for (auto& it : tags)
        if (x % it.first == 0)
            out += it.second;

    return out.empty() ? to_string(x) : out;
}

int main(int argc, const char* argv[]) {
	for (int i = 1; i <= stoi(argv[1]); i++)
		cout << fizz_buzz(i) << endl;

	return 0;
}