﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderingAPI.Model;
using OrderingAPI.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<List<OrderHistory>> Get()
        {
            DBConnect dbConnect = new DBConnect(_logger);
            var res=  dbConnect.GetOrderHistory();
            yield return res;
        }

        [HttpGet("{OrderId}")]
        public IEnumerable<List<OrderHistory>> Get(string OrderId)
        {
            DBConnect dbConnect = new DBConnect(_logger);
            var res = dbConnect.GetOrderByOrderID(OrderId);
            yield return res;
        }
    }
}