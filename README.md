SQL scripts used for creating the database and tables:
CREATE DATABASE Test;

USE Test;

CREATE TABLE TaxiData (
    tpep_pickup_datetime DATETIME NOT NULL,
    tpep_dropoff_datetime DATETIME NOT NULL,
    passenger_count INT NOT NULL,
    trip_distance DECIMAL(10,2) NOT NULL,
    store_and_fwd_flag NVARCHAR(3) NOT NULL,
    PULocationID INT NOT NULL,
    DOLocationID INT NOT NULL,
    fare_amount DECIMAL(10,2) NOT NULL,
    tip_amount DECIMAL(10,2) NOT NULL
);

CREATE INDEX idx_PULocationID ON TaxiData (PULocationID);
CREATE INDEX idx_tip_amount ON TaxiData (tip_amount);
CREATE INDEX idx_trip_distance ON TaxiData (trip_distance);

Number of rows in your table after running the program: 29889

Assume your program will be used on much larger data files. Describe in a few sentences what you would change if you knew it would be used for a 10GB CSV input file:
Use techniques like bulk insert or batch processing for database operations.
Instead of reading the entire file into memory at once, read the file in smaller chunks or lines to reduce memory usage.
Use parallel processing.
