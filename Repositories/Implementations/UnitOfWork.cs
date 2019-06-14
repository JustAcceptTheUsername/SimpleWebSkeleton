using AutoCatalogue.Contexts;
using AutoCatalogue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCatalogue.Repos
{
    public class UnitOfWork : IDisposable
    {
        private AutoCatalogueDbContext context = new AutoCatalogueDbContext();
        private GenericRepository<Car> carRepository;
        private GenericRepository<CarType> typeRepository;
        private GenericRepository<Make> makeRepository;

        public GenericRepository<Car> CarRepository
        {
            get
            {
                if(this.carRepository == null)
                {
                    this.carRepository = new GenericRepository<Car>(context);
                }
                return carRepository;
            }
        }

        public GenericRepository<Make> MakeRepository
        {
            get
            {
                if(this.makeRepository == null)
                {
                    this.makeRepository = new GenericRepository<Make>(context);
                }
                return makeRepository;
            }
        }

        public GenericRepository<CarType> TypeRepository
        {
            get
            {
                if (this.typeRepository == null)
                {
                    this.typeRepository = new GenericRepository<CarType>(context);
                }
                return typeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
                if (disposing)
                    context.Dispose();
            this.disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}