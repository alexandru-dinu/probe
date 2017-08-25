#ifndef FUNCTIONAL_HPP
#define FUNCTIONAL_HPP

#include <iostream>
#include <functional>
#include <algorithm>
#include <vector>

namespace func {

	template <typename Collection>
	bool empty(Collection c)
	{
		return c.size() == 0;
	}

	template <typename Collection>
	unsigned int length(Collection c)
	{
		return c.size();
	}

	template <typename Collection>
	typename Collection::value_type head(Collection c)
	{
		return c.at(0);
	}

	template <typename ArgType, typename Pred>
	std::function<bool(ArgType)> negate_pred(Pred &pred)
	{
		return [&pred](ArgType t) { return !pred(t); };
	}



	template <typename Elem, typename Collection>
	Collection cons(Elem x, Collection c)
	{
		c.insert(c.begin(), x);
		return c;
	}

	template <typename Elem, typename Collection>
	void cons_r(Elem x, Collection &c)
	{
		c.insert (c.begin(), x);
	}



	template <typename Collection>
	Collection take(unsigned int p, Collection c)
	{
		p = (p >= c.size()) ? c.size() : p;
		c.erase(c.begin() + p, c.end());
		return c;
	}

	template <typename Collection>
	void take_r(unsigned int p, Collection &c)
	{
		p = (p >= c.size()) ? c.size() : p;
		c.erase(c.begin() + p, c.end());
	}



	template <typename Collection>
	Collection drop(unsigned int p, Collection c)
	{
		p = (p >= c.size()) ? c.size() : p;
		c.erase(c.begin(), c.begin() + p);
		return c;
	}

	template <typename Collection>
	void drop_r(unsigned int p, Collection &c)
	{
		p = (p >= c.size()) ? c.size() : p;
		c.erase(c.begin(), c.begin() + p);
	}



	template <typename Collection>
	Collection tail(Collection c)
	{
		c.erase(c.begin(), c.begin() + 1);
		return c;
	}

	template <typename Collection>
	void tail_r(Collection &c)
	{
		c.erase(c.begin(), c.begin() + 1);
	}



	template <typename UnaryOperator, typename Collection>
	void foreach(UnaryOperator op, Collection c)
	{
		std::for_each(c.begin(), c.end(), op);
	}


	// higher-order functions

	// template <typename UnaryOperator, typename Collection>
	// void map(UnaryOperator op, Collection &c)
	// {
	// 	std::transform(c.begin(), c.end(), c.begin(), op);
	// }

	// template <typename BinaryOperator, typename Collection>
	// Collection zipWith(BinaryOperator op, Collection c1, Collection c2)
	// {
	// 	Collection r = c1;
	// 	std::transform(r.begin(), r.end(), c2.begin(), r.begin(), op);
	// 	return r;
	// }

	// template <typename Predicate, typename Collection>
	// Collection filter(Predicate pred, Collection c)
	// {
	// 	Collection r = c;
	// 	r.erase(std::remove_if(
	// 			r.begin(), r.end(),
	// 			[pred](typename Collection::value_type i) { return !pred(i);}),
	// 			std::end(r));
	// 	return r;
	// }

} // namespace func

#endif
