# DBGEN Database Utility

Build a **.NET CLI tool** that generates C# entity classes from an existing database.

---

## Flow of execution
```md
1. Read connection string
2. Fetch tables from DB
3. Show selectable list
4. Get user selection
5. Build EF scaffold command
6. Execute it
```

## How to run
```bash
cd ./DBGEN
dotnet run

DBGEN Database Utility 
-----------------------


Make you have EF Core installed: `dotnet tool install --global dotnet-ef`
Enter connection string: Server=localhost;Database=core2;User Id=user;Password=password;TrustServerCertificate=True;

Select tables                               
                                            
> [ ] dbo.__MigrationHistory                
  [ ] dbo.__RefactorLog                     
  [ ] dbo.Users                             
  [ ] dbo.Products      

(Move up and down to reveal more choices)   
(Press <space> to select, <enter> to accept)


Done.
The C# Entities were created under ./Entities.
```

**Note:** IMPORTANT: Make you have EF Core installed: `dotnet tool install --global dotnet-ef`