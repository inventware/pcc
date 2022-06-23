

namespace PCC.Frontend
{
    public enum ETokenName
    {
        // DELIM = 0,
        ID = 1,
        NUM_INT = 2,
        NUM_FLOAT = 3,
        NUM_SCIENT_NOT = 4,
        INTEGER = 5,
        LONG = 6,
        SINGLE = 7,
        DOUBLE = 8,
        STRING = 9,
        DATE = 10,
        BOOLEAN = 11,
        LITERAL = 12,
        COMMA = 13,
        PRIVATE = 14,   
        PUBLIC = 15,
        FUNCTION = 16,
        SUB = 17,
        EXIT = 18,
        CALL = 19,
        DIM = 20,
        BYREF = 21,
        BYVAL = 22,
        AS = 23,
        IF = 24,
        THEN = 25,
        END = 26,
        ELSE = 27,
        ELSEIF = 28,
        SELECT = 29,
        CASE = 30,
        FOR = 31,
        TO = 32,
        NEXT = 33,
        EACH = 34,
        IN = 35,
        DO = 36,
        WHILE = 37,
        LOOP = 38,
        ON = 39,
        ERROR = 40,
        GOTO = 41,
        WEND = 42,
        UNTIL = 43,
        CONST = 44,
        NEW = 45,
        UBOUND = 46,
        TRUE = 47,
        FALSE = 48,
        NULL = 49,
        EMPTY = 50,
        OBJECT = 51,
        VARIANT = 52,
        DEBUG = 53,
        PRINT = 54,
        SEMICOLON = 55,                     // ';'
        COLON = 56,                         // ':'
        UNDERSCORE = 57,                    // '_'
        CONCAT_OP = 58,                     // '&'
        POINT = 59,                         // '.'
        COMMENTED_TEXT = 60,                // '''
        MAIN = 61,                          // Startup Function or Subroutine of all programs.

        // Logical and Arithmetic Operators
        AND_OP = 100,
        OR_OP = 101,
        EQUAL_OP = 102,
        GREATER_THAN_OP = 103,
        GREATER_THAN_OR_EQUAL_OP = 104,
        LESS_THAN_OP = 105,
        LESS_THAN_OR_EQUAL_OP = 106,
        ADD_OP = 107,
        SUB_OP = 108,
        MULT_OP = 109,
        DIV_OP = 110,
        EXP_OP = 111,
        MOD_OP = 112,                       // Divides two numbers and returns only the remainder.
        INT_DIV_OP = 113,                   // Returns the quotient, that is, the integer that represents the number of
                                            // times the divisor can divide into the dividend without consideration of any remainder.

        // Math Functions
        ABS_FUNC = 120,
        ATN_FUNC = 121,
        COS_FUNC = 122,
        // DERIVED_MATH_FUNC = 123,          // https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/derived-math-functions
        EXP_FUNC = 124,
        INT_FUNC = 125,
        FIX_FUNC = 126,
        LOG_FUNC = 127,
        RND_FUNC = 128,
        SGN_FUNC = 129,
        SIN_FUNC = 130,
        SQR_FUNC = 131,
        TAN_FUNC = 132,

        // Conversion Functions
        ASC_FUNC = 150,
        CHR_FUNC = 151,
        CVERR_FUNC = 152,
        FORMAT_FUNC = 153,
        HEX_FUNC = 154,
        OCT_FUNC = 155,
        STR_FUNC = 156,
        VAL_FUNC = 157,

        // Validation Functions
        ISNULL = 180,
        ISEMPTY = 181,
        ISDATE = 182,
        ISARRAY = 183,
        ISNUMERIC = 184,
        ISMISSING = 185,

        // Symbols
        OPEN_BRACKET = 200,                 // '('
        CLOSE_BRACKET = 201,                // ')'
        OPEN_SQUARE_BRACKET = 202,          // '['
        CLOSE_SQUARE_BRACKET = 203,         // ']'
        OPEN_BRACE = 204,                   // '{'
        CLOSE_BRACE = 205,                  // '}'

        // Date Formats
        DATE_YYYYmmDD = 800,                // 2022-01-31
        DATE_MMddYYYY = 802,                // 01-31-2022
        DATE_DDmmYYYY = 803,                // 31-01-2022
        DATE_MMMddYYYY = 804,               // Jan-31-2022
        DATE_MMMMddYYYY = 805,              // January 31, 2022
        DATE_TIME_YYYYmmDD_HHMMSS = 806,    // 2022-01-31 14:55:26
        DATE_TIME_mmDDYYYY_HHMMSS = 807,    // 01-31-2022 14:55:26
        DATE_TIME_DDmmYYYY_HHMMSS = 808,    // 31-01-2022 14:55:26

        // Time Formats
        TIME_HHMMSS = 820,
        TIME_HHMMSS_MMM = 821,              // 12:30:15 456
        TIME_HHMMSS_AMPM = 822,             // 12:30:00 PM

        END_OF_CODE = 999,
        UNDEFINED = 000
    }
}
