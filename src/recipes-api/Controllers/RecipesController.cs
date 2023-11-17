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
[Route("recipe")]
public class RecipesController : ControllerBase
{
    public readonly IRecipeService _service;

    public RecipesController(IRecipeService service)
    {
        this._service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetRecipes());
    }

    [HttpGet("{name}", Name = "GetRecipe")]
    public IActionResult Get(string name)
    {
        Recipe recipe = _service.GetRecipe(name);
        if (recipe == null) return NotFound();
        return Ok(recipe);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Recipe recipe)
    {
        _service.AddRecipe(recipe);
        return CreatedAtAction("Get", new { name = recipe.Name }, recipe);
    }

    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody] Recipe recipe)
    {
        try
        {
            if (!_service.RecipeExists(name)) return NotFound("recipe not found");

            _service.UpdateRecipe(recipe);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
        if (!_service.RecipeExists(name)) return NotFound("Recipe not found");
        _service.DeleteRecipe(name);
        return NoContent();
    }
}
