#pragma once
// -- дистанции   Левенштeйна (динамическое программирование)
int levenshtein(
	int lx,           // длина слова x 
	const char x[],   // слово длиной lx
	int ly,           // длина слова y
	const char y[]    // слово y
);
// -- дистанции   Левенштeйна (рекурсия)
int levenshtein_r(
	int lx,           // длина строки x 
	const char x[],   // строка длиной lx
	int ly,           // длина строки y
	const char y[]    // строка y
);