﻿using Plant.Data;
using Plant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Services
{
    public class RequestService
    {
        private readonly Guid _userId;

        public RequestService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatesRequest(RequestCreate model)
        {
            var entity =
                new Request()
                {
                    UserId = _userId,
                    Content = model.Content
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Requests.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<RequestListItem> GetRequests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Requests
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new RequestListItem
                                {
                                    RequestId = e.RequestId,
                                    Content = e.Content
                                }
                        );

                return query.ToArray();

            }
        }
    }
}
