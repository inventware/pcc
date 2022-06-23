using System;


namespace PCC.Frontend
{
    public interface IPccLexeme
    {
        string Value
        {
            get;
        }

        int Line
        {
            get;
        }
    }
}
