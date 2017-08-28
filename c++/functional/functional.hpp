#ifndef FUNCTIONAL_HPP
#define FUNCTIONAL_HPP

#include <iostream>
#include <functional>
#include <algorithm>
#include <vector>

namespace func
{
	template <typename T>
	bool empty(std::vector<T> &c)
	{
		return c.size() == 0;
	}

	template <typename T>
	uint length(std::vector<T> &c)
	{
		return c.size();
	}

	template <typename T>
	T head(std::vector<T> &c)
	{
		return c.at(0);
	}

	template <typename Op, typename T>
	void foreach(Op op, std::vector<T> &c)
	{
		std::for_each(c.begin(), c.end(), op);
	}

	template <typename T>
	std::vector<T>& cons_ms(T x, std::vector<T> &&c)
	{
		c.insert(c.begin(), x);
		return c;
	}

	template <typename T>
	std::vector<T>& tail_ms(std::vector<T> &c)
	{
		c.erase(c.begin(), c.begin() + 1);
		return c;
	}

	template <typename T>
	std::vector<T> take(uint n, std::vector<T> &c)
	{
		n = (n >= c.size()) ? c.size() : n;
		std::vector<T> r(c.begin(), c.begin() + n);
		return r;
	}

	template <typename T>
	std::vector<T> drop(uint n, std::vector<T> &c)
	{
		n = (n >= c.size()) ? c.size() : n;
		std::vector<T> r(c.begin() + n, c.end());
		return r;
	}

	// template <typename ArgType, typename Pred>
	// std::function<bool(ArgType)> negate_pred(Pred &pred)
	// {
	// 	return [&pred](ArgType t) { return !pred(t); };
	// }


} // namespace func

#endif
