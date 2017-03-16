/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Student
 */
public class WorkerThread implements Runnable {

    private String command;

    public WorkerThread(String command) {
        this.command = command;
    }

    public void run() {
        System.out.println(Thread.currentThread().getName() + " start.command = " + command);
        processCommand();
        System.out.println(Thread.currentThread().getName() + " end");
    }
    
    private void processCommand() {
        try{
            Thread.sleep(5000); 
        }
        catch(Exception e) {
            
        }
    }
    
    public String toString() {
        return this.command;
    }
}
