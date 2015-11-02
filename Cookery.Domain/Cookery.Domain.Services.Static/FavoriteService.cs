using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class FavoriteService:IFavoriteService
    {
        private readonly List<Favorite> _favorites = new List<Favorite>();

        public Favorite Add(Favorite item)
        {
            var newFavorite = (Favorite)item.Clone();
            newFavorite.Id = !_favorites.Any() ? 1 : _favorites.Max(favorite => favorite.Id) + 1;
            _favorites.Add(newFavorite);
            return (Favorite)newFavorite.Clone();
        }



        public void Delete(int id)
        {
            var existFavorite = _favorites.SingleOrDefault(favorite => favorite.Id == id);
            if (existFavorite == null)
            {
                throw new NullReferenceException();
            }
            _favorites.Remove(existFavorite);
        }

        public List<Favorite> Get()
        {
            return _favorites.
                Select(item => (Favorite)item.Clone()).ToList();
        }

        public Favorite Get(int id)
        {
            var favorite = _favorites.SingleOrDefault(item => item.Id == id);
            return favorite == null ? null : (Favorite)favorite.Clone();
        }

        public Favorite Update(Favorite item)
        {
            var existFavorite = _favorites.SingleOrDefault(favorite => favorite.Id == item.Id);
            if (existFavorite == null)
            {
                throw new NullReferenceException();
            }
            existFavorite.Name = item.Name;
            return (Favorite)existFavorite.Clone();
        }

        public List<Favorite> GetFavoriteRecipeByID(int id)
        {
            return _favorites.Where(item => item.RecipeID == id).ToList();
        }
    }
}
