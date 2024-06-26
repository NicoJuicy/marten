﻿using System;
using Marten;
using Marten.Testing.Documents;
using Marten.Testing.Harness;
using Xunit;

namespace DocumentDbTests.Deleting;

public sealed class delete_a_single_document: IntegrationContext
{
    public delete_a_single_document(DefaultStoreFixture fixture): base(fixture)
    {
    }

    [Theory]
    [SessionTypes]
    public void persist_and_delete_a_document_by_entity(DocumentTracking tracking)
    {
        using var session = OpenSession(tracking);

        var user = new User { FirstName = "Mychal", LastName = "Thompson" };
        session.Store(user);
        session.SaveChanges();


        using (var session2 = theStore.LightweightSession())
        {
            session2.Delete(user);
            session2.SaveChanges();
        }

        using (var querySession = theStore.QuerySession())
        {
            querySession.Load<User>(user.Id).ShouldBeNull();
        }
    }

    [Fact]
    public void persist_and_delete_a_document_by_id()
    {
        using var session = theStore.LightweightSession();

        var user = new User { FirstName = "Mychal", LastName = "Thompson" };
        session.Store(user);
        session.SaveChanges();

        using (var session2 = theStore.LightweightSession())
        {
            session2.Delete<User>(user.Id);
            session2.SaveChanges();
        }

        using (var querySession = theStore.QuerySession())
        {
            querySession.Load<User>(user.Id).ShouldBeNull();
        }
    }

    [Fact]
    public void persist_and_delete_by_id_documents_with_the_same_id()
    {
        var id = Guid.NewGuid();
        using (var session = theStore.LightweightSession())
        {
            var user = new User { Id = id, FirstName = "Mychal", LastName = "Thompson" };
            session.Store(user);
            session.SaveChanges();

            var target = new Target { Id = id };
            session.Store(target);
            session.SaveChanges();
        }

        using (var session = theStore.LightweightSession())
        {
            session.Delete<User>(id);
            session.Delete<Target>(id);

            session.SaveChanges();
        }

        using (var session = theStore.QuerySession())
        {
            session.Load<User>(id).ShouldBeNull();
            session.Load<Target>(id).ShouldBeNull();
        }
    }
}
