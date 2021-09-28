using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FullstackMVC.Engine
{
    public class NLogCommunicator
    {


        private readonly static ILogger logger = LogManager.GetCurrentClassLogger();

        public static void Info(string msg)
        {
            logger.Info(msg);
        }

        public static void Error(HttpRequestException msg)
        {
            logger.Error(msg);
        }

        public static void Error(Exception msg)
        {
            logger.Error(msg);
        }

    }
}
