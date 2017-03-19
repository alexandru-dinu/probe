import java.util.Vector;

/**
 * Created by alex on 23.02.2016.
 */
public class PA00 {

    public static Number getMax(Number a, Number b) {
        double A = a.doubleValue();
        double B = b.doubleValue();
        double MAX = (A + B + Math.abs(A - B)) / 2;

        return MAX;
    }

    public static int rotBS(int[] A, int low, int high, int search) {
        if (low == high && search == A[low]) {
            return low;
        } else if (high - low == 1) {
            if (search == A[low])
                return low;
            else if (search == A[high])
                return high;
            else
                return -1;
        } else {
            int mid = (low + high) / 2;

            if (search == A[mid]) {
                return mid;
            } else {
                if (A[low] <= A[mid]) {
                    if (A[low] <= search && search <= A[mid]) {
                        //  1. exists, sorted
                        return rotBS(A, low, mid, search);
                    } else {
                        //  2. dne, sorted
                        return rotBS(A, mid, high, search);
                    }
                } else {
                    if (A[low] <= search || search <= A[mid]) {
                        //  3. exists, not sorted
                        return rotBS(A, low, mid, search);
                    } else {
                        //  4. dne, not sorted
                        return rotBS(A, mid, high, search);
                    }
                }
            }
        }


    }


}
