using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
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
            Context.Publications.Load();
        }

        public Context Context { get; }

        public ObservableCollection<Issuance> Issuances => Context.Issuances.Local;
        public ObservableCollection<Reader> Readers => Context.Readers.Local;
        public ObservableCollection<Publication> Publications => Context.Publications.Local;

        public void AddReader(Reader reader)
        {
            Context.Readers.Add(reader);
            Save();
        }

        public void UpdateReader(Reader reader)
        {
            var entity = Context.Readers.Find(reader.Id);
            entity.Name = reader.Name;
            entity.Birthday = reader.Birthday;
            entity.Phone = reader.Phone;

            Save();
        }

        public void RemoveReader(int id)
        {
            var readerToRemove = Context.Readers.Find(id);
            if (readerToRemove != null)
            {
                Context.Readers.Remove(readerToRemove);
            }
        }

        public void AddPublication(Publication publication)
        {
            Context.Publications.Add(publication);
            Save();
        }

        public void AddIssuance(Issuance issuance)
        {
            var publication = Context.Publications.Find(issuance.Publication.Id);
            if (publication.Quantity < issuance.Quantity)
            {
                throw new Exception("В наличии нет столько выпусков!");
            }
            else
            {
                publication.Quantity -= issuance.Quantity;
            }

            var reader = Context.Readers.Find(issuance.Reader.Id);
            if (Context.Issuances.Where(iss => iss.Reader.Id == reader.Id).Count() > 3)
            {
                throw new Exception("У данного читателя уже 3 выдачи на руках!");
            }

            Context.Issuances.Add(new Issuance
            {
                Date = DateTime.Now,
                Quantity = issuance.Quantity,
                Publication = publication,
                Reader = reader
            });

            Save();
        }

        public void CloseIssuance(int id)
        {
            var issuance = Context.Issuances.Find(id);
            Context.Publications.Find(issuance.Publication.Id).Quantity += issuance.Quantity;

            Context.Issuances.Remove(issuance);
            Save();
        }

        public void Reload()
        {
            Context.Issuances.Load();
            Context.Readers.Load();
            Context.Publications.Load();
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
