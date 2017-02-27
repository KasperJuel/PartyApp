using Microsoft.AspNet.Identity;
using PartyApp.Dtos;
using PartyApp.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace PartyApp.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId)
                .Select(un => un.Notification)
                .Include(n => n.Party.User)
                .ToList();

            return notifications.Select(n => new NotificationDto()
            {
                DateTime = n.DateTime,
                Party = new PartyDto
                {
                    User = new UserDto
                    {
                        Id = n.Party.User.Id,
                        Name = n.Party.User.Name
                    },
                    DateTime = n.Party.DateTime,
                    Id = n.Party.Id,
                    IsCanceled = n.Party.IsCanceled,
                    Location = n.Party.Location
                },
                OriginalDateTime = n.OriginalDateTime,
                OriginalLocation = n.OriginalLocation,
                Type = n.Type
            });
        }
    }
}
