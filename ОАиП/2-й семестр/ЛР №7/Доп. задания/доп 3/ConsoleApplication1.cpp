#include"Header.h"
using namespace std;

int main() {
	setlocale(LC_ALL, "Rus");
	   
	Stack* myStk = new Stack; 
	myStk->head = NULL;
	myFunc(myStk);
	cout << endl;
	show(myStk);
	return 0;

}