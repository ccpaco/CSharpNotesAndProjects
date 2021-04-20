SELECT building_name
FROM Buildings
LEFT JOIN Employees on building_name = building
WHERE ROLE is null

SELECT AGG_FUNC(column_or_expression) AS aggregate_description, …
FROM mytable
WHERE constraint_expression
GROUP BY column;

-- for some reason returns all the info, but also limits to 1 we want
SELECT *, MAX(Years_employed) FROM employees;

SELECT ROLE, AVG(Years_employed)
FROM employees
Group By Role;

-- the complete SELECT style query

SELECT DISTINCT column, AGG_FUNC(column_or_expression), …
FROM mytable
    JOIN another_table
      ON mytable.column = another_table.column
WHERE constraint_expression
GROUP BY column
HAVING constraint_expression
ORDER BY column ASC/DESC
LIMIT count OFFSET COUNT;

-- Course, Student, no faculty
-- Tables 1, Table 2

-- courses and students with, no faculty in that class
-- LEFT JOIN faculty

SELECT courses, students.firstName, students.lastName, count(studentId)
FROM students
LEFT JOIN faculty 
WHERE facultyID is null

