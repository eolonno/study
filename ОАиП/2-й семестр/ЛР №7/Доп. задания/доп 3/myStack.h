struct Stack
{
	char data;
	            //информационный элемент
	Stack* head;		 //вершина стека 
	Stack* next;		 //указатель на следующий элемент
};

void show(Stack* myStk);         //прототип
int myFunc(Stack* mySck);
void push(char x, Stack* myStk);