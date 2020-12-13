#include <iostream>
#include <stdio.h>
#include <string.h>
#include <iomanip>
#include <Windows.h>

using namespace std;

#define right 0
#define left 1

template< class T >
class Stack {

private:
	int MAX;
	int top;
	T* items;

public:
	Stack(int size) {
		MAX = size;
		top = -1;
		items = new T[MAX];
	}

	~Stack() { delete[] items; }

	void push(T c) {
		if (full()) {
			cout << "Stack Full!" << endl;
			exit(1);
		}

		items[++top] = c;
	}

	T pop() {
		if (empty()) {
			cout << "Stack Empty!" << endl;
			exit(1);
		}

		return items[top--];
	}

	int empty() { return top == -1; }

	int full() { return top + 1 == MAX; }
};

int menu();
void FixedPoint();
void FixedPointE();
void ComplexNumbers();
void isTerm();
void isCorrect();

int main() {
	setlocale(LC_CTYPE, "rus");

	do {
		switch (menu())
		{
		case 1: FixedPoint(); break;
		case 2: FixedPointE(); break;
		case 3: ComplexNumbers(); break;
		case 4: isTerm(); break;
		case 5: isCorrect(); break;
		case 6: return 0;
		default: cout << "Вы ввели некорректные данные\n";
		}
	} while (1);
	return 0;
}

int menu()
{
	int ans;
	cout << "\n1. Числа с фиксированной точкой" << endl;
	cout << "2. Числа с фиксированной точкий типа -12.2е-10\n";
	cout << "3. Комплексные числа типа 5+2j\n";
	cout << "4. Математиеское выражение вида a+b*c\n";
	cout << "5. Спарены ли все скобки в выражении\n";
	cout << "6. Выход\n";
	cout << "$ ";
	cin >> ans;
	cout << endl;
	return ans;
}

void FixedPoint()
{
	system("cls");
	Stack<string> st(1);
	//	S0 - начальное положение автомата
	//	S1 - положение, при котором считывается знак
	//	S2 - положение, при котором считывются цифры
	//	S3 - положение, при котором считывается точка

	string number[] = { "+12.05", "-12.05", "0.12.05", "12", "-12", "+12", "0.02", "++1", "-0..5", "-.6" };
	for (int i = 0; i < 10; i++)
	{
		bool isFixed = true;
		st.push("S0");
		bool wasPoint = false;
		for (int j = 0; j < number[i].length(); j++)
		{
			string state = st.pop();
			if ((number[i][j] == '+' || number[i][j] == '-') && state == "S0")
				st.push("S1");
			else if ((number[i][j] >= 48 && number[i][j] <= 57) && (state == "S0" || state == "S1" || state == "S2"))
				st.push("S2");
			else if (number[i][j] == '.' && state == "S2" && !wasPoint)
			{
				wasPoint = true;
				st.push("S2");
			}
			else
			{
				cout << number[i] << setw(20 - number[i].length()) << "NO\n";
				isFixed = false;
				break;
			}
		}
		if (isFixed)
		{
			cout << number[i] << setw(21 - number[i].length()) << "YES\n";
			st.pop();
		}
	}
}

void FixedPointE()
{
	system("cls");
	Stack<string> st(1);
	//	S0 - начальное положение автомата
	//	S1 - положение, при котором считывается знак
	//	S2 - положение, при котором считывются цифры
	//	S3 - положение, при котором считывается точка
	//	S4 - положение, при котором считывается цифра после точки
	//	S5 - положение, при котором считавается "e"
	//	S6 - положение, при котором считывается второй знак

	string number[] = {"-0.5e+2", "-12.05", "0.12.05", "12.3-e", "-12.3e-10", "+12.23e+12", "0.02", "+1.3e-4", "+12.05", "6.2e+10e", "5." };
	st.push("S0");
	for (int i = 0; i < 11; i++)
	{
		int keyPoints = 0, Ecounter = 0;
		bool isFixed = true;
		for (int j = 0; j <= number[i].length(); j++)
		{
			string state = st.pop();
			if ((number[i][j] == '+' || number[i][j] == '-') && (state == "S0" || state == "S6"))
			{
				st.push("S1");
				continue;
			}
			else if ((number[i][j] >= 48 && number[i][j] <= 57) && (state == "S0" || state == "S1" || state == "S2"))
			{
				st.push("S2");
				continue;
			}
			else if (number[i][j] == '.' && state == "S2")
			{
				keyPoints++;
				st.push("S4");
				continue;
			}
			else if ((number[i][j] >= 48 && number[i][j] <= 57) && state == "S4")
			{
				st.push("S5");
				keyPoints++;
				continue;
			}
			else if (number[i][j] == 'e' && state == "S5")
			{
				st.push("S6");
				Ecounter++;
				keyPoints++;
				continue;
			}
			else if ((keyPoints != 3 && state == "ERROR") || (Ecounter == 1 && number[i][j] == 'e'))
			{
				cout << number[i] << setw(20 - number[i].length()) << "NO\n";
				Ecounter+=10;
				break;
			}
			st.push("ERROR");
		}
		if (keyPoints == 3 && Ecounter == 1)
			cout << number[i] << setw(21 - number[i].length()) << "YES\n";
		if (st.full())
			st.pop();
		st.push("S0");
	}	
}

