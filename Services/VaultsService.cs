using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository vr)
    {
      _repo = vr;
    }
    internal Vault Create(Vault newVault)
    {
      _repo.Create(newVault);
      return newVault;
    }

    internal Vault GetById(string userId, int id)
    {
      var found = _repo.GetById(userId, id);
      if (found == null) { throw new Exception("Invalid id"); }
      return found;
    }

    internal string Delete(string userId, int id)
    {
      var exists = _repo.GetById(userId, id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _repo.Delete(userId, id);
      return "Successfully Deleted";
    }

    internal IEnumerable<Vault> Get(string userId)
    {
      var found = _repo.Get(userId);
      if (found == null) { throw new Exception("Invalid id"); }
      return found;
    }
  }
}