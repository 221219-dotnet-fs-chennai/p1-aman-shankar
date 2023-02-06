using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Education
    {
        public int e_id { get; set; }
        public string education_id { get; set; } 
        public string education_name { get; set; }
        public string ? institute_name { get; set; }
        public string ? grade { get; set; } 
        public string ? duration { get; set; }
        public Education(int e_id , string education_id,string education_name, string institute_name, string grade,string duration) 
        {
            this.e_id = e_id;
            this.education_id = education_id;
            this.education_name = education_name;
            this.institute_name = institute_name;
            this.grade =grade;
            this.duration =duration;

        }
        public Education () { }
        public override string ToString()
        {
            return $"{e_id},{education_id},{education_name},{institute_name},{grade},{duration}";
        }
    }
}
