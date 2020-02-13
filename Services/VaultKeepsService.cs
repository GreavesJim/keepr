using System;
using System.Collections.Generic;

using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository vkr)
    {
      _repo = vkr;
    }
    internal IEnumerable<Keep> GetById(int vid, string userId)
    {
      var found = _repo.GetById(vid, userId);
      if (found == null) { throw new Exception("Invalid id"); }
      return found;
    }



    internal string Delete(int vid, int kid, string userId)
    {
      // VaultKeep exists = _repo.Find(vid, kid, userId);
      // if (exists == null) { throw new Exception("Invalid Id Combination"); }
      _repo.Delete(vid, kid, userId);
      return "Successfully Deleted";
    }

    internal void Create(VaultKeep newData)
    {
      // NOTE works but commented out for testing purposes
      // VaultKeep exists = _repo.Find(newData);
      // if (exists != null) { throw new Exception("You aleady have this keep"); }
      _repo.Create(newData);
    }
  }
}