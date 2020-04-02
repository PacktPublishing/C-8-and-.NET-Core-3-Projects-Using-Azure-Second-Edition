using Microsoft.EntityFrameworkCore;
using System;

namespace WebResearch.Models
{
    public class Research
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime DateSaved { get; set; }
        public string Note { get; set; }
        public bool Read { get; set; }
    }

    public class ResearchContext : DbContext
    {
        public ResearchContext(DbContextOptions<ResearchContext> options) : base(options)
        {
        }

        public DbSet<Research> ResearchLinks { get; set; }
    }
}
