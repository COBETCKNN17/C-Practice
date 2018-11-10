using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DojoSurvey_Model.Models 
{
    public class Survey
    {
        public string name {get;set;}
        public string location {get;set;}
        public string language {get;set;}
        public string comments {get;set;}
    }
}