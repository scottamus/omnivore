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
        Task<T> GetOmnivoreCollection<T>(string url) where T : OmnivoreCollectionBase;
    }
}
