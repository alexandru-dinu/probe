/**
 * Created by Alex on 18/02/2016.
 */
public class Main {
    public static void main(String[] args) {

        int[] A = {8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 7, 7};

        int low = 0, high = A.length - 1;

        for (int search : A) {
            System.out.println(PA00.rotBS(A, low, high, search));
        }
    }
}
