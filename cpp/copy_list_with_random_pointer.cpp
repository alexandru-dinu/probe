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
        RandomListNode *auxh = head;
        RandomListNode *auxNewHead = NULL;
        RandomListNode *auxNewTail = NULL;

        while (auxh != NULL) {
            if (auxNewHead == NULL) {
                push(&auxNewHead, auxh->label);
                auxNewTail = auxNewHead;

                m[(void*)auxh] = (void*)auxNewHead;
            }
            else {
                push(&(auxNewTail->next), auxh->label);
                m[(void*)auxh] = (void*)(auxNewTail->next);
                auxNewTail = auxNewTail->next;
            }

            auxh = auxh->next;
        }

        return auxNewHead;
    }

    void push(RandomListNode **head, int label) {
        RandomListNode* node = new RandomListNode(label);
        node->next = *head;
        *head = node;
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
