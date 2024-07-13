USE HotelManager;

CREATE TABLE dbo.rooms
(
	room_id INT IDENTITY(1,1) NOT NULL,
	room_number INT NOT NULL,
	room_type NVARCHAR(50) NOT NULL,
	price_per_night MONEY NOT NULL,
	availability BIT NOT NULL,

	CONSTRAINT PK_rooms_room_id PRIMARY KEY (room_id)
)

CREATE TABLE dbo.customers
(
	customer_id INT IDENTITY(1,1) NOT NULL,
	first_name NVARCHAR(50) NOT NULL,
	last_name NVARCHAR(50) NOT NULL,
	email NVARCHAR(254) NOT NULL,
	phone_number NVARCHAR(15) NOT NULL,

	CONSTRAINT PK_customers_customer_id PRIMARY KEY (customer_id)
)

CREATE TABLE dbo.bookings
(
	booking_id INT IDENTITY(1,1) NOT NULL,
	customer_id INT NOT NULL,
	room_id INT NOT NULL,
	check_in_date DATE NOT NULL,
	check_out_date DATE NOT NULL,

	CONSTRAINT PK_bookings_booking_id PRIMARY KEY (booking_id),
	CONSTRAINT FK_bookings_customer_id 
		FOREIGN KEY (customer_id) REFERENCES dbo.customers (customer_id),
	CONSTRAINT FK_bookings_room_id 
		FOREIGN KEY (room_id) REFERENCES dbo.rooms (room_id)
)

CREATE TABLE dbo.facilities
(
	facility_id INT IDENTITY(1,1) NOT NULL,
	facility_name NVARCHAR(40) NOT NULL,

	CONSTRAINT PK_facilities_facility_id PRIMARY KEY (facility_id)
)

CREATE TABLE dbo.rooms_to_facilities
(
	room_id INT NOT NULL,
	facility_id INT NOT NULL,

	CONSTRAINT PK_rooms_to_facilities_id PRIMARY KEY (room_id, facility_id),
	CONSTRAINT FK_rooms_to_facilities_room_id 
		FOREIGN KEY (room_id) REFERENCES dbo.rooms (room_id),
	CONSTRAINT FK_rooms_to_facilities_facility_id 
		FOREIGN KEY (facility_id) REFERENCES dbo.facilities (facility_id)
)


INSERT INTO dbo.rooms (room_number, room_type, price_per_night, availability)
VALUES
	(101, 'Одноместный', 1000.0, 1),
	(102, 'Одноместный', 1000.0, 1),
	(103, 'Одноместный', 1000.0, 0),
	(104, 'Трехместный', 4000.0, 1),
	(105, 'Одноместный', 1500.0, 0),
	(201, 'Двухместный', 2000.0, 1),
	(202, 'Двухместный', 2200.0, 1),
	(203, 'Одноместный', 1700.0, 0),
	(204, 'Трехместный', 4000.0, 1),
	(205, 'Двухместный', 3000.0, 1),
	(301, 'Одноместный', 3000.0, 0),
	(302, 'Двухместный', 4200.0, 1),
	(303, 'Одноместный', 3700.0, 0),
	(304, 'Трехместный', 4000.0, 1),
	(305, 'Аппартаменты', 10000.0, 1);

INSERT INTO dbo.customers (first_name, last_name, email, phone_number)
VALUES
	('Alice', 'Johnson', 'alice.johnson@example.com', '+1234567890'),
	('Alice', 'Johnson', 'alice.johnson2@example.com', '+1234567891'),
	('Bob', 'Smith', 'bob.smith@example.com', '+1987654321'),
	('Charlie', 'Brown', 'charlie.brown@example.com', '+1123456789'),
	('David', 'Wilson', 'david.wilson@example.com', '+1098765432'),
	('Eva', 'Davis', 'eva.davis@example.com', '+1212345678'),
	('Frank', 'Miller', 'frank.miller@example.com', '+1654321879'),
	('Grace', 'Taylor', 'grace.taylor@example.com', '+1789456123'),
	('Henry', 'Martin', 'henry.martin@example.com', '+1543217890'),
	('Ivy', 'White', 'ivy.white@example.com', '+1365987420'),
	('Jack', 'Clark', 'jack.clark@example.com', '+1890765432'),
	('Tina', 'Scott', 'tina.scott@example.com', '+1789456123');

