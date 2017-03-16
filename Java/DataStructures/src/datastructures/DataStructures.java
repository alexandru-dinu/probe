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
public class DataStructures {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here

        /*
         MyStack s = new MyStack(3);
        
         for (int i = 0; i < s.size; i++) {
         s.push(i + 1);
         }
        
         System.out.println(s.pop());
         s.push(Math.PI);
        
         System.out.println(s.pop());
         */
        
        MyQueue q = new MyQueue();
        
        
        for (int i = 0; i < 5; i++) {
            q.enqueue((int)(10 * Math.random()));
        }
        
        q.print();
        
        q.delete();
        q.print();
        
        q.enqueue(10);
        q.print();
        
        MyQueue rez = q.addEven();
        rez.print();
        
            
    }

}
