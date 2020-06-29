using System;

namespace kwet_service.Helpers
{
    public interface IJwtIdClaimReaderHelper
    {
        public Guid getUserIdFromToken(string jwt);
    }
}