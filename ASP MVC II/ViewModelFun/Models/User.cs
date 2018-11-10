using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ViewModelFun.Models 
{
    public class User 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}