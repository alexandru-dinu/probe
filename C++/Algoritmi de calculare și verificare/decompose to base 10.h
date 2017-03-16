int main()
{
	long long n, div;
	int steps;
	vector<int> dcmp;

	cout << "Number to decompose: "; cin >> n;
	int n_snd = n;

	int i = integer_length(n) - 1; 
	steps = i + 1;

	while (steps)
	{
		div = n / pow(10, i); 
		dcmp.push_back(div * pow(10, i));
		n = n - div * pow(10, i);
		i--;
		steps--;
	} 

	cout << n_snd << " ---> ";
	for (int j = 0; j < dcmp.size(); j++)
	{
		cout << dcmp.at(j) << " ";
	}
}