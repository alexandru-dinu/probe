#include <iostream>
#include <vector>
#include <cstdlib>
#include <string>
#include <stdexcept>

using namespace std;


template <class T = int>
class Stack {
private:
	vector<T> elems;

public:
	void push(T const&);
	void pop();
	T top() const;
	bool empty() {return elems.empty();}

	static int count;
};

template <typename T> int Stack<T>::count = 0;

template <class T>
void Stack<T>::push (T const& elem) {
	elems.push_back(elem);

	Stack<T>::count += 1;
}

template <class T>
void Stack<T>::pop() {
	if(elems.empty())
		throw out_of_range("Stack is empty");

	elems.pop_back();
}

template <class T>
T Stack<T>::top() const {
	if(elems.empty())
		throw out_of_range("Stack is empty");

	return elems.back();
}


int main(int argc, char const *argv[])
{
	Stack<> int_stack;
	Stack<string> str_stack;

	int_stack.push(1);
	int_stack.push(2);

	str_stack.push("one");
	
	cout << "default type: " << Stack<>::count << endl;
	cout << "specified type: " << Stack<string>::count << endl;

	return 0;
}