//Assuming we start checking from 3 and above (2 can be set manually)
bool _primalityTest(int param) {
	if (param % 2 == 0)
		return false;
	else
	{
		double _tempSQRT = sqrt(param);
		for (int i = 2; i < _tempSQRT; i++) {
			if (param % i == 0) {
				return false;
			}
		}
		return true;
	}
}