using System;
using System.IdentityModel.Tokens.Jwt;

namespace kwet_service.Helpers
{
    public class JwtIdClaimReaderHelper : IJwtIdClaimReaderHelper
    {
        public Guid getUserIdFromToken(string jwt)
        {
            var token = new JwtSecurityToken(jwt.Replace("Bearer ", String.Empty));
            var idclaim = Guid.Parse((string)token.Payload["unique_name"]);
            // var idclaim = Guid.Parse((string)token.Payload[ClaimTypes.Name]);
            return idclaim;
        }
    }
}