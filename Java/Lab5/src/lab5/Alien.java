/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab5;

/**
 *
 * @author alex
 */
public class Alien {

    private int x;
    private static int k = 0;

    public Alien(int x) {
        this.x = x;
    }

    public void print() {
        System.out.println(this.x);
    }

    // inner class
    public class Head {

        private int y;

        public Head(int y) {
            this.y = y;
        }

        public void print() {
            System.out.println(x + " " + y);
        }
    }

    // static inner class
    public static class Foo {

        int z;

        public Foo(int z) {
            this.z = z;
        }

        public void print() {
            System.out.println(z + " " + k);
            
            Alien al = new Alien(10);
            al.print();
        }
    }
}
