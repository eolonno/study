// Combi4.cpp  
#include "Combi4.h"
#include <algorithm>
#define NINF  ((short)0x8000)
namespace combi4
{
	unsigned __int64 fact(unsigned __int64 x) { return(x == 0) ? 1 : (x * fact(x - 1)); };
	xcombination::xcombination(short n, short m) {
		this->n = n;
		this->m = m;
		this->sset = new short[m + 2];
		this->reset();
	}
	void  xcombination::reset()   // сбросить генератор, начать сначала 
	{
		this->nc = 0;
		for (int i = 0; i < this->m; i++) this->sset[i] = i;
		this->sset[m] = this->n;
		this->sset[m + 1] = 0;
	};
	short xcombination::getfirst() { return (this->n >= this->m) ? this->m : -1; };
	short xcombination::getnext() // сформировать следующий массив индексов  
	{
		short rc = getfirst();
		if (rc > 0) {
			short j;
			for (j = 0; this->sset[j] + 1 == this->sset[j + 1]; ++j) this->sset[j] = j;
			if (j >= this->m) rc = -1;
			else {
				this->sset[j]++;
				this->nc++;
			};
		}
		return rc;
	};
	short xcombination::ntx(short i) { return this->sset[i]; };
	unsigned __int64 xcombination::count() const {
		return (this->n >= this->m) ?
			fact(this->n) / (fact(this->n - this->m) * fact(this->m)) : 0;
	};
	permutation::permutation(short n) {
		this->n = n;
		this->sset = new short[n];
		this->dart = new bool[n];
		this->reset();
	};
	void  permutation::reset() { this->getfirst(); };
	__int64  permutation::getfirst() {
		this->np = 0;
		for (int i = 0; i < this->n; i++) { this->sset[i] = i; this->dart[i] = L; };
		return  (this->n > 0) ? this->np : -1;
	};
	__int64  permutation::getnext() {
		__int64 rc = -1;
		short maxm = NINF, idx = -1;
		for (int i = 0; i < this->n; i++) {
			if (i > 0 && this->dart[i] == L && this->sset[i] > this->sset[i - 1]
				&& maxm < this->sset[i]) maxm = this->sset[idx = i];
			if (i < (this->n - 1) && this->dart[i] == R
				&& this->sset[i] > this->sset[i + 1]
				&& maxm < this->sset[i]) 	maxm = this->sset[idx = i];
		};
		if (idx >= 0)
		{
			std::swap(this->sset[idx], this->sset[idx + (this->dart[idx] == L ? -1 : 1)]);
			std::swap(this->dart[idx], this->dart[idx + (this->dart[idx] == L ? -1 : 1)]);
			for (int i = 0; i < this->n; i++)
				if (this->sset[i] > maxm) this->dart[i] = !this->dart[i];
			rc = ++this->np;
		}
		return rc;
	};
	short permutation::ntx(short i) { return  this->sset[i]; };
	unsigned __int64 permutation::count() const { return fact(this->n); };
	accomodation::accomodation(short n, short m) {
		this->n = n;
		this->m = m;
		this->cgen = new xcombination(n, m);
		this->pgen = new permutation(m);
		this->sset = new short[m];
		this->reset();
	}
	void  accomodation::reset() {
		this->na = 0;
		this->cgen->reset();
		this->pgen->reset();
		this->cgen->getfirst();
	};
	short accomodation::getfirst() {
		short rc = (this->n >= this->m) ? this->m : -1;
		if (rc > 0) {
			for (int i = 0; i <= this->m; i++)
				this->sset[i] = this->cgen->sset[this->pgen->ntx(i)];
		};
		return rc;
	};
	short accomodation::getnext() {
		short rc;
		this->na++;
		if ((this->pgen->getnext()) > 0) rc = this->getfirst();
		else  if ((rc = this->cgen->getnext()) > 0)
		{
			this->pgen->reset();  rc = this->getfirst();
		};
		return rc;
	};
	short accomodation::ntx(short i) { return this->sset[i]; };
	unsigned __int64  accomodation::count() const {
		return (this->n >= this->m) ? fact(this->n) / fact(this->n - this->m) : 0;
	};
}