INSERT INTO dbo.bookings (customer_id, room_id, check_in_date, check_out_date)
VALUES
	(1, 1, '2024-02-12', '2024-02-18'),
	(1, 10, '2024-04-22', '2024-05-02'),
	(1, 1, '2024-05-05', '2024-05-07'),
	(2, 2, '2024-03-17', '2024-03-19'),
	(2, 6, '2024-07-17', '2024-07-19'),
	(3, 13, '2024-05-19', '2024-07-22'),
	(3, 9, '2024-06-19', '2024-07-21'),
	(3, 15, '2024-07-07', '2024-07-12'),
	(4, 6, '2024-07-07', '2024-07-15'),
	(5, 8, '2024-06-29', '2024-07-15'),
	(6, 3, '2024-01-11', '2024-01-24'),
	(10, 5, '2024-02-03', '2024-02-06'),
	(11, 2, '2024-08-09', '2024-08-16'),
	(12, 1, '2024-10-08', '2024-10-13');

INSERT INTO dbo.facilities (facility_name)
VALUES
	('Wi-Fi'),
	('Кондиционер'),
	('Мини-бар'),
	('Телевизор'),
	('Чайник'),
	('Кондиционер'),
	('Бассейн'),
	('Терраса'),
	('Завтрак');

INSERT INTO dbo.rooms_to_facilities (room_id, facility_id)
VALUES
	(1, 1),
	(1, 2),
	(1, 3),
	(1, 4),
	(2, 1),
	(2, 2),
	(2, 3),
	(2, 4),
	(3, 1),
	(3, 2),
	(4, 1),
	(4, 4),
	(4, 7),
	(4, 8),
	(5, 1),
	(5, 2),
	(6, 1),
	(6, 2),
	(6, 7),
	(7, 1),
	(7, 2),
	(7, 7),
	(8, 1),
	(8, 2),
	(9, 1),
	(9, 4),
	(9, 7),
	(9, 8),
	(10, 1),
	(10, 2),
	(10, 7),
	(11, 1),
	(11, 2),
	(12, 1),
	(12, 2),
	(13, 1),
	(13, 2),
	(14, 1),
	(14, 4),
	(14, 7),
	(14, 8),
	(15, 1),
	(15, 2),
	(15, 9);

-- Поиск всех доступных номеров для бронирования на сегодняшний день
SELECT DISTINCT
	r.room_id,
	r.room_number,
	r.room_type,
	r.price_per_night
FROM rooms as r
	JOIN bookings as b on r.room_id = b.room_id
WHERE
	GETDATE() NOT BETWEEN b.check_in_date AND b.check_out_date
	AND r.availability = 1;

-- Поиск всех клиентов, чьи фамилии начинаются с буквы 'S'
SELECT *
FROM customers as c
WHERE c.last_name LIKE 'S%';

-- Поиск всех бронирований для определенного клиента (по имени или электронному адресу).
SELECT
	b.booking_id,
	b.room_id,
	b.customer_id
FROM bookings as b
	JOIN customers as c on b.customer_id = c.customer_id
WHERE c.email = 'alice.johnson@example.com';

-- Найдите все бронирования для определенного номера.
SELECT *
FROM bookings as b
WHERE b.room_id = 1;

-- Поиск всех номеров, которые не забронированы на определенную дату.
SELECT DISTINCT
	r.room_id,
	r.room_number,
	r.room_type,
	r.price_per_night,
	r.availability
FROM rooms as r
	LEFT JOIN bookings as b on r.room_id = b.room_id
WHERE '11.07.2024' NOT BETWEEN b.check_in_date AND b.check_out_date;
