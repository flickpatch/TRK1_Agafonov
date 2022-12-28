﻿using System;
using System.Collections.Generic;

namespace TRK1_Agafonov.Database.Entity
{
    public partial class Tag
    {
        public Tag()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Color { get; set; } = null!;

        public virtual ICollection<Client> Clients { get; set; }
    }
}
