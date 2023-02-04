using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Company
    {
        public string company_id { get; set; }
        public string company_name { get; set; }
        public string industry { get; set; }
        public string duration { get; set; }

        public Company(string company_id, string company_name, string industry, string duration)
        {
            this.company_id = company_id;
            this.company_name = company_name;
            this.duration = duration;
            
        }
        public Company() { }
        public override string ToString()
        {
            return $"{company_id},{company_name},{industry},{duration}";
        }
    }
}
