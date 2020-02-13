using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }


    // internal Keep GetById(int id)
    // {
    //   string sql = "SELECT v.* FROM Keeps k WHERE id = @Id AND v.isPrivate = @0";

    //   return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    // }

    internal Keep GetById(int id)
    {
      string sql = "SELECT * FROM Keeps WHERE id = @Id";

      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
    internal Keep Create(Keep KeepData)
    {
      string sql = @"
      INSERT INTO Keeps(userId, name, description, img, isPrivate, views, shares, keeps)
      VALUES(@UserId, @Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, KeepData);
      KeepData.Id = id;
      return KeepData;
    }


    internal void Edit(Keep update)
    {
      string sql = @"
      UPDATE Keeps
      SET
      userId = @UserId,
      name = @Name,
      description = @Description,
      img = @Img,
      isPrivate = @IsPrivate,
      views = @Views,
      shares = @Shares,
      keeps = @Keeps
      WHERE id = @Id
      ";
      _db.Execute(sql, update);
    }

    internal string Delete(int id, string userId)
    {
      string sql = "DELETE FROM Keeps WHERE id = @Id and userId = @UserId ";
      _db.Execute(sql, new { id, userId });
      return "Successfully Deleted";
    }

    internal IEnumerable<Keep> GetAllUserKeep(string UserId)
    {
      string sql = "SELECT * FROM Keeps WHERE userId = @UserId;";
      return _db.Query<Keep>(sql, new { UserId });
    }
  }
}