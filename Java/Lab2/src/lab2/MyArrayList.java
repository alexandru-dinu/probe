/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab2;

/**
 *
 * @author alex
 */
public class MyArrayList {
    float[] array;
    public int dim = 0;
    private final int SZ = 100;

    public MyArrayList() {
        this.array = new float[10];
        dim = 10;
    }
    
    public MyArrayList(int n) {
        this.array = new float[SZ];
        dim = n;
        
        java.util.Scanner s = new java.util.Scanner(System.in);
        for (int i = 0; i < n; i++) {
            array[i] = s.nextFloat();
        }
    }
    
    public void add(float value) {
        this.array[dim] = value;
        dim++;
    }
    
    public boolean contains(float value) {
        for (int i = 0; i < array.length; i++) {
            if(array[i] == value)
                return true;
        }
        
        return false;
    }
    
    public float get(int index) {
        return array[index];
    }
    
    public float swap(float x, float y) {
        return x;
    }
    
    public void remove(int index) {
        for (int i = index; i < array.length - 1; i++) {
            array[i] = array[i + 1];
        }
        dim--;
    }
    
    public int size() {
        return dim;
    }
    
    public String tostring() {
        String s = "";
        
        for (int i = 0; i < dim; i++) {
            s = s + Float.toString(array[i]) + " ";
        }
        
        return s;
    }
    
}
