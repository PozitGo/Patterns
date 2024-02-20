using MediatR;

namespace Mediator
{
    public class PongResponse
    {
        public DateTime Timestamp;

        public PongResponse(DateTime Timestamp)
        {
            this.Timestamp = Timestamp;
        }
    }
    public class PingCommand : IRequest<PongResponse>
    {

    }

    public class PingCommandHandler : IRequestHandler<PingCommand, PongResponse>
    {
        public async Task<PongResponse> Handle(PingCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new PongResponse(DateTime.UtcNow)).ConfigureAwait(false);
        }
    }

}
