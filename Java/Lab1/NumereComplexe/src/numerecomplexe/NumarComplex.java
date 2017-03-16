/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package numerecomplexe;

import java.util.Scanner;

/**
 *
 * @author alex
 */
public class NumarComplex {
    float re, im;
    
    public void Read() {
        Scanner s = new Scanner(System.in);
        
        this.re = Float.parseFloat(s.nextLine());
        this.im = Float.parseFloat(s.nextLine());
    }
    
    public void Print() {
        System.out.println("z = " + re + " + " + im + "i");
    }
}
