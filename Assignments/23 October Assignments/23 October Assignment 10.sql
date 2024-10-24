--Assignment 10--

CREATE TABLE Room (
    RoomID INT PRIMARY KEY,
    RoomType VARCHAR(50),
    Availability BIT 
);

CREATE TABLE Bookings (
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    RoomID INT,
    CustomerName VARCHAR(100),
    CheckinDate DATE,
    CheckoutDate DATE,
    FOREIGN KEY (RoomID) REFERENCES Room(RoomID)
);



INSERT INTO Room (RoomID, RoomType, Availability) VALUES
(1, 'Single', 1),
(2, 'Double', 1),
(3, 'Suite', 1),
(4, 'Deluxe', 1);

BEGIN TRANSACTION;

DECLARE @RoomID INT = 2; -- Example Room ID
DECLARE @CustomerName VARCHAR(100) = 'John Doe';
DECLARE @CheckinDate DATE = '2024-11-01';
DECLARE @CheckoutDate DATE = '2024-11-05';

-- Step 1: Check if the room is available
IF EXISTS (SELECT 1 FROM Room WHERE RoomID = @RoomID AND Availability = 1)
BEGIN
    -- Step 2: Insert the booking record
    INSERT INTO Bookings (RoomID, CustomerName, CheckinDate, CheckoutDate)
    VALUES (@RoomID, @CustomerName, @CheckinDate, @CheckoutDate);
    
    -- Step 3: Mark the room as unavailable
    UPDATE Room
    SET Availability = 0
    WHERE RoomID = @RoomID;

    COMMIT TRANSACTION;
    PRINT 'Room booked successfully and marked as unavailable!';
END
ELSE
BEGIN
    -- If the room is not available, rollback the transaction
    ROLLBACK TRANSACTION;
    PRINT 'Room is not available for booking!';
END;

SELECT * FROM Room WHERE RoomID = 2;
SELECT * FROM Bookings;
