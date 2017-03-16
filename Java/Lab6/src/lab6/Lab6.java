/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab6;

/**
 *
 * @author alex
 */
public class Lab6 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        /*
         CoffeeCup c = new CoffeeCup();
         c.setTemperature(70);

         Person p = new Person();
         try {
         p.Drink(c);
         } catch (TooHotException e) {
         System.out.println("too hot");
         } catch (TooColdException e) {
         System.out.println("too cold");
         } catch (TemperatureException e) {
         System.out.println("temperature exception");
         } finally {
         System.out.println("drink it!");
         }
         */

        /*
         int n = Integer.MAX_VALUE;
         try {
         int[] x = new int[n];
         } catch (OutOfMemoryError e) {
         System.out.println("OOME");
         }
         */
        /*
         try {
         recursiv(-1000000000);
         } catch (StackOverflowError e) {
         System.out.println("SE");
         }
         */
        //System.out.println(method());
        int x = -1;
        int y = Integer.MIN_VALUE;

        try {
            System.out.println(Calculator.add(x, y));
        } catch (UnderflowException e) {
            System.out.println("UE");
        } catch (OverflowException e) {
            System.out.println("OE");
        } catch (ArithmeticException e) {
            System.out.println("AE");
        }
    }

    public static void recursiv(int n) {
        System.out.println(n);
        if (n == 0) {
            return;
        } else {
            recursiv(++n);
        }
    }

    public static int method() {
        try {
            return 1;
        } finally {
            System.out.println("it prints");
        }
    }

}
