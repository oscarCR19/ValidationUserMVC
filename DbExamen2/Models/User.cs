﻿namespace DbExamen2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Photo { get; set; }

        public DateTime? Datein { get; set; }


    }
}
