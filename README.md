# promotion_engine


## Requirements

To run this project you'll need .NET 5.0 installed along with Node (which should also be available on the system PATH).

## Getting started

To run the project execute the following:

```
git clone https://github.com/matthewblott/promotion_engine

cd promotion_engine

dotnet run

```

To run the tests execute the following:

```

...
dotnet test


```

## How it works

The guts of the application is the ```OrderService```. First the ```UniquePairingCombinations``` method is called which determines the unique combinations of ```Sku``` codes for a given ```Order```. For example a list of ```['A', 'B']``` can produce 3 lists ```['A']```, ```['B']``` and ```['A', 'B']```.

These are then run against the various promotions found in the ```Scripts``` folder of the ```Services``` project. The scripts contain JavaScript files which can be added and removed as desired. The 'best' discount is then calculated and added to the ```Discount``` property for the applicable ```Order```.


## Issues

This is a proof of concept and is not the most efficient use of an algorithm. With hindsight the process of extracting the different combinations of products can run into thousands quickly and it would be better to check against the requirements in promotions. However this posed the challenge of making something easy and flexible when it comes to adding new promotions. This project is very flexible for promotions but work on more efficient sorting algorithms is required!