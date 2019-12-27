using System;
using System.Linq;
using WebResearch.Models;

namespace WebResearch.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ResearchContext context)
        {
            context.Database.EnsureCreated();

            if (!context.ResearchLinks.Any())
            {
                var researchLinks = new Research[]
                {
                    new Research{Url="www.google.com",DateSaved=DateTime.Now,Note="Generated Data",Read=false},
                    new Research{Url="www.twitter.com",DateSaved=DateTime.Now,Note="Generated Data",Read=false},
                    new Research{Url="www.facebook.com",DateSaved=DateTime.Now,Note="Generated Data",Read=false},
                    new Research{Url="www.packtpub.com",DateSaved=DateTime.Now,Note="Generated Data",Read=false},
                    new Research{Url="www.linkedin.com",DateSaved=DateTime.Now,Note="Generated Data",Read=false},
                };
                foreach (Research research in researchLinks)
                {
                    context.ResearchLinks.Add(research);
                }
                context.SaveChanges();
            }
        }
    }
}
