﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Opain.Jarvis.Dominio.Entidades;
using Opain.Jarvis.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Opain.Jarvis.Aplicacion.Interfaces;

namespace Jarvis_Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly SignInManager<Usuario> signInManager;
        private readonly UserManager<Usuario> userManager;

        //ToDo
        //private readonly AppSettings appSettings;
        private readonly ILogger<CuentaController> _logger;
        private readonly IUsuarioAplicacion usuarioApp;

        public CuentaController(UserManager<Usuario> userMan, SignInManager<Usuario> signInMan,
            //ToDo IOptions<AppSettings> appSett, 
            ILogger<CuentaController> logger, IUsuarioAplicacion ua)
        {
            userManager = userMan;
            signInManager = signInMan;
            //ToDo appSettings = appSett.Value;
            _logger = logger;
            usuarioApp = ua;
        }

        [HttpGet]
        public async Task<string> ObtenerTokenJwt(string usr, string psw)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(usr, psw, false, false);

                if (result.Succeeded)
                {
                    var usuario = userManager.Users.SingleOrDefault(r => r.UserName.Equals(usr));
                    UsuarioOtd usuarioOtd = await usuarioApp.ObtenerPorEmailAsync(usuario.Email).ConfigureAwait(false);

                    _logger.LogInformation("ObtenerTokenJwt 1: usr:" + usr+" psw: "+psw);
                    return await GenerarJwtToken(usuarioOtd);
                }
            }
            catch (Exception err)
            {
                _logger.LogInformation("ObtenerTokenJwt 2: usr:" + usr + " psw: " + psw);
                //throw new ApplicationException("Intento de ingreso no válido");                
                return "false";
            }            
            //throw new ApplicationException("Intento de ingreso no válido");                
            return "false";
        }

        [HttpPost]
        //ToDo [Authorize]
        public async Task<object> Registro([FromBody] RegistroOtd model)
        {
            try
            {
                var usuario = new Usuario
                {
                    UserName = model.Usuario,
                    Email = model.Correo,
                    Nombre = "Usuario",
                    Apellido = "Prueba"
                };

                var resultado = await userManager.CreateAsync(usuario, model.Contrasena);

                if (resultado.Succeeded)
                {
                    await signInManager.SignInAsync(usuario, false);
                    _logger.LogInformation("Registró: {@model}", model);
                    return null;
                }

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error realizando el registro: {@model}", model);
                throw new ApplicationException("No se pudo crear el usuario");
            }

            _logger.LogWarning("Datos de registro no válidos");
            throw new ApplicationException("Datos de registro no válidos");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<Usuario> ConsultarUsuarioPorId(string id)
        {
            Usuario usuario = await userManager.FindByIdAsync(id).ConfigureAwait(false);
            return usuario;
        }

        private async Task<string> GenerarJwtToken(UsuarioOtd usuario)
        {
            var claims = new List<Claim>
            {
                //ToDo JWT
                //new Claim(JwtRegisteredClaimNames.Sub, usuario.UserName),
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id),
                new Claim(ClaimTypes.Role, usuario.RolesUsuario.FirstOrDefault().Rol.Name),
                new Claim("NombreUsuario", usuario.Nombre + " " + usuario.Apellido)
            };

            if (usuario.UsuarioAerolinea.Count > 0 && usuario.RolesUsuario.FirstOrDefault().Rol.Name.Equals("AEROLINEA"))
            {
                claims.Add(new Claim("NombreAerolinea", usuario.UsuarioAerolinea.FirstOrDefault().Aerolinea.Nombre));
                claims.Add(new Claim("IdAerolinea", usuario.UsuarioAerolinea.FirstOrDefault().Aerolinea.Id.ToString()));
            }

            claims.Add(new Claim("ActivarCarga", "1"));

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Secret));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var expires = DateTime.Now.AddDays(1);

            //var token = new JwtSecurityToken(
            //    appSettings.Issuer,
            //    appSettings.Audience,
            //    claims,
            //    expires: expires,
            //    signingCredentials: creds
            //);

            //return new JwtSecurityTokenHandler().WriteToken(token);

            return "";
        }

    }
}