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
public interface Summable {
    public void addValue(Summable value);
    public int currentSum();
}
