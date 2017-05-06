/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package datastructures;

/**
 *
 * @author alex
 */
public class MyQueue extends Array {
    
    public int prim, ultim;

    public MyQueue() {
        super(10);
        prim = 0;
        ultim = 0;
    }
    
    public void enqueue(int val) {
        if(prim == 0 && ultim == 0) {
            set(prim, val);   
            ultim++;
        }
        else {
            set(ultim, val);
            ultim++;
        }    
    }
    
    public void delete() {
        prim++;
    }
    
    public void print() {
        for (int i = prim; i < ultim; i++) {
            System.out.print(get(i) + " ");
        }
        System.out.println();
    }
    
    public boolean isVoid() {
        return (prim == 0 && ultim == 0) || (prim > ultim);
    }
    
    public MyQueue addEven() {
        MyQueue c = new MyQueue();
        
        for (int i = prim; i < ultim; i++) {
            int x = get(i);
            
            if(x % 2 == 0)
                c.enqueue(x);
        }
        
        return c;
    }
}
