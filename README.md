# Mover Candidate Test

## Introduktion

Dear candidate.

Welcome to the Mover Candidate Test.
Please use you preferred way of working, and show us what you can :)

Enjoy!

## General

1. Should be able to run with a push of f5 without any installations (NuGet packages are allowed)
2. Include tests
3. Implement in-memory storage of own choice

## Tasks

1. Implement API endpoint: Calculate least angle between watch hands.
   1. Return least angle as output

2. Inventory management
   1. Create APIs to
      1. Create inventory items
         1. With SKU, description and quantity
         2. Adding inventory with unknown SKU, it should create new.
         3. Adding inventory with known SKU, it should add the quantity to existing
      2. Remove a defined quantity for a specific SKU
      3. List of all inventory


## Solution: 
I have done this project in VS 2019 WebAPI . I used SQLite Database for data storage and built-in Swagger where we tested our API working correctly.
IN this project I used different HTTP method such as 
. HTTP GET ( Retrieving all inventory information - firts you run project you need to add some inventory ( in case if there is no inventory exist) but you add by your choice)
. HTTP POst ( Add simple New inventory).
. HTTP Delete ( Delete inventory items)
. HTTP Patch ( update specific property value in a row)

## Precaution ( How to test this project)
. Clone the project or download the project mentioned above via LINK
. once you downloaded simply hit the F5 button for the run the project , you can see in the browser Swagger show you some HTTP methods used for various purposes mentioned in the task.
. All method are very simple just hit the try out button and see the various result of HTTP method such as HTTP Get ( retrieve all data) , HTTP POST ( add new one ) , HTTP DELETE ( delete items), Finally HTTP Patch which is updated quantity of specific sku.
Before we test this HTTP patch method we need to write some HTTP request body code which send information to server for processed. IN body HTTP request we need to write something for updating specific sku , quantity property value.
for example in our case we need to modified quantity property value of the specific sku (2)- 
[
  {
    "operationType": "replace",
    "path": "quantity",
    "value": 5
  }
]

OPtype : mean we replace the method property value 
Path : mean property name 
value : new value which we replace to old one

