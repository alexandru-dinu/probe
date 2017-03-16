/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hanoi;

/**
 *
 * @author alex
 */
public class Hanoi {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here

        hanoi(6, '1', '2', '3');
    }

    public static void hanoi(int n, char st1, char st2, char st3) {
        if (n == 1) {
            System.out.println(st1 + " -> " + st2);
        } else {
            hanoi(n - 1, st1, st3, st2);
            System.out.println(st1 + " -> " + st2);
            hanoi(n - 1, st3, st2, st1);
        }
    }

}
