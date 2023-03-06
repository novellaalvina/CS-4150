# Binary Search
import numpy as np

class Node:

    def __init__(self, val, count, l, r):
        self.value = val
        self.count = count
        self.left = l
        self.right = r

# class BinaryTree:
#     def __init__(self, nodes):
#         self.tree = nodes
    
    # def __iter__(self):
    #     self.a = 1


def insert(root, counter, node):

    if root == None:
        print("counter", counter)
        path.append(counter)
        print("path", path)
        return Node(node, counter, None, None)

    else:

        if root == node:
            # even = 0
            # odd = 0
            return root
        if node < root.value:
            # even += 2
            counter = 2*int(root.count) + 1
            print("c", counter)
            root.left = insert(root.left, counter, node)
        elif node > root.value:
            # odd += 2
            counter = 2*int(root.count) + 2
            # path.append(counter)
            print("c", counter)
            root.right = insert(root.right, counter, node)
                    
# def inOrderTraverse(node):
#     if root:
#         inorder(root.left)
#         print(root.val)
#         inorder(root.right)

# def nodeIndexes(root):
#     indexes = []

def main():
    global path
    path = []
    # n = number of tree
    # k = number of input for each tree
    n_k = input().split(' ')
    n = int(n_k[0])
    k = int(n_k[1])

    tree_list = []
    for i in range(n):
        tree = list((map(int,input().split())))
        tree_list.append(tree)

    tree_nodes = []
    print("tree list", tree_list)
    for num, tree in enumerate(tree_list):
        path = []
        root = Node(tree[0], 0, None, None)                
        for i in range(1, len(tree)):
            root = insert(root, 0, tree_list[num][i])
        print("r", path)
        tree_nodes.append(root)

    # shapes = set()
    # for i in range(len(tree_nodes)):
    #     print("a")
    #     shape = []
    #     print(tree_nodes[i].count)
    #     for s in tree_nodes[i].count.strip(","):
    #         print(s)
    #         shape.append(s)
    #     shape = shape.sort()
        # print(shape)
        


    # for x in iter(tree_nodes):
    #     print(x)
    # for i in tree_nodes:
    #     for j in range(1,len(tree_nodes)):
    #         if (same_shape(i, j)):
    #             count += 1
            
    # print("count", count)
    # a = np.arange(6).reshape(2,3)
    
    # c = 0
    # for node in np.nditer(tree_nodes):
    #     print("x", node, end=' ')

    #     if c == k:
    #         c = 0
    #     print("C", c)
    #     c += 1

    # print('\n') 
    # print("a", tree_nodes)
    
if __name__ == "__main__":
    main()
