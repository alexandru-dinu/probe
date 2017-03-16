function [x, p] = primedist(n, doPlot)
%%%[x, p] = primedist(n, doPlot): if doPlot > 0, plots all the primes up to n.
%%%[x, p] = indexes and primes.

	p = primes(n);
	x = 1:length(p);
	gap = [];

	if doPlot > 0
		%	plot the primes
		figure; grid on; hold on;
		axis([0 x(end) 0 p(end)]);

		for i = 1:length(x)
			plot(x(i), p(i), 'linewidth', 1, 'k.');

			%	horizontal line
			plot([0 max(x)], [p(i) p(i)], 'linewidth', 0.25, 'k');
		end

		hold off;
		%	---

		%	populate gap vector
		for i = 1:length(x)-1
			gap(i) = p(i+1) - p(i);
		end
		%	---

		%	plot the gaps
		figure; grid on; hold on;
		axis([0 x(end) 0 max(gap)]);

		for i = 1:length(x)-1
			r = mod(i, 2);
			plot(x(i), p(i+1)-p(i), 'linewidth', 1, 'color', [0 0 r]);

			%	vertical line
			plot([x(i) x(i)], [0 max(gap)], 'linewidth', 0.25, 'k');
		end

		hold off;
		%	---
	end

end
