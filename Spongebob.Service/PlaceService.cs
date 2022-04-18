using Spongebob.Data;
using Spongebob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Service
{
    public class PlaceService
    {
        private readonly Guid _userId;
        public PlaceService() { }
        public PlaceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlace(PlaceCreate model)
        {
            var entity = new Place() { UserId = _userId, PlaceName = model.PlaceName, PlaceDescription = model.PlaceDescription, Address = model.Address };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Places.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<PlaceListItem> GetPlaces()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Places.Select(e => new PlaceListItem { PlaceId = e.PlaceId, PlaceName = e.PlaceName });
                return query.ToArray();
            }
        }

        public PlaceDetail GetPlaceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var places = ctx.Places.Where(e => e.PlaceId == id).ToArray();
                foreach (var p in places)
                {
                    if (p.PlaceId == id)
                    {
                        var entity =
                            ctx
                            .Places
                            .Single(e => e.PlaceId == id);
                        return
                            new PlaceDetail
                            {
                                PlaceId = entity.PlaceId,
                                PlaceName = entity.PlaceName,
                                PlaceDescription = entity.PlaceDescription,
                                Address = entity.Address
                            };
                    }
                }
                return null;
            }
        }

        public bool UpdatePlace(PlaceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var all = ctx.Places.ToArray();
                foreach (var p in all)
                {
                    if (p.PlaceId == model.PlaceId)
                    {
                        var entity = ctx.Places.Single(e => e.PlaceId == model.PlaceId);
                        entity.PlaceName = model.PlaceName;
                        entity.PlaceDescription = model.PlaceDescription;
                        entity.Address = model.Address;
                        return ctx.SaveChanges() >= 1;
                    }
                }
                return false;
            }
        }

        public bool DeletePlace(int placeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userPlaces = ctx.Places.Where(e => e.UserId == _userId).ToArray();
                foreach (var p in userPlaces)
                {
                    if (p.PlaceId == placeId)
                    {
                        var entity = ctx.Places.Single(e => e.PlaceId == placeId && e.UserId == _userId);
                        var hang = ctx.Hangouts.Where(e => e.UserId == _userId).ToArray();
                        foreach (var hangout in hang)
                        {
                            if (hangout.PlaceId == placeId)
                                ctx.Hangouts.Remove(hangout);
                        }
                        ctx.Places.Remove(entity);
                        return ctx.SaveChanges() >= 1;
                    }
                }
                return false;
            }
        }
    }
}
