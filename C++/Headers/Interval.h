int interval_check(int a, int b) //verificare definire interval
{
	int opt;
	int aux;

	if (a < b)
	{
		cout << "Intervalul este corect definit." << endl;
		system("PAUSE");
	}
	else if (a == b)
	{
		cout << "Valorile introduse nu formeaza un interval." << endl;
		cout << "Valoarile definesc punctul " << a << " pe axa reala." << endl;
		system("PAUSE");
	}
	else
	{
		cout << "Intervalul este incorect definit." << endl;
		cout << "Apasati: " << endl;
		cout << "1 - corectare interval" << endl;
		cout << "2 - iesire" << endl;
		cin >> opt;
		switch (opt)
		{
		case 1:
		{
				  aux = a;
				  a = b;
				  b = aux;
				  cout << "Intervalul corect este (" << a << "," << b << ")." << endl;
				  system("PAUSE");
		}
		case 2:
		{
				  return 0;
		}
		default:
			break;
		}
	}
}