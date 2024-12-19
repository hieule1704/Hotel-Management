CREATE DATABASE HotelManagement;
USE HotelManagement;

CREATE TABLE rooms(
roomid int Identity(1,1) primary key,
roomNo varchar(250) not null unique,
roomType varchar(250) not null,
bed varchar(250) not null,
price bigint not null,
booked varchar(50) default 'NO'
);


CREATE TABLE customers(
cid int Identity(1,1) primary key,
cname varchar(250) not null,
mobile bigint not null,
nationality varchar(250) not null,
gender varchar(50) not null,
dob varchar(50) not null,
idproof varchar(250) not null,
addres varchar(350) not null,
checkin varchar(250) not null,
checkout varchar(250),
chekout varchar(250) not null default 'NO',
roomid int not null,
foreign key (roomid) references rooms(roomid)
);

-- Query sử dụng để load Data cho UC_CustomerCheckOut
SELECT customers.cid, customers.cname, customers.mobile, customers.nationality, customers.gender, customers.dob, customers.idproof, customers.addres, customers.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customers INNER JOIN rooms ON customers.roomid = rooms.roomid WHERE customers.checkout = 'NO';

SELECT customers.cid, customers.cname, customers.mobile, customers.nationality, customers.gender, customers.dob, customers.idproof, customers.addres, customers.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price
FROM customers
INNER JOIN rooms
ON customers.roomid = rooms.roomid
WHERE customers.chekout = 'NO';

-- Employee
create table employee(
eid int identity(1,1) primary key,
ename varchar(250) not null,
mobile bigint not null,
gender varchar(50) not null,
emailid varchar(120) not null,
username varchar(150) not null,
pass varchar(150) not null
);

ALTER TABLE rooms
ADD CONSTRAINT chk_booked CHECK (booked IN ('YES', 'NO'));

ALTER TABLE customers
ADD CONSTRAINT chk_gender CHECK (gender IN ('Male', 'Female', 'Other'));

ALTER TABLE employee ADD CONSTRAINT uq_username UNIQUE (username);
ALTER TABLE employee ADD CONSTRAINT uq_email UNIQUE (emailid);


SELECT * FROM customers;
SELECT * FROM rooms;
SELECT * FROM employee;






