
CREATE DATABASE IF NOT EXISTS company;


USE company;


CREATE TABLE IF NOT EXISTS employee (
    employee_id INT AUTO_INCREMENT PRIMARY KEY,
    employee_name VARCHAR(255) NOT NULL,
    salary DECIMAL(10, 2) NOT NULL,
    department_id INT NOT NULL
);


CREATE TABLE IF NOT EXISTS salary_update_log (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    updated_count INT,
    update_timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


DELIMITER $$

CREATE TRIGGER after_salary_update
AFTER UPDATE ON employee
FOR EACH ROW
BEGIN
    
    DECLARE updated_count INT;

   
    IF OLD.salary <> NEW.salary THEN
        
        SELECT COUNT(*) INTO updated_count
        FROM employee
        WHERE salary <> OLD.salary AND salary = NEW.salary;

        
        INSERT INTO salary_update_log (updated_count) VALUES (updated_count);
    END IF;
END $$

DELIMITER ;

INSERT INTO employee (employee_name, salary, department_id) 
VALUES 
('sathishkumar', 50000, 1),
('Hari Haran', 55000, 2),
('Gohul', 60000, 1);
SET SQL_SAFE_UPDATES = 0;
UPDATE employee
SET salary = 55000
WHERE department_id = 2;

SELECT * FROM salary_update_log;