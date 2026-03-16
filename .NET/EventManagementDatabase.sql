CREATE TABLE Roles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL UNIQUE,
    Created DATETIME DEFAULT GETDATE(),
    Modified DATETIME NULL
);


CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    [Password] VARCHAR(255) NOT NULL,
    Phone VARCHAR(15),
    RoleID INT NOT NULL,
    IsActive BIT DEFAULT 1,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL,

    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleID)
        REFERENCES Roles(RoleID)
);

CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL UNIQUE,
    [Description] VARCHAR(255),
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL
);

CREATE TABLE Events (
    EventID INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(150) NOT NULL,
    [Description] VARCHAR(500),
    CategoryID INT NOT NULL,
    IsGroupEvent BIT NOT NULL DEFAULT 0,
    Venue VARCHAR(150),
    StartDateTime DATETIME NOT NULL,
    EndDateTime DATETIME NOT NULL,
    MaxParticipants INT NOT NULL,
    CreatedByUserID INT NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL,

    CONSTRAINT FK_Events_Categories
        FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),

    CONSTRAINT FK_Events_Users
        FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID),

    CONSTRAINT CK_Events_Date
        CHECK (EndDateTime > StartDateTime),

    CONSTRAINT CK_Event_GroupLogic
        CHECK (
            (IsGroupEvent = 1 AND MaxParticipants > 1)
         OR (IsGroupEvent = 0 AND MaxParticipants = 1)
        )
);


CREATE TABLE EventRegistrations (
    RegistrationID INT IDENTITY(1,1) PRIMARY KEY,
    EventID INT NOT NULL,
    TeamName NVARCHAR(100) NULL,
    CreatedByUserID INT NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Registered',
    RegisteredDate DATETIME NOT NULL DEFAULT GETDATE(),
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL,

    CONSTRAINT FK_EventRegistrations_Events
        FOREIGN KEY (EventID) REFERENCES Events(EventID),

    CONSTRAINT FK_EventRegistrations_Users
        FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID),

    CONSTRAINT CK_Registration_Status
        CHECK (Status IN ('Registered', 'Cancelled'))
);

--prevent duplicate team reg
CREATE UNIQUE INDEX UQ_Event_Team
ON EventRegistrations (EventID, TeamName)
WHERE TeamName IS NOT NULL;


CREATE TABLE RegistrationMembers (
    MemberID INT IDENTITY(1,1) PRIMARY KEY,
    RegistrationID INT NOT NULL,
    UserID INT NOT NULL,
    IsLeader BIT NOT NULL DEFAULT 0,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL,

    CONSTRAINT FK_RegistrationMembers_Registrations
        FOREIGN KEY (RegistrationID) REFERENCES EventRegistrations(RegistrationID),

    CONSTRAINT FK_RegistrationMembers_Users
        FOREIGN KEY (UserID) REFERENCES Users(UserID),

    CONSTRAINT UQ_Registration_User
        UNIQUE (RegistrationID, UserID)
);
--exact one leader per reg
CREATE UNIQUE INDEX UQ_OneLeaderPerRegistration
ON RegistrationMembers (RegistrationID)
WHERE IsLeader = 1;


CREATE TABLE EventCoordinators (
    EventCoordinatorID INT IDENTITY(1,1) PRIMARY KEY,
    EventID INT NOT NULL,
    UserID INT NOT NULL,
    AssignedDate DATETIME NOT NULL DEFAULT GETDATE(),
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL,

    CONSTRAINT FK_Coordinators_Events FOREIGN KEY (EventID)
    REFERENCES Events(EventID),

    CONSTRAINT FK_Coordinators_Users FOREIGN KEY (UserID)
    REFERENCES Users(UserID)
);

