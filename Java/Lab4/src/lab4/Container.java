/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab4;

/**
 *
 * @author alex
 */
public interface Container {
    // Stack
    public void push(int value);
    public void pop();
    public int top();
    
    // Queue
    public void add(int value);
    public void remove();
    
    public void print(int t);
}
