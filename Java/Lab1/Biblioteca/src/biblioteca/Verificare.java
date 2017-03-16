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
public class Verificare {
    
    public boolean dubluExemplar(Carte c1, Carte c2) {
        return c1.titlu.equals(c2.titlu);
    }
    
    public Carte grosime(Carte c1, Carte c2) {
        return (c1.nrPagini >= c2.nrPagini)?c1:c2;
    }
}
