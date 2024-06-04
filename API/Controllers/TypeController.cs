using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace crm_minimal.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly IMapper _mapper;
    }
}
