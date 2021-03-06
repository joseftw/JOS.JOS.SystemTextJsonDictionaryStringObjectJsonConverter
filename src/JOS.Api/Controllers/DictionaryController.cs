﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using JOS.SystemTextJsonDictionaryObjectJsonConverter;
using Microsoft.AspNetCore.Mvc;

namespace JOS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DictionaryController : ControllerBase
    {
        [HttpPost("default")]
        public IActionResult Default(Dictionary<string, object> data)
        {
            return new OkObjectResult(data);
        }

        [HttpPost("custom")]
        public IActionResult Custom([ModelBinder(typeof(DictionaryObjectJsonModelBinder))]Dictionary<string, object> data)
        {
            return new OkObjectResult(data);
        }

        [HttpPost("custom/property")]
        public IActionResult CustomProperty(MyInput data)
        {
            return new OkObjectResult(data);
        }
    }

    public class MyInput
    {
        public string Name { get; set; }
        [JsonConverter(typeof(DictionaryStringObjectJsonConverter))]
        public Dictionary<string, object> Data { get; set; }
    }
}
