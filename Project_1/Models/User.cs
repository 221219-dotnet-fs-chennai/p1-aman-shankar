using System;
using System.Data.SqlClient;

namespace Models
{
    public class User
    {
        public string user_id { get; set; }
        public string ? first_name { get; set; }
        public string ? middle_name { get; set; }
        public string ? last_name { get; set; }
        public string ? gender { get; set; } 
        public string ? pincode { get; set; } 
        public string Email { get; set; } 
        public string ? website { get; set; }
        public string ? mobile_number { get; set; }
        public string password { get; set; } 
        public string ? about_me { get; set; }
        public User(string id ,string first_name, string middle_name , string last_name, string gender , string pincode, string Email, string website, string mobiele_number, string password, string about_me) {
            this.user_id = id;
            this.first_name = first_name;
            this.middle_name = middle_name;
            this.last_name = last_name;
            this.gender = gender;
            this.pincode = pincode;
            this.Email= Email;
            this.website = website;
            this.mobile_number= mobiele_number;
            this.password = password;
            this.about_me = about_me;
        }
        public User() { }
        public override string ToString()
        {
            return $"{user_id},{first_name},{middle_name},{last_name},{gender},{pincode},{Email},{website},{mobile_number},{password},{about_me}";
        }
        
    }
}
