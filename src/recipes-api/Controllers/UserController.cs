using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace recipes_api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    public readonly IUserService _service;

    public UserController(IUserService service)
    {
        this._service = service;
    }

    [HttpGet("{email}", Name = "GetUser")]
    public IActionResult Get(string email)
    {
        User user = _service.GetUser(email);
        if (user == null) return NotFound("User not found");
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody] User user)
    {
        _service.AddUser(user);
        return CreatedAtAction("Get", new { email = user.Email }, user);
    }

    [HttpPut("{email}")]
    public IActionResult Update(string email, [FromBody] User user)
    {
        try
        {
            if (!_service.UserExists(email)) return NotFound("User not found");

            _service.UpdateUser(user);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{email}")]
    public IActionResult Delete(string email)
    {
        if (!_service.UserExists(email)) return NotFound("User not found");
        _service.DeleteUser(email);
        return NoContent();
    }
}