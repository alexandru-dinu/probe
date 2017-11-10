#include <iostream>
#include <algorithm>
#include <vector>
#include <map>
#include <unordered_map>

typedef std::pair<std::string, int> entry_t;

// O(NlogN)
std::vector<entry_t> count1(std::vector<std::string> &words, int k)
{
	std::map<std::string, int> freqs;

	// default initializer => value = 0
	// no need to check if key already exists
	// O(NlogN)
	for (std::string word : words) {
		freqs[word]++;
	}

	std::vector<entry_t> vfreqs;
	vfreqs.reserve(freqs.size());

	// O(N)
	for (auto it = std::begin(freqs); it != std::end(freqs); ++it) {
		entry_t e(it->first, it->second);
		vfreqs.push_back(e);
	}

	// O(NlogN)
	std::sort(std::begin(vfreqs), std::end(vfreqs), [](auto &p1, auto &p2) {return p1.second > p2.second;});

	// our resulting vector (might contain at least k words - some may have equal frequency)
	std::vector<entry_t> res;
	res.reserve(k);

	std::vector<entry_t>::size_type j = 0;
	int current_freq = vfreqs[0].second;

	// O(N)
	for (int i = 0; i < k; i++) {
		while (j != vfreqs.size() && vfreqs[j].second == current_freq) {
			res.push_back(vfreqs[j]);
			j++;
		}

		current_freq = vfreqs[j].second;
	}

	return res;
}


// O(NlogN)
std::vector<entry_t> count2(std::vector<std::string> &words, int k)
{
	std::unordered_map<std::string, int> freqs;

	// O(N), constant insertion / lookup
	for (std::string word : words)
		freqs[word]++;

	
	std::multimap<int, std::string> ord_freqs;

	// O(NlogN): O(N) copy, O(logN) insertion / lookup
	for (auto it = std::begin(freqs); it != std::end(freqs); ++it)
		ord_freqs.insert(std::make_pair(it->second, it->first));


	std::vector<entry_t> res;
	res.reserve(k);

	auto temp = std::rbegin(ord_freqs);
	int current_freq = temp->first;

	// O(N)
	for (auto it = std::rbegin(ord_freqs); it != std::rend(ord_freqs); ++it) {
		int f = it->first;
		std::string s = it->second;

		if (f < current_freq) {
			k--;
			current_freq = f;
		}

		if (k == 0)
			break;

		res.push_back(std::make_pair(s, f));
	}

	return res;
}


std::vector<entry_t> count3(std::vector<std::string> &words, int k)
{
	std::unordered_map<std::string, int> freqs;

	for (std::string word : words)
		freqs[word]++;

	std::vector<entry_t> aux;
	aux.reserve(freqs.size());

	for (auto it = std::begin(freqs); it != std::end(freqs); ++it)
		aux.push_back(*it);

	std::nth_element(std::begin(aux), std::begin(aux) + k, std::end(aux), [](const auto &a, const auto &b) {return a.second > b.second;});

	std::vector<entry_t> res;
	res.reserve(k);

	int current_freq = aux[0].second;

	for (auto it = std::begin(aux); it != std::end(aux); ++it) {
		std::string s = it->first;
		int f = it->second;
		
		if (f < current_freq) {
			k--;
			current_freq = f;
		}

		if (k == 0)
			break;

		res.push_back(*it);
	}

	return res;
}

int main(int argc, char const *argv[])
{
	std::vector<std::string> words = {"a", "a", "a", "b", "b", "b", "b", "c", "d", "d", "d"};

	std::vector<entry_t> res1 = count1(words, std::stoi(argv[1]));
	std::vector<entry_t> res2 = count2(words, std::stoi(argv[1]));	
	std::vector<entry_t> res3 = count3(words, std::stoi(argv[1]));

	for (entry_t e : res1) {
		std::cout << e.first << ": " << e.second << std::endl;
	}

	std::cout << "----------\n";

	for (entry_t e : res2) {
		std::cout << e.first << ": " << e.second << std::endl;
	}

	std::cout << "----------\n";

	for (entry_t e : res3) {
		std::cout << e.first << ": " << e.second << std::endl;
	}

	return 0;
}
