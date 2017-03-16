/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package biblioteca;

import java.util.Scanner;

/**
 *
 * @author alex
 */
public class Carte {
    
    String titlu, autor, editura;
    int nrPagini;
    
    public void Read() {
        Scanner s = new Scanner(System.in);
        
        this.titlu = s.nextLine();
        this.autor = s.nextLine();
        this.editura = s.nextLine();
        
        this.nrPagini = Integer.parseInt(s.nextLine());
    }
    
    public void Print() {
        System.out.println(titlu.toUpperCase() + " - " + autor.toUpperCase() + ", " + editura.toLowerCase() + ", " + nrPagini);
    }
    
}
