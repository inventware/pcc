
namespace PCC.Identifiers.Directors
{
    public class PccVariableDirector
    {
        public PccVariableDirector() {}

        public PccIntegerVariable BuildIntegerVariable(long id, long? idParent, string name, int initialPositionIntoTheCode,
            int finalPositionIntoTheCode, PccIdentifierScope scope, string value)
        { 
            var director = new PccIntegerVariableDirector();
            return director.Build(id, idParent, name, initialPositionIntoTheCode, finalPositionIntoTheCode, scope, value);
        }

        public PccLongVariable BuildLongVariable(long id, long? idParent, string name, int initialPositionIntoTheCode,
            int finalPositionIntoTheCode, PccIdentifierScope scope, string value)
        {
            var director = new PccLongVariableDirector();
            return director.Build(id, idParent, name, initialPositionIntoTheCode, finalPositionIntoTheCode, scope, value);
        }

        public PccSingleVariable BuildSingleVariable(long id, long? idParent, string name, int initialPositionIntoTheCode,
            int finalPositionIntoTheCode, PccIdentifierScope scope, string value)
        {
            var director = new PccSingleVariableDirector();
            return director.Build(id, idParent, name, initialPositionIntoTheCode, finalPositionIntoTheCode, scope, value);
        }

        public PccDoubleVariable BuildDoubleVariable(long id, long? idParent, string name, int initialPositionIntoTheCode,
            int finalPositionIntoTheCode, PccIdentifierScope scope, string value)
        {
            var director = new PccDoubleVariableDirector();
            return director.Build(id, idParent, name, initialPositionIntoTheCode, finalPositionIntoTheCode, scope, value);
        }

        public PccStringVariable BuildStringVariable(long id, long? idParent, string name, int initialPositionIntoTheCode,
            int finalPositionIntoTheCode, PccIdentifierScope scope, string value)
        {
            var director = new PccStringVariableDirector();
            return director.Build(id, idParent, name, initialPositionIntoTheCode, finalPositionIntoTheCode, scope, value);
        }

        public PccBooleanVariable BuildBooleanVariable(long id, long? idParent, string name, int initialPositionIntoTheCode,
            int finalPositionIntoTheCode, PccIdentifierScope scope, string value)
        {
            var director = new PccBooleanVariableDirector();
            return director.Build(id, idParent, name, initialPositionIntoTheCode, finalPositionIntoTheCode, scope, value);
        }

        public PccDatetimeVariable BuildDatetimeVariable(long id, long? idParent, string name, int initialPositionIntoTheCode,
            int finalPositionIntoTheCode, PccIdentifierScope scope, string value, string dataFormat)
        {
            var director = new PccDatetimeVariableDirector();
            return director.Build(id, idParent, name, initialPositionIntoTheCode, finalPositionIntoTheCode, scope, value, 
                dataFormat);
        }
    }
}
