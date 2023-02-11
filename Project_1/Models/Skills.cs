﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Skills
    {
        public int s_id { get; set; }
        public string skill_id { get; set; }
        public string skill_name { get; set; }
        public Skills(int s_id, string skill_id, string skill_name)
        {
            this.s_id = s_id;
            this.skill_id = skill_id;
            this.skill_name = skill_name;
        }
        public Skills() { }
        public override string ToString()
        {
            return $"{s_id},{skill_id},{skill_name}";
        }

        private readonly string connectionString;
        public Skills(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
