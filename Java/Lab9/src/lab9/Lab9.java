/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab9;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Scanner;

/**
 *
 * @author Alex
 */
public class Lab9 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here

       // Collection<String> C = new ArrayList<>();
//        3
//        for(int i = 0; i < steps; i++) {
//            String s = input.next();
//            if(!C.contains(s)) {
//                C.add(s);
//            }   
//            else {
//                System.out.println(s + " already exists.");
//            }
//        }
//        
//        System.out.println(C);

//        for (int i = 0; i < steps; i++) {
//            String s = input.next();
//            float f = input.nextFloat();
//
//            Student aux = new Student(s, f);
//
//            if (!C.contains(aux)) {
//                C.add(aux);
//            }
//            else {
//                System.out.println(aux.toString() + " already exists.");
//            }
//        }
//        
//        for(Student s : C) {
//            System.out.println(s.toString());
//        }

    MyMap map = new MyMap();
    map.createMap();
    }

}
