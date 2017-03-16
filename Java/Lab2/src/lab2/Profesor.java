/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab2;

/**
 *
 * @author alex
 */
public class Profesor extends Persoana {

    String materie;

    public Profesor() {
    }

    public Profesor(String name, String newMaterie) {
        super(name);
        this.materie = newMaterie;
    }

    public void preda() {
        System.out.println(this.name + " preda");
    }

    // Polimorfism
    @Override
    public String toString() {
        // super.toString() -> this.name
        return "Profesor: " + super.toString() + ", " + this.materie;
    }

}
