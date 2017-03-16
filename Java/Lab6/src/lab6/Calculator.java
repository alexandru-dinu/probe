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
public class Calculator {

    public static long add(int a, int b) throws OverflowException, UnderflowException {
        long x = (long) a + (long) b;

        if (x > Integer.MAX_VALUE) {
            throw new OverflowException();
        } else if (x < Integer.MIN_VALUE) {
            throw new UnderflowException();
        }

        return x;
    }

    public static int divide(int a, int b) throws ArithmeticException {
        if (b == 0) {
            throw new ArithmeticException();
        }
        return (a / b);
    }
}
