/* SBA ANSWERS -- KEEP PRIVATE */

-- #2
-- NUMBER
-- Departments and count of courses from that dept
SELECT dept.name, count(*) courses
FROM department as dept
    JOIN course as c on dept.id = c.deptId 
       Group By dept.name
ORDER BY courses asc, dept.name asc;

-- #3
-- Get the name of courses, and number of students enrolled. Use count not Sum
SELECT c.name, count(courseID) as students
FROM course as c
    JOIN studentcourse as sc on c.id = sc.courseID 
       Group By c.name
ORDER BY students desc, c.name asc;

-- #4
-- All courses WHERE #Faculty  = 0
-- ORDER BY CourseName Asc
SELECT c.name
FROM course as c
    LEFT JOIN facultycourse as fc on c.id = fc.courseId
WHERE fc.courseId is null
ORDER BY c.name asc;

-- #5
-- null c.name and # of students in those courses
-- connect facultyCourse to Course to studentCourse
-- order by # students desc, c.name asc
-- Third iteration: correct "No Faculty" courses! From Join.On clause
-- after ON. use fc.courseId, not facultyId! 
-- Update: but now COUNT is wrong!

SELECT c.name, count(sc.courseId) as students
FROM course as c
    JOIN studentcourse as sc on c.id = sc.courseID 
    LEFT JOIN facultycourse as fc on fc.courseId = sc.courseId
WHERE fc.courseID is null
Group By c.name, sc.courseId 
ORDER BY students desc, c.name asc;

-- #6
-- TOTAL: # Students in classes BY school year
-- Students | Year (enrollment year?)
-- Sort schoolyear asc, Total students desc

-- Count(studentId)
-- Group by YEAR()

SELECT Count(distinct studentId) as Students, 
Year(startDate) as Year
FROM studentcourse
GROUP BY Year
ORDER BY Year asc, Students desc;

-- #7 
-- Month(August) as Start Date | Total students enrolled in Aug
-- ORDER BY StartDate asc, Total Students asc
-- Important point was count(distinct ~)

SELECT startDate, Count(distinct studentId)
FROM studentcourse  
WHERE MONTH(startDate) = 8
GROUP BY StartDate
ORDER BY StartDate asc, Count(studentId) asc;

-- #8
-- MUST TAKE 4 total AND 2 from same dept of major
-- FIRST NAME, LAST NAME, NUMBER OF COURSES in DEPARTMENT
-- 
-- ORDER BY NumCourses desc, FirstName asc, Last Name asc

