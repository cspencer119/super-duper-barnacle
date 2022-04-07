﻿using Spongebob.Data;
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

        public PlaceService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreatePlace(PlaceCreate model)
        {
            var entity = new Place() { UserId = _userId, PlaceName = model.PlaceName, PlaceDiscription = model.PlaceDiscription, Address = model.Address };

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
                var query = ctx.Places.Where(e => e.UserId == _userId).Select(e => new PlaceListItem { PlaceId = e.PlaceId, PlaceName = e.PlaceName });
                return query.ToArray();
            }
        }

        public PlaceDetail GetPlaceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Places.Single(e => e.PlaceId == id && e.UserId == _userId);
                return
                    new PlaceDetail
                    {
                        PlaceId = entity.PlaceId,
                        Placename = entity.PlaceName,
                        PlaceDiscription = entity.PlaceDiscription,
                        Address = entity.Address
                    };
            }
        }

        public bool UpdatePlace(PlaceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Places.Single(e => e.PlaceId == model.PlaceId && e.UserId == _userId);

                entity.PlaceName = model.PlaceName;
                entity.PlaceDiscription = model.PlaceDiscription;
                entity.Address = model.Address;

                return ctx.SaveChanges() >= 1;
            }
        }

        public bool DeletePlace(int placeId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                Place entity = ctx.Places.Single(e => e.PlaceId == placeId && e.UserId == _userId);

                ctx.Places.Remove(entity);

                return ctx.SaveChanges() >= 1;
            }


        }


    }
}