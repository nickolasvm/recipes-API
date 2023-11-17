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
[Route("comment")]
public class CommentController : ControllerBase
{
    public readonly ICommentService _service;

    public CommentController(ICommentService service)
    {
        this._service = service;
    }

    [HttpPost]
    public IActionResult Create([FromBody] Comment comment)
    {
        _service.AddComment(comment);
        return CreatedAtAction("Get", new { name = comment.RecipeName }, comment);
    }

    [HttpGet("{name}", Name = "GetComment")]
    public IActionResult Get(string name)
    {
        List<Comment> comments = _service.GetComments(name);
        return Ok(comments);
    }
}