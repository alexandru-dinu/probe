/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication2;

/**
 *
 * @author Student
 */
public class SynchronizedThread extends Thread{
    Value value;

    public SynchronizedThread(Value value) {
        this.value = value;
    }

    public void print() {
        synchronized (value) {
            for (int i = 1; i <= 5; i++) {
                System.out.println(value.getN() * i);

                try {
                    Thread.sleep(400);
                } catch (Exception e) {
                }
            }
        }
    }

    public void run() {
        print();
    }
}
