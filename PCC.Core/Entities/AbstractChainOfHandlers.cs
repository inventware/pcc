using PCC.Core.Contracts;


namespace PCC.Core.Entities
{
    /// <summary>
    /// SOURCE CODE:
    ///     https://refactoring.guru/pt-br/design-patterns/chain-of-responsibility/csharp/example
    /// </summary>
    public abstract class AbstractHandler : IChainOfHandlers
    {
        private IChainOfHandlers _nextHandler;

        /// <summary>
        /// Returning a handler from here will let us link handlers in a convenient way like this:
        ///     monkey.SetNext(squirrel).SetNext(dog);
        /// </summary>
        public IChainOfHandlers SetNext(IChainOfHandlers handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual object Handle(object request)
        {
            if (_nextHandler != null){
                return _nextHandler.Handle(request);
            }
            else {
                return null;
            }
        }
    }
}
