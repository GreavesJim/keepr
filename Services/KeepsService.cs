using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }


    internal Keep GetById(int id, string userId)
    {
      var found = _repo.GetById(id);
      if (found == null) { throw new Exception("Invalid id"); }
      else if (found.IsPrivate != true && found.UserId != userId)
      { throw new Exception("you are not the user"); }
      return found;
    }
    internal Keep Create(Keep newKeep)
    {
      _repo.Create(newKeep);
      return newKeep;
    }

    internal Keep Edit(Keep update)
    {
      Keep exists = _repo.GetById(update.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      if (exists.UserId != update.UserId)
      {
        throw new Exception("I can't let you do that");
      }
      _repo.Edit(update);
      return update;
    }

    internal string Delete(string userId, int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      if (exists.UserId != userId)
      {
        throw new Exception("I can't let you do that");
      }
      _repo.Delete(id, userId);
      return "Successfully deleted";
    }

    internal IEnumerable<Keep> GetAllUserKeep(string userId)
    {
      return _repo.GetAllUserKeep(userId);
    }
  }
}