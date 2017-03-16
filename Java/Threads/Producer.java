/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication2;

import java.util.concurrent.*;

/**
 *
 * @author Student
 */
public class Producer implements Runnable {

    private BlockingQueue<Message> queue;

    public Producer(BlockingQueue<Message> queue) {
        this.queue = queue;
    }

    public void run() {
        for (int i = 0; i < 9; i++) {
            Message msg = new Message(Integer.toString(i));
            try {
                Thread.sleep(500);
                queue.put(msg);
                System.out.println("produced: " + msg.getMsg());
            } catch (Exception e) {

            }
        }

        Message msg = new Message("exit");
        try {
            queue.put(msg);
        } catch (Exception e) {
        }
    }
}
