using System;
using System.Data.Entity;
using WpfLab.Models;

namespace WpfLab.Services
{
    public class PeriodicalService
    {
        public PeriodicalService(Context context)
        {
            Context = context;

            Context.Issuances.Load();
            Context.Readers.Load();
            Context.Publishings.Load();
            Context.Publications.Load();
        }

        public Context Context { get; }

        public int AddReader(string name, string phone, DateTime birthday)
        {
            var reader = new Reader(name, phone, birthday);

            Context.Readers.Add(reader);
            Save();

            return reader.Id;
        }

        private void Save()
        {
            Context.SaveChanges();
        }
    }
}
