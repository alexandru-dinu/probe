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
public class AbstractClassRunner {
    TaskDS[] t = new TaskDS[10];
    int n = 0;
    
    public void AddTask(int type) {
        t[n++] = new TaskDS(type);
    }
}
