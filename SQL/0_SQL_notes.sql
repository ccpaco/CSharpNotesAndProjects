/* 3/11/21 SQL notes Mark's lecture */



SELECT customername, SUM(amount), MIN(paymentdate)
FROM customers AS customername
    JOIN payments AS o ON c.customernumber = o.customernumber
GROUP BY customername
HAVING SUM(amount) > 50000 AND MIN(paymentdate) > 01-01-2003

/* Clone */
SELECT customername, SUM(amount), MIN(paymentdate)
FROM customers AS customername
    JOIN payments AS o ON c.customernumber = o.customernumber
    WHERE customername LIKE 'A%' --Begins with A
GROUP BY customername
HAVING SUM(amount) > 50000 AND MIN(paymentdate) > 01-01-2003
    -- Having allows > or < 
-- Australian Gift Network, Co | 55,190.16 | 2003-11-15

SELECT customerName, lastName, firstName
FROM customers
    JOIN employees on customers.id=employees.id 

-- mock sql sba 1
-- Name = Marion
SELECT u.*
FROM users AS u
    --join
WHERE u.USER_ID LIKE "MARION%"

-- mock sql sba 2
-- all users with no orders
SELECT u.*
FROM users AS u
WHERE u.USER_ID NOT IN (SELECT user_id FROM orders)

-- mock sql sba 3
-- based on order numbers of items 2 or more
SELECT name, price
FROM Items
WHERE ITEM_ID IN 
    (SELECT item_id 
    FROM order_items 
    GROUP BY item_id 
    HAVING COUNT(*) > 1) -- or >=2

-- mock ql sba 4
-- orders from NY, asc order
SELECT oi.order_id, i.name, price, quantity
FROM order_items as order_id
    JOIN items AS i ON oi.item_id = i.item_id
    JOIN orders AS o ON oi.order_id = o.order_id
    JOIN stores AS s ON o.STORE_ID = s.STORE_ID
WHERE city = 'New York'
ORDER BY order_id asc


-- 3/11 MARK's OFFICE HOURS FRIDAY 

-- Calculates total sales of a product based on priceEach * quantityOrdered
SELECT STATUS, COUNT(o.orderNumber),
    (Select SUM(orderdetails.quantityOrdered * orderdetails.priceEach) 
    FROM orderdetails WHERE ordernumber = o.orderNumber)
FROM orders AS o
GROUP BY status

SELECT STATUS, COUNT(o.orderNumber),
    (Select CAST(SUM(orderdetails.quantityOrdered * orderdetails.priceEach) AS integer)
    FROM orderdetails WHERE ordernumber = o.orderNumber) AS total
FROM orders AS o
GROUP BY STATUS
ORDER BY COUNT(o.orderNumber) DESC, total asc

-- 3/15  MARK'S LECTURE MONDAY-Morning 
SELECT STATUS, COUNT(o.orderNumber),
    (SELECT CAST(SUM(orderdetails.quantityOrdered * orderdetails.priceEach) AS integer)
    FROM orderdetails WHERE ordernumber = o.orderNumber) AS total 
FROM orders AS o 
GROUP BY STATUS
ORDER BY COUNT(o.orderNumber) DESC, total ASC

SELECT * 
FROM products AS p
WHERE p.productLine NOT IN
(SELECT productline FROM productlines WHERE productline = 'green cars')


-- work with nulls example
SELECT i.instructorname 
FROM instructor AS i
WHERE instructornumber NOT IN 
    (SELECT instructornumber   
    FROM lookuptable 
    WHERE instructornumber = i.instructornumber)

        -- Data Definition Lang: Create Alter Drop

        DROP DATABASE IF EXISTS 'myDatabaseName';
        CREATE DATABASE 'myDatabaseName';
        USE 'myDatabaseName';

        DROP TABLE IF EXISTS 'myFancyTable';
        CREATE TABLE 'myFancyTable' (
        'customerNumber' int(11) NOT NULL,
        'customerName' varchar(50) NOT NULL,
        'contactLastName' varchar(50) NOT NULL,
        'phone' varchar(50) NOT NULL,
        -- write other column stuff
        -- code below may be incomplete refer to powerpoint
        PRIMARY KEY ('customerNumber')
        CONSTRAINT constraint_name FOREIGNKEY (customerNumber)
            REFERENCES customers (customerNumnber)
        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- so you alter a TABLE, modify a COLUMN
-- ALTER table: add columns, drop columns, modify columns, add constraint, drop constraint

-- count
SELECT count(oi.order_id), i.NAME, price, quantity
FROM order_items AS oi
    JOIN items AS i ON oi.item_id = i.ITEM_ID
    JOIN orders AS o ON oi.order_id = o.order_id
    JOIN stores AS s ON o.STORE_ID = s.STORE_ID
WHERE city = 'New York'

-- get Order, prodName and Price/item

SELECT o.order_ID, productName, buyPrice
FROM ORDERS AS o
    JOIN orderdetails AS od ON o.orderNumber = od.orderNumber
    JOIN products AS p ON od.productCode = p.productCode
GROUP BY o.order_ID
ORDER BY ordernumber

-- Classic Models, Customers
-- WHERE clause filter BEFORE grouped
SELECT * FROM customers
WHERE customerName LIKE 'H%'

SELECT customerName, COUNT(p.customerNumber)
FROM customers AS C
    LEFT JOIN payments AS p ON c.customerNumber = p.customerNumber
WHERE customerName LIKE 'H%'
GROUP BY customerName 

-- or HAVING clause filter AFTER grouped
-- Can't filter aggregates (Count, Max, Sum, Min) in WHERE, but can filter them
-- in having Clause
SELECT customerName, COUNT(p.customerNumber)
FROM customers AS C
    LEFT JOIN payments AS p ON c.customerNumber = p.customerNumber
GROUP BY customerName 
HAVING customerName LIKE 'H%' AND COUNT(p.customerNumber) > 2

-- MMark hackkerrank weather stations 5

-- Version 1 using union
(Select city, length(city) 
from station 
where length(city) = (select max(length(city)) from station)
order by city limit 1)
Union
(select city, length(city) 
from station
where length(city) = (select min(length(city))
from station )
order by city limit 1)
order by length(city)

-- Version 2 correct, correct, no use of Union
(Select city, length(city) 
from station 
where length(city) = (select min(length(city)) from station)
order by city limit 1);

(select city, length(city) 
from station
where length(city) = (select max(length(city))
from station )
order by city limit 1);






