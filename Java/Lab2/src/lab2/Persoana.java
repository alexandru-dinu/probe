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
public class Persoana {
    public String name;
    
    public Persoana() {
    }

    public Persoana(String newName) {
        this.name = newName;
    }

    @Override
    public String toString() {
        return "Persoana{" + "name=" + name + '}';
    } 
    
}
