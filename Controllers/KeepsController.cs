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
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }
    [HttpGet]
    [AllowAnonymous]
    public ActionResult<IEnumerable<Keep>> Get()
    {

      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpGet("users")]
    public ActionResult<IEnumerable<Keep>> GetAllUserKeeps()
    {

      try
      {


        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var keep = _ks.GetAllUserKeep(userId);

        return Ok(keep);

      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }

    }
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep newKeep)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newKeep.UserId = userId;
        return Ok(_ks.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public ActionResult<Keep> GetById(int id)
    {

      try
      {
        var creator = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        var userId = "";
        if (creator != null) { userId = creator.Value; }
        var keep = _ks.GetById(id, userId);

        return Ok(keep);

      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }

    }
    [HttpPut("{id}")]
    public ActionResult<Keep> Edit([FromBody] Keep update, int id)
    {
      try
      {
        update.Id = id;
        update.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ks.Edit(update));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        var creatorId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ks.Delete(creatorId, id));

      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}