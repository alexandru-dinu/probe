// Using headers.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Libraries.h"
#include "Variables and constants.h"


void main()
{
	kmh kmh_first_lap;
	kmh kmh_second_lap;

	travel distance_fl;
	travel distance_sl;

	cin>>kmh_first_lap>>kmh_second_lap>>distance_fl>>distance_sl;

	double result_fl = (double(distance_fl)/double(kmh_first_lap))*60;
	double result_sl = (double(distance_sl)/double(kmh_second_lap))*60;

	cout<<"First lap time was : "<<result_fl<<" minutes."<<endl;
	cout<<"Second lap time was : "<<result_sl<<" minutes."<<endl;

	int gata;
	cin>>gata;
}

