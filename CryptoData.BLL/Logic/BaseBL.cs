using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoData.DAL;
using System.Data.Entity;
using CryptoData.Core.Interfaces;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Reflection;

namespace CryptoData.BLL
{
   public class BaseBL : IBaseBL
    {
        private IBaseBL _parentBL;

        public IUnitOfWork RepositoryManager { get; set; }
        protected readonly DbContext _context;



       

        public BaseBL(IBaseBL parentBL = null)
        {
            if (parentBL == null)
            {
                this.dbContext = CreateDB();
                this.RepositoryManager = new UnitOfWork(dbContext);
            }
            else
            {
                this._parentBL = parentBL;
                this.RepositoryManager = parentBL.RepositoryManager;
            }
        }


        //private string _cnnString;
        //public string CnnString
        //{
        //    get { return this._parentBL == null ? this._cnnString : this._parentBL.CnnString; }
        //}

        private DbContext dbContext;
        public DbContext DB
        {
            get { return this._parentBL == null ? this.dbContext : this._parentBL.DB; }
        }


        public void RecreateDB()
        {
            if (this._parentBL == null)
                this.dbContext = this.CreateDB();
            else
                this._parentBL.RecreateDB();
        }

        private DbContext CreateDB()
        {
            var DB = new ParsingEntities();
            return DB;
        }

        private static MetadataWorkspace _metadataWorkspace;
        private static MetadataWorkspace MetadataWorkspace
        {
            get
            {
                if (_metadataWorkspace == null)
                    _metadataWorkspace = new MetadataWorkspace(
                        new string[] { "res://*/" },
                        new Assembly[] { Assembly.GetAssembly(typeof(ParsingEntities)) });
                return _metadataWorkspace;
            }
        }



        #region IDisposable
        private bool _disposed = false;
        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed == false && this._parentBL == null)
            {
                if (disposing)
                {
                    if (this.dbContext != null)
                        this.dbContext.Dispose();
                    this._disposed = true;
                }
            }
        }

        #endregion
    }
}
