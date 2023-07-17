﻿using Shared.Entities;

namespace FirstApi.Data.Entities
{
    public class Reservation : BaseEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
