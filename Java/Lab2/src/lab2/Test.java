/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab2;

/**
 *
 * @author alex
 */
public class Test {
    MyArrayList v = new MyArrayList(3);
    
    public boolean check() {
        for (int i = 0; i < v.dim; i++) {
            if(v.get(i) != i)
                return false;
        }
        return true;
    }
    
    
}
