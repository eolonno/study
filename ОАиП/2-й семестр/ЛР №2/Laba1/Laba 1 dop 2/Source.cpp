
//1

//#include <stdio.h>
//#include <iostream>
//int main()
//{
//	setlocale(LC_ALL, "");
//	errno_t err;
//	FILE* f;
//	FILE* ff;
//	int arr[30];
//	err = fopen_s(&f, "fileA.txt", "r");
//	if (err != 0)
//	{
//		perror("Невозможно прочитать файл\n");
//		return EXIT_FAILURE;
//	}
//	for (int i = 0; i < 30; i++) {
//		fscanf_s(f,"%d",&arr[i]);
//	}
//	fclose(f);
//	err = fopen_s(&ff, "fileB.txt", "w");
//	if (err != 0)
//	{
//		perror("Невозможно прочитать файл\n");
//		return EXIT_FAILURE;
//	}
//
//	for (int i = 0; i < 30; i ++){
//		int a = arr[i];
//		for (int j = 0; j < 30; j++) {
//
//			if (a == arr[j]) {
//				if (j < i) {
//					break;
//				}
//				else if(j==i){}
//				if (j > i) {
//					fprintf_s(ff, "%d", a);
//					fprintf_s(ff, "%s", " "); break;
//				}
//			}
//		}
//
//	}
//	printf("Данные записаны в файл fileB\n");
//	fclose(ff);
//	return 0;
//}

//2

#include <stdio.h>
#include <iostream>
int main()
{
	setlocale(LC_ALL, "");
	errno_t err;
	FILE* f;
	FILE* ff;
	int arr[20];
	err = fopen_s(&f, "f.txt", "r");
	if (err != 0)
	{
		perror("Невозможно прочитать файл\n");
		return EXIT_FAILURE;
	}
	for (int i = 0; i < 20; i++) {
		fscanf_s(f,"%d",&arr[i]);
	}
	fclose(f);
	err = fopen_s(&ff, "g.txt", "w");
	if (err != 0)
	{
		perror("Невозможно прочитать файл\n");
		return EXIT_FAILURE;
	}
	bool m = true;
	for (int i = 0; i < 20; i ++){
		int a = arr[i];
		for (int j = 0; j < 20; j++) {
			if (a == arr[j]) {
				if (i == j) {}
				else {
					m = false;
					break;
				}
			}
		}
		if (m) {
			fprintf_s(ff, "%d", a);
			fprintf_s(ff, "%s", " ");
		}
		m = true;
	}
	printf("Данные записаны в файл g\n");
	fclose(ff);
	return 0;
}
