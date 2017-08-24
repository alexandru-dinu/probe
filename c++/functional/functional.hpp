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
		Collection r = c;
		Collection dummy;

		r.insert (r.begin(), x);

		c.swap(dummy);
		return r;
	}

	template <typename Collection>
	Collection take(int p, Collection c)
	{
		Collection r = c;
		Collection dummy;

		p = (p >= c.size()) ? c.size() : p;
		r.erase(r.begin() + p, r.end());

		c.swap(dummy);
		return r;
	}

	template <typename Collection>
	Collection drop(int p, Collection c)
	{
		Collection r = c;
		Collection dummy;

		p = (p >= c.size()) ? c.size() : p;
		r.erase(r.begin(), r.begin() + p);

		c.swap(dummy);
		return r;
	}

	template <typename Collection>
	Collection tail(Collection c)
	{
		return drop(1, c);
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
