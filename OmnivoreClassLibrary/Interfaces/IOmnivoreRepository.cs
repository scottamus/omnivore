using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmnivoreClassLibrary.DataContracts.V01;

namespace OmnivoreClassLibrary.Interfaces
{
    public interface IOmnivoreRepository
    {
        Task<T> GetOmnivoreObject<T>(string url) 
            where T : OmnivoreBase;

        Task<U> PostOmnivoreObject<T, U>(string url, T itemToPost)
            where U : OmnivoreBase;
    }
}
