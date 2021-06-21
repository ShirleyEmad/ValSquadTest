# ValSquadTest
It's an API that manages tha cars of employees and provides a parking access card for each car.
First: (GetCar,PostCar,PutCar,DeleteCar) are the CRUD operations for any car.
Second: CarExists is a function that checks car exisistence by its plate number.
Third: PostCarFirstTime is a post function that simulates car registeration and creates its parking access card with welcome credit 10 dollars.
Forth: PutCarPassesHighway is a put function that simulates any car that already exisits in the system passes the highway gate and charge the card by 4 dollars and if this car passes two times in the same minute the second pass is free.
