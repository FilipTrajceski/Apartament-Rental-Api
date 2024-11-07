using S_T.Apartaments.Entities.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Infrastructure.TokenService
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> GenerateTokenAsync(User user);
    }
}
