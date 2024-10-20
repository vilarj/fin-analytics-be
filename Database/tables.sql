-- Create Users Table
CREATE TABLE IF NOT EXISTS Users (
    userId INTEGER PRIMARY KEY AUTOINCREMENT,
    fullName TEXT,
    DoB DATE NOT NULL,
    phone INTEGER NOT NULL,
    address TEXT NOT NULL,
    email TEXT NOT NULL,
    company TEXT NOT NULL
);

-- Create Reports Table
CREATE TABLE IF NOT EXISTS Reports (
    reportId INTEGER PRIMARY KEY AUTOINCREMENT,
    userId INTEGER NOT NULL,
    details TEXT NOT NULL,
    lastGeneratedIn TEXT NOT NULL,
    FOREIGN KEY (userId) REFERENCES Users(userId)
);