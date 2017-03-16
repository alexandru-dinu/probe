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
public class Lab5 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        /*
         Alien al = new Alien(5);
         al.print();
        
         Alien.Head h = al.new Head(4);
         h.print();
        
         Alien.Foo f = new Alien.Foo(6);
         f.print();
         */

        /*
         Array a = new Array(5);
         Array.IteratorClass ic = a.new IteratorClass();
        
         for (int i = 0; i < 10; i++) {
         a.set(i,i);
         }
        
         while(ic.hasNext()) {
         System.out.println(ic.next());
         }
         */
        EncrypterClass ec = new EncrypterClass("test");
        ec.encrypt(1);
        ec.get();
        ec.encrypt(2);
        ec.get();

    }

}
