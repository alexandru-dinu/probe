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
public class SortingAlgorithms {

    /**
     * @param list the list that has to be sorted
     * @param args the command line arguments
     */
    
    public static void print(double[] list) {
        for (int i = 0; i < list.length; i++) {
            System.out.print(list[i] + " ");
        }
        System.out.println();
    }
    
    public static void main(String[] args) {
        // TODO code application logic here
        double[] list = new double[]{1,7,8,3,10,5};
        
        InsertionSort.sort(list);
        
        print(list);
        
    }
}
