namespace
#if SunamoShared
SunamoShared
#else
SunamoExceptions
#endif
;

public class TypesList
{
    public static readonly Type tLong = typeof(List<long>);
    public static readonly Type tString = typeof(List<string>);
}
