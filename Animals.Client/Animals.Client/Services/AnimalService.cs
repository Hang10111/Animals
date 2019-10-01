using Animals.Client.Models;
using Animals.Share;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Client.Services
{
    public static class AnimalService
    {
        public static async Task<IEnumerable<AnimalItem>> GetAnimals()
        {
            var url = Configuration.ID_HOST + "/api/Animal";
            IEnumerable<AnimalItem> result = null;
            try
            {
                BodyResponseFormatBase<List<Tuple<SinhVat, Hinh, ObservableCollection<Location>>>> Response = await HttpService.GetAsync<List<Tuple<SinhVat, Hinh, ObservableCollection<Location>>>>(url);
                result = Response.Result.Select(e => new AnimalItem(e.Item1, e.Item2, e.Item3));
            }
            catch (Exception) { }
            return result ?? new List<AnimalItem>();
        }
    }
}
