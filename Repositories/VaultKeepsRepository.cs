using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep Find(VaultKeep vk)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (vaultId = @VaultId AND keepId = @KeepId)";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, vk);
    }
    internal VaultKeep Find(int vid, int kid, string userId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (vaultId = @VaultId AND keepId = @KeepId)";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vid, kid, userId });
    }

    internal IEnumerable<Keep> GetById(int VaultId, string userId)
    {
      string sql = "SELECT k.* FROM vaultkeeps vk INNER JOIN keeps k ON k.id = vk.keepId  WHERE (vk.userId = @UserId AND vaultId = @VaultId) ";

      return _db.Query<Keep>(sql, new { VaultId, userId });
    }

    internal VaultKeep Create(VaultKeep newData)
    {
      string sql = @"
            INSERT INTO vaultkeeps 
            (keepId, vaultId, userId) 
            VALUES 
            
            (@KeepId, @VaultId, @UserId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }

    internal string Delete(int vid, int kid, string userId)
    {
      string sql = "DELETE FROM vaultkeeps WHERE (userId = @userId AND vaultId = @vid)";
      _db.Execute(sql, new { vid, kid, userId });
      return "Successfully Deleted";
    }
  }
}