using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spongebob.Data;
using Spongebob.Models.Hangouts;
using Spongebob.Models.Locations;

namespace Spongebob.Service
{
    public class HangoutsService
    {
        private readonly Guid _userId;
        public HangoutsService() { }
        public HangoutsService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateHangouts(HangoutsCreate model)
        {
            var entity =
                new Hangouts()
                {
                    UserId = _userId,
                    CharacterId = model.CharacterId,
                    PlaceId = model.PlaceId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Hangouts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<HangoutsListItem> GetHangouts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Hangouts
                    .Select(
                        e =>
                        new HangoutsListItem
                        {
                            PlaceId = e.PlaceId,
                            HangoutsId = e.HangoutsId,
                            CharacterId = e.CharacterId,
                        });
                return query.ToArray();
            }
        }

        public HangoutsDetail GetHangoutsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Hangouts
                    .Single(e => e.HangoutsId == id && e.UserId == _userId);
                return
                    new HangoutsDetail
                    {
                        HangoutsId = entity.HangoutsId,
                        CharacterId = entity.CharacterId,
                        CharacterName = entity.Character.CharacterName,
                        PlaceId = entity.PlaceId,
                        PlaceName = entity.Place.PlaceName
                    };
            }
        }

        public bool UpdateHangouts(HangoutsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var all = ctx.Hangouts.ToArray();
                foreach (var h in all)
                {
                    if (h.HangoutsId == model.HangoutsId)
                    {
                        var entity =
                            ctx
                            .Hangouts
                            .Single(e => e.HangoutsId == model.HangoutsId);
                        entity.PlaceId = model.PlaceId;
                        entity.HangoutsId = model.HangoutsId;
                        entity.CharacterId = model.CharacterId;
                        return ctx.SaveChanges() >= 1;
                    }
                }
                return false;
            }
        }

        public bool DeleteHangouts(int hangoutsId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userHangout = ctx.Hangouts.Where(e => e.UserId == _userId).ToArray();
                foreach (var h in userHangout)
                {
                    if (h.HangoutsId == hangoutsId)
                    {
                        var entity =
                            ctx
                            .Hangouts
                            .Single(e => e.HangoutsId == hangoutsId && e.UserId == _userId);
                        ctx.Hangouts.Remove(entity);
                        return ctx.SaveChanges() >= 1;
                    }
                }
                return false;
            }
        }
    }
}
