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
public class BubbleSort {

    public BubbleSort() {
    }
    
    private static int swap(int x, int y) {
        return x;
    }
    
    public static int[] sort(int[] list) {
        int len = list.length;
        
        for (int i = 0; i < len; i++) {
            for (int j = 0; j < i; j++) {
                if(list[i] < list[j])
                    list[i] = swap(list[j], list[j] = list[i]);
            }
        }
        
        return list;
    }
}
