#include <iostream>
#include <string>

template <class T>
class Test
{
public:
	T m_data;
	Test() {}
	Test(T y): m_data(y) {}
	~Test() {}

	T operator/(Test const& that) {
		return this->m_data / that.m_data;
	}
};


int main()
{
	Test<double> s1(10);
	Test<double> s2(2.12);

	std::cout << s1 / s2 << std::endl;

	return 0;
}
