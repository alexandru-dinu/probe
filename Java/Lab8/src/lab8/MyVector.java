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
public class MyVector implements Summable {

    public int[] v;
    private int s = 0;

    public MyVector() {
        v = new int[3];

        for (int i = 0; i < 3; i++) {
            v[i] = i;
            s += v[i];
        }
    }

    @Override
    public void addValue(Summable value) {
        s += value.currentSum();
    }

    @Override
    public int currentSum() {
        return s;
    }
}
