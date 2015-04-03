using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmnivoreClassLibrary.DataContracts.V01;
using OmnivoreClassLibrary.DataContracts.V01.Enums;
using OmnivoreClassLibrary.Interfaces;

namespace OmnivoreClassLibrary.DataAccess
{
    public class OmnivoreDataManager
    {
        private IOmnivoreRepository _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OmnivoreDataManager"/> class.
        /// Note, this one uses a real OmnivoreRepository behind the scenes, to make it
        /// easier on the client application.
        /// </summary>
        public OmnivoreDataManager()
        {
            this._repo = new OmnivoreRepository(); // use the real one by default.  I might refactor later to use IoC with Unity, but I'm not sure how bootstrapping Únity works in a class library, as opposed to a web site or console app, so Im leaving that alone for now and will revisit if I have time.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OmnivoreDataManager"/> class.
        /// This allows other assemblies/classes to inject dependencies as needed.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public OmnivoreDataManager(IOmnivoreRepository repository)
        {
            this._repo = repository;
        }

        /// <summary>
        /// Gets the omnivore collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<T> GetOmnivoreCollection<T>(string url)
            where T : OmnivoreCollectionBase
        {
            return await this._repo.GetOmnivoreCollection<T>(url);
        }
    }
}
