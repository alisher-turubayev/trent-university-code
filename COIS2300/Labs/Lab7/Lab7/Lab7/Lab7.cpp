#include "pch.h"
#include <iostream>
using namespace std;

int main()
{
	cout.precision(0);
	float inc = 0.0000001, sum = 0.0;
	for (float i = 1.0; i <= 1000000.0;) {
		sum += (1.0 / i);
		i += 1.0;
	}
	cout << sum;
	cin.get();
	return 0;
}