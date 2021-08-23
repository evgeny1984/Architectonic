﻿using System;

namespace Architect.Dto.Dto
{
    public class BaseEntityDTO
    {
        public int Id { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
        public string IpAddress { get; set; }
    }
}