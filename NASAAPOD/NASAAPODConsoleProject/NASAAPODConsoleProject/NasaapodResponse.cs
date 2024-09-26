using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASAAPODConsoleProject
{
    public class NasaapodResponse
    {
        public string? Copyright { get; set; }
        public DateTimeOffset Date { get; set; }
        public string? Explanation { get; set; }
        public Uri? Hdurl { get; set; }
        public string? MediaType { get; set; }
        public string? ServiceVersion { get; set; }
        public string? Title { get; set; }
        public Uri? Url { get; set; }
    }
}
