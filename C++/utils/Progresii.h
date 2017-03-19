int AS_sum(int a1, int an, double n) //suma progresiei aritmetice
{
	return n*(double((a1 + an)) / double(2));	
}

int AS_ratio(int a1, int an, double n) //ratia progresiei aritmetice
{
	return double(double(2 * AS_sum(a1, an, n)) / double(n) - 2 * a1) / double(n - 1);
}

int GS_sum(int b1, double q, double n) //suma progresiei geometrice
{
	return b1*(double(pow(q, n) - 1) / double(q - 1));
}