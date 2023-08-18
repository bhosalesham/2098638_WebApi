CREATE DATABASE airlinesManagement;

USE airlinesManagement;

CREATE TABLE FlightInfo
(
	FlightNo int Primary key,
	FromCity varchar(20),
	ToCity varchar(20),
	AvailableSeats int,
	Fare decimal
);
