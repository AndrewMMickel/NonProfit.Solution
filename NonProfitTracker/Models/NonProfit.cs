using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace NonProfitTracker.Models
{
    public class NonProfit
    {
        public string Name { get; set; }
        public int NonProfitId { get; set; }

        public virtual ICollection<BoardMember> BoardMembers { get; set; }

        public NonProfit()
        {
            this.BoardMembers = new HashSet<BoardMember>();
        }
    }
}