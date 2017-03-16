/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab7;

import java.io.Serializable;
import java.util.Arrays;

/**
 *
 * @author Alex
 */
public class CircularList implements Serializable {

    public Element[] element;

    public CircularList(int n) {
        element = new Element[n + 1];

        for (int i = 0; i < n; i++) {
            element[i] = new Element(n - i);
            element[i].setNext(element[i + 1]);
        }

        element[n] = new Element(0);
        element[n].setNext(element[0]);
    }

    public String toString() {
        return Arrays.deepToString(element);
    }

}
