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
public abstract class Angajat {
    String nume;
    int salariuBaza;

    public Angajat() {
    }

    public Angajat(String nume, int salariuBaza) {
        this.nume = nume;
        this.salariuBaza = salariuBaza;
    }
    
    abstract public double calculSalariu();
}
