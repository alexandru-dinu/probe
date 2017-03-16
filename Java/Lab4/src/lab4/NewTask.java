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
public class NewTask implements Task {

    private int i;

    public NewTask() {
        this.i = 0;
    }

    public void print(String m) {
        System.out.println(m);
    }

    public void generator() {
          int x = (int) (Math.random() * 10);
          System.out.println(x);
    }

    public void increment() {
        this.i++;
        System.out.println(i);
    }
}
