import random

def swap(lst, a, b):
    i, j = lst.index(a), lst.index(b)
    lst[j], lst[i] = lst[i], lst[j]


def find_kth(arr, l, r, k):
    if k <= 0 or k > r - l + 1:
        return None

    # partition the array using a pivot
    # pos = index of that pivot in the sorted array
    pos = partition(arr, l, r)

    # pos - l to get an index from the beginning of arr
    # because l, r denote a sub-list
    # k - 1 to be zero-based
    if pos - l == k - 1:
        return arr[pos]
    if pos - l > k - 1:
        return find_kth(arr, l, pos - 1, k)
    if pos - l < k - 1:
        return find_kth(arr, pos + 1, r, k - pos + l - 1)



def partition(arr, l, r):
    """
    put all elements <= pivot to the left
    put all elements > pivot to the right
    return pivot index in the sorted array

    pivot = random or last element
    """
    # select a random pivot and move it to the end
    # pivotIndex = random.randint(l, r)
    # swap(arr, arr[pivotIndex], arr[r])

    pivot = arr[r]
    index = l

    for i in range(l, r):
        if arr[i] <= pivot:
            swap(arr, arr[index], arr[i])
            index += 1

    # put pivot back to its place
    swap(arr, arr[index], arr[r])

    return index


if __name__ == '__main__':

    mean = lambda x : x[len(x)/2] if len(x)&1 else  0.5*(x[len(x)/2-1] + x[len(x)/2])

    n = 10003
    x = random.sample(range(1, int(1e6)), n)
    k = n / 2 + 1

    #print x
    kth = find_kth(x, 0, n - 1, k)

    x.sort()
    print kth, mean(x)
