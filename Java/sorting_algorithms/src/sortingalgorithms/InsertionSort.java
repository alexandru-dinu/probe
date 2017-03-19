/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sortingalgorithms;

/**
 *
 * @author alex
 */
public class InsertionSort {
    public static void sort(double[] array) {
        int len = array.length;
        
        for (int i = 1; i < len; i++) {
            double aux = array[i];
            int j = i;
            
            while(j > 0 && array[j-1] > aux) {
                array[j] = array[j-1];
                j--;
            }
            
            array[j] = aux;
        }
    }
}
