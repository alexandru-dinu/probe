#include "tags.h"

#include <vector>
#include <utility>
#include <algorithm>

std::vector<std::pair<int, std::string>> tags = {
    {3, "Fizz"}, {5, "Buzz"}, {7, "Bazz"}
};

std::string get(int x) {
    std::string out = "";

    for (auto& it : tags) {
        if (x % it.first == 0)
            out += it.second;
    }

    return out.empty() ? std::to_string(x) : out;
}
