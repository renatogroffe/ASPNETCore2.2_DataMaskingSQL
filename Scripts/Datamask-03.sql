USE ExemploDataMask
GO

CREATE LOGIN testedatamasks
    WITH PASSWORD = 'TesteDataMasks01!';

CREATE USER testedatamasks FOR LOGIN testedatamasks;
GO

EXEC sp_addrolemember 'db_datareader', 'testedatamasks'