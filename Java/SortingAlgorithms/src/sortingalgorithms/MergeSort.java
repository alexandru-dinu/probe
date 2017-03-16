/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sortingalgorithms;

/**
 *
 * @author Alexandru
 */
public class MergeSort {

    public MergeSort() {
    }
    
    private static double[] merge(double[] A, double[] B) {
        double[] result = new double[A.length + B.length];
        
        int i = 0, j = 0, k = 0;
        
        while(i < A.length && j < B.length) {
            if(A[i] > B[j])
                result[k++] = B[j++];
            else
                result[k++] = A[i++];
        }
        
        while(i < A.length)
            result[k++] = A[i++];
        
        while(j < B.length)
            result[k++] = B[j++];
        
        return result;
    }
    
    public static double[] mergesort(double[] array) {
        int len = array.length;
        
        if(len == 1)
            return array;
        
        int mid = len / 2;
        
        double[] left = new double[mid];
        double[] right = new double[len - mid];
        
        System.arraycopy(array, 0, left, 0, mid);
        System.arraycopy(array, mid, right, 0, len - mid);
        
        left = mergesort(left);
        right = mergesort(right);
        
        return merge(left, right);
    }
}
