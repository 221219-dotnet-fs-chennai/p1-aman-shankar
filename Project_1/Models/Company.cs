using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Company
    {
        public int c_id { get; set; }
        public string company_id { get; set; } 
        public string company_name { get; set; }
        public string ? industry { get; set; }
        public string ? duration { get; set; }

        public Company(int c_id , string company_id, string company_name, string industry, string duration)
        {
            this.c_id = c_id;
            this.company_id = company_id;
            this.company_name = company_name;
            this.duration = duration;
            
        }
        public Company() { }
        public override string ToString()
        {
            return $"{c_id},{company_id},{company_name},{industry},{duration}";
        }
    }
}
