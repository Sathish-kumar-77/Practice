CREATE VIEW chennai_tn_employees AS
SELECT employee_id,
       employee_name,
       salary,
       location,
       state,
       department_id
FROM employees
WHERE location = 'Chennai' AND state = 'TN';

select * from chennai_tn_employees
CREATE TABLE employees (
    employee_id INT PRIMARY KEY,            
    employee_name VARCHAR(255),             
    salary DECIMAL(10, 2),                 
    location VARCHAR(255),                  
    state VARCHAR(2),                      
    department_id INT                      
);

INSERT INTO employees (employee_id, employee_name, salary, location, state, department_id)
VALUES
(1, 'John Doe', 50000, 'Chennai', 'TN', 101),     
(2, 'Jane Smith', 55000, 'Chennai', 'TN', 102),   
(3, 'Alice Johnson', 60000, 'Mumbai', 'MH', 103),  
(4, 'Bob Williams', 70000, 'Chennai', 'TN', 101),  
(5, 'Charlie Brown', 75000, 'Chennai', 'TN', 104);