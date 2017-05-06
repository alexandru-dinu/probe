function y = primeinterp(x, p, ord, doMultiple)
%%%y = primeinterp(x, p, ord, doMultiple):
%%%Uses the array of indexes x and corresponding primes p
%%%to construct an 'ord' order fitting polynomial.
%%%If doMultiple > 0, the function constructs all
%%%the fitting polynomials with order 1:ord.

	y = polyfit(x, p, ord);

	if doMultiple > 0
		for i = 1:ord
			figure; grid on;
			P = polyfit(x, p, i);

			for j = 1:length(x)
				y(j) = polyval(P, j);
			end

			plot(x, y, 'linewidth', 2, 'color', 'b');
		end
	end
end