SELECT s.firstName, s.lastName -- COUNT (-- WORKS , [ s.majorId, d.name ]
FROM student as s
JOIN department as d ON s.majorId = d.id  
JOIN 

            -- WORKING VERS
            -- sort by #courses desc, s.firstname asc, s.lastname asc
            -- close, only with where/having do we filter out

            SELECT 
            s.firstName, 
            s.lastName, 
            s.id, 
            count(DISTINCT sc.courseId) as coursesFromMajor,
            s.majorId,
            c.deptId
            FROM student as s
                JOIN studentcourse as sc ON sc.studentId = s.id
                JOIN course as c ON c.deptId = s.majorId 
            WHERE sc.courseID = c.id
            GROUP BY s.id
            HAVING s.majorID = c.deptID
            ORDER BY coursesFromMajor desc, s.firstName asc, s.lastName asc;

            -- WORKING VERS CLEANED
            -- sort by #courses desc, s.firstname asc, s.lastname asc
            -- close, only with where/having do we filter out

            -- sort by #courses desc, s.firstname asc, s.lastname asc

            SELECT 
            s.firstName, 
            s.lastName, 
            count(DISTINCT sc.courseId) as coursesFromMajor
            FROM student as s
                JOIN studentcourse as sc ON sc.studentId = s.id
                JOIN course as c ON c.deptId = s.majorId 
            WHERE sc.courseID = c.id
            GROUP BY s.id 
            ORDER BY coursesFromMajor, s.firstName, s.lastName
-- FINAL VERS 
SELECT 
    s.firstName, 
    s.lastName, 
    count(DISTINCT sc.courseId) as coursesFromMajor
FROM student as s
    JOIN studentcourse as sc ON sc.studentId = s.id
    JOIN course as c ON c.deptId = s.majorId 
WHERE sc.courseID = c.id
GROUP BY s.id 
ORDER BY coursesFromMajor desc, s.firstName asc, s.lastName asc;

-- #9 working version
-- s.firstName, s.lastName, avg(sc.progress) with round 1 50%, less than 50%
-- ORDER by avg(progress) desc, s.firstName asc, s.lastName asc
-- avg of progress sc.progress

        SELECT s.firstName, s.lastName, round(avg(sc.progress))
        FROM student AS s
        JOIN studentcourse AS sc ON s.id = sc.studentId
        GROUP BY s.id;

        -- WORKING VERS. SLIGHTLY REFINED
        SELECT s.firstName, s.lastName, round(avg(sc.progress), 1)
        FROM student AS s
        JOIN studentcourse AS sc ON s.Id = sc.studentId
        WHERE sc.progress < 50
        GROUP BY s.Id, sc.progress
        ORDER BY sc.progress desc, s.firstName asc, s.lastName asc;

-- SUCCESS, change WHERE to HAVING
SELECT s.firstName, s.lastName, round(avg(sc.progress), 1)
    FROM student AS s
    JOIN studentcourse AS sc ON s.Id = sc.studentId
GROUP BY s.Id
HAVING round(avg(sc.progress), 1) < 50
ORDER BY round(avg(sc.progress), 1) desc, s.firstName asc, s.lastName asc

-- #10
-- Working version, moving on
-- CourseName, Average(sc.Progress)
-- FROM course Join studentCourse
-- round(avg(sc.progress))

    SELECT  c.name, round(avg(sc.progress), 1)
        FROM course as c
        Join studentCourse as sc ON c.id = sc.courseId
    GROUP BY c.id
    ORDER BY round(avg(sc.progress), 1) desc, c.name asc;

    -- #11 
            select max(avg_salary)
            from (select worker_id, avg(salary) AS avg_salary
                from workers
                group by worker_id) As maxSalary;
    -- 
    SELECT distinct c.name, max(avg_studentProgress)) 
    FROM course as c
    JOIN studentCourse as sc ON c.id = sc.courseId
    GROUP BY ;


    -- 
    -- successful avg of each course
    -- now need to get the highest one?

    SELECT c.name, round(avg(sc.progress), 1) as avgProg
    FROM course as c
    JOIN studentCourse as sc ON c.id = sc.courseId
    WHERE max(avgProg)
    GROUP BY c.name;

    SELECT c.name, round(avg(sc.progress), 1)
    FROM course AS c
    JOIN studentCourse AS sc ON c.id = sc.courseId
    GROUP BY c.name;

-- Isolate to 1, the highest avg
-- CORRECT #11
SELECT c.name, round(avg(sc.progress), 1) as courseAvg
FROM course AS c
LEFT JOIN studentCourse AS sc ON c.id = sc.courseId
GROUP BY c.name
ORDER BY courseAvg DESC
LIMIT 1

-- #12
-- SUCCESS on faculty's student progress avg

-- f.firstName, f.lastName, avg(progress) all courses
-- round(avg(sc.progress), 1)
-- avg(prog)desc, firstName asc, lastName asc

-- faculty.id -> facultyCourse.facultyId -> c.id -> avg
-- (sc.progress)

SELECT 
    f.firstName, 
    f.lastName, 
    round(avg(sc.progress), 1) AS avgProg 
FROM faculty as f
JOIN facultycourse as fc ON f.id = fc.facultyId
JOIN course as c ON fc.courseId = c.id
JOIN studentcourse as sc ON c.id = sc.courseId
GROUP BY f.id
ORDER BY avgProg desc, f.firstName asc, f.lastName asc;

