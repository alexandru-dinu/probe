/**
 * Created by Alex on 18/02/2016.
 */
public class Factorial {
    final private static int NON_EXISTENT = -1;

    public static int solve(int z) {
        if (z == 0)
            return 1;

        final int STARTING_N = z;

        int n = STARTING_N;

        while (5 * z != (n + computeSum(n))) {
            n += 1;

            if(n >= 5 * z)
                return NON_EXISTENT;
        }

        return n;
    }

    private static int computeSum(int n) {
        int N = (int) Math.floor(Math.log(n) / Math.log(5));
        int S = 0;

        for (int k = 2; k <= N; k++) {
            S += (int) Math.floor(n / Math.pow(5, k));
        }

        return 5 * S;
    }
}
