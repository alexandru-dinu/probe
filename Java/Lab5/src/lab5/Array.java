/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab5;

/**
 * Clasa wrapper peste array-uri, verifica daca indexul in vector se incadreaza
 * in intervalul valid
 *
 * @author Mihnea
 *
 */
public class Array {

    public static final int ERROR = Integer.MIN_VALUE;
    int count = 0;

    // vectorul din spate
    private int a[];

    public Array() {
        this(100);
    }

    public Array(int n) {
        a = new int[n];
    }

    public class IteratorClass implements Iterator {

        // implements Iterator
        public boolean hasNext() {
            return count < a.length - 1;
        }

        public int next() {
            return (hasNext() == true) ? (a[count++]) : (-1);
        }
    }

    /**
     * Intoarce valoarea din vector de pe pozitia specificata: vector[pos]
     *
     * @param pos pozitia din vector
     * @return valoarea in caz de succes, constanta ERROR in caz de eroare
     */
    public int get(int pos) {
        // verificare pozitie valida
        if (pos < 0 || pos >= a.length) {
            return ERROR;
        }

        return a[pos];
    }

    /**
     * Seteaza o valoare din vector: vector[pos] = val
     *
     * @param pos pozitia din vector
     * @param val valoarea adaugata
     * @return 0 in caz de succes, constanta ERROR in caz de eroare
     */
    public int set(int pos, int val) {
        // verificare pozitie valida
        if (pos < 0 || pos >= a.length) {
            return ERROR;
        }

        a[pos] = val;

        return 0;
    }

    public String toString() {
        String s = "[";
        for (int i = 0; i < a.length; i++) {
            s += a[i] + " ";
        }
        return s + "]";
    }

    public static void main(String[] args) {
        // array cu 10 elemente
        Array array = new Array(10);

        //*********** EXEMPLE DE ADAUGARE ******************
        //adaugare corecta
        if (array.set(4, 99) != Array.ERROR) {
            System.out.println(array);
        } else {
            System.out.println("Error adding value");
        }

        //adaugare incorecta
        if (array.set(11, 99) != Array.ERROR) {
            System.out.println(array);
        } else {
            System.out.println("Error adding value");
        }

        //*********** EXEMPLE DE OBTINERE ******************
        //obtinere corecta
        int val = array.get(4);
        if (val != Array.ERROR) {
            System.out.println(val);
        } else {
            System.out.println("Error retrieving value");
        }

        //obtinere incorecta
        val = array.get(11);
        if (val != Array.ERROR) {
            System.out.println(val);
        } else {
            System.out.println("Error retrieving value");
        }

    }

}
