create database bankingDBAPI;

use bankingDBAPI;

create table branchInfo
(
	branchNo int primary key,
	branchName varchar(20),
	branchCity varchar(20)
);

create table accountInfo
(
	accountNo int primary key ,
	accountName varchar(20),
	accountBalnce decimal,
	accountIsActive bit,
	accountBranch int foreign key(accountBranch) REFERENCES [dbo].[branchInfo] ([branchNo]) 
);

create table transactionInfo
(
	transactionNo int primary key,
	transactionDate DateTime,
	transactionFromAcc int foreign key(transactionFromAcc) REFERENCES [dbo].accountInfo (accountNo),
	transactionToAcc int foreign key(transactionToAcc) REFERENCES [dbo].accountInfo (accountNo),
	transactionAmount decimal,
	transactionStatus varchar(20)
);

ALTER TABLE transactionInfo
ALTER COLUMN transactionDate DateTime;