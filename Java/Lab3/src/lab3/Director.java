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
public class Director extends Angajat {

    int indemnizatie;

    public Director() {
    }

    public Director(String nume, int salariuBaza, int indemnizatie) {
        super(nume, salariuBaza);
        this.indemnizatie = indemnizatie;
    }

    public double calculSalariu() {
        double salariu = super.salariuBaza * (1 + this.indemnizatie / 100);
        return salariu;
    }
}
