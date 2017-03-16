/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab7;

import java.io.Serializable;

/**
 *
 * @author Alex
 */
public class Element implements Serializable {

    public int x;
    public Element next;

    public Element(int x) {
        this.x = x;
    }

    public void setNext(Element nextElement) {
        this.next = nextElement;
    }
    
    @Override
    public String toString(){
        return Integer.toString(x);
    }
}
