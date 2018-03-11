#include <iostream>
#include <map>

using namespace std;

struct RandomListNode {
    int label;
    RandomListNode *next, *random;
    RandomListNode(int x) : label(x), next(NULL), random(NULL) {}
};

class Solution {
public:
     RandomListNode *clone(RandomListNode *head, std::map<void*, void*> &m) {
        if (head == NULL)
            return NULL;

        RandomListNode *node = new RandomListNode(head->label);
        m[(void*)head] = (void*) node;
        node->next = clone(head->next, m);
        return node;
    }

    RandomListNode *copyRandomList(RandomListNode *head) {
        std::map<void*, void*> m;

        RandomListNode *copy = clone(head, m);

        RandomListNode *auxc = copy;
        RandomListNode *auxh = head;

        while (auxh != NULL) {
            auxc->random = (RandomListNode*) m[(RandomListNode*)auxh->random];

            auxc = auxc->next;
            auxh = auxh->next;
        }

        return copy;
    }
};


int main()
{
    RandomListNode* n1 = new RandomListNode(1);
    RandomListNode* n2 = new RandomListNode(2);
    RandomListNode* n3 = new RandomListNode(3);

    n1->next = n2;
    n1->random = n3;

    n2->next = n3;
    n2->random= n1;

    n3->next = NULL;
    n3->random = n2;

    Solution s;

    RandomListNode *c1 = s.copyRandomList(n1);
    RandomListNode *c2 = c1->next;
    RandomListNode *c3 = c2->next;

    cout << (void*) c2->random << endl;
    cout << (void*) c1 << endl;

    return 0;
}
