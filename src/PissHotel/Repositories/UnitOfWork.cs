using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PissHotel.Models;

namespace PissHotel.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private PissHotelEntities context = new PissHotelEntities();

        #region Album

        private GenericRepository<Album> albumRepository;
        public GenericRepository<Album> AlbumRepository
        {
            get
            {

                if (this.albumRepository == null)
                {
                    this.albumRepository = new GenericRepository<Album>(context);
                }
                return albumRepository;
            }
        }

        #endregion

        #region Room

        private GenericRepository<Room> roomRepository;
        public GenericRepository<Room> RoomRepository
        {
            get
            {

                if (this.roomRepository == null)
                {
                    this.roomRepository = new GenericRepository<Room>(context);
                }
                return roomRepository;
            }
        }

        #endregion

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}