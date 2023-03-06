from itertools import combinations
import copy

class Star:
    def __init__(self, x, y, c):
        self.x = x
        self.y = y
        self.c = c
    
    def calculate_distance(self, otherstar, d):
        return (self.x-otherstar.x)**2 + (self.y-otherstar.y)**2 <= d**2


def findMajority(A, d): 

    if (len(A) == 0):  
        return None
    elif  (len(A) == 1): 
        return A[0]
    else:
        Ap = []
        mid = len(A)/2
        
        for i in range(0,len(A), 2):

            if i == len(A)-1:
                y = A[-1]
            else:
                if A[i].calculate_distance(A[i+1], d):
                    Ap.append(A[i])

        x = findMajority(Ap, d)

        if x == None:
            if len(A) % 2 != 0:
                c = 0
                for i in range(len(A)):
                    if y.calculate_distance(A[i], d):
                        c += 1
                if c > mid: 
                    y.c = c
                    return y
                else:
                    return None
        else:
            c = 0
            for i in range(len(A)):
                if x.calculate_distance(A[i], d):
                    c += 1
            if c > mid: 
                x.c = c
                return x
            else:
                return None

def main():
    d = 0

    d_k = input().split(' ')
    d = int(d_k[0])
    k = int(d_k[1])

    coords = []

    for i in range(k):

        x_y = input().split(' ')
        x = int(x_y[0])
        y = int(x_y[1])
        coords.append(Star(x, y, 0))

    coord = findMajority(coords, d)

    if (coord != None):
        print(coord.c)
    else:
        print("NO")


if __name__ == "__main__":
    main()    
