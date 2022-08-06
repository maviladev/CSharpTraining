using System;
using Microsoft.AspNetCore.Mvc;
using WebAPIAutores.DTOs;

namespace WebAPIAutores.Controllers
{
	[ApiController]
	[Route("api/cuentas")]
	public class CuentasController : ControllerBase
	{
		public CuentasController()
		{
		}

		[HttpPost("registrar")]
		public async Task<ActionResult<RespuestaAutenticacion>>Registra()
	}
}

