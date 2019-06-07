#include <iostream>
#include <map>

using namespace std;

class Node
{
public:
	Node* ptr1;
	Node* ptr2;
	int data;
	Node()
	{}

	Node(const int item, Node* ptrNext)
	{
		this->data = item;
		this->ptr1 = ptrNext;
	}

	Node* NextNode()
	{
		return this->ptr1;
	}

	void InsertAfter(Node* p)
	{
		p->ptr1 = this->ptr1;
	}

	Node* DeleteAfter()
	{
		Node* tempNode = ptr1;
		if (ptr1 != NULL)
			ptr1 = ptr1->ptr1;
		return tempNode;
	}

	Node* GetNode(const int item, Node* nextPtr)
	{
		Node* newNode;
		newNode = new Node(item, nextPtr);
		if (newNode == NULL)
		{
			cerr << "Memory allocation failed." << endl;
			exit(1);
		}
		return newNode;
	}
};

typedef map<Node*, Node*> NodeMap;

class MapNode
{
	// 13.7
public:
	static Node* copy_recursive(Node* cur, NodeMap& nodeMap)
	{
		if (cur == NULL)
			return NULL;

		NodeMap::iterator i = nodeMap.find(cur);
		if (i != nodeMap.end()) // we've been here before, return the copy
			return i->second;

		Node* node = new Node;
		nodeMap[cur] = node; // map current before traversing links
		node->ptr1 = copy_recursive(cur->ptr1, nodeMap);
		node->ptr2 = copy_recursive(cur->ptr2, nodeMap);
		return node;
	}

	static Node* copy_structure(Node* root)
	{
		NodeMap nodeMap; // we will need an empty map
		return copy_recursive(root, nodeMap);
	}

	static void RunMapNode()
	{
		Node* root = new Node(5, NULL);
		Node* results = MapNode::copy_structure(root);
	}
};