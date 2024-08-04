using System;

public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        using var databaseOperation = database;
        try
        {
            databaseOperation.BeginTransaction();
            databaseOperation.Write(data);
            databaseOperation.EndTransaction();
        }
        catch (InvalidOperationException)
        {
            Database.lastData = Database.lastData == "bad write" ? "bad write" : "bad commit";
            throw;
        }
    }

    public bool WriteSafely(string data)
    {
        using var databaseOperation = database;
        try
        {
            databaseOperation.BeginTransaction();
            databaseOperation.Write(data);
            databaseOperation.EndTransaction();

            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }
}