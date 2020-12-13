#include"Header.h"
using namespace std;

int main() {
	setlocale(LC_ALL, "Rus");
	int choice;
	Stack* myStk = new Stack; 
	myStk->head = NULL;       
	fromFile(myStk);
	show(myStk);
	myFunct(myStk);
	return 0;

}