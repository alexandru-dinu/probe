/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab5;

import java.util.Arrays;

/**
 *
 * @author alex
 */
public class EncrypterClass implements Encrypter {

    String s;
    private char[] arr;

    public EncrypterClass(String s) {
        this.s = s;
        arr = s.toCharArray();
    }

    public void encrypt(int t) {
        if (t == 1) {
            for (int i = 0; i < arr.length; i++) {
                arr[i] += 1;
            }
        } else if (t == 2) {
            for (int i = 0; i < arr.length; i++) {
                arr[i] -= 5;
            }
        }
    }

    public void decrypt(int t) {
        if (t == 1) {
            for (int i = 0; i < arr.length; i++) {
                arr[i] -= 1;
            }
        } else if (t == 2) {
            for (int i = 0; i < arr.length; i++) {
                arr[i] += 5;
            }
        }
    }

    public void get() {
        System.out.println(Arrays.toString(arr));
    }
}
