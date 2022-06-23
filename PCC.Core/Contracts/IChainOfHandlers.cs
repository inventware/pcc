
namespace PCC.Core.Contracts
{
    /// <summary>
    /// SOURCE CODE:
    ///     https://refactoring.guru/pt-br/design-patterns/chain-of-responsibility/csharp/example
    /// </summary>
    public interface IChainOfHandlers
    {
        IChainOfHandlers SetNext(IChainOfHandlers handler);

        object Handle(object request);
    }
}
