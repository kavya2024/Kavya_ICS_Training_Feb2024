create Database Railway_Reservation_System
 
use  Railway_Reservation_System
--table to store train details
create table Train_Details
(Train_No Numeric(5) primary key not null,
T_Name varchar(45)not null,
Source varchar(20) not null,
Dest varchar(20) not null,
softDelete varchar(20) not null)
 select * from Train_Details
--Data into Train-Details
insert into Train_Details values
(22538,'Kushinagar SF Express','Khushinagar','Gorakhpur','yes'),
(14553,'HIMACHAL-EXP','Delhi','Himachal','no'),
(12276,'Humsafar Express','New Delhi','Allahabad','yes')


--table to store class details and fare
create table Fare
(Serial_No int identity,
Train_No numeric(5) foreign key references Train_Details(Train_No)not null,
FirstAC float not null,
SencodAC float not null,
Sleeper float not null)
 
--Fare info into Train Class details
insert into Fare values
(22538,4500,3000,1000),
(14553,5200,3000,900),
(12276,3300,2200,800)
select * from Fare
--table to store seat details of train
create table Seat_Availability
(S_No int identity,
Train_No numeric(5) foreign key references Train_Details(Train_No),
[1-A] int,
[2-A] int,
SL int)
--seat availability information
insert into Seat_Availability values
(22538,100,200,300),
(14553,50,100,200),
(12276,120,200,500)
 
--table to store user details
create table User_detail
(User_id numeric(3) primary key,
U_Name varchar(30),
Age int)
 
--table for admin details
create table AdminDetail
(Admin_id numeric(3) primary key,
Admin_Name varchar(35),
passwords varchar(30) unique) 
--setting two admin for reservation system
insert into AdminDetail values
(121,'Kavya','kav123'),
(122,'Admin','Admin123')
 
--table to store booked ticket
create table Booked_Ticket
([PNR-No] numeric(8) primary key not null,
[User-id] numeric(3) foreign key references User_Details([User-id]),
[Train-No] numeric(5) foreign key references Train_Details([Train-No]),
[Passanger-Name] varchar(30) not null,
[Passanger-Age] int not null,
TotalFare float not null,
[Booking-Date-Time] datetime not null)
 
--to store conceled ticket info
create table Canceled_Ticket
([Canceled-id] int identity,
[PNR-No] numeric(8) foreign key references Booked_Ticket([PNR-No]),
[User-id] numeric(3) foreign key references User_Details([User-id]),
[Train-No] numeric(5) foreign key references Train_Details([Train-No]),
[Cancellation-Date-Time] datetime,
[Refund-Ammount] float)
 
select * from Booked_Ticket
delete from Booked_Ticket
select * from User_details
select * from Seat_Availability
 
--procesor to manage seat
CREATE or alter PROCEDURE SeatManageProc( @TrainNo NUMERIC(5), @Class int)
AS
BEGIN
    IF @Class = 1
        UPDATE Seat_Availability
        SET [1-A] = [1-A] - 1
        WHERE [Train-No] = @TrainNo;
    ELSE IF @Class = 2
        UPDATE Seat_Availability
        SET [2-A] = [2-A] - 1
        WHERE [Train-No] = @TrainNo;
	ELSE IF @Class = 3
        UPDATE Seat_Availability
        SET [SL] = [SL] - 1
        WHERE [Train-No] = @TrainNo;
 
END

update Train_Details set [Train-Status]='Active' where [Train-No]=12121
select * from Train_Details
 
delete from Train_Details where [Train-No]=12134
create or alter proc AddTrain(@tno numeric(5),@tname varchar(30),@source varchar(20),@dest varchar(20),@sts varchar(10))
as 
begin
	insert into TrainDetails values
	(@tno,@tname,@source,@dest,@sts)
end
create or alter proc modifytrain(@trainno numeric(5),@source varchar(20),@dest varchar(20))
as 
begin
	update TrainDetails set Source=@source,Destination=@dest where Train_No=@trainno
end