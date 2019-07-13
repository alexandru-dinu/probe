/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package datastructures;

import java.util.Arrays;

/**
 *
 * @author alex
 */
public class MyStack {
    
    //TODO: do not define initial capacity!
    
    private final int DEFAULT_SIZE = 100;
    private double[] stack;
    private int index = 0;
    public int capacity = 0;
    
    public MyStack() {
        stack = new double[DEFAULT_SIZE];
        capacity = DEFAULT_SIZE;
    }
    
    public MyStack(int newSize) {
        stack = new double[newSize];
        capacity = newSize;
    }
    
    public void push(double x) {
        this.stack[index++] = x;
    }
    
    public double pop() {
        if(capacity != 0) {
            double x = this.stack[index - 1];
            index--;
            
            return x;
        }
        
        else {
            System.out.println("Stack is empty!");
            return Double.NaN; // convention
        }
    }
    
}
