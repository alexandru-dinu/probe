/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab8;

/**
 *
 * @author Alex
 */
public class Test implements UnaryPredicate<Integer> {

    @Override
    public boolean primeTest(Integer i) {
        i = Math.abs(i);

        int s = 0;
        if (i == 1) {
            return false;
        }

        if (i == 2) {
            return true;
        }

        if (i % 2 == 0) {
            return false;
        }

        for (int k = 3; k <= Math.sqrt(i); k++) {
            if (i % k == 0) {
                return false;
            }
        }
        return true;
    }
}
