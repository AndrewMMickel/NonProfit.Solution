using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace NonProfitTracker.Models
{
    public class BoardMember
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public int BoardMemberId { get; set; }

        public int NonProfitId { get; set; }
        public virtual NonProfit NonProfit { get; set; }
    }
}