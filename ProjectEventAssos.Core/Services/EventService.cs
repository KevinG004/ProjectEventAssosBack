using ProjectEventAssos.Core.Dto.Requests.Event;
using ProjectEventAssos.Core.Dto.Responses.Event;
using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Core.Interfaces.Services;
using ProjectEventAssos.Domain.Enum;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProjectEventAssos.Core.Services
{
    public class EventService(
        IEventRepository _eventRepo,
        IWaitingListEventRepository _waitEventRepo,
        IParticipeEventRepository _particieEventRepo
        ) : IEventService
    {
        public Task<Event> AddAsync(Event entity)
        {
            throw new NotImplementedException();
        }

        public async Task CancelEventAsync(Guid id)
        {
            var EventCancel = await _eventRepo.GetByIdAsync(id);
            if(EventCancel == null)
            {
                throw new InvalidOperationException("Événement introuvable");
            }
            if (EventCancel.Status != StatusEvent.Encours)
            {
                throw new InvalidOperationException("Événement en cours");
            }
            EventCancel.Status = StatusEvent.Annuler;
            await _eventRepo.UpdateAsync(id, EventCancel);
        }

        public async Task CloseEventAsync(Guid id)
        {
            var EventClose = await _eventRepo.GetByIdAsync(id);
            if (EventClose == null)
            {
                throw new InvalidOperationException("Événement introuvable");
            }
            if ((EventClose.Status != StatusEvent.Encours))
            {
                throw new InvalidOperationException("Événement en cours");
            }
            else
            {
                EventClose.Status = StatusEvent.Terminer;
                await _eventRepo.UpdateAsync(id, EventClose);
            }
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Event> CreateEventAsync(CreateEventRequestDTO dto, Guid userId)
        {
            var newEvent = new Event
            {
                Id = Guid.NewGuid(),
                CoverImage = dto.CoverImage,
                CategorieId = dto.CategorieId,
                Name = dto.Name,
                Description = dto.Description,
                Place = dto.Place,
                DateTimeStart = dto.DateTimeStart,
                DateTimeFinish = dto.DateTimeFinish,
                MinParticipants = dto.MinParticipants,
                MaxParticipants = dto.MaxParticipants,
                WaitList = dto.WaitList,
                DateLimiteInscription = dto.DateLimiteInscription,
                Status = StatusEvent.EnAttente,
                CreationDate = DateTime.Now,
                MajDate = DateTime.Now,
                Categorie = null!
            };

            var createdEvent = await _eventRepo.AddAsync(newEvent);

            var participate = new ParticipateEvent
            {
                UserId = userId,
                EventId = createdEvent.Id
            };
            await _particieEventRepo.AddParticipantsAsync(participate);

            return createdEvent;
        }

        public async Task DeleteAsync(Guid id)
        {
            var EventDelete = await _eventRepo.GetByIdAsync(id);
            if(EventDelete == null)
            {
                throw new InvalidOperationException("Événement introuvable");
            }
            await _eventRepo.DeleteAsync(id);
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> FindAsync(Expression<Func<Event, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _eventRepo.GetAllAsync();
        }

        public async Task<Event?> GetByIdAsync(Guid id)
        {
            return await _eventRepo.GetByIdAsync(id);
        }

        public async Task<EventDetailsResponseDTO> GetEventDetailsAsync(Guid id)
        {
            var EventDetails = await _eventRepo.GetByIdAsync(id);
            if (EventDetails == null)
            {
                throw new InvalidOperationException("Événement introuvable");
            }
            var CountParticipant = await _particieEventRepo.CountParticipantsAsync(id);
            var EventWaitList = await _waitEventRepo.GetWaitingListAsync(id);
            var participants = await _particieEventRepo.GetParticipantsAsync(id);
            return new EventDetailsResponseDTO
            {
                Id = EventDetails.Id,
                CoverImage = EventDetails.CoverImage,
                CategorieName = EventDetails.Categorie.Name,
                Name = EventDetails.Name,
                Description = EventDetails.Description,
                Place = EventDetails.Place,
                DateTimeStart = EventDetails.DateTimeStart,
                DateTimeFinish = EventDetails.DateTimeFinish,
                MinParticipants = EventDetails.MinParticipants,
                MaxParticipants = EventDetails.MaxParticipants,
                Status = EventDetails.Status,
                WaitList = EventDetails.WaitList,
                DateLimiteInscription = EventDetails.DateLimiteInscription,
                NbInscrits = CountParticipant,
                Participants = participants.Select(p => p.User.UserName ?? "").ToList(),
                WaitListEvent = EventWaitList.Select(w => w.User.UserName ?? "").ToList()
            };
        }

        public async Task<PageEventResult> GetPageEventAsync(int pageId)
        {
            return await _eventRepo.GetPageEventResult(pageId);
        }

        public async Task RegisterToEventAsync(Guid userId, Guid eventId)
        {
            var RegisterEvent = await _eventRepo.GetByIdAsync(eventId);
            var UserRegister = await _particieEventRepo.IsUserRegisterAsync(userId, eventId);
            var count = await _particieEventRepo.CountParticipantsAsync(userId);
            if (RegisterEvent == null)
            {
                throw new InvalidOperationException("Événement introuvable");
            }
            if (RegisterEvent.Status != StatusEvent.EnAttente)
            {
                throw new InvalidOperationException("Événement n'est plus en attente");
            }
            if(DateTime.Now > RegisterEvent.DateLimiteInscription)
            {
                throw new InvalidOperationException("Date d'inscription depasser");
            }
            if (UserRegister)
            {
                throw new InvalidOperationException("déjà Inscrit");
            }
            if(count >= RegisterEvent.MaxParticipants)
            {
                if (!RegisterEvent.WaitList)
                {
                    throw new InvalidOperationException("Événement complet");
                }
                await _waitEventRepo.AddWaitingListAsync(new WaitingListEvent { 
                    UserId = userId,
                    EventId = eventId
                });
            }
            else
            {
                await _particieEventRepo.AddParticipantsAsync(new ParticipateEvent
                {
                    UserId = userId,
                    EventId = eventId
                });
            }
        }

        public async Task StartEventAsync(Guid id)
        {
            var StartEvent = await _eventRepo.GetByIdAsync(id);
            var count = await _particieEventRepo.CountParticipantsAsync(id);
            if (StartEvent == null) {
                throw new InvalidOperationException("Événement introuvable");
            }
            if (StartEvent.Status != StatusEvent.EnAttente)
            {
                throw new InvalidOperationException("Événement n'est plus en attente");
            }
            if (DateTime.Now < StartEvent.DateTimeStart) {
                throw new InvalidOperationException("La date de début n'est pas encore atteinte");
            }
            if(count < StartEvent.MinParticipants)
            {
                throw new InvalidOperationException("Nombre minimum de participants non atteint");
            }
            StartEvent.Status = StatusEvent.Encours;
            await _eventRepo.UpdateAsync(id, StartEvent);

        }

        public async Task UnregisterFromEventAsync(Guid userId, Guid eventId)
        {
            var unregisterEvent = await _eventRepo.GetByIdAsync(eventId);
            var userUnregister = await _particieEventRepo.IsUserRegisterAsync(userId, eventId);
            if (unregisterEvent == null)
            {
                throw new InvalidOperationException("Événement introuvable");
            }
            if(unregisterEvent.Status != StatusEvent.EnAttente)
            {
                throw new InvalidOperationException("Evenement n'est plus en attente");
            }
            if (userUnregister)
            {
                await _particieEventRepo.RemoveParticipantsAsync(userId, eventId);
                var firstUser = await _waitEventRepo.FirstInWaitingList(eventId);
                if (firstUser != null) {
                    await _waitEventRepo.RemoveWaitingListAsync(firstUser.UserId, eventId);
                    await _particieEventRepo.AddParticipantsAsync(new ParticipateEvent
                    {
                        UserId = firstUser.UserId,
                        EventId = eventId
                    });
                }
            }
            else
               {
                  var userWait = await _waitEventRepo.IsUserInWaitingListAsync(userId, eventId);
                  if (userWait)
                  {
                      await _waitEventRepo.RemoveWaitingListAsync(userId, eventId);
                  }
                  else
                  {
                      throw new InvalidOperationException("user non inscrit");
                  }
                }
        }

        public Task UpdateAsync(Guid id, Event entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEventAsync(Guid id, UpdateEventRequestDTO dto)
        {
            var EventUpdate = await _eventRepo.GetByIdAsync(id);
            if (EventUpdate == null) 
            {
                throw new InvalidOperationException("Événement introuvable");
            }
            EventUpdate.CoverImage = dto.CoverImage;
            EventUpdate.CategorieId = dto.CategorieId;
            EventUpdate.Name = dto.Name;
            EventUpdate.Description = dto.Description;
            EventUpdate.Place = dto.Place;
            EventUpdate.DateTimeStart = dto.DateTimeStart;
            EventUpdate.DateTimeFinish = dto.DateTimeFinish;
            EventUpdate.MinParticipants = dto.MinParticipants;
            EventUpdate.MaxParticipants = dto.MaxParticipants;

            await _eventRepo.UpdateAsync(id, EventUpdate);
        }
    }
}
