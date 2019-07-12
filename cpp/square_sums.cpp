#include <iostream>
#include <unordered_map>
#include <set>
#include <vector>
#include <math.h>
#include <functional>

using num_t     = int;
using set_t     = std::set<num_t>;
using graph_t   = std::unordered_map<num_t, set_t>;

inline void add_node(num_t node, graph_t& g, const set_t& squares) {
    g[node] = set_t();

    for (auto it = g.begin(); it != g.end(); ++it) {
        if (squares.find(it->first + node) != squares.end()) {
            (it->second).insert(node);
            g[node].insert(it->first);
        }
    }
}

inline std::vector<num_t> get_path(graph_t& g, num_t start, std::vector<num_t> acc) {
    if (std::find(acc.begin(), acc.end(), start) != acc.end())
        return {};

    acc.emplace_back(start);

    if (acc.size() == g.size())
        return acc;

    for (auto& next : g[start]) {
        auto p = get_path(g, next, acc);
        if (not p.empty())
            return p;
    }


    return {};
}

std::vector<int> square_sums_row(int N)
{
    graph_t g;
    set_t squares;

    num_t lim = static_cast<num_t>(sqrt(2 * N - 1));

    for (num_t i = 1; i <= lim; i++)
        squares.insert(i * i);

    for (num_t i = 1; i <= N; i++)
        add_node(i, g, squares);

    for (num_t s = 1; s <= N; s++) {
        std::vector<num_t> acc;
        auto p = get_path(g, s, acc);

        if (not p.empty())
            return p;
    }

    return {};
}

int main(int, char** argv) {
    int N = std::stoi(argv[1]);

    auto sol = square_sums_row(N);

    for (auto x: sol)
        std::cout << x << " ";
    std::cout << "\n";


    return 0;
}
