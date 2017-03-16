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
public class Muncitor extends Angajat {
    int nrNopti;

    public Muncitor() {
    }

    public Muncitor(String nume, int salariuBaza, int nrNopti) {
        super(nume, salariuBaza);
        this.nrNopti = nrNopti;
    }

    @Override
    public double calculSalariu() {
        double salariu = super.salariuBaza + 0.5 * this.nrNopti * (super.salariuBaza / 20);
        return salariu;
    }
    
    
}
