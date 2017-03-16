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
public class Operatii {
    
    public NumarComplex Add(NumarComplex c1, NumarComplex c2) {
        NumarComplex s = new NumarComplex();
        
        s.re = c1.re + c2.re;
        s.im = c1.im + c2.im;
        
        return s;
    }
    
    public NumarComplex Multiply(NumarComplex c1, NumarComplex c2) {
        NumarComplex p = new NumarComplex();
        
        p.re = c1.re * c2.re - c1.im * c2.im;
        p.im = c1.re * c2.im + c1.im * c2.re;
        
        return p;
    }
}
