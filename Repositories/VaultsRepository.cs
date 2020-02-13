using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Vault Create(Vault newVault)
    {
      string sql = @"
      INSERT INTO Vaults (name, description, userId)
      VALUES(@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newVault);
      newVault.Id = id;
      return newVault;
    }

    internal Vault GetById(string userId, int id)
    {
      string sql = "SELECT * FROM Vaults WHERE userId = @UserId and id = @Id;";

      return _db.QueryFirstOrDefault<Vault>(sql, new { userId, id });
    }

    internal IEnumerable<Vault> Get(string userId)
    {
      string sql = "SELECT * FROM Vaults WHERE userId = @UserId";
      return _db.Query<Vault>(sql, new { userId });
    }

    internal void Delete(string userId, int id)
    {
      string sql = "DELETE FROM Vaults WHERE userId = @UserId and id = @Id";
      _db.Execute(sql, new { id, userId });
    }
  }
}