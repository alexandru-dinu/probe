#include <iostream>
#include <stdlib.h>

using namespace std;

struct Node {
	int data;
	struct Node* next;
};

Node* empty() {
	return nullptr;
}

Node* cons(int data, Node* next) {
	Node* l = new Node;

	l->data = data;
	l->next = next;

	return l;
}


Node* append(Node* l1, Node* l2) {
	if(l1 == empty())
		return l2;

	return cons(l1->data, append(l1->next, l2));
}

Node* consLast(int data, Node* head) {
	Node* r = append(head, cons(data, empty()));

	return r;
}


Node* RemoveDuplicates(Node *head)
{
    Node* clean = new Node;
    clean->data = head->data;
    clean->next = nullptr;
    
    head = head->next;
    
    int last = clean->data;
    
    while(head != nullptr) {

        if(last != head->data) {
            clean = consLast(head->data, clean);
            last = head->data;
        }
        
        head = head->next;
    }

    
    
    return clean;
}


int main(int argc, char const *argv[])
{
	
	Node* l1 = cons(1, cons(1, cons(3, cons(3, cons(5, cons(6, empty()))))));

	Node* c = RemoveDuplicates(l1);

	while(c != empty()) {
		cout << c->data << " ";
		c = c->next;
	}
	cout << endl;

	return 0;
}