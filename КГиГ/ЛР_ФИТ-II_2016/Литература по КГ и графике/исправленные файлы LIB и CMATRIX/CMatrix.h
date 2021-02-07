#ifndef CMATRIXH
# define CMATRIXH 1
class CMatrix
{
	double **array;
	int n_rows;							// Число строк
	int n_cols;							// Число столбцов
public:
	CMatrix();							// Конструктор по умолчанию (1 на 1)	
	CMatrix(int,int);		    		// Конструктор	
	CMatrix(int);						// Конструктор -вектора (один столбец)
	CMatrix(const CMatrix&);			// Конструктор копирования	
	~CMatrix();	
	double &operator()(int,int);        // Выбор элемента матрицы по индексу 
	double &operator()(int);            // Выбор элемента вектора по индексу 
	CMatrix operator-();			    // Оператор "-"
	CMatrix operator=(const CMatrix&);	// Оператор "Присвоить":    M1=M2
	CMatrix operator*(CMatrix&);        // Оператор "Произведение": М1*М2
	CMatrix operator+(CMatrix&);	    // Оператор "+": M1+M2
	CMatrix operator-(CMatrix&);	    // Оператор "-": M1-M2
	CMatrix operator+(double);		    // Оператор "+": M+a
	CMatrix operator-(double);		    // Оператор "-": M-a
	int rows()const{return n_rows;} ;   // Возвращает число строк
	int cols()const{return n_cols;};    // Возвращает число строк
	CMatrix Transp();				    // Возвращает матрицу,транспонированную к текущей
	CMatrix GetRow(int);			    // Возвращает строку по номеру
	CMatrix GetRow(int,int,int);			 
	CMatrix GetCol(int);			    // Возвращает столбец по номеру
	CMatrix GetCol(int,int,int);
	CMatrix RedimMatrix(int,int);	    // Изменяет размер матрицы с уничтожением данных
	CMatrix RedimData(int,int);         // Изменяет размер матрицы с сохранением данных, 
	                                    //которые можно сохранить
	CMatrix RedimMatrix(int);	        // Изменяет размер матрицы с уничтожением данных
	CMatrix RedimData(int);             // Изменяет размер матрицы с сохранением данных,
                                        //которые можно сохранить
	double MaxElement();			  	// Максимальный элемент матрицы
	double MinElement();				// Минимальный элемент матрицы
};


#endif