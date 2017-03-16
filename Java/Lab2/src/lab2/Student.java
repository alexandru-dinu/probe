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
public class Student extends Persoana {
    int nota;

    public Student() {
    }

    public Student(String name, int newNota) {
        super(name);
        this.nota = newNota;
    }
    
    public void invata() {
        System.out.println(super.toString() + " invata");
    }
   
    @Override
    public String toString() {
        return "Student: " + super.toString() + ", " + this.nota;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        
        if (getClass() != obj.getClass()) {
            return false;
        }
        
        final Student other = (Student) obj;
       
        return this.name.equals(other.name) && this.nota == other.nota;
        
    }
    
    
}
