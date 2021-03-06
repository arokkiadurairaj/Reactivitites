using System;
using System.Threading;
using System.Threading.Tasks;
using Data;
using Domains;
using MediatR;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid ActivityId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
            public string City { get; set; }
            public string Venue { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;

            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = new Activity
                {
                    ActivityId = request.ActivityId,
                    Title = request.Title,
                    Description = request.Description,
                    Category = request.Category,
                    Date = request.Date,
                    City = request.City,
                    Venue = request.Venue
                };
                this.context.Activities.Add(activity);
                var success = await this.context.SaveChangesAsync() > 0;
                if(success) return Unit.Value;
                

                throw new Exception("An error occured while saving the activity");
            }
        }
    }
}