-- #13 PROGRESSING VERSION
SELECT 
    f.firstName, 
    f.lastName, 
    round(avg(sc.progress), 1) AS avgProg 
FROM faculty as f
JOIN facultycourse as fc ON f.id = fc.facultyId
JOIN course as c ON fc.courseId = c.id
JOIN studentcourse as sc ON c.id = sc.courseId
WHERE avgProg > 90
GROUP BY f.id
ORDER BY avgProg desc, f.firstName asc, f.lastName asc

-- WHERE >= 90 game changer
SELECT 
    f.firstName, 
    f.lastName, 
    round(avg(sc.progress)/count(distinct sc.studentId), 1) AS avgProg 
FROM faculty as f
JOIN facultycourse as fc ON f.id = fc.facultyId
JOIN course as c ON fc.courseId = c.id
JOIN studentcourse as sc ON c.id = sc.courseId
WHERE sc.progress >= 90
GROUP BY f.id 
ORDER BY avgProg desc, f.firstName asc, f.lastName asc

-- as close as it gets, but what's missing?
SELECT 
    f.firstName, 
    f.lastName, 
    round(avg(sc.progress), 1) AS avgProg 
FROM faculty as f
    JOIN facultycourse as fc ON f.id = fc.facultyId
    JOIN course as c ON fc.courseId = c.id
    JOIN studentcourse as sc ON c.id = sc.courseId
WHERE sc.progress >= 90
GROUP BY f.id  
ORDER BY avgProg DESC, f.firstname asc, f.lastname asc;

-- #14

-- Two grades based on min and max  
-- Progress <40: F
-- Progress <50: D
-- Progress <60: C
-- Progress <70: B
-- Progress >= 70: A

-- DISPLAY
-- FIRST  NAME, LAST NAME, MINUMUM GRADE based on min progress
-- AND max(grade) based on maximum
-- ORDER BY MIN(grade) DESC, MAX(grade) DESC, 
-- FIRST NAME ASC, LAST NAME ASC

-- Version 1
SELECT 
    s.firstname, 
    s.lastname, 
    min(sc.progress), 
    max(sc.progress)
FROM student AS s
    JOIN studentCourse as sc ON s.id = sc.studentid
    GROUP BY firstname, lastname

-- Version 2 

SELECT 
    s.firstname, 
    s.lastname, 
    CASE 
    	WHEN min(sc.progress) <= 40 THEN 'F'
        WHEN min(sc.progress) <= 50 AND min(sc.progress) > 40 THEN 'D'
        WHEN min(sc.progress) <= 60 AND min(sc.progress) > 50 THEN 'C'
        WHEN min(sc.progress) <= 70 AND min(sc.progress) > 60 THEN 'B'
        WHEN min(sc.progress) > 70 THEN 'A'
    END AS 'Minimum Grade', 
    CASE 
    	WHEN max(sc.progress) <= 40 THEN 'F'
        WHEN max(sc.progress) <= 50 AND max(sc.progress) > 40 THEN 'D'
        WHEN max(sc.progress) <= 60 AND max(sc.progress) > 50 THEN 'C'
        WHEN max(sc.progress) <= 70 AND max(sc.progress) > 60 THEN 'B'
        WHEN max(sc.progress) > 70 THEN 'A'
    END AS 'Maximum Grade'
	
FROM student AS s
    JOIN studentCourse as sc ON s.id = sc.studentid
    GROUP BY 
        firstname, 
        lastname, 
        CASE 
            WHEN min(sc.progress) <= 40 THEN 'F'
            WHEN min(sc.progress) <= 50 AND min(sc.progress) > 40 THEN 'D'
            WHEN min(sc.progress) <= 60 AND min(sc.progress) > 50 THEN 'C'
            WHEN min(sc.progress) <= 70 AND min(sc.progress) > 60 THEN 'B'
            WHEN min(sc.progress) > 70 THEN 'A'
        END AS 'Minimum Grade',
        CASE 
            WHEN max(sc.progress) <= 40 THEN 'F'
            WHEN max(sc.progress) <= 50 AND max(sc.progress) > 40 THEN 'D'
            WHEN max(sc.progress) <= 60 AND max(sc.progress) > 50 THEN 'C'
            WHEN max(sc.progress) <= 70 AND max(sc.progress) > 60 THEN 'B'
            WHEN max(sc.progress) > 70 THEN 'A'
        END AS 'Maximum Grade'

