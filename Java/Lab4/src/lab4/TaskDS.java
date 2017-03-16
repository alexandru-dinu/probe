/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab4;

import java.util.ArrayList;

/**
 *
 * @author alex
 */
public class TaskDS implements Container {

    private ArrayList<Integer> s = new ArrayList<>();
    private int vf = -1;

    private ArrayList<Integer> q = new ArrayList<>();
    private int prim = -1, ultim = -1;

    public TaskDS(int t) {
        if(t == 1) {
            for (int i = 0; i < 5; i++) {
                push(i);
            }
            print(1);
            System.out.println("...");
            pop();
            print(1);
            System.out.println("---");
        }
        else {
            for (int i = 0; i < 5; i++) {
                add(i);
            }
            print(2);
            System.out.println("...");
            remove();
            print(2);
            System.out.println("---");
        }
    }
    
    

    public void push(int value) {
        s.add(value);
        vf++;
    }

    public void pop() {
        s.remove(vf);
        vf--;
    }

    public int top() {
        return s.get(vf);
    }

    public void add(int value) {
        ultim++;
        if (prim == -1) {
            prim++;
        }
        q.add(value);
    }
    
    public void remove() {
        prim++;
    }
    
    public void print(int t) {
        if(t == 1) {
            for (int i = 0; i <= vf; i++) {
                System.out.println(s.get(i));
            }
        }
        else {
            for (int i = prim; i <= ultim; i++) {
                System.out.println(q.get(i));
            }
        }
    }
}
