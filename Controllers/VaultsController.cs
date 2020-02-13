using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Keepr.Services;
using Keepr.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;
    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }

    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vs.Get(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Vault> Post([FromBody] Vault newVault)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newVault.UserId = userId;
        return Ok(_vs.Create(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{id}")]
    [Authorize]
    public ActionResult<Vault> GetById(int id)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vs.GetById(userId, id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }

    }
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vs.Delete(userId, id));

      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }


  }
}