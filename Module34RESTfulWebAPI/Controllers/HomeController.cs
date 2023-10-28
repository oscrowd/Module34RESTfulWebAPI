using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Module34RESTfulWebAPI.Configuration;
using Module34RESTfulWebAPI.Contracts.HomeApi.Contracts;
using System.Text;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    // Ссылка на объект конфигурации
    private IOptions<HomeOptions> _options;
    private IMapper _mapper;

    // Инициализация конфигурации при вызове конструктора
    public HomeController(IOptions<HomeOptions> options, IMapper mapper)
    {
        _options = options;
        _mapper = mapper;
    }

    /// <summary>
    /// Метод для получения информации о доме
    /// </summary>
    [HttpGet] // Для обслуживания Get-запросов
    [Route("info")] // Настройка маршрута с помощью атрибутов
    public IActionResult Info()
    {
        // Получим запрос, "смапив" конфигурацию на модель запроса
        var infoResponse = _mapper.Map<HomeOptions, InfoResponse>(_options.Value);
        // Вернём ответ
        return StatusCode(200, infoResponse);

        
    }
}