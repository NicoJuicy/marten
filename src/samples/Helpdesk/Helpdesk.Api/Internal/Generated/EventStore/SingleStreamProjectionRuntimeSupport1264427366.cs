// <auto-generated/>
#pragma warning disable
using Marten;
using Marten.Events.Aggregation;
using Marten.Internal.Storage;
using System;
using System.Linq;

namespace Marten.Generated.EventStore
{
    // START: SingleStreamProjectionLiveAggregation1264427366
    public class SingleStreamProjectionLiveAggregation1264427366 : Marten.Events.Aggregation.SyncLiveAggregatorBase<Helpdesk.Api.Incidents.Incident>
    {
        private readonly Marten.Events.Aggregation.SingleStreamProjection<Helpdesk.Api.Incidents.Incident> _singleStreamProjection;

        public SingleStreamProjectionLiveAggregation1264427366(Marten.Events.Aggregation.SingleStreamProjection<Helpdesk.Api.Incidents.Incident> singleStreamProjection)
        {
            _singleStreamProjection = singleStreamProjection;
        }



        public override Helpdesk.Api.Incidents.Incident Build(System.Collections.Generic.IReadOnlyList<Marten.Events.IEvent> events, Marten.IQuerySession session, Helpdesk.Api.Incidents.Incident snapshot)
        {
            if (!events.Any()) return null;
            Helpdesk.Api.Incidents.Incident incident = null;
            var usedEventOnCreate = snapshot is null;
            snapshot ??= Create(events[0], session);;
            if (snapshot is null)
            {
                usedEventOnCreate = false;
                snapshot = CreateDefault(events[0]);
            }

            foreach (var @event in events.Skip(usedEventOnCreate ? 1 : 0))
            {
                snapshot = Apply(@event, snapshot, session);
            }

            return snapshot;
        }


        public Helpdesk.Api.Incidents.Incident Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.IncidentLogged> event_IncidentLogged569:
                    return Helpdesk.Api.Incidents.Incident.Create(event_IncidentLogged569.Data);
                    break;
            }

            return null;
        }


        public Helpdesk.Api.Incidents.Incident Apply(Marten.Events.IEvent @event, Helpdesk.Api.Incidents.Incident aggregate, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.AgentRespondedToIncident> event_AgentRespondedToIncident570:
                    aggregate = aggregate.Apply(event_AgentRespondedToIncident570.Data);
                    break;
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.CustomerRespondedToIncident> event_CustomerRespondedToIncident571:
                    aggregate = aggregate.Apply(event_CustomerRespondedToIncident571.Data);
                    break;
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.IncidentClosed> event_IncidentClosed574:
                    aggregate = aggregate.Apply(event_IncidentClosed574.Data);
                    break;
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.IncidentResolved> event_IncidentResolved572:
                    aggregate = aggregate.Apply(event_IncidentResolved572.Data);
                    break;
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.ResolutionAcknowledgedByCustomer> event_ResolutionAcknowledgedByCustomer573:
                    aggregate = aggregate.Apply(event_ResolutionAcknowledgedByCustomer573.Data);
                    break;
            }

            return aggregate;
        }

    }

    // END: SingleStreamProjectionLiveAggregation1264427366
    
    
    // START: SingleStreamProjectionInlineHandler1264427366
    public class SingleStreamProjectionInlineHandler1264427366 : Marten.Events.Aggregation.AggregationRuntime<Helpdesk.Api.Incidents.Incident, System.Guid>
    {
        private readonly Marten.IDocumentStore _store;
        private readonly Marten.Events.Aggregation.IAggregateProjection _projection;
        private readonly Marten.Events.Aggregation.IEventSlicer<Helpdesk.Api.Incidents.Incident, System.Guid> _slicer;
        private readonly Marten.Internal.Storage.IDocumentStorage<Helpdesk.Api.Incidents.Incident, System.Guid> _storage;
        private readonly Marten.Events.Aggregation.SingleStreamProjection<Helpdesk.Api.Incidents.Incident> _singleStreamProjection;

        public SingleStreamProjectionInlineHandler1264427366(Marten.IDocumentStore store, Marten.Events.Aggregation.IAggregateProjection projection, Marten.Events.Aggregation.IEventSlicer<Helpdesk.Api.Incidents.Incident, System.Guid> slicer, Marten.Internal.Storage.IDocumentStorage<Helpdesk.Api.Incidents.Incident, System.Guid> storage, Marten.Events.Aggregation.SingleStreamProjection<Helpdesk.Api.Incidents.Incident> singleStreamProjection) : base(store, projection, slicer, storage)
        {
            _store = store;
            _projection = projection;
            _slicer = slicer;
            _storage = storage;
            _singleStreamProjection = singleStreamProjection;
        }



        public override async System.Threading.Tasks.ValueTask<Helpdesk.Api.Incidents.Incident> ApplyEvent(Marten.IQuerySession session, Marten.Events.Projections.EventSlice<Helpdesk.Api.Incidents.Incident, System.Guid> slice, Marten.Events.IEvent evt, Helpdesk.Api.Incidents.Incident aggregate, System.Threading.CancellationToken cancellationToken)
        {
            switch (evt)
            {
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.AgentRespondedToIncident> event_AgentRespondedToIncident576:
                    aggregate ??= CreateDefault(evt);
                    aggregate = aggregate.Apply(event_AgentRespondedToIncident576.Data);
                    return aggregate;
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.CustomerRespondedToIncident> event_CustomerRespondedToIncident577:
                    aggregate ??= CreateDefault(evt);
                    aggregate = aggregate.Apply(event_CustomerRespondedToIncident577.Data);
                    return aggregate;
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.IncidentClosed> event_IncidentClosed580:
                    aggregate ??= CreateDefault(evt);
                    aggregate = aggregate.Apply(event_IncidentClosed580.Data);
                    return aggregate;
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.IncidentLogged> event_IncidentLogged581:
                    aggregate = Helpdesk.Api.Incidents.Incident.Create(event_IncidentLogged581.Data);
                    return aggregate;
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.IncidentResolved> event_IncidentResolved578:
                    aggregate ??= CreateDefault(evt);
                    aggregate = aggregate.Apply(event_IncidentResolved578.Data);
                    return aggregate;
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.ResolutionAcknowledgedByCustomer> event_ResolutionAcknowledgedByCustomer579:
                    aggregate ??= CreateDefault(evt);
                    aggregate = aggregate.Apply(event_ResolutionAcknowledgedByCustomer579.Data);
                    return aggregate;
            }

            return aggregate;
        }


        public Helpdesk.Api.Incidents.Incident Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<Helpdesk.Api.Incidents.IncidentLogged> event_IncidentLogged575:
                    return Helpdesk.Api.Incidents.Incident.Create(event_IncidentLogged575.Data);
                    break;
            }

            return null;
        }

    }

    // END: SingleStreamProjectionInlineHandler1264427366
    
    
}
