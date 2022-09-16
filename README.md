# Congestion-Tax-Calculator

The congestion taxes are intended to improve traffic flow in Sweden. This tool used to calculate the congestion tax city wise.
The solution contains one web application one API(with test project) and a class library.

Assignment Link :[congestion-tax-calculator](https://github.com/volvo-cars/congestion-tax-calculator)
 

What all done

1.	Added 3 Solutions 
	a.	Web Application (.net core 6)- Entry point
	b.	Web Api (.net core 6) ( Swagger API Endpoint available to Test the Apis)
	c.	Shared Library (.net core 6)

2.	Added Entity Framework With code first approach to setup local DB with some initial test values ( Run Web api first )

3.	Added City wise tax Calculation.
		As of now same charge given for all the cities, to test different charges please update the local db entry and rebuild the API.

4.	Added Vehicle Number to identify the vehicle to calculate tax properly and implemented the Logic.
		if two vehicles(car type with different vehicle number) are passing the toll station it will get charged separately.

5.	Fixed the tax calculation logic errors.

6.	Corrected the Exempt Vehicle Details.


How to Install

1. Run Congestion-tax-calculator-api first then run Congestion-tax-calculator-web

2. Congestion-tax-calculator-api is consuming the Shared library and the Dll for the library is placed in "Shared-library-dll" folder 
 	if you are modifying anything in the class library please replace the existing dll in "Shared-library-dll" folder.

3. Please modify Local DB to add more entries.


Assumptions

1. Not considering the milliseconds while calculating the one hour duration.

2. Tax charged separately for vehicles passing throgh different cities, meaning need to pay separate tax as per city rate(travelling from one city to another)  eventhough it is with in one hour.





 
 
