--create database CustomerOrderServices

create table customer(
	customer_id nvarchar(10) primary key,
	phonenumber nvarchar(12) unique,
	fullname nvarchar(50),
	password nvarchar(20)
)

create table customer_orders(
	order_id nvarchar(10) primary key,
	date_created date,
	created_by nvarchar(50),
	state_order nvarchar(20) check (state_order in ('HOÀN THÀNH', 'CHO XÁC NHẬN', 'ĐANG XỬ LÝ')),
	detail_order nvarchar(50),
	total_order money,
	customer_id nvarchar(10),
	foreign key (customer_id) references customer(customer_id)
)