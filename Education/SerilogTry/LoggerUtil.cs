using Serilog;

namespace SerilogTry
{
    static class LoggerUtil
    {
        public static ILogger WithUser(this ILogger logger, User user)
        {
            return logger.ForContext("User", new
            {
                Id = user.Id,
                Login = user.Login,
            }, true);
        }
    }
}
