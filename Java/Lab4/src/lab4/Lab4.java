/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab4;

import java.util.Date;

/**
 *
 * @author alex
 */
public class Lab4 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        AbstractClassRunner a = new AbstractClassRunner();
        
        for (int i = 1; i <= 5; i++) {
            Date d = new Date();
            
            System.out.println(d);
            
            if(i % 2 == 0) {
                a.AddTask(1);
            }
            else {
                a.AddTask(2);
            }
            try {
                Thread.sleep(1000);
            }
            catch(InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
    
}
