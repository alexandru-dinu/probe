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
public class Singleton extends Persoana {

    private static Singleton instance = null;

    private Singleton() {
        //System.out.println("Hello, world!");
    }

    public static Singleton getInstance() {
        if (instance == null) {
            instance = new Singleton();
        }

        return instance;
    }
}
