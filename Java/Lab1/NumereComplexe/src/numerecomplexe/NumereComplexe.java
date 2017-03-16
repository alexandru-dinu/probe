/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package numerecomplexe;

/**
 *
 * @author alex
 */
public class NumereComplexe {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        NumarComplex c1, c2, s, p;
        c1 = new NumarComplex();
        c2 = new NumarComplex();
        
        c1.Read();
        c2.Read();
        
        Operatii op = new Operatii();
        s = op.Add(c1, c2);
        p = op.Multiply(c1, c2);
        
        c1.Print();
        c2.Print();
        
        s.Print();
        p.Print();
    }
    
}
