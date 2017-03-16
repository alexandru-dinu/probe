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
public class GenericMethods {

    public <T extends Summable> int allSum(Collection<T> c) {
        int s = 0;

        for (T elem : c) {
            s += elem.currentSum();
        }

        return s;
    }
}
