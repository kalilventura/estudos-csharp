using GraphQL.Types;

namespace app.GraphQL.Interfaces {
    public interface IMySchema
    {
        ISchema GraphQLSchema { get; }
    }
}