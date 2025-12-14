CREATE TABLE Roles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL UNIQUE,
    Created DATETIME DEFAULT GETDATE(),
    Modified DATETIME NULL
);


INSERT INTO Roles (RoleName)
VALUES ('Admin'), ('Coordinator'), ('Student');

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Phone VARCHAR(15),
    RoleID INT NOT NULL,
    IsActive BIT DEFAULT 1,
    Created DATETIME DEFAULT GETDATE(),
    Modified DATETIME NULL,

    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleID)
        REFERENCES Roles(RoleID)
);

CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL,
    Description VARCHAR(255),
    Created DATETIME DEFAULT GETDATE(),
    Modified DATETIME NULL
);

CREATE TABLE Events (
    EventID INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(150) NOT NULL,
    Description VARCHAR(500),
    CategoryID INT NOT NULL,
    Venue VARCHAR(150),
    StartDateTime DATETIME NOT NULL,
    EndDateTime DATETIME NOT NULL,
    MaxParticipants INT,
    CreatedByUserID INT NOT NULL,
    IsActive BIT DEFAULT 1,
    Created DATETIME DEFAULT GETDATE(),
    Modified DATETIME NULL,

    CONSTRAINT FK_Events_Categories FOREIGN KEY (CategoryID)
    REFERENCES Categories(CategoryID),

    CONSTRAINT FK_Events_Users FOREIGN KEY (CreatedByUserID)
    REFERENCES Users(UserID)
);

CREATE TABLE EventRegistrations (
    RegistrationID INT IDENTITY PRIMARY KEY,
    EventID INT NOT NULL,
    TeamName NVARCHAR(100) NULL,
    TeamLeaderUserID INT NOT NULL,
    IsGroupEvent BIT NOT NULL,
    RegisteredDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Registered',
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL,

    CONSTRAINT FK_EventRegistrations_Events 
        FOREIGN KEY (EventID) REFERENCES Events(EventID),

    CONSTRAINT FK_EventRegistrations_Users 
        FOREIGN KEY (TeamLeaderUserID) REFERENCES Users(UserID)
);

CREATE TABLE RegistrationMembers (
    MemberID INT IDENTITY PRIMARY KEY,
    RegistrationID INT NOT NULL,
    UserID INT NOT NULL,
    IsLeader BIT NOT NULL DEFAULT 0,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL,

    CONSTRAINT FK_RegistrationMembers_Registrations 
        FOREIGN KEY (RegistrationID) REFERENCES EventRegistrations(RegistrationID),

    CONSTRAINT FK_RegistrationMembers_Users 
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE EventCoordinators (
    EventCoordinatorID INT IDENTITY(1,1) PRIMARY KEY,
    EventID INT NOT NULL,
    UserID INT NOT NULL,
    AssignedDate DATETIME DEFAULT GETDATE(),
    Created DATETIME DEFAULT GETDATE(),
    Modified DATETIME NULL,

    CONSTRAINT FK_Coordinators_Events FOREIGN KEY (EventID)
    REFERENCES Events(EventID),

    CONSTRAINT FK_Coordinators_Users FOREIGN KEY (UserID)
    REFERENCES Users(UserID)
);

