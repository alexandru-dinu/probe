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
public class MyMatrix implements Summable {

    public int[][] m;
    private int s = 0;

    public MyMatrix() {
        m = new int[4][4];
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                m[i][j] = i + j;
                s += m[i][j];
            }
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
