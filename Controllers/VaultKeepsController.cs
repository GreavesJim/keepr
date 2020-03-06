using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Authorize]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }


    [HttpGet("{vid}/keeps")]
    public ActionResult<Vault> Get(int vid)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        return Ok(_vks.GetById(vid, userId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }

    }



    [HttpPost]
    public ActionResult<String> Create([FromBody] VaultKeep newData)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newData.UserId = userId;
        _vks.Create(newData);
        return Ok("Success");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{vid}/keeps/{kid}")]
    public ActionResult<String> Delete(int vid, int kid)
    {
      try
      {
        var creatorId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.Delete(vid, kid, creatorId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



  }
}