-- WORKING VERS, has NULL when X0 number
SELECT 
    s.firstname, 
    s.lastname, 
    CASE 
        WHEN min(sc.progress) < 40 THEN 'F'
        WHEN min(sc.progress) < 50 AND min(sc.progress) >= 40 THEN 'D'
        WHEN min(sc.progress) < 60 AND min(sc.progress) >= 50 THEN 'C'
        WHEN min(sc.progress) < 70 AND min(sc.progress) >= 60 THEN 'B'
        WHEN min(sc.progress) >= 70 THEN 'A'
    END AS 'Minimum Grade', 
    CASE 
        WHEN max(sc.progress) < 40 THEN 'F'
        WHEN max(sc.progress) < 50 AND max(sc.progress) >= 40 THEN 'D'
        WHEN max(sc.progress) < 60 AND max(sc.progress) >= 50 THEN 'C'
        WHEN max(sc.progress) < 70 AND max(sc.progress) >= 60 THEN 'B'
        WHEN max(sc.progress) >= 70 THEN 'A'
    END AS 'Maximum Grade'
FROM student AS s
    JOIN studentCourse as sc ON s.id = sc.studentid
    GROUP BY s.id
    ORDER BY min(sc.progress) desc, max(sc.progress) desc, s.firstName asc, s.lastName asc;

-- WINNER WINNER CHICKEN DINNER 14 DONEZO! ORDER BY CASE
    SELECT 
    s.firstname, 
    s.lastname, 
    CASE 
        WHEN min(sc.progress) < 40 THEN 'F'
        WHEN min(sc.progress) < 50 AND min(sc.progress) >= 40 THEN 'D'
        WHEN min(sc.progress) < 60 AND min(sc.progress) >= 50 THEN 'C'
        WHEN min(sc.progress) < 70 AND min(sc.progress) >= 60 THEN 'B'
        WHEN min(sc.progress) >= 70 THEN 'A'
    END AS 'Minimum Grade', 
    CASE 
        WHEN max(sc.progress) < 40 THEN 'F'
        WHEN max(sc.progress) < 50 AND max(sc.progress) >= 40 THEN 'D'
        WHEN max(sc.progress) < 60 AND max(sc.progress) >= 50 THEN 'C'
        WHEN max(sc.progress) < 70 AND max(sc.progress) >= 60 THEN 'B'
        WHEN max(sc.progress) >= 70 THEN 'A'
    END AS 'Maximum Grade'
FROM student AS s
    JOIN studentCourse as sc ON s.id = sc.studentid
    GROUP BY s.id
    ORDER BY CASE 
        WHEN min(sc.progress) < 40 THEN 'F'
        WHEN min(sc.progress) < 50 AND min(sc.progress) >= 40 THEN 'D'
        WHEN min(sc.progress) < 60 AND min(sc.progress) >= 50 THEN 'C'
        WHEN min(sc.progress) < 70 AND min(sc.progress) >= 60 THEN 'B'
        WHEN min(sc.progress) >= 70 THEN 'A'
    END desc, 
    CASE 
        WHEN max(sc.progress) < 40 THEN 'F'
        WHEN max(sc.progress) < 50 AND max(sc.progress) >= 40 THEN 'D'
        WHEN max(sc.progress) < 60 AND max(sc.progress) >= 50 THEN 'C'
        WHEN max(sc.progress) < 70 AND max(sc.progress) >= 60 THEN 'B'
        WHEN max(sc.progress) >= 70 THEN 'A'
    END desc, s.firstName asc, s.lastName asc

