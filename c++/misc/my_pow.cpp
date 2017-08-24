// MyPow.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <iostream>
#include <math.h>

using namespace std;

const double E = exp(1.0);
const double c0 = -10.0 / 3;
double mypow(double, double);

long fact(int x)
{
	if (x == 0)
		return 1;
	else return x * fact(x - 1);
}

double mylog(double x)
{
	if (x == 1)
		return 0;
	else if (x == E)
		return 1;

	int w;
	if (x < 1)
		return c0 + 8 * x - 5 * x * x; // least squares approx. for ln(x)
	else
		w = floor(x);

	double delta = x - w;
	cout << delta;

	double s = 0;

	int order = 10;
	for (int k = 1; k <= order; k++)
	{
		double term = mypow(delta, k) / (k * mypow(w, k));
		if (k % 2 == 0)
			s -= term;
		else
			s += term;
	}

	return log(w) + s;
}

double mypow(double base, double expt)
{
	// special cases
	if (base < 0 && expt != floor(expt))
	{
		cout << "Can't have negative base!" << endl;
		return NAN;
	}

	if (expt == 0)
		return 1;
	else if (base == 0 && expt != 0)
		return 0;
	else if (expt == 1)
		return base;
	else if (expt == -1)
		return 1 / base;
	else if (expt == floor(expt))
	{
		double result = 1;
		for (int k = 1; k <= abs(expt); k++)
			result *= base;

		if (expt > 0)
			return result;
		else
			return 1 / result;
	}

	double power = 0;
	double aux = expt * mylog(base);	//	e^(aux)

	//	center point for series representation
	int w = floor(aux);
	//	order of the Taylor polynomial
	int order = 10;

	//	Taylor polynomial (up to specified order) for exp(x)
	for (int k = 0; k <= order; k++)
	{
		double prod = 1;

		for (int i = 1; i <= k; i++)
			prod *= (aux - w);

		power += prod / fact(k);
	}

	return mypow(E, w) * power;
}

int _tmain(int argc, _TCHAR* argv[])
{
	double x, y;

	cin >> x >> y;

	double res = mypow(x, y);
	double eps = 1e-4;

	if (!isnan(res))
	{
		double realres = pow(x, y);

		if (abs(res - realres) <= eps)
		{
			cout << "err: 0" << endl;
			cout << res << " vs. " << realres << endl;
		}
		else
		{
			cout << "err: " << abs(res - realres) << endl;
			cout << res << " vs. " << realres << endl;
		}
	}
	
	system("PAUSE");
	return 0;
}

