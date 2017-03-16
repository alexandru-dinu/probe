/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab8;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.PriorityQueue;
import java.util.Random;

/**
 *
 * @author Alex
 */
public class Methods {

    public static ArrayList<Integer> generateRandomList(int n) {
        ArrayList<Integer> l = new ArrayList<>(n);

        Random r = new Random();
        for (int i = 0; i < n; i++) {
            l.add(r.nextInt() % 100);
        }

        return l;
    }

    public static void useArrayList(ArrayList<Integer> l) {
        Collections.sort(l);

        for (Integer i : l) {
            System.out.println(i);
        }
    }

    public static void usePriorityQueue(ArrayList<Integer> l) {
        PriorityQueue<Integer> pq = new PriorityQueue<>(l);

        while (!pq.isEmpty()) {
            System.out.println(pq.remove());
        }
    }

}
