CREATE DATABASE IF NOT EXISTS inventory;


USE inventory;


CREATE TABLE IF NOT EXISTS product (
    product_id INT AUTO_INCREMENT PRIMARY KEY,
    product_name VARCHAR(255) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    quantity INT NOT NULL
);


CREATE TABLE IF NOT EXISTS product_count_log (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    count INT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


DELIMITER $$

CREATE TRIGGER after_product_insert
AFTER INSERT ON product
FOR EACH ROW
BEGIN
   
    DECLARE row_count INT;

    
    SELECT COUNT(*) INTO row_count FROM product;

    
    INSERT INTO product_count_log (count) VALUES (row_count);
END $$

DELIMITER ;

INSERT INTO product (product_name, price, quantity) 
VALUES ('Iphone', 1000, 20);
SELECT * FROM product_count_log;
