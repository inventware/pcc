
namespace PCC.Identifiers
{
    public enum PccIdentifierClass
    {
        VARIABLE = 1,
        FUNCTION = 2,
        SUBROUTINE = 3,
        PARAMETER = 4,
        ARRAY = 5,
        UNDEFINED = 99
    }


    public enum PccIdentifierType
    {
        VOID = 0,
        INTEGER = 1,
        LONG = 2,
        SINGLE = 3,
        DOUBLE = 4,
        STRING = 5,
        DATE = 6,
        BOOLEAN = 7,
        UNDEFINED = 99
    }


    public enum PccIdentifierScope
    {
        GLOBAL = 1,
        LOCAL = 2,
        INTERN_STRUCTURE = 3,
        UNDEFINED = 99
    }


    public abstract class PccIdentifier
    {
        public long Id { get; protected set; }

        public long? IdParent { get; protected set; }

        public string Name { get; protected set; }

        public int InitialPositionIntoTheCode { get; protected set; }

        public int FinalPositionIntoTheCode { get; protected set; }

        public PccIdentifierClass Class { get; protected set; }

        public PccIdentifierScope Scope { get; protected set; }

        public PccIdentifierType Type { get; protected set; }


        internal void SetId (long id)
        { 
            Id = id; 
        }

        internal void SetIdParent (long? idParent)
        { 
            IdParent = idParent; 
        }

        internal void SetName (string name)
        { 
            Name = name; 
        }

        internal void SetInitialPositionIntoTheCode (int initialPositionIntoTheCode)
        { 
            InitialPositionIntoTheCode = initialPositionIntoTheCode; 
        }

        internal void SetFinalPositionIntoTheCode (int finalPositionIntoTheCode)
        { 
            FinalPositionIntoTheCode = finalPositionIntoTheCode; 
        }

        internal void SetClass (PccIdentifierClass @class)
        { 
            Class = @class; 
        }

        internal void SetScope (PccIdentifierScope scope)
        { 
            Scope = scope; 
        }

        internal void SetType (PccIdentifierType type)
        { 
            Type = type; 
        }
    }
}
