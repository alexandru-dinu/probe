/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 *
 * @author Student
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here

//        Value value = new Value(5);
//        SynchronizedThread t1 = new SynchronizedThread(value);
//        SynchronizedThread t2 = new SynchronizedThread(value);
//        
//        t1.start();
//        t2.start();
//        BlockingQueue<Message> queue = new ArrayBlockingQueue<>(10);
//        Producer producer = new Producer(queue);
//        Consumer consumer = new Consumer(queue);
//        new Thread(producer).start();
//        new Thread(consumer).start();
//        System.out.println("P and C has been started");

        int n = 100000;
        
        ExecutorService exec = Executors.newFixedThreadPool(n);

        for (int i = 0; i < n; i++) {
            Runnable worker = new WorkerThread(Integer.toString(i));
            exec.execute(worker);
        }
        exec.shutdown();

        while (!exec.isTerminated()) {
        }
        
        System.out.println("Finished all threads");
    }

}
