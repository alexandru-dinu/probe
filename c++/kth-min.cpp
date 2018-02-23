#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>

using namespace std;

int partition(vector<int> &arr, int l, int r)
{
    int pivot = arr[r];
    int index = l;

    for (int i = l; i < r; i++) {
        if (arr[i] <= pivot) {
            iter_swap(arr.begin() + index, arr.begin() + i);
            index++;
        }
    }

    iter_swap(arr.begin() + index, arr.begin() + r);

    return index;
}

int find_kth(vector<int> &arr, int l, int r, int k)
{
    int pos = partition(arr, l, r);

    if (pos - l == k)
        return arr[pos];
    if (pos - l > k)
        return find_kth(arr, l, pos - 1, k);
    else
        return find_kth(arr, pos + 1, r, k - pos + l - 1);
}

int main()
{
    /* Enter your code here. Read input from STDIN. Print output to STDOUT */

    int n;
    cin >> n;

    int k = n / 2;
    vector<int> arr(n);

    for (int i = 0; i < n; i++)
        cin >> arr[i];

    cout << find_kth(arr, 0, n - 1, k);

    return 0;
}
