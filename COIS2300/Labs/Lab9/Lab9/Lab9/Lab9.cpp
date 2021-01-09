#include <iostream>
#include <stdio.h>
using namespace std;

inline void boost() {
	ios_base::sync_with_stdio(0);
	cin.tie(0), cout.tie(0);
}

int main() {
	boost();
	int n, result = 0;
	cin >> n;
	for (int i = 1; i <= n; i++) {
		char q;
		cin >> q;
		if ((int)q % 2 == 0)
			result += i;
	}
	cout << result;
	return 0;
}