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
public class Person {

    static int tooHot = 85;
    static int tooCold = 65;

    public void Drink(CoffeeCup c) throws
            TooColdException, TooHotException, TemperatureException {
        int t = c.getTemperature();

        if (t >= tooHot && t <= 100) {
            throw new TooHotException();
        } else if (t > 0 && t <= tooCold) {
            throw new TooColdException();
        } else if (t <= 0 || t > 100) {
            throw new TemperatureException();
        }
    }
}
