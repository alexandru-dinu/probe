/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab8;

import java.util.Collection;

/**
 *
 * @author Alex
 */
public final class Algorithm {

    public static <T> int countIf(Collection<T> c, UnaryPredicate<T> p) {
        int count = 0;
        for (T elem : c) {
            if (p.primeTest(elem)) {
                ++count;
                System.out.println("[" + elem + "]");
            }
        }
        return count;
    }
}
