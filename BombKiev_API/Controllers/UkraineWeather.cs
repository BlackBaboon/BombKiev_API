using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace BombKiev_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UkraineWeather : ControllerBase
    {
        private static List<string> Slava_RoZZii = new()
        {
        "������-2","������","�������","�������","����-�����"
        };

        private readonly ILogger<UkraineWeather> _logger;

        public UkraineWeather(ILogger<UkraineWeather> logger)
        {
            _logger = logger;
        }

        [HttpGet("����� �� �������")]
        public IActionResult GetByIndex([Required] int index)
        {
            if (index < 0 || index >= Slava_RoZZii.Count)
                return BadRequest("�������� ������ ��������");
            return Ok(Slava_RoZZii[index]);
        }

        [HttpGet("����� �� �����")]
        public int GetByName([Required] string name)
        {
            return Slava_RoZZii.Where(p => p == name).Count();
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrat)
        {
            if(sortStrat == null)
            {
                return Ok(Slava_RoZZii);
            }
            else if(sortStrat == 1)
            {
                return Ok(Slava_RoZZii.OrderBy(p => p));
            }
            else if(sortStrat == -1)
            {
                return Ok(Slava_RoZZii.OrderByDescending(p=>p));
            }
            else
            {
                return BadRequest("�����������. �������� ��� ���");
            }
        }

        [HttpPost]
        public IActionResult Add([Required] string name)
        {
            Slava_RoZZii.Add(name);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([Required] int index)
        {
            if (index < 0 || index >= Slava_RoZZii.Count)
                return BadRequest("�������� ������ ��������");
            Slava_RoZZii.RemoveAt(index);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([Required] int index, [Required] string name)
        {
            if(index < 0 || index >= Slava_RoZZii.Count)
                return BadRequest("�������� ������ ��������");

            Slava_RoZZii[index] = name;
            return Ok();
        }
    }
}