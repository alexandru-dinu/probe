/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab9;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

/**
 *
 * @author Alex
 */
public class MyMap {

    ArrayList<Student>[] list = new ArrayList[11];

    void add(Student s) {
        int medie = Math.round(s.getMedie());
        list[medie].add(s);
    }

    public void createMap() {
        Map<Integer, ArrayList<Student>> map = new TreeMap<>(
                new Comparator<Integer>() {
            @Override
            public int compare(Integer o1, Integer o2) {
                return o2.compareTo(o1);
            }
        });

        for (int i = 0; i < list.length; i++) {
            list[i] = new ArrayList<>();
        }

        Scanner s = new Scanner(System.in);
        int n = s.nextInt();

        for (int i = 0; i < n; i++) {
            String name = s.next();
            float medie = s.nextFloat();
            add(new Student(name, medie));
        }

        for (int i = 0; i <= 10; i++) {
            map.put(i, list[i]);
        }
        
        for (Map.Entry<Integer, ArrayList<Student>> m : map.entrySet()) {
            Collections.sort(m.getValue());
            System.out.print("key: " + m.getKey() + ", value: ");
            System.out.println(m.getValue());
        }
    }

}
