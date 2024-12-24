using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _dbContext;

        public UpdateNoteCommandHandler(INotesDbContext dbContext)
            => _dbContext = dbContext;

        public async Task Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _dbContext.Notes
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (note == null || note.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            note.Title = request.Title;
            note.Details = request.Details;
            note.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
