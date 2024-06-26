﻿using DaihoWebAPI.Controllers;
using DaihoWebAPI.Data;
using DaihoWebAPI.Models;
using DaihoWebAPI.Models.Response;
using DaihoWebAPI.Models.DTO;
using IdentityModel.Client;
using Microsoft.IdentityModel.Tokens;
using Oracle.ManagedDataAccess.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DaihoWebAPI.Utilities;
using DaihoWebAPI.Constants;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace DaihoWebAPI.Repositories
{
    public class AuthRepository :  IAuthRepository
    {
        private readonly OraDbContext dbContext;
        private readonly string _connectionString;
        private WmUser users;
        private readonly IConfiguration configuration;
        

        public AuthRepository(OraDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("OraDbConnection");
           
        }
        public async Task<Responses> getAuth(string USR_ID, string password)
        {
            bool isValid = true;
            //Response? resp;
            

            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();


                string sql = "SELECT W.*,RU.ROLEID FROM WM_USER W LEFT JOIN ASM_Z_USER_ROLES RU ON W.USR_ID" +
                    "= ru.USERID WHERE USR_ID = :USR_ID AND PASSWORD = WF_ENCRYPT(:PASSWORD, 'Frame380')";
                

                // Create a command with parameters
                using (var command = new OracleCommand(sql, connection))
                {
                    command.Parameters.Add("@USR_ID", USR_ID);
                    command.Parameters.Add("@PASSWORD", password);

                    // Execute the command and read the result asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {

                        if (await reader.ReadAsync())
                        {
                            var authClaims = new List<Claim>
                            {
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            };
                            authClaims.Add(new Claim("USR_ID", reader["USR_ID"].ToString()));
                            authClaims.Add(new Claim("CO_CD", reader["CO_CD"].ToString()));
                            authClaims.Add(new Claim("INVALIDATE_FLG", reader["INVALIDATE_FLG"].ToString()));

                            // Fetch roles from the database
                            var userRoles = await (from role in dbContext.aSM_Z_ROLEs
                                                join asmRole in dbContext.UserRoles on role.ROLEID equals asmRole.ROLEID
                                                join user in dbContext.Users on asmRole.USERID equals user.USR_ID
                                                where user.USR_ID == USR_ID
                                                select new DaihoWebAPI.Models.DTO.UserRolesDTO
                                                {
                                                    //ID=asmRole.ID,
                                                    ROLEID = role.ROLEID,
                                                    USERNAME = user.USR_NM,
                                                    USERID = user.USR_ID,
                                                    ROLENAME = role.ROLENAME,
                                                    ID = asmRole.ID,


                                                }).ToListAsync();
                            // Collect roles into a list
                            var roles = new List<string>();

                            foreach (var userRole in userRoles)
                            {
                                var role = userRole.ROLEID;
                                roles.Add(role);
                                authClaims.Add(new Claim(ClaimTypes.Role, role));
                            }
                            var token = GetToken(authClaims);

                            var tokenResp = new Models.Response.TokenResponse
                            {
                                Token = new JwtSecurityTokenHandler().WriteToken(token),
                                ExpiresAt = token.ValidTo,
                                Role = "admin",
                                Roles= roles
                            };

                            
                            return Utilities.Utils.NewSuccessResponse(tokenResp,null);
     
                        
                        }
                        else
                        {
                            // No user found with the given USR_ID and password
                            return Utilities.Utils.NewErrorResponse(null, "invalid username or password", Status.BadRequestErr, (int)HttpStatusCode.BadRequest); 
                        }

                    }
                    //return users;
                }
            }
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dwc8aqu8ExmFfJxKLudj4DpefeE7dDAMBhSEexM"));

            var token = new JwtSecurityToken(
                issuer: "https://localhost:7298",
                audience: "https://localhost:7298",
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