void ComplexNumbers()
{
	system("cls");
	Stack<string> st(1);
	//	S0 - начальное положение автомата
	//	S1 - положение, при котором считывается знак
	//	S2 - положение, при котором считывается цифра
	//	S3 - положение, при котором считывается точка
	//	S4 - положение, при котором считывается "j"

	string number[] = { "-0.5j+2", "-12.05+2.32j", "12j5", "12.3-4j", "-12.3e-10", "+12.23j+12", "1+0.02j", "+1.3-4j", "+12.05", "6.2j+10j", "5+3j", "-3j", "12" };
	st.push("S0");
	for (int i = 0; i < 13; i++)
	{
		bool isComplex = true;
		for (int j = 0; j <= number[i].length(); j++)
		{
			string state = st.pop();
			if ((number[i][j] == '+' || number[i][j] == '-') && (state == "S0" || state == "S2"))
			{
				st.push("S1");
				continue;
			}
			else if ((number[i][j] >= 48 && number[i][j] <= 57) && (state == "S0" || state == "S1" || state == "S2" || state == "S3"))
			{
				st.push("S2");
				continue;
			}
			else if (number[i][j] == '.' && state == "S2")
			{
				st.push("S3");
				continue;
			}
			else if (number[i][j] == 'j' && state == "S2")
			{
				st.push("S4");
				continue;
			}
			else if ((state == "S4" && j != number[i].length()) || (state != "S4" && j == number[i].length()) || state == "ERROR")
			{
				cout << number[i] << setw(20 - number[i].length()) << "NO\n";
				isComplex = false;
				break;
			}
			st.push("ERROR");
		}
		if (isComplex)
			cout << number[i] << setw(21 - number[i].length()) << "YES\n";
		if (st.full())
			st.pop();
		st.push("S0");
	}
}

void isTerm()
{
	system("cls");
	Stack<string> st(1);
	// S0 - начальное положение автомата
	// S1 - положение, при котором считываются переменные
	// S2 - положение, при котором считываются знаки

	st.push("S0");
	string forCheck[] = { "a+b*c", "aa-b", "a(b+d)", "a*v+k/n", "-f+d", "12+x" };

	for (int i = 0; i < 6; i++)
	{
		bool isTerm = true;
		for (int j = 0; j < forCheck[i].length(); j++)
		{
			string state = st.pop();
			if ((forCheck[i][j] >= 97 && forCheck[i][j] <= 122) && (state == "S0" || state == "S2"))
				st.push("S1");
			else if ((forCheck[i][j] == '+' || forCheck[i][j] == '-' || forCheck[i][j] == '*' || forCheck[i][j] == '/') && forCheck[i][j + 1] != '\0' && state == "S1")
				st.push("S2");
			else
			{
				cout << forCheck[i] << setw(20 - forCheck[i].length()) << "NO\n";
				isTerm = false;
				break;
			}
		}
		if (isTerm)
			cout << forCheck[i] << setw(21 - forCheck[i].length()) << "YES\n";
		if (st.full())
			st.pop();
		st.push("S0");
	}
}

void isCorrect()
{
	system("cls");
	Stack<string> st(1);
	// S0 - начальное положение автомата
	// S1 - положение, при котором считываются открывающие скобочки
	// S2 - положение, при котором считываются закрывающие скобочки
	// S3 - положение, при котором считываются символы

	string forCheck[] = { "(a+b)*(c-d)", "(a-(c+)", "((a+12)-37)", ")12-d()j*e(", "(d-s+12)-3)", "(((a+1)+2+3)+c)", "j(-s+k)", "u+73", "s)j+12-3(" };

	st.push("S0");
	for (int i = 0; i < 9; i++)
	{
		int brackets[2] = {0,0};
		for (int j = 0; j < forCheck[i].length(); j++)
		{
			string state = st.pop();
			if (forCheck[i][j] == '(' && (state == "S0" || state == "S3" || state == "S1"))
			{
				st.push("S1");
				brackets[left]++;
			}
			else if (forCheck[i][j] == ')' && (state == "S3" || state == "S2"))
			{
				if (brackets[left] > brackets[right])
				{
					st.push("S2");
					brackets[right]++;
				}
				else
				{
					st.push("S3");
					brackets[right]+=10;
				}
			}
			else
				st.push("S3");
		}

		if (brackets[left] == brackets[right])
			cout << forCheck[i] << setw(26 - forCheck[i].length()) << "YES\n";
		else
			cout << forCheck[i] << setw(25 - forCheck[i].length()) << "NO\n";

		if (st.full())
			st.pop();
		st.push("S0");
	}
}