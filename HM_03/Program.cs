// See https://aka.ms/new-console-template for more information

using HM_03;
using HM_03.Containers;
using HM_03.Transports;

Console.WriteLine("Hello, World!");

var ship1 = new Ship(20, 500, 200);
var ship2 = new Ship(25, 400, 220);

var cont1 = new GasContainer(2000, 200, 100, 400, 5000, 10);
var cont2 = new GasContainer(1800, 200, 120, 400, 5500, 12);
var cont3 = new LiquidContainer(1000, 200, 300, 400, 4000, true);
var cont4 = new LiquidContainer(1300, 200, 290, 400, 4000, false);
var cont5 = new RefrigeratedContainer(
    2900, 
    200, 
    340, 
    400, 
    3500, 
    -13, 
    Product.Butter
    );
var cont6 = new RefrigeratedContainer(
    2900, 
    200, 
    340, 
    400, 
    3500, 
    -15, 
    Product.Meat
    );
var cont7 = new GasContainer(2000, 200, 100, 400, 5000, 10);


ship1.LoadContainers([cont1, cont3, cont5]);
ship2.LoadContainers([cont2, cont4, cont6]);

Console.WriteLine(ship1.Replace(1, cont7));
Console.WriteLine(ship2.TransferContainerTo(cont2, ship1));

Console.WriteLine(ship1);
ship1.DisplayAllContainers();

Console.WriteLine(ship2);
ship2.DisplayAllContainers();



