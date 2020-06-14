using System;
using System.Threading;
using System.Threading.Tasks;
using Data;
using MediatR;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid ActivityId { get; set; }
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
                var activity = await this.context.Activities.FindAsync(request.ActivityId);
                if (activity == null)
                    throw new Exception("Activity not found");
                
                this.context.Remove(activity);
                
                var success = await this.context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;

                throw new Exception("An error occured while saving the activity");
            }
        }
    }
}