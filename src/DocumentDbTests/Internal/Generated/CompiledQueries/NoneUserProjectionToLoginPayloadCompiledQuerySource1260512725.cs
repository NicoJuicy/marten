// <auto-generated/>
#pragma warning disable
using DocumentDbTests.Reading.Linq.Compiled;
using Marten.Internal.CompiledQueries;
using Marten.Linq.QueryHandlers;
using System;

namespace Marten.Generated.CompiledQueries
{
    // START: NoneUserProjectionToLoginPayloadCompiledQuery1260512725
    public class NoneUserProjectionToLoginPayloadCompiledQuery1260512725 : Marten.Internal.CompiledQueries.StatelessCompiledQuery<DocumentDbTests.Reading.Linq.Compiled.LoginPayload, DocumentDbTests.Reading.Linq.Compiled.UserProjectionToLoginPayload>
    {
        private readonly Marten.Linq.QueryHandlers.IQueryHandler<DocumentDbTests.Reading.Linq.Compiled.LoginPayload> _inner;
        private readonly DocumentDbTests.Reading.Linq.Compiled.UserProjectionToLoginPayload _query;
        private readonly Marten.Internal.CompiledQueries.HardCodedParameters _hardcoded;

        public NoneUserProjectionToLoginPayloadCompiledQuery1260512725(Marten.Linq.QueryHandlers.IQueryHandler<DocumentDbTests.Reading.Linq.Compiled.LoginPayload> inner, DocumentDbTests.Reading.Linq.Compiled.UserProjectionToLoginPayload query, Marten.Internal.CompiledQueries.HardCodedParameters hardcoded) : base(inner, query, hardcoded)
        {
            _inner = inner;
            _query = query;
            _hardcoded = hardcoded;
        }



        public override void ConfigureCommand(Weasel.Postgresql.CommandBuilder builder, Marten.Internal.IMartenSession session)
        {
            var parameters = builder.AppendWithParameters(@"select jsonb_build_object('Username', d.data ->> 'UserName') as data from public.mt_doc_user as d where d.data ->> 'UserName' = ? LIMIT ?");

            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text;
            parameters[0].Value = _query.UserName;
            _hardcoded.Apply(parameters);
        }

    }

    // END: NoneUserProjectionToLoginPayloadCompiledQuery1260512725
    
    
    // START: NoneUserProjectionToLoginPayloadCompiledQuerySource1260512725
    public class NoneUserProjectionToLoginPayloadCompiledQuerySource1260512725 : Marten.Internal.CompiledQueries.CompiledQuerySource<DocumentDbTests.Reading.Linq.Compiled.LoginPayload, DocumentDbTests.Reading.Linq.Compiled.UserProjectionToLoginPayload>
    {
        private readonly Marten.Internal.CompiledQueries.HardCodedParameters _hardcoded;
        private readonly Marten.Linq.QueryHandlers.IQueryHandler<DocumentDbTests.Reading.Linq.Compiled.LoginPayload> _queryHandler;

        public NoneUserProjectionToLoginPayloadCompiledQuerySource1260512725(Marten.Internal.CompiledQueries.HardCodedParameters hardcoded, Marten.Linq.QueryHandlers.IQueryHandler<DocumentDbTests.Reading.Linq.Compiled.LoginPayload> queryHandler)
        {
            _hardcoded = hardcoded;
            _queryHandler = queryHandler;
        }



        public override Marten.Linq.QueryHandlers.IQueryHandler<DocumentDbTests.Reading.Linq.Compiled.LoginPayload> BuildHandler(DocumentDbTests.Reading.Linq.Compiled.UserProjectionToLoginPayload query, Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.CompiledQueries.NoneUserProjectionToLoginPayloadCompiledQuery1260512725(_queryHandler, query, _hardcoded);
        }

    }

    // END: NoneUserProjectionToLoginPayloadCompiledQuerySource1260512725
    
    
}
