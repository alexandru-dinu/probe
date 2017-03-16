/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package biblioteca;

/**
 *
 * @author alex
 */
public class Biblioteca {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        Carte c = new Carte();
        Test t = new Test();
        
        c.Read();
        
        if(t.NotZero(c))
            c.Print();
        else
            System.out.println("Nr pagini <= 0!");
        
        
        /*
        
        Carte c1 = new Carte();
        Carte c2 = new Carte();
        
        c1.Read();
        c2.Read();
        
        Verificare v = new Verificare();
        System.out.println(v.dubluExemplar(c1, c2));
        System.out.println(v.grosime(c1, c2).titlu);
                
        */
    }
    
}
