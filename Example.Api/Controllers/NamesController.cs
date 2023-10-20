using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NamesController : ControllerBase
{
    public static List<string> Methods { get; set; } = new List<string>
    {
        "Adam",
        "Billy",
        "Ceasar",
        "Danny",
        "Emilia",
        "Fin",
        "Garo",
        "Hella",
        "Ino",
        "Jimmy",
        "Kate",
        "Lena",
        "Mike",
        "Nimo",
        "Obito",
        "Pluto",
        "Quinn",
        "Rattata",
        "Saka",
        "Takamura",
        "Usopp",
        "Violet",
        "Wayne",
        "Xavier",
        "Yuma",
        "Zimo"
    };

    [HttpGet]
    public ActionResult<IList<string>> Get()
    {
        return Methods;
    }

    [HttpGet("{index}")]
    public ActionResult<string> Get(int index)
    {
        return Methods[index];
    }

    [HttpPost]
    public ActionResult<string> Post(string name)
    {
        Methods.Add(name);
        return Ok(name);
    }

    [HttpPut("{index}")]
    public IActionResult Put(int index, string name)
    {
        Methods[index] = name;
        return NoContent();
    }

    [HttpDelete("{index}")]
    public ActionResult<string> Delete(int index)
    {
        var value = Methods[index].Clone();
        Methods.RemoveAt(index);
        return Ok(value);
    }
}
