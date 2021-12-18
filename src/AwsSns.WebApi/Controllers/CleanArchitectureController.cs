﻿using AwsSns.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using AwsSns.Domain.Entities.Dto;

namespace AwsSns.WebApi.Controllers
{
    /// <summary>
    /// Sample controller for Clean Architecture
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CleanArchitectureController : ControllerBase
    {
        private readonly IStatusService _statusService;
        private readonly ILogger<CleanArchitectureController> _logger;

        /// <summary>
        /// This constructor initializes a new CleanArchitectureController using a <paramref name="logger"/> and <paramref name="statusService"/>
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> instance</param>
        /// <param name="statusService">The <see cref="IStatusService"/> instance</param>
        public CleanArchitectureController(ILogger<CleanArchitectureController> logger, IStatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
        }

        /// <summary>
        /// Get the status of the service
        /// </summary>
        /// <returns>The service <see cref="StatusResponse"/></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StatusResponse>> Get()
        {
            _logger.LogInformation("Calling Get Status");

            return Ok(await _statusService.GetStatusAsync());
        }
    }
}
