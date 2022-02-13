
	// OS12.h
	#pragma once
	#define OS12HANDEL void*
	namespace OS12
	{
		OS12HANDEL Init();                                // инициализация OS12
		//   if CoCreateInstance(... IID_Unknown)!= succesfull --> throw (int)HRESULT  
		namespace Adder
		{
			double Add(OS12HANDEL h, double x, double y);        // return x+y
			//  if QueryInteface(IID_IAdder) != succesfull -->  throw (int)HRESULT     
			double Sub(OS12HANDEL h, double x, double y);        // return x-y
			//  if QueryInteface(IID_IAdder) != succesfull -->  throw (int)HRESULT
		}
		namespace Multiplier
		{
			double Mul(OS12HANDEL h, double x, double y);        // return x*y
			//  if QueryInteface(IID_IMultiplier) != succesfull -->  throw (int)HRESULT 
			double Div(OS12HANDEL h, double x, double y);        // return x/y
			//  if QueryInteface(IID_IMultiplier) != succesfull -->  throw (int)HRESULT 
		}
		void Dispose(OS12HANDEL h);                       // завершение работы с OS12                  
	}

