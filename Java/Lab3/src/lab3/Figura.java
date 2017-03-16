/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab3;

import java.util.Scanner;

/**
 *
 * @author alex
 */
public class Figura {

    public int n;
    public Punct[] P;

    public Figura() {
    }

    public Figura(int n) {
        this.n = n;
        this.P = new Punct[n];

        for (int i = 0; i < this.n; i++) {
            P[i] = new Punct();
        }
    }

    public void setPoints() {
        Scanner s = new Scanner(System.in);
        for (int i = 0; i < this.n; i++) {
            P[i].x = s.nextInt();
            P[i].y = s.nextInt();
        }
    }

    public void getPoints() {
        for (Punct p : P) {
            System.out.println(p.x + " " + p.y);
        }
    }

    private double getDist(Punct a, Punct b) {
        double o1 = Math.pow((a.x - b.x), 2);
        double o2 = Math.pow((a.y - b.y), 2);
        return Math.sqrt(o1 + o2);
    }

    public double perimeter() {
        double perimeter = 0;

        for (int i = 0; i < P.length - 1; i++) {
            perimeter += getDist(P[i], P[i + 1]);
        }

        perimeter += getDist(P[P.length - 1], P[0]);

        return perimeter;
    }

    public double area() {
        double area = 0;

        for (int i = 0; i < this.n - 1; i++) {
            int stub = (P[i].x * P[i + 1].y - P[i].y * P[i + 1].x);
            area += stub;
        }

        return Math.abs(0.5 * area);
    }

}
