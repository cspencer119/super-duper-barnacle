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
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new HangoutsListItem
                        {
                            PlaceId = e.PlaceId,
                            HangoutsId = e.HangoutsId,
                            CharacterId = e.CharacterId,
                        }
                        );
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
                        PlaceId = entity.PlaceId,
                        HangoutsId = entity.HangoutsId,
                        CharacterId = entity.CharacterId,
                    };
            }
        }

        public bool UpdateHangouts(HangoutsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Hangouts
                    .Single(e => e.HangoutsId == model.HangoutsId && e.UserId == _userId);

                entity.PlaceId = model.PlaceId;
                entity.HangoutsId = model.HangoutsId;
                entity.CharacterId = model.CharacterId;
                return ctx.SaveChanges() >= 1;
            }
        }

        public bool DeleteHangouts(int hangoutsId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Hangouts
                    .Single(e => e.HangoutsId == hangoutsId && e.UserId == _userId);

                ctx.Hangouts.Remove(entity);

                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
