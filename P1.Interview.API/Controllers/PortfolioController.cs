﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PI.Interview.Services;

namespace P1.Interview.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        /// <summary>
        /// Gets N random firm related portfolios.
        /// </summary>
        /// <param name="sampleSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSample(int sampleSize)
        {
            return Ok(await _portfolioService.GetNRandomPortfolios(sampleSize));
        }
    }
}
