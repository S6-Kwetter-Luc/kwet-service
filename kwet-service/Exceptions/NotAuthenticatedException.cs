using System;

namespace kwet_service.Exceptions
{
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException() : base("You are not authenticated to do this") { }
    }
}