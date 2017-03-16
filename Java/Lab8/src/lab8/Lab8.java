/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab8;

import java.util.*;

/**
 *
 * @author Alex
 */
public class Lab8 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here

//        int n = 10000000;
//        long startTime, elapsedTime;
//
//        List list1;
//        List<Integer> list2;
//        TreeSet<Integer> ts;
//
//        list1 = new ArrayList();
//        list2 = new ArrayList<>(n);
//        ts = new TreeSet<>();
//
//        startTime = System.currentTimeMillis();
//
//        for (int i = 0; i < n; i++) {
//            ts.add(i);
//        }
//
////        for (int i = 0; i < n; i++) {
////            int x = list2.get(i);
////        }
//        elapsedTime = System.currentTimeMillis() - startTime;
//        System.out.println(elapsedTime);
//        ArrayList<Integer> l = Methods.generateRandomList(10);
//        Methods.useArrayList(l);
//        Methods.usePriorityQueue(l);â
//        ArrayList<Integer> l = new ArrayList<>();
//        for (int i = 0; i < 100; i++) {
//            l.add(i);
//        }
//        Algorithm.countIf(l, new Test());

        MyVector v = new MyVector();
        MyMatrix m = new MyMatrix();

        ArrayList<Summable> A = new ArrayList<>();

        A.add(v);
        A.add(m);
        
        v.addValue(v);
        v.addValue(m);
        
        for(Summable s : A) {
            System.out.println(s.currentSum());
        }
        
        GenericMethods GM = new GenericMethods();
        System.out.println(GM.allSum(A));

    }
}
