struct Stack
{
	int data;
	int num;			
	Stack* head;		 
	Stack* next;		
};

void show(Stack* myStk);        
void push(int x, int i, Stack* myStk);  
int fromFile(Stack* myStk);
int myFunct(Stack* myStk);