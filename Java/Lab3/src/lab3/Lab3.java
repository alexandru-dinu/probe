/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab3;

/**
 *
 * @author alex
 */
public class Lab3 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Angajat[] a = new Angajat[2];
        
        a[0] = new Muncitor("Ion", 800, 6);
        a[1] = new Director("George", 5000, 1000);
        
        for (Angajat ang : a) {
            System.out.println(ang.calculSalariu());
        }
    }

}
