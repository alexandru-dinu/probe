/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication2;

import java.util.concurrent.BlockingQueue;

/**
 *
 * @author Student
 */
public class Consumer implements Runnable{
    private BlockingQueue<Message> queue;

    public Consumer(BlockingQueue<Message> queue) {
        this.queue = queue;
    }
    
    public void run() {
        try {
            Message msg;
            while((msg = queue.take()).getMsg().equals("exit") == false) {
                System.out.println("consumed: " + msg.getMsg());
            }
        }
        catch(Exception e) {
           
        }
    }
}
