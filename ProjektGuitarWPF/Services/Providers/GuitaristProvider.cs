﻿using Microsoft.EntityFrameworkCore.Internal;
using ProjektGuitarWPF.Database;
using ProjektGuitarWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGuitarWPF.Services.Providers
{
    public class GuitaristProvider : IGuitaristProvider
    {
        private readonly DbContextFactory contextFactory;

        public GuitaristProvider(DbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void CreateGuitarist(int guitarId, Guitarist guitarist)
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                var guitar = context.Guitars.Where(g => g.Id == guitarId).FirstOrDefault();

                var guitaristGuitar = new GuitaristGuitar()
                {
                    Guitar = guitar,
                    Guitarist = guitarist
                };

                context.Add(guitaristGuitar);
                context.Add(guitarist);
                context.SaveChanges();
            }
        }

        public List<Guitarist> GetAllGuitarists()
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                return context.Guitarists.ToList();
            }
        }
    }
}