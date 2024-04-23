using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khatra.Models
{
    public static class RoleName
    {
        public const string Admins = "Admins";
        public const string Publishers = "Publishers";
        public const string AdminsOrPublishers = Admins + "," + Publishers;
    }
}