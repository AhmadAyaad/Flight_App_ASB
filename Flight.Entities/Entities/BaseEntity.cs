﻿using System;

namespace Flight.Entities.Entities
{

    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
