/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab9;

/**
 *
 * @author Alex
 */
public class Student implements Comparable<Student> {

    String nume;
    float medie;

    public Student(String nume, float medie) {
        this.nume = nume;
        this.medie = medie;
    }

    public String getNume() {
        return nume;
    }

    public float getMedie() {
        return medie;
    }

    @Override
    public String toString() {
        return nume + " " + medie;
    }

    @Override
    public int compareTo(Student s) {
        if (nume.equals(s.nume) && medie == s.medie) {
            return 0;
        }
        return -1;
    }

}
